using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    protected Vector3 targetPos;
    protected Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + transform.forward * 2.5f;
    }

    void Update()
    {
        OpenDoor();
    }

    protected void OpenDoor()
    {
        if (!Main.TestDistance(startPos, 3))// ”œﬂºÏ≤‚
        {
            transform.position = Vector3.Lerp(transform.position, startPos, 0.08f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, 0.08f);
        }
    }
}
