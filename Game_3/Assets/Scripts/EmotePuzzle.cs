using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EmotePuzzle : MonoBehaviour
{

    [SerializeField]
    private EmoteTracker[] emoteTrackers;

    [SerializeField]
    public AudioSource[] puzzleEmoteMusic;

    [SerializeField]
    private List<int> playerSolution = new List<int>();

    private int currentEmotePlayed = 0;
    private bool allEmotesPlayed = false;

    public TextMeshProUGUI tutorialText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playPuzzleMusicOrder());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1")) {
            playerSolution.Add(1);
            currentEmotePlayed++;
        }
        if(Input.GetKeyDown("2")) {
            playerSolution.Add(2);
            currentEmotePlayed++;
        }
        if(Input.GetKeyDown("3")) {
            playerSolution.Add(3);
            currentEmotePlayed++;
        }
        if(Input.GetKeyDown("4")) {
            playerSolution.Add(4);
            currentEmotePlayed++;
        }
        if(Input.GetKeyDown("5")) {
            playerSolution.Add(5);
            currentEmotePlayed++;
        }
        if(Input.GetKeyDown("6")) {
            playerSolution.Add(6);
            currentEmotePlayed++;
        }

        if(Input.GetKeyDown("8")) {
            StartCoroutine(playPuzzleMusicOrder());
        }


        if(playerSolution.Count == 6) {
            for (int i = 0; i < 6; i++) {
            //Debug.Log("Player Solution: " + playerSolution[i]);
            //Debug.Log("Puzzle Solution: " + emoteTrackers[i].trackerNum);
            if (playerSolution[i] != emoteTrackers[i].trackerNum) {
                playerSolution.Clear();
                Debug.Log("CurrentEmotePlayed reset: " + currentEmotePlayed);
                currentEmotePlayed = 0;
                Debug.Log("CurrentEmotePlayed reset: " + currentEmotePlayed);
                tutorialText.text = "Puzzle Failed >:( Try Again! Press 8 to listen to the audio snippet again.";
                
            }
        }
        }

        if(currentEmotePlayed == 6) {
            allEmotesPlayed = true;
        }

        if(allEmotesPlayed) {
            tutorialText.text = "Emote Puzzle solved!!";
        }
    }

    IEnumerator playPuzzleMusicOrder() {
        yield return new WaitForSeconds(8f);
        tutorialText.text = "Listen Carefully... emote in the correct order to proceed!";
        for(int i = 0; i < 6; i++) {
            puzzleEmoteMusic[i].Play();
            puzzleEmoteMusic[i].SetScheduledEndTime(AudioSettings.dspTime+(5f));
            yield return new WaitForSeconds(5f);
        }
    }

    
}