using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static PokemonBase;


//���x���ɉ������X�e�[�^�X�̈Ⴄ�����X�^�[�𐶐�����N���X
//���Ӂ@�f�[�^�݈̂���

[System.Serializable]
public class Pokemon
{
//#14-2の8:50秒あたりでエラーが起きるが、原因はデータの初期化がされていないから　また_baseとlevelが使われていないい

    //インスペクターから実行できるようにする
    //変更：モンスター
    [SerializeField] PokemonBase _base;//戦わせるモンスターをセット
    [SerializeField] int level;
        //�x�[�X�ƂȂ�f�[�^
   public PokemonBase Base { get=>_base; }
   public int Level { get=>level; }


    public int HP { get; set; }

    //�g����Z
    public List<Move> Moves { get; set; }


    //�R���X�g���N�^�[�@�������̏����ݒ�
    public void Init()
    {
       
        HP = MaxHp;

        Moves = new List<Move>();


        //�g����Z�̐ݒ�:�o����Z�̃��x���ȏ�Ȃ�Moves�ɒǉ�
        foreach (LearnableMove learnableMove in Base.LearnableMoves)
        {
            if (Level >=learnableMove.Level)
            {
                //�Z���o����
                Moves.Add(new Move(learnableMove.Base));
            }
            //4�ȏ�̋Z�͎g���Ȃ�





            if (Moves.Count >= 4)
            {
                break;
            }
        }
    }
    //level�ɉ������X�e�[�^�X��Ԃ����́F�v���p�e�B�i+�����������邱�Ƃ��ł���j
    //�֐��o�[�W����

    //�v���p�e�B

    public int Attack
    {
        get { return Mathf.FloorToInt((Base.Attack * Level) / 100f) + 5; }
    }
public int Defense
    {
        get
        {
            return Mathf.FloorToInt((Base.Defense * Level) / 100f) + 5;
        }
        }

public int SpAttack
    {
        get
        {
            return Mathf.FloorToInt((Base.SpAttack * Level) / 100f) + 5;
        }
        }
public int SpDefense
    {
        get
        {
            return Mathf.FloorToInt((Base.SpDefense * Level) / 100f) + 5;
        }
        }

public int Speed
    {
        get
        {
            return Mathf.FloorToInt((Base.Speed * Level) / 100f) + 5;
        }
        }
public int MaxHp
    {
        get
        {
            return Mathf.FloorToInt((Base.MaxHP * Level) / 100f) + 10;
        }
    }










    public DamageDetails  TakeDamage(Move move,Pokemon attacker)
    {

        //クリティカル　急所攻撃
        float critical =1f;
        //6.25%の攻撃で急所攻撃
        if (Random.value*100<=6.25f)
        {
            critical=2f;
        }

        //タイプの相性 
        float type =TypeChart.GetEffectivenss(move.Base.Type,Base.Type1)*TypeChart.GetEffectivenss(move.Base.Type,Base.Type2) ;
        DamageDetails damageDetails = new DamageDetails

        {
            Fainted =false,//戦闘不能化
            Critical=critical,//きゅうしょか
            TypeEffectiveness=type//タイプ
        };
        
        //特殊技の場合
        float attack=attacker.Attack;
        float defense=Defense;
        if (move.Base.InSpecial)
        {
            attack=attacker.SpAttack;
            defense=SpDefense;
        }
        
        
        float modififers = Random.Range(0.85f,1f)*type*critical
        ;//ダメージが１００％なのか８５％なのか,タイプの相性も追加
        float a = (2*attacker.Level+10)/250f; //レベルに応じてダメージ変化
        float d = a*move.Base.Power*((float)attacker.Attack/Defense)+2;//技の威力にレベルが依存
        int damage=Mathf.FloorToInt(d*modififers);//ダメージ計算 FloorToIntは小数点以下切り捨て

        HP -= damage;
        if (HP <=0) //もしHPが０以下なら０にしましょう
        {
            HP=0;
            damageDetails.Fainted=true; //戦闘不能になったらTrue
        }

        return damageDetails;//そうでなけれあ、残りのHPで大丈夫
    }

    public Move GetRandomMove()
    {
    
        int r = Random.Range(0,Moves.Count);//どんな技がくるのか
        return Moves[r];//Movesの中からランダムで選ぶ
    }
}

public class DamageDetails 
{
    public bool Fainted {get;set;}//戦闘不能かどうか
    public float Critical {get;set;}
    public float TypeEffectiveness {get;set;}
}