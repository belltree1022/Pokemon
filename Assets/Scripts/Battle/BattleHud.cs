using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText; //�C���X�y�N�^�[�Ƀ����X�^�[�̖��O��ݒ�ł���
    [SerializeField] Text levelText;//�C���X�y�N�^�[�Ƀ����X�^�[�̃��x����ݒ�ł���
    [SerializeField] Hpbar hpbar;//�C���X�y�N�^�[�Ƀ����X�^�[��HP�i�̗́j�ǉ�


    public void SetData(Pokemon pokemon)
    {
        nameText.text = pokemon.Base.Name; 
        levelText.text = "LV " + pokemon.Level;
        hpbar.SetHP((float)pokemon.HP/pokemon.MaxHp);

    }
}
