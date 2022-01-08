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
    private Animator currentchoiceanimator;
    public bool RightAnwser;
    protected bool IsReChoice = false;
    public List<Animator> choiceAnimator;
    public Animator uIAnimator;
    public GameObject currentEvent;
    public GameObject nextEvent;

    void Start ()
    {
        Image = button.GetComponent<Image>();
        ScaleChange = new Vector3(0.01f, 0.01f);
        currentchoiceanimator = GetComponent<Animator>();
        
    }

    void Update()
    {
    }

    public IEnumerator ChoicePlayTime()
    {
        yield return new WaitForSeconds((float)ChoiceTime);
        EventScript.instance.player.Pause();

        if (RightAnwser == false)
        {
            // if answer is wrong
            currentchoiceanimator.SetBool("Show", true);
            uIAnimator.SetTrigger("Show");

            for (int i = 0; i < choiceAnimator.Count; i++)
            {
                choiceAnimator[i].SetBool("Show", true);
            }
        }
        else
        {
            //if right
            currentEvent.SetActive(false);
            nextEvent.SetActive(true);
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
        uIAnimator.SetBool("Show", false);
        currentchoiceanimator.SetBool("Choosed", true);

        for (int i = 0; i < choiceAnimator.Count; i++) {
            choiceAnimator[i].SetBool("Show",false);
                }

        uIAnimator.SetBool("First Time Play", false);
        StartCoroutine(ChoicePlayTime());
    }

    public void RemoveButton()
    {
        if (RightAnwser != true)
        {
            currentchoiceanimator.SetBool("Choosed", true);
        }
        else
        {
            currentchoiceanimator.SetBool("Show", false);
        }

    }

    public void SetTrigger(string name,bool value)
    {
        for (int i = 0; i < choiceAnimator.Count; i++){
            choiceAnimator[i].SetBool(name, true);
        }
    }
    
}