using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public AudioSource[] emoteMusic;
    [SerializeField]
    GameObject player;



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1")) {
            stopAudio();
            emoteMusic[0].Play();
            player.GetComponent<Animator>().Play("Dance Moves", -1, 0f);
        } 

        if(Input.GetKeyDown("2")) {
            stopAudio();
            emoteMusic[1].Play();
            player.GetComponent<Animator>().Play("Floss", -1, 0f);
        } 

        if(Input.GetKeyDown("3")) {
            stopAudio();
            emoteMusic[2].Play();
            player.GetComponent<Animator>().Play("Breakdance", -1, 0f);
        } 

        if(Input.GetKeyDown("4")) {
            stopAudio();
            emoteMusic[3].Play();
            player.GetComponent<Animator>().Play("Orange Justice", -1, 0f);
        } 

        if (Input.GetKeyDown("5")) {
            stopAudio();
            emoteMusic[4].Play();
            player.GetComponent<Animator>().Play("Celebrate", -1, 0f);
        }

        if (Input.GetKeyDown("6")) {
            stopAudio();
            player.GetComponent<Animator>().Play("Idle", -1, 0f);
        }

    }

    void stopAudio() {
        foreach (AudioSource audio in emoteMusic)
        {
            audio.Stop();
        }
    }
}
