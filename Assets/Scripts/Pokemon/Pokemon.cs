using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PokemonBase;


//���x���ɉ������X�e�[�^�X�̈Ⴄ�����X�^�[�𐶐�����N���X
//���Ӂ@�f�[�^�݈̂���
public class Pokemon
{
    //�x�[�X�ƂȂ�f�[�^
   public PokemonBase Base { get; set; }
   public int Level { get; set; }


    public int HP { get; set; }

    //�g����Z
    public List<Move> Moves { get; set; }


    //�R���X�g���N�^�[�@�������̏����ݒ�
    public Pokemon(PokemonBase pBase, int pLevel)
    {
        Base = pBase;
        Level = pLevel;
        HP = MaxHp;

        Moves = new List<Move>();


        //�g����Z�̐ݒ�:�o����Z�̃��x���ȏ�Ȃ�Moves�ɒǉ�
        foreach (LearnableMove learnableMove in pBase.LearnableMoves)
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
    public bool TakeDamage(Move move,Pokemon attacker)
    {
        float modififers = Random.Range(0.85f,1f);//ダメージが１００％なのか８５％なのか
        float a = (2*attacker.Level+10)/250f; //レベルに応じてダメージ変化
        float d = a*move.Base.Power*((float)attacker.Attack/Defense)+2;//技の威力にレベルが依存
        int damage=Mathf.FloorToInt(d*modififers);//ダメージ計算 FloorToIntは小数点以下切り捨て

        HP -= damage;
        if (HP <=0) //もしHPが０以下なら０にしましょう
        {
            HP=0;
            return true;
        }

        return false;//そうでなけれあ、残りのHPで大丈夫
    }

    public Move GetRandomMove()
    {
        if (Moves.Count==0){

            return null;
        }

        int r = Random.Range(0,Moves.Count);//どんな技がくるのか
        return Moves[r];//Movesの中からランダムで選ぶ
    }
}