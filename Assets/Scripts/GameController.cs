using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    FreeRoam,//マップ移動
    Battle,
}

public class GameController : MonoBehaviour
{
    //ゲームの状態を管理
    [SerializeField] PlayerController playerController;
    [SerializeField] BattleSystem battleSystem;


    GameState state=GameState.FreeRoam;


    void Update()
    {
        if (state==GameState.FreeRoam)//マップだったら
        {
            playerController.HandleUpdate();
   
        }
        else if (state==GameState.Battle)
        {
            //battlesysytem
            battleSystem.HandleUpdate();
        }
        
    }
}
