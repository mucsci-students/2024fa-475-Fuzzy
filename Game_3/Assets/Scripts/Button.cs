using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool pressed;
    public bool playerPressed;
    public bool cubePressed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        pressed = true;
    }
    void OnTriggerExit(Collider other)
    {
        pressed = false;
        
    }
}
