using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class MoveBase : ScriptableObject
{
    //�Z�̃}�X�^�[�f�[�^

    //���O�A�ڍׁA�^�C�v�A�З́A���m���APP�i�Z���g���Ƃ��ɏ����ۂ���t�j
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

    //�ق��̃t�@�C������Q�Ƃ��邽�߂Ƀv���p�e�B

}
