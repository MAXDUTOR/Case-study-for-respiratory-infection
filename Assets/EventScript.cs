using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class EventScript : MonoBehaviour
{
    private float Converter;
    private VideoSeek Seek;
    private VideoTimer Timer;
    private VideoPlayer Player;
    private VideoTime timeIndex;
    protected bool IsReChoice = false;

    void Start()
    {
        Player = GameObject.Find("Demo-01-00.19.19.12").GetComponent<VideoPlayer>();
        Seek = GameObject.Find("Video Player").GetComponent<VideoSeek>();
        Timer = GameObject.Find("Video Player").GetComponent<VideoTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RunChoice(VideoTime time)
    {
        Seek.SeekTime(this.Convert(time.Min, time.Sec, time.Frame));
    }

    public double Convert(int Min,int Sec,int Frame)
    {
        double Time = ((Min * 60) + Sec + ((Frame / 25)*100));
        return Time;
    }

    public void Pause()
    {
        if (IsReChoice == false)
        {
            Debug.Log("Pause");
            Player.Pause();
            IsReChoice = true;
        }
    }

    public void GetTime()
    {
    }

    public void Play()
    {
        Player.Play();
    }
}