using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_05 : MonoBehaviour
{
    public List<Animator> checkBoxAnimator;
    private Animator uIAnimator;
        void Start()
    {
        uIAnimator = GetComponent<Animator>();
        StartCoroutine(DelaysThanPause());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckAnswer()
    {
        for (int i = 0; i < checkBoxAnimator.Count; i++)
        {
            checkBoxAnimator[i].GetBool("Checked");
        }

        if (checkBoxAnimator[5].GetBool("Checked") == true &&
            checkBoxAnimator[4].GetBool("Checked") == true &&
            checkBoxAnimator[3].GetBool("Checked") == false &&
            checkBoxAnimator[2].GetBool("Checked") == true &&
            checkBoxAnimator[1].GetBool("Checked") == false &&
            checkBoxAnimator[0].GetBool("Checked") == false)
        {
            EventScript.instance.ShowCorrectImage();
        }
        else
        {
            EventScript.instance.ShowWrongImage();
        }
        uIAnimator.SetTrigger("Hide UI");
        EventScript.instance.player.Play();
    }
    IEnumerator DelaysThanPause()
    {
        yield return new WaitForSeconds(4.28f);
        EventScript.instance.player.Pause();
        uIAnimator.SetTrigger("Start Event");
    }
}

