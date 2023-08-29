using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip[] au;//音频组件
    private int count;
    void Start()
    {
        
    }
    private int i = 1;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayAudio();
        }
        if (Input.GetKeyDown(KeyCode.Space))//如果按下了空格键
        {
            if (i==1)//正在播放背景音乐时
            {
                this.GetComponent<AudioSource>().Stop();
                i--;
            }
            else//未播放背景音乐时
            {
                this.GetComponent<AudioSource>().Play();
                i++;
            }
        }
    }
    public void ChangetimelinePlay()
    {
        this.GetComponent<AudioSource>().clip = au[0];
        this.GetComponent<AudioSource>().Play();
        count = 0;
    }
    public void PlayAudio()
    {
        count++;
        this.GetComponent<AudioSource>().clip = au[count];
        this.GetComponent<AudioSource>().Play();
        if (count == 4)
        { count = 0; }
    }
}
