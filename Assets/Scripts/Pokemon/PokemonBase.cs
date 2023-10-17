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
}