using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHoverScaleObject : MonoBehaviour
{

    private Vector3 scaleChange;
    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(0.01f, 0.01f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator MouseIn()
    {
        for(int i = 0; i < 15; i++)
        {
            transform.localScale += scaleChange;
            yield return null;

        }
    }

    public IEnumerator MouseOut()
    {
        for(int i=0; i < 15; i++)
        {
            transform.localScale -= scaleChange;
            yield return null;

        }
    }

    public void In()
    {
        StartCoroutine(MouseIn());
    }

    public void Out()
    {
        StartCoroutine (MouseOut());
    }
}
