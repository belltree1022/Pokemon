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

    //壁判定のLayer
    [SerializeField] LayerMask SolidObjestLayer;//
    //草むらＬａｙｅｒの判定
    [SerializeField] LayerMask longGrassLayer;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
        if (!isMoveing)//ismovingで移動中には入力を受け付けない
        {
            //得た情報を保持するために定義付け　//キーボードの入力があったらその方向に動く
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            
            if (input.x != 0) //斜め移動　これで禁止できる
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
                if (IsWalkable(targetPos)){　//入力する前に歩けるかどうかを確認する
                    StartCoroutine(Move(targetPos));
                }




            }
        }
        animator.SetBool("isMoving", isMoveing);

    }


    //コルーチンを使用して徐々に移動
    IEnumerator Move(Vector3 targetPos)
    {

        //????????t?????????

        isMoveing = true;

        //targetPosと現在の場所を引き算　targetposとの差が左にあるなら繰り返す
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            //targetposに近づける
            transform.position = Vector3.MoveTowards(
                transform.position,//現在の場所
                targetPos,//目的地
                moveSpeed*Time.deltaTime);

            yield return null;
        }
        transform.position = targetPos;
        isMoveing = false;
        CheckForEncounters();
    }

    //targetPosに移動可能かを調べる関数
    bool IsWalkable(Vector2 targetPos)
    {
        //tagetPosに半径0.2ｆの円のＲａｙを飛ばして、ぶつからなかったらＦａｌｓｅ
        return Physics2D.OverlapCircle(targetPos, 0.2f, SolidObjestLayer) == false;

    }
        void CheckForEncounters()
        {
            if (Physics2D.OverlapCircle(transform.position, 0.2f, longGrassLayer))
            {
                //ランダムカウント
                if (Random.Range(0, 100) < 10)
                {

                //random.range(0,100):0~99までのどれかの数字が出る
                //10より小さい数字は０～９までの10個
                //10以上の数字は10～99までの99個
                Debug.Log("モンスターに遭遇");
                }

            }
        }
    }
