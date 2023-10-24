using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using static PokemonBase;
public class BattleDialogBox : MonoBehaviour
{

    [SerializeField] Color highlightColor;//colorの中にHighlightcolorのインスペクターを追加、このおかげでコマンドを選択するときに色に設定できる。

    [SerializeField] int letterPerSecond; //インスペクターにlettrPesSecondを定義、この時間を調整することで時間を文字が出てくる時間を調整
    [SerializeField] Text dialogText;　//インスペクターにdialogtextを追加、ここで自分が打った文字を反映するとその文字が追加される

    [SerializeField] GameObject actionSelector;//バトルダイアログのBOXにactionselelctor用のインスペクターを追加
    [SerializeField] GameObject moveSelector;//バトルダイアログのBOXにmoveselector用のインスペクターを追加
    [SerializeField] GameObject moveDetails;//バトルダイアログのBOXactionselector用のインスペクターを追加
    [SerializeField] List<Text> actionTexts;//アクションテキストをインスペクターに追加、Listだから個数を選べる、例えば２つなら２つ　今回の場合、戦うか逃げるか
    [SerializeField] List<Text> moveTexts;//movetextををインスペクターに追加、Listだから個数を選べる、例えば２つなら２つ、今回の場合技名

    [SerializeField] Text ppText;
    [SerializeField] public Text typeText;

    //Text??ｿｽ?ｿｽ??ｿｽ?ｿｽﾏ更??ｿｽ?ｿｽ??ｿｽ?ｿｽ??ｿｽ?ｿｽ驍ｽ??ｿｽ?ｿｽﾟの関撰ｿｽ
    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }

    //??ｿｽ?ｿｽ^??ｿｽ?ｿｽC??ｿｽ?ｿｽv??ｿｽ?ｿｽ`??ｿｽ?ｿｽ??ｿｽ?ｿｽ??ｿｽ?ｿｽﾅ包ｿｽ??ｿｽ?ｿｽ??ｿｽ?ｿｽ??ｿｽ?ｿｽ??ｿｽ?ｿｽ\??ｿｽ?ｿｽ??ｿｽ?ｿｽ??ｿｽ?ｿｽ??ｿｽ?ｿｽ??ｿｽ?ｿｽ??ｿｽ?ｿｽ
    public IEnumerator TypeDialog(string dialog)
    {
        Debug.Log(dialog);
        dialogText.text = "";
        foreach (char letter in dialog)
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSecond);
        }

        yield return new WaitForSeconds(0.7f); //1秒待機
    }

    //UI??ｿｽ?ｿｽﾌ表??ｿｽ?ｿｽ??ｿｽ?ｿｽ
    //dialogtext??ｿｽ?ｿｽﾌ表??ｿｽ?ｿｽ??ｿｽ?ｿｽ
    public void EnableDialogText(bool enabled)
    {
        dialogText.enabled = enabled;
    }

    public void EnableActionSelector(bool enabled)
    {
        actionSelector.SetActive(enabled);
    }

    //moveselector??ｿｽ?ｿｽﾌ表??ｿｽ?ｿｽ??ｿｽ?ｿｽ
    public void EnableMoveSelector(bool enabled)
    {
        moveSelector.SetActive(enabled);
        moveDetails.SetActive(enabled);
    }

    //??ｿｽ?ｿｽI??ｿｽ?ｿｽ???ｿｽﾌ色??ｿｽ?ｿｽ??ｿｽ?ｿｽﾏゑｿｽ??ｿｽ?ｿｽ??ｿｽ?ｿｽ
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

    public void UpdateMoveSelection(int selectMove, Move move)
    {
        for (int i = 0; i < moveTexts.Count; i++)
        {
            if (selectMove == i)
            {
                moveTexts[i].color = highlightColor;
            }
            else
            {
                moveTexts[i].color = Color.black;
            }
            // Debug.Log("move:"+move.PP);
            // Debug.Log("moveBase:"+move.Base.PP);
            ppText.text = $"PP {move.PP}/{move.Base.PP}";
            // if (typeText == null)
            // {
            //     Debug.LogError("typeText is null.");
            // }
            // else
            // {
            //     // typeText は null ではないので、何か処理を行うことができます。
            //     // 例: typeText のテキストを取得して表示する
            //     Debug.Log("typeText is not null. Text: " + typeText.text);
            // }
            //Debug.Log("Type:" + move.Base.Type.ToString());
            
            typeText.text = move.Base.Type.ToString();
            // typeText.text = "1";
        }
    }

    public void SetMovenames(List<Move> moves)
    {

        for (int i = 0; i < moveTexts.Count; i++)
        {
            if (i < moves.Count)
            {
                moveTexts[i].text = moves[i].Base.Name;
            }
            else
            {
                moveTexts[i].text = ".";
            }
        }
    }
}


