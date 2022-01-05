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
    private Animator animator;

    // Start is called before the first frame update

    void Start()
    {
        animator = GameObject.Find("Event 01").GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(CurrentVideo.time);
        //Skip to Question 1
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            SeekTime(Convert(0, 15, 0));
            animator.SetTrigger("Show");
            animator.SetBool("First Time Play", true);

        }
    }

    public double Convert(int Min,int Sec,int Frame)
    {
        double Time = ((double)Min * 60) + (double)Sec + ((double)Frame / 25);
        return Time;
    }

    public void SeekTime(double ReceiveTime)
    {
        CurrentVideo.time = ReceiveTime;
    }

}
