using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �|�P�����̃}�X�^�[�f�[�^�F�O������ύX���Ȃ��i�C���X�y�N�^�[�����ύX�\�j
[CreateAssetMenu]
public class PokemonBase : ScriptableObject
{
    // ���O,����,�摜,�^�C�v,�X�e�[�^�X

    [SerializeField] new string name;//�|�P�����̖��O���`
    [TextArea]
    [SerializeField] string description;//�|�P�����̐���

    // �摜
    [SerializeField] Sprite frontSprite;//�|�P�����̑O�摜
    [SerializeField] Sprite backSprite;//���摜

    // �^�C�v
    [SerializeField] PokemonType type1;//�^�C�v1���C���X�y�N�^�[�ɒǉ�
    [SerializeField] PokemonType type2;//�^�C�v�Q���C���X�y�N�^�[�ɒǉ�

    // �X�e�[�^�X:hp,at,df,sAT,sDF,sp
    [SerializeField] int maxHP;//�|�P������HP���`���ăC���X�y�N�^�[�ɒǉ�
    [SerializeField] int attack;//�|�P�����̍U���͂��`���ăC���X�y�N�^�[�ɒǉ�
    [SerializeField] int defense;//�|�P�����̖h��͂��`���ăC���X�y�N�^�[�ɒǉ�
    [SerializeField] int spAttack;//�|�P�����̓��U���`
    [SerializeField] int spDefense;//���h���`���ăC���X�y�N�^�[�ɒǉ�
    /// </summary>
    [SerializeField] int speed;//���΂₳���`���ăC���X�y�N�^�[�ɒǉ�

    // �o����Z�ꗗ
    [SerializeField] List<LearnableMove> learnableMoves;


    // ���t�@�C������attack�̒l�̎擾�͂ł��邪�ύX�͂ł��Ȃ�
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
   


    // �o����Z�N���X�F�ǂ̃��x���ŉ����o����̂�
    [Serializable]
    public class LearnableMove
    {
        // �q�G�����L�[�Őݒ肷��
        [SerializeField] MoveBase _base;
        [SerializeField] int level;//���x���̒�`

        public MoveBase Base { get => _base; }
        public int Level { get => level; }
    }

    public enum PokemonType //�|�P�����̃^�C�v�ꗗ
    {
        None,//�Ȃ�
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
    public class TypeChart
{
    //どこからでもアクセスできるようにstatic
    static float[][] chart=
    {//2次元判定の作成
         //攻撃、防御         Normal,Fire,Water,Electrlic,Grass,Ice,Fight,Poison   
        /*normal*/new float[]{1f,1f,1f,1f,1f,1f,1f,1f},
        /*Fire*/new float[]{1f,0.5f,0.5f,1f,2f,2f,1f,1f},
        /*Water*/new float[]{1f,2f,0.5f,1f,0.5f,1f,1f,1f},
         /*elec*/new float[]{1f,1f,2f,0.5f,0.5f,1f,1f,1f},
        /*Grass*/new float[]{1f,0.5f,2f,1f,0.5f,1f,1f,0.5f},
        /*Ice*/new float[]{1f,0.5f,0.5f,1f,2f,0.5f,1f,1f},
         /*Fight*/new float[]{2f,1f,1f,1f,1f,2f,1f,0.5f},
        /*Poison*/new float[]{1f,1f,1f,1f,2f,1f,1f,0.5f},
        
    };

    public static float GetEffectivenss(PokemonType attackType,PokemonType defenseType)//PokemonTypeが表示されなかったが、前に起きたエラーと同じようにusing static PokemonBase;と入れたら解決できた
    {
        if (attackType==PokemonType.None || defenseType==PokemonType.None)
        {
            return 1f; //何もない場合は倍率はそのまま
        }



        int row=(int)attackType-1;//-1するのはなんでもないというタイプを省きたいため
        int col=(int)defenseType-1;
        return chart[row][col];

    }
}
}
