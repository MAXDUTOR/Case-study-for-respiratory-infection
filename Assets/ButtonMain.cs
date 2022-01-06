using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMain : EventScript
{
    public double ChoiceTime;
    public GameObject button;
    protected Vector3 ScaleChange;
    protected float ColorChange;
    protected Color CurrentColor;
    protected Image Image;
    protected bool IsPress = false;
    private EventScript Event;
    private Animator animator;
    private Animator ChoiceAnimator;
    public bool RightAnwser;

    // Start is called before the first frame update
    void Start()
    {
        Image = button.GetComponent<Image>();
        ScaleChange = new Vector3(0.01f, 0.01f);
        Event = GameObject.Find("Event 01").GetComponent<EventScript>();
        animator = GameObject.Find("Event 01").GetComponent<Animator>();
        ChoiceAnimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(CurrentColor);
    }

    public IEnumerator ChoicePlayTime()
    {
        yield return new WaitForSeconds((float)ChoiceTime);
        Debug.Log("Show");
        ChoiceAnimator.SetTrigger("Show");
        animator.SetTrigger("Show");

        for (int i = 0; i < Event.choiceanimator.Count; i++)
        {
            Event.choiceanimator[i].SetBool("Show", true);
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
        timeObj.videoTime.GetTime();
        Event.Play();
        RemoveButton();
        animator.SetBool("Show", false);


        for (int i = 0; i < Event.choiceanimator.Count; i++) {
            Event.choiceanimator[i].SetTrigger("Choosed");
            Event.choiceanimator[i].SetBool("Show",false);
                }

        animator.SetBool("First Time Play", false);
        StartCoroutine(ChoicePlayTime());
    }

    public void RemoveButton()
    {
        if (RightAnwser != true)
        {
            ChoiceAnimator.SetTrigger("Choosed");
        }
        else
            ChoiceAnimator.SetBool("Show", false);

    }
}