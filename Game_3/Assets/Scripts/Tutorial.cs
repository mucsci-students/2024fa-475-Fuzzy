using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    private bool isWaitingForInput = false;
    private bool waitForSkip = false;

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
        if (Input.GetKeyDown(KeyCode.Backspace)) {
            waitForSkip = true;
            StartCoroutine(endTutorial());
        }
    }

    IEnumerator runTutorial()
    {
        Debug.Log("'RunTutorial' Ran");
        tutorialText.text = "Press 'Backspace' at any time to skip tutorial";
        yield return StartCoroutine(DestroyMessageAfterDelay(5f)); // Wait for initial message to disappear

        yield return StartCoroutine(learnMovement());
        yield return StartCoroutine(learnEmotes());
        yield return StartCoroutine(learnPortals());
        yield return StartCoroutine(learnObjective());

        yield return StartCoroutine(endTutorial()); // Move to the next scene after the tutorial is done
    }

    // Destroys intital instructions after a specified delay
    private IEnumerator DestroyMessageAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
    }

    // Instructs the user on basic movement controls
    IEnumerator learnMovement() {
        if (waitForSkip != true) {
            Debug.Log("'learnMovement' Ran");
            tutorialText.text = "Use WASD to move forwards, left, backwards, and right. You can use 'Space' to jump and 'Shift' to sprint.  ('Enter' to continue)";
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        }
    }

    // Instructs the user on emote controls
    IEnumerator learnEmotes() {
        yield return new WaitUntil(() => !Input.GetKeyDown(KeyCode.Return));
        if (waitForSkip != true) {
            Debug.Log("'learnEmotes' Ran");
            tutorialText.text = "Use 1 - 6 to activate emotes. Press 7 to stop.  ('Enter' to continue)";
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        }
    }

    // Instructs the user on basic portal controls
    IEnumerator learnPortals() {
        yield return new WaitUntil(() => !Input.GetKeyDown(KeyCode.Return));
        if (waitForSkip != true) {
            Debug.Log("'learnPortals' Ran");
            tutorialText.text = "When you get access to portals, use 'left click' and 'right click' to shoot portals. ('Enter' to continue)";
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        }
    }

    // Provides overall game objective / narrative
    IEnumerator learnObjective() {
        yield return new WaitUntil(() => !Input.GetKeyDown(KeyCode.Return));
        if (waitForSkip != true) {
            Debug.Log("'learnObjective' Ran");
            tutorialText.text = "Each level is a test of your abilities. Use your portals to move to the next stage! ('Enter' to continue)";
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        }
    }

    // Changes scene from the tutorial to the actual game
    IEnumerator endTutorial() {
        Debug.Log("'endTutorial' Ran");
        tutorialText.text = "Ending tutorial. One moment...";
        yield return StartCoroutine(DestroyMessageAfterDelay(5f));
        SceneManager.LoadScene("Scene2");
    }
}
