using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPuzzle : MonoBehaviour
{
    public Text box;
    private string doorText = "A door has opened";
    // Start is called before the first frame update
    void Start()
    {
        box.text = "Welcome to the Cube test";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
