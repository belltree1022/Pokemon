using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ポケモンのマスターデータ：外部から変更しない（インスペクターだけ変更可能）
[CreateAssetMenu]
public class PokemonBase : ScriptableObject
{
    // 名前,説明,画像,タイプ,ステータス

    [SerializeField] new string name;//ポケモンの名前を定義
    [TextArea]
    [SerializeField] string description;//ポケモンの説明

    // 画像
    [SerializeField] Sprite frontSprite;//ポケモンの前画像
    [SerializeField] Sprite backSprite;//後ろ画像

    // タイプ
    [SerializeField] PokemonType type1;//タイプ1をインスペクターに追加
    [SerializeField] PokemonType type2;//タイプ２をインスペクターに追加

    // ステータス:hp,at,df,sAT,sDF,sp
    [SerializeField] int maxHP;//ポケモンのHPを定義してインスペクターに追加
    [SerializeField] int attack;//ポケモンの攻撃力を定義してインスペクターに追加
    [SerializeField] int defense;//ポケモンの防御力を定義してインスペクターに追加
    [SerializeField] int spAttack;//ポケモンの特攻を定義
    [SerializeField] int spDefense;//特防を定義してインスペクターに追加
    /// </summary>
    [SerializeField] int speed;//すばやさを定義してインスペクターに追加

    // 覚える技一覧
    [SerializeField] List<LearnableMove> learnableMoves;


    // 他ファイルからattackの値の取得はできるが変更はできない
    public int Attack { get => attack; }
    public int Defense { get => defense; }
    public int SpAttack { get => spAttack; }
    public int SpDefense { get => spDefense; }
    public int Speed { get => speed; }
    public int MaxHP { get => maxHP; }

    public List<LearnableMove> LearnableMoves { get => learnableMoves; }
    public string Name { get => name; }
    public string Description { get => description; }
    public Sprite FrontSprite { get => frontSprite; }
    public Sprite BackSprite { get => backSprite; }
    public PokemonType Type1 { get => type1; }
    public PokemonType Type2 { get => type2; }
   


    // 覚える技クラス：どのレベルで何を覚えるのか
    [Serializable]
    public class LearnableMove
    {
        // ヒエラルキーで設定する
        [SerializeField] MoveBase _base;
        [SerializeField] int level;//レベルの定義

        public MoveBase Base { get => _base; }
        public int Level { get => level; }
    }

    public enum PokemonType //ポケモンのタイプ一覧
    {
        None,//なし
        Normal,
        Fire,
        Water,
        Electric,
        Grass,
        Ice,
        Fighting,
        Poison,
        Ground,
        Flying,
        Psychic,
        Bug,
        Ghost,
        Dragon,
    }
}