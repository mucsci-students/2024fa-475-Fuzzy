using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool activated;    
    public bool multi;
    public bool pressed;
    public bool toggleable;
    //public bool playerPressed;
    //public bool cubePressed;
    public GameObject leftObj;
    public GameObject rightObj;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }

    }
    //turn off is true if result of button press should be deactivated
    void activate(bool active)
    {
        //closedObj.SetActive(TurnOff);
        //openObj.SetActive(!TurnOff);
        //closedObj.transform.Rotate(new Vector3(0f,80f,0f));
        StartCoroutine(Open(active, 115));
        if(multi)
        {
            foreach (Button b in transform.parent.GetComponentsInChildren<Button>())
            {   
                b.activated = active;
            }
        }
        activated = active;
    }
    IEnumerator Open(bool open, int dist)
    {
        int speed = 1;
        if (!open)
        {
            speed = -1;
        }
        while (dist > 0)
        {
            yield return new WaitForSeconds (0.01f);
            leftObj.transform.Rotate (new Vector3(0f, -speed, 0f));
            rightObj.transform.Rotate (new Vector3(0f, speed, 0f));
            dist--;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        pressed = true;
        if(multi)
        {
            foreach (Button b in transform.parent.GetComponentsInChildren<Button>())
            {   
                if(!b.pressed && b.multi)
                {
                    return;
                }
            }
        }
        if(!activated)
        {
            activate(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        pressed = false;
        if(multi)
        {
            foreach( Button b in transform.parent.GetComponentsInChildren<Button>())
            {   
                if(b.pressed)
                {
                    return;
                }
            }
        }
        if(toggleable && activated)
        {
            activate(false);
        }
    }
}
