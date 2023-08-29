using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bow : MonoBehaviour
{
    public GameObject arrowPrefab;
    Transform point;
    Transform canvas;
    Slider slider;

    bool isDeath;
    float time;
    float shootTime = 1;
    float attDis = 12;
    float hp = 100;
    private void Start()
    {
        canvas = transform.Find("Canvas");
        slider = canvas.GetComponentInChildren<Slider>();
        slider.maxValue = hp;
        slider.value = hp;
        point = transform.Find("Point");
    }
    private void Update()
    {
        if (isDeath)
        {
            return;
        }
        canvas.LookAt(Main.player);
        slider.value += 0.1f;
        TestPlayer();
    }

    private void TestPlayer()
    {
        if (!Main.TestDistance(transform.position, attDis))
        {
            return;
        }
        Vector3 dir = Main.player.position - transform.position;
        Ray ray = new Ray(transform.position, dir);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, attDis))
        {
            if (hit.collider.tag == "Player")
            {
                Shoot(dir);
            }
        }
    }

    private void Shoot(Vector3 dir)
    {
        Quaternion euler = Quaternion.LookRotation(-dir);//向量转角度
        transform.rotation = Quaternion.Lerp(transform.rotation, euler, 0.04f);
        if (Vector3.Angle(transform.forward,-dir)>5)
        {
            return;
        }
        if (Time.time - time < shootTime)
        {
            return;
        }
        time = Time.time;
        GameObject arrow = Instantiate(arrowPrefab, point.position, point.rotation);
        arrow.GetComponent<Rigidbody>().AddForce(-arrow.transform.forward*1000);
        Destroy(arrow, 5);
    }

    public void BowHurt(float f)
    {
        if (isDeath)
        {
            return;
        }
        slider.value -= f;
        if (slider.value == 0)
        {
            isDeath = true;
            Destroy(canvas.gameObject);
        }
    }
}
