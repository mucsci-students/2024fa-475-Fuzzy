using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public bool growable;
    public GameObject player;
    // Start is called before the first frame update
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
    void Move()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        growable = false;
    }
    void OnTriggerExit(Collider other){
        growable = true;
    }
}
