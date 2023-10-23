using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    BattleState state;
    int currentAction; //0:Fight 1:Run
    int currentMove;
    private void Start()
    {
        StartCoroutine(SetupBattle());//setupbattleのコルーチンを開始、コルーチン：中断できる処理のまとまり、数秒後に何か処理を行いたいときややめたいときに使用
    }
    IEnumerator SetupBattle()
    {
        state = BattleState.Start;
        playerUnit.Setup();
        enemyUnit.Setup();
        playerHud.SetData(playerUnit.Pokemon);
        enemyHud.SetData(enemyUnit.Pokemon);
        dialogBox.SetMovenames(playerUnit.Pokemon.Moves);
        yield return dialogBox.TypeDialog($"やせいの {enemyUnit.Pokemon.Base.Name} があらわれた");
        yield return new WaitForSeconds(1);
        PlayerAction();
    }
    void PlayerAction()
    {
        state = BattleState.PlayerAction; // Update the battle state
        dialogBox.EnableActionSelector(true);
        StartCoroutine(dialogBox.TypeDialog("Choose an action"));
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
        state=BattleState.Busy;

        //技を決定
        Move move = playerUnit.Pokemon.Moves[currentMove];//現在選択してる技
         yield return dialogBox.TypeDialog($" {playerUnit.Pokemon.Base.Name} は{move.Base.Name}をつかった");
         yield return new WaitForSeconds(1); //1秒まつ

         //ダメージ計算 //ダメージを受けるのはポケモンだからPokemonクラスで実行したいものを記入
         bool isFainted=enemyUnit.Pokemon.TakeDamage(move,playerUnit.Pokemon); //faintedは気絶の意味
         //HP反映
         enemyHud.UpdateHP();


         //戦闘不能ならメッセージ

         if (isFainted)
         {
            yield return dialogBox.TypeDialog($" {playerUnit.Pokemon.Base.Name} は戦闘不能");
         }
         //戦闘可能ならEnemyMove
         else
         {

         }
    }

    

    private void Update()
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
            dialogBox.EnableMoveSelector(true); //表示だからtrue
        //技決定の処理

            StartCoroutine(PerformPlayerMove());

        }
    }
}


