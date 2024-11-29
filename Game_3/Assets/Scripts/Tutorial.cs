using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    private bool isWaitingForInput = false;

    // Start is called before the first frame update
    void Start()
    {
        runTutorial();
    }

    // Update is called once per frame
    void Update()
    {
        // Destroys the text in each stage after user affrims understanding
        if (isWaitingForInput && Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(tutorialText.gameObject);
            isWaitingForInput = false;
        }

        // Enables the user to manually skip the tutorial
        if (Input.GetKeyDown(KeyCode.Return)) {
            endTutorial();
        }
    }

    // Initiates the game tutorial
    void runTutorial() {
        tutorialText.text = "Press 'Enter' at any time to skip tutorial";
        StartCoroutine(DestroyMessageAfterDelay(5f));
        learnMovement();
        learnPortals();
        learnObjective();
        endTutorial();
    }

    // Destroys intital instructions after a specified delay
    private IEnumerator DestroyMessageAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        Destroy(tutorialText.gameObject);
    }

    // Instructs the user on basic movement controls
    void learnMovement() {
        tutorialText.text = "Use WASD to move forwards, left, backwards, and right. ('Space' to continue)";
        isWaitingForInput = true;
    }

    // Instructs the user on basic portal controls
    void learnPortals() {
        tutorialText.text = "Use 'left click' to shoot a portal. ('Space' to continue)";
        isWaitingForInput = true;
    }

    // Provides overall game objective / narrative
    void learnObjective() {
        tutorialText.text = "Each level is a puzzle to solve. Use your portals to move to the next stage! ('Space' to continue)";
        isWaitingForInput = true;
    }

    // Changes scene from the tutorial to the actual game
    void endTutorial() {
        SceneManager.LoadScene("GameScene");
    }
}
