using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PokemonBase;

[CreateAssetMenu]
public class MoveBase : ScriptableObject
{
    // ���O, �ڍ�, �^�C�v, �З�, ���m��, PP(�Z���g���Ƃ��ɏ����|�C���g)
    [SerializeField] string name;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] PokemonType type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;
    // ���̃t�@�C������Q�Ƃ��邽�߂Ƀv���p�e�B���g��
    public string Name { get => name; }
    public string Description { get => description; }
    public PokemonType Type { get => type; }
    public int Power { get => power; }
    public int PP { get => pp; }
}