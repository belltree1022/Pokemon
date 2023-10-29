using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PokemonBase;//�|�P�����x�[�X����|�P�����^�C�v�������Ă���

[CreateAssetMenu]
public class MoveBase : ScriptableObject
{
    // ���O, �ڍ�, �^�C�v, �З�, ���m��, PP(�Z���g���Ƃ��ɏ����|�C���g)
    [SerializeField] string name;//�Z�����`���ăC���X�y�N�^�[�ɒǉ�
    [TextArea]
    [SerializeField] string description;//�Z�̐������C���X�y�N�^�[�ɒǉ�
    [SerializeField] PokemonType type;//�Z�̃^�C�v��I���ł���C���X�y�N�^�[�ɒǉ�
    [SerializeField] int power;//�Z�̍U���͂��C���X�y�N�^�[�ɒǉ�
    [SerializeField] int accuracy;//�Z�̖��������C���X�y�N�^�[�ɒǉ�
    [SerializeField] int pp;//�Z�̎g�p�ł��鐔���C���X�y�N�^�[�ɒǉ�
    // ���̃t�@�C������Q�Ƃ��邽�߂Ƀv���p�e�B���g��
    public string Name { get => name; }
    public string Description { get => description; }
    public PokemonType Type { get => type; }
    public int Power { get => power; }
    public int PP { get => pp; }

    //特殊技、特殊タイプ
    public bool InSpecial
    {
        get
        {
            if (type==PokemonType.Fire || type==PokemonType.Water||type==PokemonType.Grass
            || type==PokemonType.Ice || type==PokemonType.Electric||type==PokemonType.Dragon)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}