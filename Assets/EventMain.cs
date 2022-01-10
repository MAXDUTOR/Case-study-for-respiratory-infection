using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMain : MonoBehaviour
{
    public GameObject nextEvent;
    public bool nextEventIfChoosedAllChoice;
    protected Animator currentEventAnimator;
    protected bool isRechoice = false;
    public int eventNumber { get; protected set; }

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
}
