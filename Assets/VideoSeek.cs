using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSeek : MonoBehaviour
{
    public int Minuntes;
    public int Seconds;
    public int Frames;
    private float Converter;
    public VideoPlayer CurrentVideo;
    // Start is called before the first frame update

    void Start()
    {
        Converter = ((Minuntes * 60) + Seconds + (Frames / 100));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CurrentVideo.time = Converter;
            Debug.Log(Converter);
        }
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
