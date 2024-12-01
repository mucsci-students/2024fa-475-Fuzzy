using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePortal : MonoBehaviour
{
    [SerializeField]
    private Portal portal;

    [SerializeField]
    private LayerMask layerMask;

    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            FirePortal(transform.position, transform.forward, 250.0f);
        }
    }

    private void FirePortal(Vector3 pos, Vector3 dir, float distance) {
        RaycastHit hit;
        Physics.Raycast(pos, dir, out hit, distance, layerMask);

        if (Physics.Raycast(pos, dir, out hit, distance, layerMask)) { 
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow); 
            Debug.Log("Did Hit"); 

            Debug.Log(hit.point);

            portal.transform.position = hit.point;

        }

    }

}
