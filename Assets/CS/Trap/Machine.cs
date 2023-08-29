using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    protected bool isOpen;
    public ToolType[] states;
    public GameObject beGetObj;


    private void OnMouseDown()
    {
        if (!Main.TestDistance(transform.position, 3))
        {
            print("Too far");
            return;
        }
        if (isOpen)
        {
            print("Machine is open");
            return;
        }
        if (!TestToolState())
        {
            print("tool wrong");
            return;
        }
        OpenMachine();
    }
    protected virtual void OpenMachine()//虚函数,父类定义，子类可重写
    {
        string toolName = Main.toolType.ToString();
        GameObject toolObj = Main.handPoint.Find(toolName).gameObject;//找道具
        GameObject go = Main.UseTool(toolName, toolObj);//参数传送
        go.transform.position = transform.position;
        go.transform.rotation = transform.rotation;
        isOpen = true;
        if (TestFinish())
        {
            beGetObj.GetComponent<Collider>().enabled = true;
        }
    }

    protected bool TestFinish()
    {
        foreach (Transform item in transform.parent)
        {
            if (!item.GetComponent<Machine>().isOpen)
            {
                return false;
            }
        }
        return true;
    }
    protected bool TestToolState()
    {
        for (int i = 0; i < states.Length; i++)
        {
            if (states[i]==Main.toolType)
            {
                return true;
            }
        }
        return false;
    }
}
