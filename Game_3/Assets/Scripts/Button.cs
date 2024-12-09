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
    public GameObject closedObj;
    public GameObject openObj;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //turn off is true is result of button press should be deactivated
    void activate(bool TurnOff)
    {
        closedObj.SetActive(false);
        closedObj.SetActive(false);
        activated = true;

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
