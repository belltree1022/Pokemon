using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class MoveBase : ScriptableObject
{
    //技のマスターデータ

    //名前、詳細、タイプ、威力、正確性、PP（技を使うときに消費するぽいんt）
    [SerializeField] new string name;
    [TextArea]
    [SerializeField] string description;

    [SerializeField] PokemonBase type;
    [SerializeField] int power;
    [SerializeField] int accuracy;//seikausei
    [SerializeField] int pp;

   
    public string Name{ get => name; }
    public string Description { get => description; }
    public PokemonBase Type { get => type; }
    public int Power { get => power; }
    public int Accuracy { get => accuracy; }
    public int Pp { get => pp; }

    //ほかのファイルから参照するためにプロパティ

}
