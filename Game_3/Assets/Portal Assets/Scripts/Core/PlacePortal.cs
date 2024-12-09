using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePortal : MonoBehaviour
{
    [SerializeField]
    private Portal portal1;
    [SerializeField]
    private Portal portal2;

    [SerializeField]
    private LayerMask layerMask;
    private int maxRange = 200;
    private void Update() {
        if(Time.timeScale == 0)
        {
            return;
        }
        if(Input.GetMouseButtonDown(0)) {
            FirePortal(portal1, transform.position, transform.forward, maxRange);
        }
        if(Input.GetMouseButtonDown(1)) {
            FirePortal(portal2, transform.position, transform.forward, maxRange);
        }
    }

    private void FirePortal(Portal portal, Vector3 pos, Vector3 dir, float distance) {
        RaycastHit hit;
        //Physics.Raycast(pos, dir, out hit, distance, layerMask);
        Ray ray;
        Vector3 mousePos = Input.mousePosition;
        ray = Camera.main.ScreenPointToRay(mousePos);
        if (Physics.Raycast(ray, out hit, distance, layerMask)) 
        {
            Debug.Log(mousePos);
            Vector3 newPoint = ray.GetPoint(hit.distance);
            //calculate orientation of portal
            float yRot = -hit.normal.x;
            // if flat ground, face player
            if (hit.normal.y == 1)
            {
                yRot = ray.direction.x;
                // if on lower side of unit circle, mirror portal rotation
                if (ray.direction.z < 0)
                {
                    yRot *= -1;
                    yRot -= 2;
                }
            }
            else
            {
                //put 1/2 from walls to allow player through
                newPoint += hit.normal * 0.5f;
            }
            if(portal.tag == "Portal1")
            {
                //add two, but if greater than 2 (equivalent to 180 degrees), set lower
                yRot += 2;
            }
            //only do if room for portal
            float width = 1.22f;// 1/2 the width of portal
            yRot *= 90;
            Vector3 rayDir = new Vector3(0f, 0f, 0f);
            //Vector3 rayDir = new Vector3(Mathf.Sin(yRot * Mathf.Deg2Rad), 0f, Mathf.Cos(yRot * Mathf.Deg2Rad));
            if (!(Physics.Raycast(newPoint, rayDir, width) || Physics.Raycast(newPoint, -rayDir, width)))
            {
                portal.transform.position = newPoint;
                portal.transform.eulerAngles = new Vector3(0, yRot, 0);
            }
            
            //hit.point  hit.collider.transfrom
            //transform.rotation
            //float x = portal.transform.position.x;
            //float y = portal.transform.position.y;
            //float z = portal.transform.position.z;
            //portal.transform.position = new Vector3 (x, y, z);

        }

    }

}
