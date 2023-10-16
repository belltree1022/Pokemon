using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleDialogBox : MonoBehaviour
{

    [SerializeField] Color highlightColor;

    //����:dialog�̂s����������͂��āA�ύX����
    [SerializeField] int letterPerSecond; //1����������̕\�����x
    [SerializeField] Text dialogText;

    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject moveSelector;
    [SerializeField] GameObject moveDetails;

    [SerializeField] List<Text> actionTexts;
    [SerializeField] List<Text> moveTexts;

    [SerializeField] Text ppText;
    [SerializeField] Text typeText;

    //Text��ύX���邽�߂̊֐�
    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }

    //�^�C�v�`���ŕ�����\������
    public IEnumerator TypeDialog(string dialog)
    {

        dialogText.text = "";
        foreach (char letter in dialog)
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSecond);
        }
    }

    //UI�̕\��
    //dialogtext�̕\��
    public void EnableDialogText(bool enabled)
    {
        dialogText.enabled = enabled;
    }

    public void EnableActionSelector(bool enabled)
    {
        actionSelector.SetActive(enabled);
    }

    //moveselector�̕\��
    public void EnableMoveSelector(bool enabled)
    {
        moveSelector.SetActive(enabled);
        moveDetails.SetActive(enabled);
    }

    //�I�𒆂̐F��ς���
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

    public void SetMoveNames(List<Move> moves)
    {
        moveTexts[0].text = moves[0].Base.Name;
    }
}
