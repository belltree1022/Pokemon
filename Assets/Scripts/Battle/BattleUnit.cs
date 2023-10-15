using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleUnit : MonoBehaviour
{
    [SerializeField] PokemonBase _base;//戦わせるモンスター設定
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit; //差別化


    public Pokemon Pokemon { get; set; }
    //バトルで使うモンスター保持
    //モンスターの画像を反映する


    public void Setup()
    {
        //_ベースからレベルに応じたモンスターを生成
        //battelesysytemで使うからプロパティ入れる
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
