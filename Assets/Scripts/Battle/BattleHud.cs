using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText; //�C���X�y�N�^�[�Ƀ����X�^�[�̖��O��ݒ�ł���
    [SerializeField] Text levelText;//�C���X�y�N�^�[�Ƀ����X�^�[�̃��x����ݒ�ł���
    [SerializeField] Hpbar hpbar;//�C���X�y�N�^�[�Ƀ����X�^�[��HP�i�̗́j�ǉ�

    Pokemon _pokemon;




    public void SetData(Pokemon pokemon)
    {
        _pokemon=pokemon;
        nameText.text = pokemon.Base.Name; 
        levelText.text = "LV " + pokemon.Level;
        hpbar.SetHP((float)pokemon.HP/pokemon.MaxHp);

    }

    public void UpdateHP() //HPを反映ダメージ計算
    {
        hpbar.SetHP((float)_pokemon.HP/_pokemon.MaxHp);

    }
}
