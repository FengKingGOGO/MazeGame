using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : Machine
{
    public Transform otherLion;
    protected override void OpenMachine()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 45, 0);
        Test();
    }

    void Test()
    {
        if (SetDirection()&&otherLion.GetComponent<Lion>().SetDirection())
        {
            isOpen = true;
            otherLion.GetComponent<Lion>().isOpen = true;
            beGetObj.SetActive(false);
        }
    }

    public bool SetDirection()
    {
        Vector3 dir = otherLion.position - transform.position;
        if (Vector3.Angle(dir, transform.right) < 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
