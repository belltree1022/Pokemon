using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //草むらを作り当たり判定とコライダーをつくる。





    //playerの移動
    [SerializeField] float moveSpeed;

    bool isMoveing;
    Vector2 input;

    Animator animator;

    //壁判定のlayer
    [SerializeField] LayerMask SolidObjestLayer;

    //草むら判定のlayer
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
            //キーボードの入力方向に動く
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //斜め移動
            if (input.x != 0)
            {
                input.y = 0;
            }

            if (input != Vector2.zero)
            {

                //コルーチンを使って徐々に目的地に近づける
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

      
    //コルーチンを使って徐々に目的地に近づける
    IEnumerator Move(Vector3 targetPos)
    {

        //移動中は受け付けたくない

        isMoveing = true;

        //targetPosと左があるなら繰り返す
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            //transformに近づける
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

    //targetPosに移動可能かを調べる
    bool IsWalkable(Vector2 targetPos)
    {
        // tagetPosに半径0.2fの円のRayを飛ばして、ぶつかったらなかったらfalse
        //その否定だから"!"
        return Physics2D.OverlapCircle(targetPos, 0.2f, SolidObjestLayer) == false;

        //自分の場所から円のRayを飛ばして、草むらLayerに当たったら、ランダムエンカウント
    }
        void CheckForEncounters()
        {
            if (Physics2D.OverlapCircle(transform.position, 0.2f, longGrassLayer))
            {
                //ランダムエンカウント
                if (Random.Range(0, 100) < 10)
                {

                    //Random.Range(0,100):0~99までのどれかの数字が出る
                    //10より小さい数字は0~9までの10個
                    //10以上の数字は10~99までの90子
                    Debug.Log("モンスターに遭遇");
                }

            }
        }
    }
