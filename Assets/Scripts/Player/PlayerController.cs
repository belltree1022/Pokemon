using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //SerializeField�ŕt�^���ꂽ���̂��C���X�y�N�^�[�ɕ\���A
    [SerializeField] float moveSpeed;// �����������`���āA�C���X�y�N�^�[�ɕ\��

    bool isMoveing; //ismoving��bool�^�ATrue��False�������
    Vector2 input; //2D�x�N�g���̗v�f�����iX�������AY���c�����j

    Animator animator;//�A�j���[�^�@�\

    //�ǔ����Layer
    [SerializeField] LayerMask SolidObjestLayer;//
    //���ނ�k���������̔���
    [SerializeField] LayerMask longGrassLayer;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update

    // Update is called once per frame
public void HandUpdate()
    {
        
        if (!isMoveing)//ismoving�ňړ����ɂ͓��͂��󂯕t���Ȃ�
        {
            //��������ێ����邽�߂ɒ�`�t���@//�L�[�{�[�h�̓��͂��������炻�̕����ɓ���
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            
            if (input.x != 0) //�΂߈ړ��@����ŋ֎~�ł���
            {
                input.y = 0;
            }

            if (input != Vector2.zero)
            {

                //?R???[?`?????g??????X???I?n???????
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

               
                Vector2 targetPos = transform.position;
                targetPos += input;
                if (IsWalkable(targetPos))
                {

                    StartCoroutine(Move(targetPos));
                }




            }
        }
        animator.SetBool("isMoving", isMoveing);

    }


    //�R���[�`�����g�p���ď��X�Ɉړ�
    IEnumerator Move(Vector3 targetPos)
    {

        //????????t?????????

        isMoveing = true;

        //targetPos�ƌ��݂̏ꏊ�������Z�@targetpos�Ƃ̍������ɂ���Ȃ�J��Ԃ�
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            //targetpos�ɋ߂Â���
            transform.position = Vector3.MoveTowards(
                transform.position,//���݂̏ꏊ
                targetPos,//�ړI�n
                moveSpeed*Time.deltaTime);

            yield return null;
        }
        transform.position = targetPos;
        isMoveing = false;
        CheckForEncounters();
    }

    //targetPos�Ɉړ��\���𒲂ׂ�֐�
    bool IsWalkable(Vector2 targetPos)
    {
        //tagetPos�ɔ��a0.2���̉~�̂q�������΂��āA�Ԃ���Ȃ�������e��������
        return Physics2D.OverlapCircle(targetPos, 0.2f, SolidObjestLayer) == false;

    }
        void CheckForEncounters()
        {
            if (Physics2D.OverlapCircle(transform.position, 0.2f, longGrassLayer))
            {
                //�����_���J�E���g
                if (Random.Range(0, 100) < 10)
                {

                //random.range(0,100):0~99�܂ł̂ǂꂩ�̐������o��
                //10��菬���������͂O�`�X�܂ł�10��
                //10�ȏ�̐�����10�`99�܂ł�99��
                Debug.Log("モンスターに遭遇");
    
                }

            }
        }
    }
