using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeadTop : Bead
{
    
    void Start()
    {
        SetStartValue(transform.forward * 0.1f);
    }

    protected override void BeadClick()
    {
        if (!isClicked)
        {
            transform.position = targetPos;
            //BeadGroup.AddBead(line, 5);
        }
        else
        {
            transform.position = startPos;
            //BeadGroup.AddBead(line, -5);
        }
        isClicked = !isClicked;
        BeadGroup.TestOpenDoor();
    }
}
