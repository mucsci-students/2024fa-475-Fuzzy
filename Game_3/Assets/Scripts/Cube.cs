using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private bool locked;
    private Rigidbody body;
    public bool growable;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

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
