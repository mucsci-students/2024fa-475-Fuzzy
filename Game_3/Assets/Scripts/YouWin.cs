using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class YouWin : MonoBehaviour
{
    public TextMeshProUGUI youWinText;

    void OnTriggerEnter(Collider col) {
        GameObject player = GameObject.Find("Player");
        if(col.gameObject == player) {
            youWinText.text = "You're free! Thanks for playing our game!";
        }

        StartCoroutine(teleportToNewWorld());
    }


    IEnumerator teleportToNewWorld() {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("End Credits");
    }
}
