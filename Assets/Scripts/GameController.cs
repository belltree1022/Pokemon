using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    FreeRoam,
    Battle,
}
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] BattleSystem battleSystem;
    [SerializeField] GameController gameController;
    

    GameState state = GameState.FreeRoam;

    private void Start()
    {
        playerController.OnEncounted+=StartBattle;
        battleSystem.BattleOver+=EndBattle;
    }



    public void StartBattle()
    {
        state = GameState.Battle;
        battleSystem.gameObject.SetActive(true);
        //パーティーと野生ポケモンの取得
        PokemonParty playerParty=playerController.GetComponent<PokemonParty>();
        //野生ポケモン、マップの取得 FindObject0fTypeはシーン内から一致するコンポーネントを１つ取得すする
        Pokemon wildPokemon = FindObjectOfType<MapArea>().GetRandomWildPokemon();
        battleSystem.StartBattle(playerParty,wildPokemon);
        
    }
    public void EndBattle()
    {
        state = GameState.FreeRoam;
        battleSystem.gameObject.SetActive(false);
        
    }
    // ゲームの状態を管理
    void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerController.HandUpdate();
        }
        else if (state == GameState.Battle)
        {
            battleSystem.HandUpdate();
        }
    }
}