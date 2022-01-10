using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_01 : EventMain {

    void Start()
    {
        base.Start();
        eventNumber = 1;
        StartCoroutine(DelaysThanPause(5.40f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public IEnumerator DelaysThanPause(float time)
    {
        Debug.Log("Start pause coroutine");
        yield return new WaitForSeconds(time);
        EventScript.instance.playerList[eventNumber].Pause();
        Debug.Log("End Pause");
        currentEventAnimator.SetTrigger("Show UI");

        for(int i = 0;i < (choiceAnimator.Count); i++)

        {
            choiceAnimator[i].SetBool("Show", true);
        }
    }
}