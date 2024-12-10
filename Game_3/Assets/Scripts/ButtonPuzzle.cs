using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPuzzle : MonoBehaviour
{
    private string doorText = "A door has opened";
    private float minDispTime = 2f;
    public GameObject light;
    public Text box;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisplayText("Welcome to the Cube Test", "Use the cubes to press a series of buttons to open doors to escape"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DisplayText(string message, string next)
    {
        box.text = message;
        yield return new WaitForSeconds(minDispTime + message.length * 0.1f);
        StartCoroutine(DisplayText(next, ""));
    }

    
}
