using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class EventScript : MonoBehaviour
{
    private VideoTimer Timer;
    private VideoPlayer Player;
    public List<Animator> choiceanimator;

    protected bool IsReChoice = false;

    void Start()
    {
        Player = GameObject.Find("Demo-01-00.19.19.12").GetComponent<VideoPlayer>();
        Timer = GameObject.Find("Video Player").GetComponent<VideoTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        if (IsReChoice == false)
        {
            Debug.Log("Pause");
            Player.Pause();
            IsReChoice = true;

            for (int i = 0; i < choiceanimator.Count; i++)
            {
                choiceanimator[i].SetBool("Show",true);
                //choiceanimator[i].SetBool("Show",false);
            }
            
        }

        
    }

    public void Play()
    {
        Player.Play();
    }



}