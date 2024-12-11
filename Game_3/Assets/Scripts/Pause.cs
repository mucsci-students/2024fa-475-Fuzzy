using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public bool paused;
    public bool pauseable;
    public Manager script;
    public GameObject pauseUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseable && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseToggle();
        }
    }
    //loads the specified scene
    public void LoadScene(int scene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        SceneManager.LoadScene(script.level);
    }
    public void PauseToggle()
    {
        if(!pauseable)
        {
            return;
        }
        if(paused)
        {
            Time.timeScale = 1;
            paused = false;
            pauseUI.SetActive(false);
        }
        else
        {
            paused = true;
            Time.timeScale = 0;
            pauseUI.SetActive(true);
        }
    }

    public void StartGame() {
        SceneManager.LoadScene("scene1");
    }

    //Quits the game
    public void Quit()
    {
        Application.Quit();
    }
}
