using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleDialogBox : MonoBehaviour
{

    //役割:dialogのＴｅｘｔを入力して、変更する
    [SerializeField] Text dialogText;

    //Textを変更するための関数
    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }
}
