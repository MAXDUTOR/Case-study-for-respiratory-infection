using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class EventScript : MonoBehaviour
{
    public static EventScript instance;
    private VideoTimer timer;
    public List<VideoPlayer> playerList;
    public List<Animator> eventAnimator;
    public Animator answerAnimator;
    public List<GameObject> events;
    public List<float> delaysTime;
    public GameObject videoPlayer;

    void Start()
    {
        playerList[0].playOnAwake = true;
    }

    public void ChangeVideo(UnityEngine.Video.VideoPlayer thisPlayer)
    {
        videoPlayer.SetActive(true);
        playerList[0].Play();
        StartEvent();
    }
    void Update()
    {
        //Skip to Qustion 1
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            
        }

        //Skip to Question 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            VideoTime section2 = new VideoTime(0, 24, 21);
            playerList[2].time = section2.GetTime();

            events[1].SetActive(true);
        }

        //Skip to Question 3
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            VideoTime question3 = new VideoTime(0,33,11);
            playerList[3].time = question3.GetTime();
        }

        //Skip to Qustion 4
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            VideoTime question4 = new VideoTime(1, 16, 06);
            playerList[4].time = question4.GetTime();
            StartCoroutine(DelaysThenPause2(2.84f,4));
        }
        //Skip to Qustion 5
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            VideoTime question5 = new VideoTime(4, 27, 03);
            playerList[5].time=question5.GetTime();
        }
    }
    
    public void StartEvent()
    {
        events[0].SetActive(true);
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

    public IEnumerator DelaysThenPause(double time,double playTime, Animator animator, string triggerName,int i)
    {
        yield return new WaitForSeconds((float)time);
        animator.SetTrigger(triggerName);
        playerList[i].Pause();
    }
    public IEnumerator DelaysThenPause0(double time,Animator animator,string triggerName, int i)
    {
        yield return new WaitForSeconds((float)time);
        animator.SetTrigger(triggerName);
        playerList[i].Pause();
    }

    public IEnumerator DelaysThenPause1(double time, int i)
    {
        yield return new WaitForSeconds((float)time);
        eventAnimator[2].SetTrigger("Show UI");
        playerList[i].Pause();
    }
    public IEnumerator DelaysThenPause2(double time, int i)
    {
        yield return new WaitForSeconds((float)time);
        eventAnimator[3].SetTrigger("Show UI");

        playerList[i].Pause();
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