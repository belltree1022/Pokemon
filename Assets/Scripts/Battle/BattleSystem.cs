using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;
    [SerializeField] BattleDialogBox dialogBox;


    int currentAction; //0:Fight 1:Run
    private void Start()
    {
        StartCoroutine(SetupBattle());
    }
    IEnumerator SetupBattle()
    {
        playerUnit.Setup(); //ÉÇÉìÉXÉ^Å[ÇÃê∂ê¨Ç∆ï«âÊ
        enemyUnit.Setup();
        //HUDÇÃï«âÊ
        playerHud.SetData(playerUnit.Pokemon);
        enemyHud.SetData(enemyUnit.Pokemon);

        yield return dialogBox.TypeDialog($"A wild {enemyUnit.Pokemon.Base.Name} apeared");
        yield return new WaitForSeconds(1);
        dialogBox.EnableActionSelector(true);
        yield return dialogBox.TypeDialog("chose an action");

    }

    private void Update()
    {
        //â∫Çì¸óÕÇ∑ÇÈÇ∆Run,è„Çì¸óÕFightÇ…Ç»ÇÈ
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


                dialogBox.EnableDialogText(false);
                dialogBox.EnableActionSelector(false);
                dialogBox.EnableMoveSelector(true);
            }
        }
    }
}