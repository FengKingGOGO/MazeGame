using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public float rotSpeed = 20f;//Ðý×ªËÙ¶È
    
    void Start()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            SceneManager.LoadScene("chongxin");
        }
    }
}
