using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button btnStart;


    delegate void Fun();//关于委托之类的理解：不能带着其他的工牌去，可看为a，b工牌和无工牌
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
