using UnityEngine;

public class MainCamera : MonoBehaviour {

    Portal[] portals;
    private bool masked;
    void Awake () {
        portals = FindObjectsOfType<Portal> ();
    }

    void OnPreCull () {

        for (int i = 0; i < portals.Length; i++) {
            portals[i].PrePortalRender ();
        }
        for (int i = 0; i < portals.Length; i++) {
            portals[i].Render ();
        }

        for (int i = 0; i < portals.Length; i++) {
            portals[i].PostPortalRender ();
        }

    }
    //hide hat when looking up in some scenes
    void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }
        if(transform.localRotation.x < 0 && !masked)
        {
            transform.gameObject.GetComponent<Camera>().cullingMask -= 16;
            masked = true;
        }
        if(transform.localRotation.x > 0 && masked)
        {
            masked = false;
            transform.gameObject.GetComponent<Camera>().cullingMask += 16;
        }
    }

}