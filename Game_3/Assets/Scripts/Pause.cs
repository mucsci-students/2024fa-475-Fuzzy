using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Quits the game
    void Quit()
    {
        Application.Quit();
    }
    //loads the specified scene
    void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
