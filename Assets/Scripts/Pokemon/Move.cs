using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    // Pokemon�����ۂɎg���Ƃ��̋Z�f�[�^

    // �Z�̃}�X�^�[�f�[�^������
    // �g���₷���悤�ɂ��邽�߂�PP������

    // Pokemon.cs���Q�Ƃ���̂�public�ɂ��Ă���
    public MoveBase Base { get; set; }
    public int Pp { get; set; }


    // �����ݒ�
    public Move(MoveBase pBase)
    {
        Base = pBase;
        Pp = pBase.Pp;
    }
}
