using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class EventScript : MonoBehaviour
{
    public static EventScript instance;
    private VideoTimer Timer;
    public List<Animator> uIAnimator;
    public List<GameObject> gameObjects;
    public List<float> delaysTime;
    public VideoPlayer player { get; private set; }


     protected void Start()
    {
        player = GameObject.Find("Demo-01-00.19.19.12").GetComponent<VideoPlayer>();
        Timer = GameObject.Find("Video Player").GetComponent<VideoTimer>();
    }
    void Update()
    {
        //Skip to Question 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            VideoTime time_15s = new VideoTime(0, 17, 0);
            player.time = time_15s.GetTime();
            uIAnimator[0].SetBool("First Time Play", true);
        }

        //Skip to Question 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].SetActive(false);
            }

            VideoTime section2 = new VideoTime(0, 24, 21);
           player.time = section2.GetTime();

            gameObjects[1].SetActive(true);
            uIAnimator[1].SetBool("Show", true);
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
    
    public IEnumerator Delays(int index)
    {
        yield return new WaitForSeconds(delaysTime[index]);

    }

}