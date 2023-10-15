using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleDialogBox : MonoBehaviour
{

    [SerializeField] Color highlightColor;

    //役割:dialogのＴｅｘｔを入力して、変更する
    [SerializeField] int letterPerSecond; //1文字あたりの表示速度
    [SerializeField] Text dialogText;

    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject moveSelector;
    [SerializeField] GameObject moveDetails;

    [SerializeField] List<Text> actionTexts;
    [SerializeField] List<Text> moveTexts;

    [SerializeField] Text ppText;
    [SerializeField] Text typeText;

    //Textを変更するための関数
    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }

    //タイプ形式で文字を表示する
    public IEnumerator TypeDialog(string dialog)
    {

        dialogText.text = "";
        foreach (char letter in dialog)
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSecond);
        }
    }

    //UIの表示
    //dialogtextの表示
    public void EnableDialogText(bool enabled)
    {
        dialogText.enabled = enabled;
    }

    public void EnableActionSelector(bool enabled)
    {
        actionSelector.SetActive(enabled);
    }

    //moveselectorの表示
    public void EnableMoveSelector(bool enabled)
    {
        moveSelector.SetActive(enabled);
        moveDetails.SetActive(enabled);
    }

    //選択中の色を変える
    public void UpdateActionSelection(int selectAction)
    {
        for (int i = 0; i < actionTexts.Count; i++)
        {
            if (selectAction == i)
            {
                actionTexts[i].color = highlightColor;
            }
            else
            {
                actionTexts[i].color = Color.black;
            }
        }
    }
}
