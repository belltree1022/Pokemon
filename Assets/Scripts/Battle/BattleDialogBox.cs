using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using static PokemonBase;
public class BattleDialogBox : MonoBehaviour
{

    [SerializeField] Color highlightColor;//color�̒���Highlightcolor�̃C���X�y�N�^�[��ǉ��A���̂������ŃR�}���h��I������Ƃ��ɐF�ɐݒ�ł���B

    [SerializeField] int letterPerSecond; //�C���X�y�N�^�[��lettrPesSecond���`�A���̎��Ԃ𒲐����邱�ƂŎ��Ԃ𕶎����o�Ă��鎞�Ԃ𒲐�
    [SerializeField] Text dialogText;�@//�C���X�y�N�^�[��dialogtext��ǉ��A�����Ŏ������ł��������𔽉f����Ƃ��̕������ǉ������

    [SerializeField] GameObject actionSelector;//�o�g���_�C�A���O��BOX��actionselelctor�p�̃C���X�y�N�^�[��ǉ�
    [SerializeField] GameObject moveSelector;//�o�g���_�C�A���O��BOX��moveselector�p�̃C���X�y�N�^�[��ǉ�
    [SerializeField] GameObject moveDetails;//�o�g���_�C�A���O��BOXactionselector�p�̃C���X�y�N�^�[��ǉ�
    [SerializeField] List<Text> actionTexts;//�A�N�V�����e�L�X�g���C���X�y�N�^�[�ɒǉ��AList���������I�ׂ�A�Ⴆ�΂Q�Ȃ�Q�@����̏ꍇ�A�키�������邩
    [SerializeField] List<Text> moveTexts;//movetext�����C���X�y�N�^�[�ɒǉ��AList���������I�ׂ�A�Ⴆ�΂Q�Ȃ�Q�A����̏ꍇ�Z��

    [SerializeField] Text ppText;
    [SerializeField] public Text typeText;

    //Text??��?��??��?��ύX??��?��??��?��??��?��邽??��?��߂̊֐�
    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }

    //??��?��^??��?��C??��?��v??��?��`??��?��??��?��??��?��ŕ�??��?��??��?��??��?��??��?��\??��?��??��?��??��?��??��?��??��?��??��?��
    public IEnumerator TypeDialog(string dialog)
    {
        Debug.Log(dialog);
        dialogText.text = "";
        foreach (char letter in dialog)
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSecond);
        }

        yield return new WaitForSeconds(0.7f); //1�b�ҋ@
    }

    //UI??��?��̕\??��?��??��?��
    //dialogtext??��?��̕\??��?��??��?��
    public void EnableDialogText(bool enabled)
    {
        dialogText.enabled = enabled;
    }

    public void EnableActionSelector(bool enabled)
    {
        actionSelector.SetActive(enabled);
    }

    //moveselector??��?��̕\??��?��??��?��
    public void EnableMoveSelector(bool enabled)
    {
        moveSelector.SetActive(enabled);
        moveDetails.SetActive(enabled);
    }

    //??��?��I??��?��???��̐F??��?��??��?��ς�??��?��??��?��
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
            //     // typeText �� null �ł͂Ȃ��̂ŁA�����������s�����Ƃ��ł��܂��B
            //     // ��: typeText �̃e�L�X�g���擾���ĕ\������
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


