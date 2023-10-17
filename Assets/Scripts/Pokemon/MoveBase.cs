using System.Net.Mime;
using System.Collections;　
using System.Collections.Generic;
using UnityEngine;
using static PokemonBase;//ポケモンベースからポケモンタイプを持ってくる

[CreateAssetMenu]
public class MoveBase : ScriptableObject
{
    // 名前, 詳細, タイプ, 威力, 正確性, PP(技を使うときに消費するポイント)
    [SerializeField] string name;　//技名を定義してインスペクターに追加
    [TextArea]
    [SerializeField] string description;//技の説明をインスペクターに追加
    [SerializeField] PokemonType type;//技のタイプを選択できるインスペクターに追加
    [SerializeField] int power;//技の攻撃力をインスペクターに追加
    [SerializeField] int accuracy;//技の命中率をインスペクターに追加
    [SerializeField] int pp;//技の使用できる数をインスペクターに追加
    // 他のファイルから参照するためにプロパティを使う
    public string Name { get => name; }
    public string Description { get => description; }
    public PokemonType Type { get => type; }
    public int Power { get => power; }
    public int PP { get => pp; }
}