using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ToolType
{
    BallRed, BallGreen, BallYellow, BallWhite, BallBlack,
    BallStone, PicYZ, PicYX, PicYC, PicZF,
    Brush, Bomb, Torch, HealthBox, Hand
}
public class Main : MonoBehaviour
{
    public static Transform player;
    public static Transform bag;
    public static Transform handPoint;
    public Transform canveas;
    public static ToolType toolType { set; get; }
    //public GameObject doorPic;
    //static GameObject _doorPic;
    void Start()
    {
        toolType = ToolType.Hand;
        bag = canveas.Find("Panel").Find("Bag");
        player = GameObject.Find("Player").transform;
        handPoint = player.GetComponent<Player>().handPoint;
        //_doorPic = doorPic;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Application.Quit();
        }
    }
    //public static void OpenDoorPic()
    //{
    //    _doorPic.GetComponent<DoorKey>().isOpen = true;
    //}

    public static bool TestDistance(Vector3 pos, float distance)
    {
        return Vector3.Distance(player.position, pos) < distance;
    }

    public static bool IsHand()
    {
        return toolType == ToolType.Hand;
    }

    public static void AllToolVisible(bool b)
    {
        foreach (Transform item in handPoint)
        {
            item.gameObject.SetActive(b);
        }
    }

    public void Hand()
    {
        toolType = ToolType.Hand;
        AllToolVisible(false);
    }

    public static GameObject UseTool(string toolName, GameObject obj)
    {
        BtnTools btnTools = bag.Find("Btn" + toolName).GetComponent<BtnTools>();
        if (btnTools.GetToolNun() > 0)
        {
            GameObject go = null;
            if (obj)
            {
                go = Instantiate(obj);
            }
            btnTools.AddToolNum(-1);
            if (btnTools.GetToolNun() == 0)
            {
                Destroy(handPoint.Find(toolName).gameObject);
                Destroy(btnTools.gameObject, 0.1f);
                toolType = ToolType.Hand;
            }
            return go;
        }
        else
        {
            return null;
        }
    }
   
}
