using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_02 : EventMain {
    public Animator uIAnimator;

    void Start()
    {
        StartCoroutine(StartEvent());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartEvent()
    {
        yield return new WaitForSeconds(3.88f);
        uIAnimator.SetBool("Show UI", true);
    }
}
