using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMain : MonoBehaviour
{
    public double ChoiceTime;
    public GameObject button;
    protected Vector3 ScaleChange;
    protected float ColorChange;
    protected Color CurrentColor;
    protected Image Image;
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
        Image = button.GetComponent<Image>();
        currentAnimator = GetComponent<Animator>();
        ScaleChange = new Vector3(0.01f, 0.01f);
        
    }

    void Update()
    {
    }

    public IEnumerator ChoicePlayTime()
    {
        yield return new WaitForSeconds((float)ChoiceTime);
        EventScript.instance.player.Pause();
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
            button.transform.localScale += ScaleChange;
            yield return null;
        }

    }
    public IEnumerator MouseOutAnimation()
    {
        for (int i = 0; i < 15; i++)
        {
            button.transform.localScale -= ScaleChange;
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

    public void MouseClick(VideoTime_obj timeObj)
    {
        EventScript.instance.player.time = timeObj.videoTime.GetTime();
        EventScript.instance.player.Play();
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
            StartCoroutine(ChoicePlayTime());
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
            if (choiceAnimator[i].GetBool("Choosed"))
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
        else
        {

        }
        }
               
    }

    
