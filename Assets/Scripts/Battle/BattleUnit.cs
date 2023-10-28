using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] PokemonBase _base;//��킹�郂���X�^�[�ݒ�
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit; //���ʉ�


    public Pokemon Pokemon { get; set; }
    //�o�g���Ŏg�������X�^�[�ێ�
    //�����X�^�[�̉摜�𔽉f����


    //最初の位置　オリジナルポジション
    Vector3 originalPos;
    Color originalColor;
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        originalPos=transform.localPosition;
        originalColor=image.color;
    }


    public void Setup()
    {
        //_�x�[�X���烌�x���ɉ����������X�^�[�𐶐�
        //battelesysytem�Ŏg������v���p�e�B�����
        Pokemon = new Pokemon(_base, level);

        
        if (isPlayerUnit)
        {
            image.sprite = Pokemon.Base.FrontSprite;
        }
        else
        {
            image.sprite = Pokemon.Base.FrontSprite;
        }
        PlayerEnterAnimation();
    }
    //登場Animation
    public void PlayerEnterAnimation()
    {
        if (isPlayerUnit)
        {
            //左端に配置
            transform.localPosition=new Vector3(-1250,originalPos.y);
        }
        else
        {
            //右端に配置
            transform.localPosition=new Vector3(1200,originalPos.y);
        }
        //戦闘時の位置までアニメーショ
        transform.DOLocalMoveX(originalPos.x,1.0f);
    }
    //攻撃Anim
    public void PlayerAttackAnimation()
    {
        //シーケンス
        //右に動いたら元の位置に戻る
        Sequence sequence = DOTween.Sequence();
        if (isPlayerUnit)
        {
            sequence.Append(transform.DOLocalMoveX(originalPos.x+50,0.25f));//後ろに追加
        }
        else
        {
            sequence.Append(transform.DOLocalMoveX(originalPos.x-50,0.25f));//後ろに追加
        }



        
        sequence.Append(transform.DOLocalMoveX(originalPos.x,0.2f));//後ろに追加  シーケンスは自分でタイミング調節可能
    }

    //ダメージAnim
    public void PlayerHitAnimation()
    {
        //色を一度GLAYにして戻す
        Sequence sequence = DOTween.Sequence();
        sequence.Append(image.DOColor(Color.gray,0.1f));
        sequence.Append(image.DOColor(originalColor,0.1f));

    }

}
