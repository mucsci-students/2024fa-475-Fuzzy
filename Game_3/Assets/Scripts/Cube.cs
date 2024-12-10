using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private int sidesBlocked;
    private float distanceToPlayer;
     private int maxHeight = -20;
    private Vector3 startPos;
    private Rigidbody body;
    private GameObject player;
    public int minHeight;
    public bool grabbed;
    public bool growable;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        body = GetComponent<Rigidbody>();
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        checkKeys();
        if (transform.position.y < minHeight || transform.position.y > maxHeight)
        {
            transform.position = startPos;
        }
    }
    void checkKeys()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !grabbed)
        {
            {
                Grab(true);
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
            Grab(false);
        }
        
    }
    //if release is true, then release the cube
    void Grab(bool keep)
    {
        if(!keep)
        {
            body.useGravity = true;
            grabbed = false;
            return;
        }
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 100) && hit.collider.tag == "Cube" && hit.transform == transform)
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
        //keep player from grabbing while on cube
        if(ray.direction.y < -(.8f - 0.05f * transform.localScale.x) && player.transform.position.y > transform.position.y)
        {
            Grab(false);
            return;
        }
        Vector3 angle = ray.GetPoint(distanceToPlayer) - transform.position;
        //updats distance but keeps it some distance away from the player
        float tempDistance = Vector3.Distance(ray.origin, transform.position);
        distanceToPlayer = Mathf.Max(1f + 1f * transform.localScale.x, tempDistance);
        //if too close to player, add force in direction away from player
        if (distanceToPlayer > tempDistance)
        {
            angle += ray.direction;
        }
        else
        {
            //if pushed or player walking towards, push away
            if(val == 1 || Input.GetKey(KeyCode.W))
            {
                angle += ray.direction;
            }
            //if pulled or player walking away, pull towards
            if (val == 2 || Input.GetKey(KeyCode.S))
            {
                angle -= ray.direction;
            }
        }
        //slow down if speed too fast
        if(body.velocity.magnitude > 10)
        {
            angle -= body.velocity.normalized;
        }
        body.AddForce(angle);
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
