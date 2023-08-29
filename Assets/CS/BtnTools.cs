using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnTools : MonoBehaviour
{
    public int toolGetNum;
    Text text;
    int toolNum;

    //void Awake()
    //{
    //    Init();
    //}

    public void Init()
    {
        text = GetComponentInChildren<Text>();
        toolNum = toolGetNum;
        text.text = toolNum.ToString();
        GetComponent<Button>().onClick.AddListener(BtnClick);
    }

    void BtnClick()
    {
        string toolName = name.Remove(0, 3);
        ShowTool(toolName, true); 
        Main.toolType = (ToolType)Enum.Parse(typeof(ToolType), toolName);
    }

    void ShowTool(string n, bool b)
    {
        Main.AllToolVisible(false);
        GameObject tool = Main.handPoint.Find(n).gameObject;
        tool.SetActive(b);
    }

    public int GetToolNun()
    {
        return toolNum;
    }

    public void AddToolNum(int num)
    {
        toolNum += num;
        text.text = toolNum.ToString();
    }
}
