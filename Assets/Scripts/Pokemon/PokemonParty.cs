using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // LINQを使用するために必要な名前空間]
using static Pokemon;
public class PokemonParty : MonoBehaviour
{
    //トレーナーのポケモン管理
    [SerializeField] List<Pokemon> pokemons;
    //戦えるポケモンを渡す（HP＞０のポケモンを探す）
    public Pokemon GetHealthyPokemon()
    {
        return pokemons.Where(monster => monster.HP > 0).FirstOrDefault(); // Whereメソッドを使用してHPが0より大きいポケモンを探す
    }
}