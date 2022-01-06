using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSeek : MonoBehaviour
{
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
        //Skip to Question 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            VideoTime time_15s = new VideoTime(0, 17, 0);
            CurrentVideo.time = time_15s.GetTime();

            animator.SetBool("First Time Play", true);
        }
        
    }
}


