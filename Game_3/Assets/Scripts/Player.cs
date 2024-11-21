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
            emoteMusic[0].Play();
            player.GetComponent<Animator>().Play("Dance Moves", -1, 0f);
        } 

        if(Input.GetKeyDown("2")) {
            emoteMusic[1].Play();
            player.GetComponent<Animator>().Play("Floss", -1, 0f);
        }

        if(Input.GetKeyDown("3")) {
            emoteMusic[1].Play();
            player.GetComponent<Animator>().Play("Breakdance", -1, 0f);
        }
    }
}
