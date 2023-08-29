using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject bombEffect;//爆炸特效预制体
    float attDis = 10;//伤害判定距离
    float attMax = 100;//最大伤害
    void Start()
    {
        Invoke("BombEffect",3);//延迟
        Destroy(gameObject, 3);
    }

    void BombEffect()
    {
        GameObject effect = Instantiate(bombEffect, transform.position, transform.rotation);
        Collider[] bowColl = Physics.OverlapSphere(transform.position, attDis, LayerMask.GetMask("Bow"));
        foreach (Collider c in bowColl)
        {
            c.GetComponent<Bow>().BowHurt(Hurt(c.gameObject));
        }
        Destroy(effect, 3);
    }

    float Hurt(GameObject go)
    {
        float distance = Vector3.Distance(transform.position, go.transform.position);
        if (distance >= attDis)
        {
            return 0;
        }
        else
        {
            return attMax - distance * attMax / attDis;
        }
    }
}
