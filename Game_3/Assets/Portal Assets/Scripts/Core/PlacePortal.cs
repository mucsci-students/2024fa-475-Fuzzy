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

    private void Update() {
        if(Time.timeScale == 0)
        {
            return;
        }
        if(Input.GetMouseButtonDown(0)) {
            FirePortal(portal1, transform.position, transform.forward, Mathf.Infinity);
        }
        if(Input.GetMouseButtonDown(1)) {
            FirePortal(portal2, transform.position, transform.forward, Mathf.Infinity);
        }
    }

    private void FirePortal(Portal portal, Vector3 pos, Vector3 dir, float distance) {
        RaycastHit hit;
        //Physics.Raycast(pos, dir, out hit, distance, layerMask);
        Ray ray;
        Vector3 mousePos = Input.mousePosition;
        ray = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out hit, distance, layerMask)) { 
            Debug.Log(hit.transform.gameObject.name);
            Debug.Log(mousePos);
            Vector3 newPoint = ray.GetPoint(hit.distance-0.5f);
            portal.transform.position = newPoint;//hit.transform.position;
            //hit.point  hit.collider.transfrom
            //transform.rotation
            //float x = portal.transform.position.x;
            //float y = portal.transform.position.y;
            //float z = portal.transform.position.z;
            //portal.transform.position = new Vector3 (x, y, z);

        }

    }

}
