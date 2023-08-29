using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button btnStart;


    delegate void Fun();//����ί��֮�����⣺���ܴ��������Ĺ���ȥ���ɿ�Ϊa��b���ƺ��޹���
    Fun fun;
    void Start()
    {
        btnStart.onClick.AddListener(GoScene);
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
