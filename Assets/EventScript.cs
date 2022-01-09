using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class EventScript : MonoBehaviour
{
    public static EventScript instance;
    private VideoTimer timer;
    public List<Animator> eventAnimator;
    public Animator answerAnimator;
    public List<GameObject> events;
    public List<float> delaysTime;
    public GameObject videoPlayer;
    public VideoPlayer player;
    public VideoPlayer introPlayer;


    void Start()
    {
        //timer = GameObject.Find("Demo-01-00.19.19.12").GetComponent<VideoTimer>();
        introPlayer.loopPointReached += ChangeVideo;
    }
    public void ChangeVideo(UnityEngine.Video.VideoPlayer thisPlayer)
    {
        videoPlayer.SetActive(true);
        player.Play();
        StartEvent();
    }
    void Update()
    {
        //Skip to Qustion 1
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            VideoTime videoTime1 = new VideoTime(1,35,0);
            introPlayer.time = videoTime1.GetTime();
        }

        //Skip to Question 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            VideoTime section2 = new VideoTime(0, 24, 21);
           player.time = section2.GetTime();

            events[1].SetActive(true);
        }

        //Skip to Question 3
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            VideoTime question3 = new VideoTime(0,33,11);
            player.time = question3.GetTime();
        }

        //Skip to Qustion 4
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            VideoTime question4 = new VideoTime(1, 16, 06);
            player.time = question4.GetTime();
            StartCoroutine(DelaysThenPause2(2.84f));
        }
        //Skip to Qustion 5
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            VideoTime question5 = new VideoTime(4, 27, 03);
            player.time=question5.GetTime();
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

    public IEnumerator DelaysThenPause(double time,double playTime, Animator animator, string triggerName)
    {
        yield return new WaitForSeconds((float)time);
        animator.SetTrigger(triggerName);
        player.Pause();
    }
    public IEnumerator DelaysThenPause0(double time,Animator animator,string triggerName)
    {
        yield return new WaitForSeconds((float)time);
        animator.SetTrigger(triggerName);
        player.Pause();
    }

    public IEnumerator DelaysThenPause1(double time)
    {
        yield return new WaitForSeconds((float)time);
        eventAnimator[2].SetTrigger("Show UI");
        player.Pause();
    }
    public IEnumerator DelaysThenPause2(double time)
    {
        yield return new WaitForSeconds((float)time);
        eventAnimator[3].SetTrigger("Show UI");
        
        player.Pause();
    }

    public void PlayAtTime(double time)
    {
        player.time = time;
        player.Play();
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