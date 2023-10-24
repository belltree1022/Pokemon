using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hpbar : MonoBehaviour
{
    //HP�̑�����ǉ�
    [SerializeField] GameObject health; 


    public void SetHP(float hp)
    {
        health.transform.localScale = new Vector3(hp, 1, 1);
    }

    //コルーチンを使用してなめらかな動きでダメージが減る
   public IEnumerator SetHPSmooth(float newHP)
    {
        float currentHP=health.transform.localScale.x;//現在のHP
        float changeAmount=currentHP-newHP;//変化量

        while (currentHP-newHP>Mathf.Epsilon)//現在のHPから新しくなったHPが、わずかでもあったら（Mathf.Epsilon）その処理を繰り返す  

        {
            currentHP-=changeAmount*Time.deltaTime;//1秒かけてchangeamount分減らす
             health.transform.localScale = new Vector3(currentHP, 1, 1);//減らした分の描画
            yield return null;//遅らせながら繰り返す

        }



        //最終的にはこれ
        health.transform.localScale = new Vector3(newHP, 1, 1);
    }
}
