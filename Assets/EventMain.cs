using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMain : MonoBehaviour
{
    public GameObject nextEvent;
    protected Animator currentEventAnimator;
    protected bool isRechoice = false;

    [SerializeField]
    public List<Animator> choiceAnimator;

    public void Start()
    {
        currentEventAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause(int index)
    {
        if (isRechoice == false)
        {
            Debug.Log("Pause");
            EventScript.instance.playerList[index].Pause();
            isRechoice = true;

            for (int i = 0; i < choiceAnimator.Count; i++)
            {
                choiceAnimator[i].SetBool("Show", true);
            }
        }
    }
}
