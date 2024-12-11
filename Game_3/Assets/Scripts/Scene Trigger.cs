using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{

    void OnTriggerEnter(Collider col) {
        GameObject player = GameObject.Find("Player");
        if(col.gameObject == player) {
           StartCoroutine(teleportToNewWorld());
        }
    }


    IEnumerator teleportToNewWorld() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("scene3");
    }
}
