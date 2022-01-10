using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMain : MonoBehaviour
{
    
    public double ChoiceTime;
    public bool replay;
    protected Vector3 ScaleChange;
    protected bool IsPress = false;
    public List<Animator> choiceAnimator;
    private Animator currentAnimator;
    public bool RightAnwser;
    protected bool IsReChoice = false;
    public Animator uIAnimator;
    public GameObject currentEvent;
    public GameObject nextEvent;

    void Start ()
    {
        currentAnimator = GetComponent<Animator>();
        ScaleChange = new Vector3(0.01f, 0.01f);
    }

    void Update()
    {
    }

    public IEnumerator ChoicePlayTime(int index)
    {
        //if you have choosed wrong answer or 

        yield return new WaitForSeconds((float)ChoiceTime);

        EventScript.instance.playerList[index].Pause();
            currentAnimator.SetBool("Show", true);
            uIAnimator.SetTrigger("Show UI");

            for (int i = 0; i < choiceAnimator.Count; i++)
            {
                choiceAnimator[i].SetBool("Show", true);
            }

    }

    public IEnumerator MouseInAnimation()
    {
        for (int i = 0; i < 15; i++)
        {
            gameObject.transform.localScale += ScaleChange;
            yield return null;
        }

    }
    public IEnumerator MouseOutAnimation()
    {
        for (int i = 0; i < 15; i++)
        {
            gameObject.transform.localScale -= ScaleChange;
            yield return null;
        }
    }
    public void MouseIn()
    {
        StartCoroutine(MouseInAnimation());
    }

    public void MouseOut()
    {
        StartCoroutine(MouseOutAnimation());
    }

    public void MouseClick(int index)
    {
        EventScript.instance.playerList[index].time = timeObj.videoTime.GetTime();
        EventScript.instance.playerList[index].Play();
        RemoveButton();
        uIAnimator.SetTrigger("Hide UI");
        currentAnimator.SetBool("Choosed", true);

        if(RightAnwser != false)
        {
            nextEvent.SetActive(true);
            currentEvent.SetActive(false);
        }
        else
        {
            for (int i = 0; i < choiceAnimator.Count; i++)
            {
                choiceAnimator[i].SetBool("Show", false);
            }
            StartCoroutine(ChoicePlayTime(index));
        }
            AllChoosedCheck();
    }

    public void RemoveButton()
    {
        if (RightAnwser != true)
        {
            currentAnimator.SetBool("Choosed", true);
        }
        else
        {
            currentAnimator.SetBool("Show", false);
        }

    }

    public void AllChoosedCheck()
    {
        bool allChoosed = true;
        for (int i = 0; i < choiceAnimator.Count; i++)
        {
            if (!choiceAnimator[i].GetBool("Choosed"))
            {
                allChoosed = false;
                break;
            }
        }

        if (allChoosed)
        {
            nextEvent.SetActive(true) ;
            gameObject.SetActive(false);
            }
        }
               
    }

    
