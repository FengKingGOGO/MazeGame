using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hahaha : MonoBehaviour
{
    public Button btnStart;
    public AudioClip soundClip;//��Ч

    delegate void Fun();//����ί��֮�����⣺���ܴ��������Ĺ���ȥ���ɿ�Ϊa��b���ƺ��޹���
    Fun fun;
    void Start()
    {
        btnStart.onClick.AddListener(GoScene);
        AudioSource.PlayClipAtPoint(soundClip, transform.position);
    }

    void GoScene()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
