using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBox : Machine
{
    protected override void OpenMachine()
    {
        Material mat = Main.handPoint.Find("Brush").GetComponentInChildren<Renderer>().materials[2];//��ȡbursh�������ϵ���ɫ���
        mat.color = GetComponent<Renderer>().material.color;//����ɫ�����ɫ
    }
}
