using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBox : Machine
{
    protected override void OpenMachine()
    {
        Material mat = Main.handPoint.Find("Brush").GetComponentInChildren<Renderer>().materials[2];//获取bursh子物体上的颜色组件
        mat.color = GetComponent<Renderer>().material.color;//给颜色组件变色
    }
}
