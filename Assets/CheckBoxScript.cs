using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoxScript : MonoBehaviour
{
    public List<Animator> checkBoxAnimator;
    private Animator currentCheckBoxAnimator;
    // Start is called before the first frame update
    void Start()
    {
        currentCheckBoxAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckOnBox()
    {
        if (currentCheckBoxAnimator.GetBool("Checked") == false)
        {
            currentCheckBoxAnimator.SetBool("Checked", true);
        }
        else
        {
            currentCheckBoxAnimator.SetBool("Checked",false);
        }
    }

    
}
