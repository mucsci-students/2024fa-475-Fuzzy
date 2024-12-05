using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoteTracker : MonoBehaviour
{

    [SerializeField]
    private EmoteTracker emoteTracker;

    [SerializeField]
    public int trackerNum;

    private string trackNumString;

    public bool emotePlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        trackNumString = trackerNum.ToString();

        if(Input.GetKeyDown(trackNumString)) {
            emotePlayed = true;
        }
    }
}
