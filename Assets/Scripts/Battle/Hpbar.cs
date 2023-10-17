using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hpbar : MonoBehaviour
{
    //HP‚Ì‘Œ¸‚ğ•Ç‰æ
    [SerializeField] GameObject health; 


    public void SetHP(float hp)
    {
        health.transform.localScale = new Vector3(hp, 1, 1);
    }
}
