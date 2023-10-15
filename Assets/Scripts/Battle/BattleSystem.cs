using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;
    private void Start()
    {
        playerUnit.Setup(); //モンスターの生成と壁画
        enemyUnit.Setup();
        //HUDの壁画
        playerHud.SetData(playerUnit.Pokemon);
        enemyHud.SetData(enemyUnit.Pokemon);
    }
}