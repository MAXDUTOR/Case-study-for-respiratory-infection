using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event04 : EventMain
{
    public bool choosedAllBeforeNext;
    void Start()
    {
        base.Start();
        StartCoroutine(DelaysThanPause());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DelaysThanPause()
    {
        yield return new WaitForSeconds(17.72f);
        EventScript.instance.player.Pause();
        currentEventAnimator.SetTrigger("Start Event");

        for (int i = 0; i < choiceAnimator.Count; i++)
        {
            choiceAnimator[i].SetBool("Show", true);
        }
    }
}
    