using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnswerScript : MonoBehaviour
{
    public List<string> rightAnswer;
    public List<string> answer { get; private set; }
    public TMPro.TMP_InputField InputField;
    public Animator eventAnimator;
    public List<double> nextSectionTime;
    public List<double> rightAnswerDuration;
    public GameObject nextEvent;
    public int sectionIndex{ get; private set; }

    // Start is called before the first frame update
    void Start()
    {
       this.answer = new List<string>();
        StartCoroutine(DelaysThanStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SubmitAnswer()
    {
        answer.Add(InputField.text.ToLower()) ;
        CheckAnswer(answer[sectionIndex],sectionIndex);
        this.sectionIndex++;
    }

    public void CheckAnswer(string text,int section)
    {
        if(rightAnswer[section] == text)
        {
            EventScript.instance.ShowCorrectImage();
        }
        else
        {
            EventScript.instance.ShowWrongImage();  
        }
        EventScript.instance.PlayAtTime(nextSectionTime[section]);
        eventAnimator.SetTrigger("Hide");

        if (rightAnswerDuration[section] != 0)
        {
            StartCoroutine(EventScript.instance.DelaysThenPause(rightAnswerDuration[section], section, eventAnimator, "Show UI"));
        }
        else
        {
            nextEvent.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    IEnumerator DelaysThanStart()
    {
        yield return new WaitForSeconds(12.04f);
        EventScript.instance.player.Pause();
        eventAnimator.SetTrigger("Show UI");
    }
}