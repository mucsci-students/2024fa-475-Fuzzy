using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool activated;    
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
        
    }
    //turn off is true is result of button press should be deactivated
    void activate(bool turnOff)
    {
        //closedObj.SetActive(TurnOff);
        //openObj.SetActive(!TurnOff);
        //closedObj.transform.Rotate(new Vector3(0f,80f,0f));
        StartCoroutine(Open(turnOff, 115));
        activated = !turnOff;

    }
    IEnumerator Open(bool open, int dist)
    {
        Debug.Log("open");
        int speed = 1;
        if (open)
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
        if(!activated)
        {
            activate(false);
        }
    }
    void OnTriggerExit(Collider other)
    {
        pressed = false;
        if(toggleable)
        {
            activate(true);
        }
    }
}
