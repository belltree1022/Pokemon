using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //SerializeFieldで付与されたものがインスペクターに表示、
    [SerializeField] float moveSpeed;// 動く速さを定義して、インスペクターに表示

    bool isMoveing; //ismovingのbool型、TrueとFalseかを取る
    Vector2 input; //2Dベクトルの要素を代入（Xが水平、Yが縦方向）

    Animator animator;//アニメータ機能

    //
    [SerializeField] LayerMask SolidObjestLayer;//

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
          
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //?????
            if (input.x != 0)
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
                if (IsWalkable(targetPos)){
                    StartCoroutine(Move(targetPos));
                }




            }
        }
        animator.SetBool("isMoving", isMoveing);

    }

      
    //?R???[?`?????g??????X???I?n???????
    IEnumerator Move(Vector3 targetPos)
    {

        //????????t?????????

        isMoveing = true;

        //targetPos???????????J????
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            //transform???????
            transform.position = Vector3.MoveTowards(
                transform.position,//??????
                targetPos,//??I?n
                moveSpeed*Time.deltaTime);

            yield return null;
        }
        transform.position = targetPos;
        isMoveing = false;
        CheckForEncounters();
    }

    //targetPos??????\??????
    bool IsWalkable(Vector2 targetPos)
    {
        // tagetPos????a0.2f??~??Ray???????A??????????????????false
        //??????????"!"
        return Physics2D.OverlapCircle(targetPos, 0.2f, SolidObjestLayer) == false;

        //???????????~??Ray???????A?????Layer???????????A?????_???G???J?E???g
    }
        void CheckForEncounters()
        {
            if (Physics2D.OverlapCircle(transform.position, 0.2f, longGrassLayer))
            {
                //?????_???G???J?E???g
                if (Random.Range(0, 100) < 10)
                {

                    //Random.Range(0,100):0~99??????????????o??
                    //10?????????????0~9????10??
                    //10?????????10~99????90?q
                    Debug.Log("?????X?^?[?????");
                }

            }
        }
    }
