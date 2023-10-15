using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleUnit : MonoBehaviour
{
    [SerializeField] PokemonBase _base;//��킹�郂���X�^�[�ݒ�
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit; //���ʉ�


    public Pokemon Pokemon { get; set; }
    //�o�g���Ŏg�������X�^�[�ێ�
    //�����X�^�[�̉摜�𔽉f����


    public void Setup()
    {
        //_�x�[�X���烌�x���ɉ����������X�^�[�𐶐�
        //battelesysytem�Ŏg������v���p�e�B�����
        Pokemon = new Pokemon(_base, level);

        Image image = GetComponent<Image>();
        if (isPlayerUnit)
        {
            image.sprite = Pokemon.Base.FrontSprite;
        }
        else
        {
            image.sprite = Pokemon.Base.FrontSprite;
        }
    }
}
