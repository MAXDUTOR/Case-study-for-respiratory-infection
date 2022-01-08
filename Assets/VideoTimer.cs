using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoTimer : MonoBehaviour
{
    private VideoPlayer Player;
    public Animator EventAnimator;
    private EventScript EventScript;

    private bool IsPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        EventScript = GameObject.Find("Event 01").GetComponent<EventScript>();
        Player = GameObject.Find("Demo-01-00.19.19.12").GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventAnimator != null && !IsPlaying)
        {
            if((float)Player.time > 18f)
            {
                EventAnimator.SetFloat("TimeStart", (float)Player.time);
                IsPlaying = true;
            }
        }
    }

    public double Time { get { return Player.time; } }
}
