using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip[] au;//��Ƶ���
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
        if (Input.GetKeyDown(KeyCode.Space))//��������˿ո��
        {
            if (i==1)//���ڲ��ű�������ʱ
            {
                this.GetComponent<AudioSource>().Stop();
                i--;
            }
            else//δ���ű�������ʱ
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
