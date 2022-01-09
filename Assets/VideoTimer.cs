using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoTimer : MonoBehaviour
{
    private VideoPlayer Player;
    public GameObject startEvent;
    public Animator EventAnimator;


    void Start()
    {
        //Player = GameObject.Find("Demo-01-00.19.19.12").GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator DelayThanPause()
    {
        yield return new WaitForSeconds(0.44f);
        EventAnimator.SetFloat("TimeStart", (float)Player.time);
    }

    public double Time { get { return Player.time; } }
}
