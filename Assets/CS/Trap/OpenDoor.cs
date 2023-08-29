using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Machine
{
    protected override void OpenMachine()
    {
        GetComponentInParent<DoorKey>().isOpen = true;//满足条件
        GetComponent<Renderer>().enabled = true;//跟门上的颜色对应才能开门 
    }
}

