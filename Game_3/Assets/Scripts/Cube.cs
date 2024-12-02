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

    void OnCollisionEnter(Collision other)
    {
        growable = false;
    }
    void OnCollisionExit(Collision other){
        growable = true;
    }
}
