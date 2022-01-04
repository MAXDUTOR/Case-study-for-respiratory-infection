using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceAnimation : MonoBehaviour
{
    public GameObject Choice;
    // Start is called before the first frame update
    void Start()
    { }
    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.one;
    }

    public void MouseEnter()
    {
        Debug.Log("Enter");
           Choice.transform.localScale = new Vector3(1.15f,1.15f,1.15f);
    }

    public void MouseExit()
    {
        Debug.Log("Exit");
        Choice.transform.localScale = new Vector3(1f,1f,1f);
    }
}
