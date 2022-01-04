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

    // Start is called before the first frame update

    [SerializeField]
    public List<VideoTime> timeIndex = new List<VideoTime>();

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

    public void RunChoice(int index)
    {
        Seek.SeekTime(this.Convert(timeIndex[0].Min, timeIndex[0].Sec, timeIndex[0].Frame));
    }

    public double Convert(int Min,int Sec,int Frame)
    {
        double Time = ((Min * 60) + Sec + (Frame / 100));
        return Time;
    }

    public void Pause()
    {
            Player.time = 18.11;
            Player.Pause();
        }
    }


