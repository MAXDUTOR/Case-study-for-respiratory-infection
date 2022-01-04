using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMain : MonoBehaviour
{
    public GameObject button;
    protected Vector3 ScaleChange;
    protected float ColorChange;
    protected Color CurrentColor;
    protected Image Image;
    protected bool IsPress = false;
    private EventScript Event;

    // Start is called before the first frame update
    void Start()
    {
        Image = button.GetComponent<Image>();
        ScaleChange = new Vector3(0.01f, 0.01f);
        CurrentColor = new Color(1f,1f,1f,0.5f);
        ColorChange = 0.03f;
        Event = GameObject.Find("Event 01").GetComponent<EventScript>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(CurrentColor);
    }

    public IEnumerator MouseInAnimation()
    {
        for (int i = 0; i < 15; i++)
        {
            button.transform.localScale += ScaleChange;
            CurrentColor.a += ColorChange;
            Image.color = CurrentColor;
            yield return null;
        }

    }
    public IEnumerator MouseOutAnimation()
    {
        for (int i = 0; i < 15; i++)
        {
            button.transform.localScale -= ScaleChange;
            CurrentColor.a -= ColorChange;
            Image.color = CurrentColor;
            yield return null;
        }
    }
    public void MouseIn()
    {
        Debug.Log("In");
        StartCoroutine(MouseInAnimation());
    }
    public void MouseOut()
    {
        Debug.Log("Out");
        StartCoroutine(MouseOutAnimation());
    }

    public void MouseClick(VideoTime time)
    {
        Debug.Log("Clicked");
        Event.RunChoice(time);
        Event.Play();

    }

}