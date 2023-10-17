using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText; //インスペクターにモンスターの名前を設定できる
    [SerializeField] Text levelText;//インスペクターにモンスターのレベルを設定できる
    [SerializeField] Hpbar hpbar;//インスペクターにモンスターのHP（体力）追加


    public void SetData(Pokemon pokemon)
    {
        nameText.text = pokemon.Base.Name; 
        levelText.text = "LV " + pokemon.Level;
        hpbar.SetHP((float)pokemon.HP/pokemon.MaxHp);

    }
}
