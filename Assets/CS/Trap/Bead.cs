using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bead : Machine
{
    protected int line;
    protected int num;
    protected Vector3 startPos;
    protected Vector3 targetPos;

    public bool isClicked;

    void Start()
    {
        SetStartValue(-transform.forward * 0.2f);
    }

    protected void SetStartValue(Vector3 v3)
    {
        line = int.Parse(name[4].ToString());//获取列
        num = int.Parse(name[5].ToString());//行
        startPos = transform.position;
        targetPos = startPos + v3;
    }

    protected virtual void BeadClick()
    {
        if (!isClicked)
        {
            if (num == 0)
            {
                transform.position = targetPos;
                isClicked = !isClicked;
                //BeadGroup.AddBead(line, 1);
            }
            else
            {
                if (BeadGroup.beadAllDown[line, num - 1].GetComponent<Bead>().isClicked)
                {
                    transform.position = targetPos;
                    isClicked = !isClicked;
                    //BeadGroup.AddBead(line, 1);
                }
            }
        }
        else
        {
            if (num == 3)
            {
                transform.position = startPos;
                isClicked = !isClicked;
                //BeadGroup.AddBead(line, -1);
            }
            else
            {
                if (!BeadGroup.beadAllDown[line, num +1].GetComponent<Bead>().isClicked)
                {
                    transform.position = startPos;
                    isClicked = !isClicked;
                    //BeadGroup.AddBead(line, -1);
                }
            }
        }
        BeadGroup.TestOpenDoor();
    }

    protected override void OpenMachine()
    {
        if (Main.toolType == ToolType.Hand)
        {
            BeadClick();
        }
        if (Main.toolType == ToolType.Brush)
        {
            PaintColor();
        }
    }

    protected void PaintColor()
    {
        Material mat = GetComponent<Renderer>().material;
        mat.color= Main.handPoint.Find("Brush").GetComponentInChildren<Renderer>().materials[2].color;
        BeadGroup.TestOpenDoor();
    }
}
