using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tools : MonoBehaviour
{
    GameObject btnTool;
    void Start()
    {
        btnTool=Resources.Load<GameObject>("Prefab/Btn" + name);
    }

    private void OnMouseDown()
    {
        if (!Main.TestDistance(transform.position, 3))
        {
            print("Too far");
            return;
        }
        if (!Main.IsHand())
        {
            print("hand non empty");
            return;
        }
        if (Main.handPoint.Find(name))
        {
            BtnTools btn = Main.bag.Find(btnTool.name).GetComponent<BtnTools>();
            btn.AddToolNum(btn.toolGetNum);
            Destroy(gameObject);
        }
        else
        {
            Pickup();
        }
    }

    void Pickup()
    {
        transform.position = Main.handPoint.position;
        transform.SetParent(Main.handPoint, true);
        transform.localEulerAngles = Vector3.zero;
        gameObject.SetActive(false);
        GetComponent<Collider>().enabled = false;
        enabled = false;

        GameObject btn = Instantiate(btnTool, Main.bag);
        btn.name = btnTool.name;
        btn.GetComponent<BtnTools>().Init();
    }

    public void PickPic()
    {
        Pickup();
    }
}
