using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public bool grabbed;
    private int sidesBlocked;
    private float distanceToPlayer;
    private Rigidbody body;
    private GameObject player;
    public bool growable;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        checkKeys();
    }
    void checkKeys()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !grabbed)
        {
            {
                Grab(false);
            }
        }
        if(grabbed && Input.GetKey(KeyCode.LeftShift))
        {
            Move();
            if(growable && Input.GetKey(KeyCode.R))
            {
                Grow(true);
            }
            else if(Input.GetKey(KeyCode.F))
            {
                Grow(false);
            }
        }
        else
        {
            Grab(true);
        }
        
    }
    //if release is true, then release the cube
    void Grab(bool release)
    {
        if(release)
        {
            body.useGravity = true;
            grabbed = false;
            return;
        }
        RaycastHit hit;
        Vector3 mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        if(Physics.Raycast(ray, out hit, 100) && hit.collider.tag == "Cube")
        {
            distanceToPlayer = Vector3.Distance(ray.origin, transform.position);//hit.distance;
            grabbed = true;
            body.angularVelocity = Vector3.zero;
            body.useGravity = false;
        }
    }
    void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        Vector3 angle = transform.position - ray.GetPoint(distanceToPlayer);
        body.AddForce(-angle);
        distanceToPlayer = Vector3.Distance(ray.origin, transform.position);
        //transform.position = ray.GetPoint(distanceToPlayer);
        //check for collision
        
    }
    //bigger is false to shrink
    //grow is only called when grabbed and growable
    void Grow(bool bigger)
    {
        int way = -1;
        if(bigger)
        {
            way = 1;
        }
        float scalar = transform.localScale.x + transform.localScale.x * 0.1f * way;
        transform.localScale = new Vector3(scalar, scalar, scalar);
        body.mass += body.mass * 0.1f * way;
    }
    void OnTriggerEnter(Collider other)
    {
        growable = false;
        sidesBlocked++;
    }
    void OnTriggerExit(Collider other)
    {
        sidesBlocked--;
        if (sidesBlocked <= 0)
        {
            growable = true;
        }
    }
}
