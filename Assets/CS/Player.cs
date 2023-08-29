using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Transform eye;
    float speedMove = 4;
    float speedH = 3f;
    float speedAngle = 120;
    float downSpeed;//重力
    CharacterController cc;

    float minAngle = -40;
    float maxAngle = 70;
    float yRote;

    float hp = 100;
    public Slider hpline;
    public Slider powerline;

    public Transform handPoint;
    GameObject bombPrefab;

    public Image la;
    public AudioClip soundClip;//声效
    void Awake()
    {
        eye = transform.Find("Eye");
        handPoint = eye.Find("胳膊").Find("HandPoint");
        cc = GetComponent<CharacterController>();
        bombPrefab = Resources.Load<GameObject>("Prefab/Bomb");
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        PowerLineCtrl();
        UseHandTool();
    }

    private void Move()
    {
        float f=Mathf.Clamp(powerline.value/50,0.05f,1);

        if (powerline.value < 1)
        {
            return;
        }
        float y= Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        cc.Move(transform.forward * Time.deltaTime * y * speedMove*f);
        cc.Move(transform.right * Time.deltaTime * x * speedH);//此处原为speedH，嫌太慢了将其换掉了

        downSpeed = 10f;//给重力赋值
        cc.Move(transform.up * downSpeed * Time.deltaTime*-1);//每秒给他一个向下的值 这个值就是重力

        if (Input.GetMouseButton(1))
        {
            float xRote = Input.GetAxis("Mouse X");//x 左右移动
            transform.Rotate(transform.up * speedAngle * xRote * Time.deltaTime*6f);

            yRote -= Input.GetAxis("Mouse Y");
            yRote = Mathf.Clamp(yRote, minAngle, maxAngle);
            eye.localEulerAngles = new Vector3(yRote, 0, 0);
        }
        
    }

    void PowerLineCtrl()
    {
        if (Input.anyKey)
        {
            SliderNum(powerline, -0.03f);
        }
        else
        {
            SliderNum(powerline, 0.3f);
        }
    }

    int i = 1;
    public void SliderNum(Slider slider, float f)
    {
        slider.value += f;
        if (slider.name == "SliderHP" && slider.value == 0)
        {
            speedMove = 0;
            speedH = 0;
            speedAngle = 0;
            slider.value = -1;
            if (i == 1)
            {
                AudioSource.PlayClipAtPoint(soundClip, transform.position);//音乐
                i++;
            }
            la.gameObject.SetActive(true);
            
            //return;
            //SceneManager.LoadScene("chongxin");
        }
    }

    void UseHandTool()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            switch (Main.toolType)
            {
                case ToolType.Bomb:
                    ThrowBomb();
                    break;
                case ToolType.HealthBox:
                    SliderNum(hpline, 50);
                    Main.UseTool("HealthBox", null);
                    break;
            }
        }
    }

    private void ThrowBomb()
    {
        GameObject go = Main.UseTool("Bomb", bombPrefab);
        go.transform.position = Main.handPoint.position;
        go.GetComponent<Rigidbody>().AddForce(eye.transform.forward * 600);
    }
    public void GoScene()
    {
        SceneManager.LoadScene("Game");
    }
}
