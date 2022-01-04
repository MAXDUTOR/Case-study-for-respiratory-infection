using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSeek : MonoBehaviour
{
    private int Minuntes;
    private int Seconds;
    private int Frames;
    private float Converter;
    public VideoPlayer CurrentVideo;
    // Start is called before the first frame update

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Skip to Question 1
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            Convert(0, 15, 0);
        }
    }

    void Convert(int Min,int Sec,int Frame)
    {
        Converter = ((Min * 60) + Sec + (Frame / 100));
        CurrentVideo.time = Converter;

    }
    void SkipTime()
    {
        CurrentVideo.time = Converter;
    }

    public void SeekTime(double ReceiveTime)
    {
        CurrentVideo.time = ReceiveTime;
    }

}
