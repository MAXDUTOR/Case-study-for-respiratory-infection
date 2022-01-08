using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMain : MonoBehaviour
{
    public GameObject nextEvent;
    protected GameObject currentEvent;
    protected bool isRechoice = false;

    [SerializeField]
    protected List<Animator> choiceAnimator;
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextEvent()
    {
        if (nextEvent != null)
        {
            nextEvent.SetActive(true);
        }
    }

    public void EndEvent()
    {
        currentEvent.SetActive(false);
    }

    public void Pause()
    {
        if (isRechoice == false)
        {
            Debug.Log("Pause");
            EventScript.instance.player.Pause();
            isRechoice = true;

            for (int i = 0; i < choiceAnimator.Count; i++)
            {
                choiceAnimator[i].SetBool("Show", true);

            }
        }
    }
}
