using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //���ނ����蓖���蔻��ƃR���C�_�[������B





    //player�̈ړ�
    [SerializeField] float moveSpeed;

    bool isMoveing;
    Vector2 input;

    Animator animator;

    //�ǔ����layer
    [SerializeField] LayerMask SolidObjestLayer;

    //���ނ画���layer
    [SerializeField] LayerMask longGrassLayer;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        if (!isMoveing)
        {
            //�L�[�{�[�h�̓��͕����ɓ���
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //�΂߈ړ�
            if (input.x != 0)
            {
                input.y = 0;
            }

            if (input != Vector2.zero)
            {

                //�R���[�`�����g���ď��X�ɖړI�n�ɋ߂Â���
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                Vector2 targetPos = transform.position;
                targetPos += input;
                if (IsWalkable(targetPos)){
                    StartCoroutine(Move(targetPos));
                }




            }
        }
        animator.SetBool("isMoving", isMoveing);

    }

      
    //�R���[�`�����g���ď��X�ɖړI�n�ɋ߂Â���
    IEnumerator Move(Vector3 targetPos)
    {

        //�ړ����͎󂯕t�������Ȃ�

        isMoveing = true;

        //targetPos�ƍ�������Ȃ�J��Ԃ�
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            //transform�ɋ߂Â���
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

    //targetPos�Ɉړ��\���𒲂ׂ�
    bool IsWalkable(Vector2 targetPos)
    {
        // tagetPos�ɔ��a0.2f�̉~��Ray���΂��āA�Ԃ�������Ȃ�������false
        //���̔ے肾����"!"
        return Physics2D.OverlapCircle(targetPos, 0.2f, SolidObjestLayer) == false;

        //�����̏ꏊ����~��Ray���΂��āA���ނ�Layer�ɓ���������A�����_���G���J�E���g
    }
        void CheckForEncounters()
        {
            if (Physics2D.OverlapCircle(transform.position, 0.2f, longGrassLayer))
            {
                //�����_���G���J�E���g
                if (Random.Range(0, 100) < 10)
                {

                    //Random.Range(0,100):0~99�܂ł̂ǂꂩ�̐������o��
                    //10��菬����������0~9�܂ł�10��
                    //10�ȏ�̐�����10~99�܂ł�90�q
                    Debug.Log("�����X�^�[�ɑ���");
                }

            }
        }
    }
