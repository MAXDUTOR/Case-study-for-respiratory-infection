using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_02 : EventMain {
    public Animator uIAnimator;

    void Start()
    {
        uIAnimator.SetBool("Show", true);
        EventScript.instance.player.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
