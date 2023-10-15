using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleDialogBox : MonoBehaviour
{

    //–ğŠ„:dialog‚Ì‚s‚…‚˜‚”‚ğ“ü—Í‚µ‚ÄA•ÏX‚·‚é
    [SerializeField] Text dialogText;

    //Text‚ğ•ÏX‚·‚é‚½‚ß‚ÌŠÖ”
    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }
}
