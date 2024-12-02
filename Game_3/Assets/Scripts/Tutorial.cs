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
        StartCoroutine(runTutorial());
        Debug.Log("Start Ran");
    }

    // Update is called once per frame
    void Update()
    {
        // Enables the user to manually skip the tutorial
        if (Input.GetKeyDown(KeyCode.Return)) {
            endTutorial();
        }
    }

    IEnumerator runTutorial()
    {
        Debug.Log("'RunTutorial' Ran");
        tutorialText.text = "Press 'Enter' at any time to skip tutorial";
        yield return StartCoroutine(DestroyMessageAfterDelay(5f)); // Wait for initial message to disappear

        yield return StartCoroutine(learnMovement()); // Wait for user to press space in learnMovement
        yield return StartCoroutine(learnPortals()); // Wait for user to press space in learnPortals
        yield return StartCoroutine(learnObjective()); // Wait for user to press space in learnObjective

        endTutorial(); // Move to the next scene after the tutorial is done
    }

    // Destroys intital instructions after a specified delay
    private IEnumerator DestroyMessageAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        //Destroy(tutorialText.gameObject);
    }

    // Instructs the user on basic movement controls
    IEnumerator learnMovement() {
        Debug.Log("'learnMovement' Ran");
        tutorialText.text = "Use WASD to move forwards, left, backwards, and right. ('Space' to continue)";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
    }

    // Instructs the user on basic portal controls
    IEnumerator learnPortals() {
        yield return new WaitUntil(() => !Input.GetKeyDown(KeyCode.Space));
        Debug.Log("'learnPortals' Ran");
        tutorialText.text = "Use 'left click' to shoot a portal. ('Space' to continue)";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
    }

    // Provides overall game objective / narrative
    IEnumerator learnObjective() {
                yield return new WaitUntil(() => !Input.GetKeyDown(KeyCode.Space));
        Debug.Log("'learnObjective' Ran");
        tutorialText.text = "Each level is a puzzle to solve. Use your portals to move to the next stage! ('Space' to continue)";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
    }

    // Changes scene from the tutorial to the actual game
    void endTutorial() {
        Debug.Log("'endTutorial' Ran");
        SceneManager.LoadScene("GameScene");
    }
}
