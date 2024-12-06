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
        if (grabbed && Input.GetKey(KeyCode.LeftShift))
        {
            int moveVal = 0;
            //pulling and pushing
            if (Input.GetKey(KeyCode.T))
            {
                moveVal = 1;
            }
            else if (Input.GetKey(KeyCode.G))
            {
                moveVal = 2;
            }
            Move(moveVal);
            //growing and shrinking
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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 100) && hit.collider.tag == "Cube")
        {
            //distanceToPlayer = Vector3.Distance(ray.origin, transform.position);
            distanceToPlayer = hit.distance;
            grabbed = true;
            body.angularVelocity = Vector3.zero;
            body.useGravity = false;
        }
    }
    private void Move(int val)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 angle = transform.position - ray.GetPoint(distanceToPlayer);
        body.AddForce(-angle);
        //updats distance but keeps it some distance away from the player
        float tempDistance = Vector3.Distance(ray.origin, transform.position) - 0.1f;
        distanceToPlayer = Mathf.Max(1f + 1f * transform.localScale.x, tempDistance);
        if(distanceToPlayer > tempDistance)
        {
            body.AddForce(ray.direction);
        }
    }
    //bigger is false to shrink
    //grow is only called when grabbed and growable
    private void Grow(bool bigger)
    {
        int way = -1;
        if(bigger)
        {
            if(transform.localScale.x > 10)
            {
                return;
            }
            way = 1;
        }
        else if(transform.localScale.x < 0.2f)
        {
            return;
        }
        float scalar = transform.localScale.x + transform.localScale.x * 0.05f * way;
        transform.localScale = new Vector3(scalar, scalar, scalar);
        body.mass += body.mass * 0.05f * way;
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
