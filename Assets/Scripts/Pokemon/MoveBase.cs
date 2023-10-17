using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PokemonBase;

[CreateAssetMenu]
public class MoveBase : ScriptableObject
{
    // 名前, 詳細, タイプ, 威力, 正確性, PP(技を使うときに消費するポイント)
    [SerializeField] string name;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] PokemonType type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;
    // 他のファイルから参照するためにプロパティを使う
    public string Name { get => name; }
    public string Description { get => description; }
    public PokemonType Type { get => type; }
    public int Power { get => power; }
    public int PP { get => pp; }
}