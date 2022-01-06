using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class VideoTime
{
    public int min;
    public int sec;
    public int frame;

    public VideoTime()
    {
        min = 0;
        sec = 0;
        frame = 0;
    }
    public VideoTime(int min, int sec, int frame)
    {
        this.min = min;
        this.sec = sec;
        this.frame = frame;
    }

    public double GetTime()
    {
        double ReceiveTime = ((double)min * 60) + (double)sec + ((double)frame / 25);
        return ReceiveTime;
    }
}
