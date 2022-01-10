using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class EventScript : MonoBehaviour
{
    public static EventScript instance;
    public List<VideoPlayer> playerList;
    public List<Animator> eventAnimator;
    public Animator answerAnimator;
    public List<GameObject> events;

    void Start()
    {
        //playerList[0].playOnAwake = true;
    }

    void Update()
    {
        Debug.Log(playerList[1].time);


        //Skip to Qustion 1
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            playerList[1].time = new VideoTime(0, 0, 0).GetTime();
        }

    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void PlayAtTime(double time, int i)
    {
        playerList[i].time = time;
        playerList[i].Play();
    }

    public void ShowCorrectImage()
    {
        Debug.Log("Right");
        answerAnimator.SetTrigger("Right");
    }

    public void ShowWrongImage()
    {
        Debug.Log("Wrong");
        answerAnimator.SetTrigger("Wrong");
    }

    public void Exit()
    {
        Application.Quit();
    }
}