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
    [SerializeField]  PlayerController playerController;
    [SerializeField]  BattleSystem battleSystem;

    GameState state = GameState.FreeRoam;

    // ゲームの状態を管理
    void Update()
    {
        if (state==GameState.FreeRoam)
        {
            playerController.HandUpdate();
        }
        else if (state==GameState.Battle)
        {
            battleSystem.HandUpdate();
        }
        
    }
}
