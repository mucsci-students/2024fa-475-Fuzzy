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
    //loads the specified scene
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    //Quits the game
    public void Quit()
    {
        Application.Quit();
    }
}
