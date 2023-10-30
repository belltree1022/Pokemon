using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public enum BattleState
{
    Start,
    PlayerAction,
    PlayerMove,
    EnemyMove,
    Busy,
}
public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;//バトルシステムのオブジェクトにplayerunitのプロジェクトをインスペクターに追加できるようにする
    [SerializeField] BattleUnit enemyUnit;//バトルシステムのオブジェクトにenemyUnitのプロジェクトをインスペクターに追加できるようにする
    [SerializeField] BattleHud playerHud;//バトルシステムのオブジェクトplayerHudtのプロジェクトをインスペクターに追加できるようにする
    [SerializeField] BattleHud enemyHud;//バトルシステムのオブジェクトにenemyHudtのプロジェクトをインスペクターに追加できるようにする
    [SerializeField] BattleDialogBox dialogBox;//バトルシステムのオブジェクトにdialogBoxのプロジェクトをインスペクターに追加できるようにする
    //[SerializeField] GameController gameController;
    public UnityAction BattleOver;



    BattleState state;
    int currentAction; //0:Fight 1:Run
    int currentMove;

    //これらの変数をどこから取得するか？
    PokemonParty playerParty;
    Pokemon wildPokemon;
    public void StartBattle( PokemonParty playerParty,Pokemon wildPokemon)
    {
        this.playerParty=playerParty;
        this.wildPokemon=wildPokemon;
        StartCoroutine(SetupBattle());//setupbattleのコルーチンを開始、コルーチン：中断できる処理のまとまり、数秒後に何か処理を行いたいときややめたいときに使用
    }
    IEnumerator SetupBattle()
    {
        state = BattleState.Start;
        playerUnit.Setup(playerParty.GetHealthyPokemon());//プレイヤーのポケモンセット
        enemyUnit.Setup(wildPokemon);//野生ポケモンセット
        playerHud.SetData(playerUnit.Pokemon);
        enemyHud.SetData(enemyUnit.Pokemon);
        dialogBox.SetMovenames(playerUnit.Pokemon.Moves);
        yield return dialogBox.TypeDialog($"やせいの {enemyUnit.Pokemon.Base.Name} があらわれた");
        
        PlayerAction();
    }
    void PlayerAction()
    {
        state = BattleState.PlayerAction; // Update the battle state
        dialogBox.EnableActionSelector(true);
        StartCoroutine(dialogBox.TypeDialog("どうする"));
    }
    void PlayerMove()
    {
        state = BattleState.PlayerMove;
        dialogBox.EnableDialogText(false);
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableMoveSelector(true);
    }

    //PlayerMoveの実行
    IEnumerator PerformPlayerMove()
{
    state = BattleState.Busy;
    // 技を決定
    Move move = playerUnit.Pokemon.Moves[currentMove];
    move.PP--;
    Debug.Log("Hello");
    yield return dialogBox.TypeDialog($" {playerUnit.Pokemon.Base.Name} は {move.Base.Name} を使った");
    playerUnit.PlayerAttackAnimation();
    yield return new WaitForSeconds(0.7f);//攻撃を受けてから動くのが早いので調節
    enemyUnit.PlayerHitAnimation();
    
    // ダメージ計算
    DamageDetails damageDetails = enemyUnit.Pokemon.TakeDamage(move, playerUnit.Pokemon);
    // HP反映
    yield return enemyHud.UpdateHP();
    yield return ShowDamageDetails(damageDetails);
    if (damageDetails.Fainted)
    {
        yield return dialogBox.TypeDialog($"{enemyUnit.Pokemon.Base.Name} は戦闘不能になった！");
        enemyUnit.PlayerFaintAnimation();
        yield return new WaitForSeconds(0.7f);
        //gameController.EndBattle();
        BattleOver();
        // 戦闘終了の処理を追加するか、次のステップに進むかを決めるロジックをここに追加
    }
    else
    {
        // 敵の行動（EnemyMove）または次のプレイヤーの行動（PlayerAction）に進むロジックをここに追加
        //EnemyMoveを追加
        StartCoroutine(EnemyMove());
    }
}
IEnumerator EnemyMove()
{
     state = BattleState.EnemyMove;
    // 技を決定:ランダムになる　敵の行動
    Move move = enemyUnit.Pokemon.GetRandomMove();
    //PP消費
    move.PP--;
    Debug.Log("Hello");
    yield return dialogBox.TypeDialog($" {enemyUnit.Pokemon.Base.Name} は {move.Base.Name} を使った");
    enemyUnit.PlayerAttackAnimation();
    yield return new WaitForSeconds(0.7f);//攻撃を受けてから動くのが早いので調節
    playerUnit.PlayerHitAnimation();
    
    // ダメージ計算
    DamageDetails damageDetails = playerUnit.Pokemon.TakeDamage(move, enemyUnit.Pokemon);//プレイヤーがダメージを受けて、敵がダメージを与えるからTakeDmageの中はenemyUnit
    // HP反映
    yield return playerHud.UpdateHP();//プレイヤーがダメージを受けるからPlayerHud
    //相性/クリティカルのメッセージ
    yield return ShowDamageDetails(damageDetails);
    if (damageDetails.Fainted)
    {
        yield return dialogBox.TypeDialog($"{playerUnit.Pokemon.Base.Name} は戦闘不能になった！");
        playerUnit.PlayerFaintAnimation();
        yield return new WaitForSeconds(0.7f);
        //gameController.EndBattle();
        BattleOver();
       
        // 戦闘終了の処理を追加するか、次のステップに進むかを決めるロジックをここに追加
    }
    else
    {
        // それ以外ならプレイヤーのターンだからPlayerActionをかえす
        PlayerAction();
    }

} 

IEnumerator ShowDamageDetails(DamageDetails damageDetails)//タイプや状態によって出てくる文字がかわる
{

    if (damageDetails.Critical>1f)
    {
        yield return dialogBox.TypeDialog($"きゅうしょにあたった!");
    }
    
    if (damageDetails.TypeEffectiveness>1f)
    {
        yield return dialogBox.TypeDialog($"こうかはばつぐんだ！");
    }
    else if (damageDetails.TypeEffectiveness<1f)
    {
        yield return dialogBox.TypeDialog($"こうかはいまひとつだ...");
    }
     
      
}

    public void HandUpdate()
    {
        if (state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }

        else if (state == BattleState.PlayerMove)
        {
            HandleMoveSelection();
        }

    }
    void HandleActionSelection()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAction < 1)
            {
                currentAction++;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAction > 0)
            {
                currentAction--;
            }
        }
        dialogBox.UpdateActionSelection(currentAction);
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentAction == 0)
            {
                PlayerMove();
            }
        }
    }
    void HandleMoveSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentMove < playerUnit.Pokemon.Moves.Count - 1)
            {
                currentMove++;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentMove > 0)
            {
                currentMove--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentMove < playerUnit.Pokemon.Moves.Count - 2)
            {
                currentMove += 2;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentMove > 1)
            {
                currentMove -= 2;
            }
        }
        dialogBox.UpdateMoveSelection(currentMove, playerUnit.Pokemon.Moves[currentMove]);

        if(Input.GetKeyDown(KeyCode.Z))//zボタンをおすと
        {
            //技決定
            //技選択のUIは非表示
            dialogBox.EnableMoveSelector(false); //非表示だからFalse
            //メッセージ復活
            dialogBox.EnableDialogText(true); //表示だからtrue
        //技決定の処理
            Debug.Log("genchan");
            StartCoroutine(PerformPlayerMove());

        }
    }
}


