using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_01 : EventMain {
    void Start()
    {
        base.Start();
        StartCoroutine(DelaysThanPlay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public IEnumerator DelaysThanPlay()
    {
        yield return new WaitForSeconds(18.44f);
        EventScript.instance.player.Pause();
        currentEventAnimator.SetBool("Show",true);
        for(int i = 0;choiceAnimator.Count > 0; i++)
        {
            choiceAnimator[i].SetBool("Show", true);
        }
    }
}
