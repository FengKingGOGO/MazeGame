using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeadGroup : MonoBehaviour
{
    public static GameObject[,] beadAllDown = new GameObject[4,4];
    public static GameObject[] beadTop = new GameObject[4];
    public static int answer;
    static int[] answers = new int[4] {4,0,2,2 };
    static Color[] answers_Color = new Color[4] { Color.red, Color.green, new Color(1, 1, 0), Color.black };
    static bool[] answersTop = new bool[4] { true, true, false, true };
    static Color[] answersTop_Color = new Color[4] { Color.red, Color.green,  Color.white, Color.black };
    public GameObject door;
    static GameObject _door;
    void Start()
    {
        GetBead();
        _door = door;
    }
    void GetBead()
    {
        for (int i = 0; i< 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                beadAllDown[i,j] = transform.GetChild(i * 4 + j).gameObject;
            }
        }
        for (int i = 0; i < beadTop.Length; i++)
        {
            beadTop[i] = transform.GetChild(16 + i).gameObject;
        }
    }
    public static void AddBead(int line, int num)//第一种方法
    {
        answer += (int)Mathf.Pow(10, (3 - line)) * num;
        print(answer);
        if (answer == 9527)
        {
            print("right");
        }
    }
    static bool TestBeadOK()
    {
        for (int i = 0; i < answers.Length; i++)
        {
            if (answers[i] < 4)
            {
                if (beadAllDown[i, answers[i]].GetComponent<Bead>().isClicked)//和循环判断有异曲同工之妙
                {
                    return false;
                }
            }
            if (answers[i]!=0)
            {
                if (!beadAllDown[i, answers[i]-1].GetComponent<Bead>().isClicked)//个人感觉为双重保障
                {
                    return false;
                }
            }
        }
        return true;
    }
    static bool TestBeadOK2()//3
    {
        for (int k = 0; k < answers.Length; k++)
        {
            for (int i = 0; i < answers[k]; i++)
            {
                if (!beadAllDown[k, i].GetComponent<Bead>().isClicked)
                {
                    return false;
                }
                if (!TestBeadColor(beadAllDown[k, i], answers_Color[k]))
                {
                    return false;
                }
            }
            for (int i = answers[k]; i < 4; i++)
            {
                if (beadAllDown[k, i].GetComponent<Bead>().isClicked)
                {
                    return false;
                }
                if (!TestBeadColor(beadAllDown[k, i], Color.white))
                {
                    return false;
                }
            }
        }
        return true;
    }
    static bool TestBeadColor(GameObject bead, Color color)
    {
        if (bead.GetComponent<Renderer>().material.color == color)
        {
            return true;
        }
        return false;
    }

    static bool TestBeadTopOK()
    {
        for (int i = 0; i < answersTop.Length; i++)
        {
            if (beadTop[i].GetComponent<Bead>().isClicked != answersTop[i])
            {
                return false;
            }
            if (!TestBeadColor(beadTop[i], answersTop_Color[i]))
            {
                return false;
            }
        }
        return true;
    }
    public static void TestOpenDoor()
    {
        if (!TestBeadOK2())
        {
            return;
        }
        if (!TestBeadTopOK())
        {
            return;
        }
        _door.GetComponent<DoorKey>().isOpen=true;
    }
}
