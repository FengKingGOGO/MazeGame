using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame :Machine
{
    protected Vector3 doorStartPos;
    Vector3 startPos = new Vector3(0, -0.055f, -0.003f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected override void OpenMachine()
    {
        if (transform.childCount == 0)
        {
            if (Main.toolType != ToolType.Hand)
            {
                PickPic();
            }
        }
        else
        {
            if (Main.toolType == ToolType.Hand)
            {
                GetComponentInChildren<Tools>().PickPic();
            }
        }
        if (TestAllPic())
        {
            SetAllPic();
        }
    }

    private void PickPic()
    {
        string str = Main.toolType.ToString();
        Transform t = Main.handPoint.Find(str);
        t.parent = transform;
        t.localEulerAngles = Vector3.zero;
        t.localPosition = startPos;
        Transform btnT = Main.bag.Find("Btn" + str);
        Main.toolType = ToolType.Hand;
        Destroy(btnT.gameObject);
    }

    protected bool TestAllPic()
    {
        foreach (Transform t in transform.parent)
        {
            if (t.childCount == 0)
            {
                return false;
            }
            if (t.name != "K" + t.GetChild(0).name)
            {
                return false;
            }
        }
        return true;
    }

    protected void SetAllPic()
    {
        foreach (Transform t in transform.parent)
        {
            t.GetComponent<Frame>().isOpen = true;
        }
        //Main.OpenDoorPic();
        beGetObj.GetComponent<DoorKey>().isOpen = true;
    }
}
