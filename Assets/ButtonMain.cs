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
        yield return new WaitForSeconds(3.32f);
        Debug.Log("Show");
        ChoiceAnimator.SetTrigger("Show");
        animator.SetTrigger("Show");


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

    public void MouseClick(VideoTime time)
    {
        Event.RunChoice(time);
        Event.Play();
        animator.SetTrigger("Hide");
        animator.SetBool("First Time Play", false);
        StartCoroutine(ChoicePlayTime());
    }

    public void RemoveButton()
    {
        if (RightAnwser != true)
        {
            ChoiceAnimator.SetTrigger("Choosed");
        }
    }
}