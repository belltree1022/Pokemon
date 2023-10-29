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
    public void StartBattle()
    {
        state = GameState.Battle;
        battleSystem.gameObject.SetActive(true);
        
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