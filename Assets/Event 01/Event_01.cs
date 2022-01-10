using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_01 : EventMain {
    void Start()
    {
        base.Start();
        StartCoroutine(DelaysThanPause(5.56f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public IEnumerator DelaysThanPause(float time)
    {
        yield return new WaitForSeconds(time);
        EventScript.instance.playerList[1].Pause();
        currentEventAnimator.SetBool("Show",true);

        for(int i = 0;choiceAnimator.Count > 0; i++)

        {
            choiceAnimator[i].SetBool("Show", true);
        }
    }
}