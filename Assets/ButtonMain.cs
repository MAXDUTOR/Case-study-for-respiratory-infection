using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ButtonMain : MonoBehaviour
{
    private int eventNumber;
    public float choiceDuration;
    public double answerPositionTime;
    protected Vector3 scaleChange;
    protected bool isPress = false;
    private List<Animator> choiceAnimator;
    private Animator currentAnimator;
    public bool rightAnwser;
    protected bool isReChoice = false;

    private Animator eventAnimator;
    private GameObject currentEvent;
    private GameObject nextEvent;
    private bool nextEventIfChoosedAllChoice;
    private VideoPlayer player;
    void Start()
    {
        nextEventIfChoosedAllChoice = GetComponentInParent<EventMain>().nextEventIfChoosedAllChoice;
        nextEvent = GetComponentInParent<EventMain>().nextEvent;
        currentEvent = gameObject.transform.parent.gameObject;
        eventAnimator = gameObject.transform.parent.GetComponent<Animator>();
        choiceAnimator = new List<Animator>();
        eventNumber = currentEvent.GetComponent<EventMain>().eventNumber;
        currentAnimator = GetComponent<Animator>();
        scaleChange = new Vector3(0.01f, 0.01f);
        player = EventScript.instance.playerList[eventNumber];


        for (int i = 0; i < (currentEvent.transform.childCount - 1); i++)
        {
            choiceAnimator.Add(currentEvent.transform.GetChild(i + 1).GetComponent<Animator>());
        }

    }

    void Update()
    {
        // Debug.Log(eventAnimator);
    }

    public IEnumerator ChoicePlayTime()
    {

        yield return new WaitForSeconds(choiceDuration);

        player.time = 0;
        player.Pause();

        currentAnimator.SetBool("Show", true);
        eventAnimator.SetTrigger("Show UI");

        for (int i = 0; i < choiceAnimator.Count; i++)
        {
            choiceAnimator[i].SetBool("Show", true);
        }
    }

    public IEnumerator MouseInAnimation()
    {
        for (int i = 0; i < 15; i++)
        {
            gameObject.transform.localScale += scaleChange;
            yield return null;
        }

    }
    public IEnumerator MouseOutAnimation()
    {
        for (int i = 0; i < 15; i++)
        {
            gameObject.transform.localScale -= scaleChange;
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

    public void MouseClick()
    {
        EventScript.instance.PlayAtTime(answerPositionTime, eventNumber);
        RemoveButton();
        eventAnimator.SetTrigger("Hide UI");
        currentAnimator.SetBool("Choosed", true);

        if (rightAnwser)
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

        if (nextEventIfChoosedAllChoice)
        {
            AllChoosedCheck();
        }
    }

    public void RemoveButton()
    {
        if (!rightAnwser)
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
            nextEvent.SetActive(true);
            gameObject.SetActive(false);
        }
    }

}


