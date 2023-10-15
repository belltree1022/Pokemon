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
        playerUnit.Setup(); //�����X�^�[�̐����ƕǉ�
        enemyUnit.Setup();
        //HUD�̕ǉ�
        playerHud.SetData(playerUnit.Pokemon);
        enemyHud.SetData(enemyUnit.Pokemon);
    }
}