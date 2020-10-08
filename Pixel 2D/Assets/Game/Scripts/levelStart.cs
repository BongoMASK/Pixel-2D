using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelStart : MonoBehaviour
{
    public GameObject convoCanvas, spawnGameObject, finish, bossSlider;
    public static GameObject playerCollision;
    bool isStarted;

    void Start()
    {
        playerCollision = GameObject.FindGameObjectWithTag("Respawn");
        //playerCollision.SetActive(false);
        spawnGameObject.SetActive(false);
        //enemyCollisions = boss.GetComponent<EnemyCollisions>();
    }

    void Update()
    {
        if(EnemyCollisions.bossIsDead == true) {
            finish.SetActive(true);  
        }
    }
    void OnTriggerExit2D(Collider2D col) {
        if(col.CompareTag("Player") && isStarted != true) {
            Time.timeScale = 0;
            convoCanvas.SetActive(true);
            StartCoroutine(DialogueTrigger());
            isStarted = true;
            bossSlider.SetActive(true);
            //playerCollision.SetActive(true);
        }
    }
    IEnumerator DialogueTrigger() {
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
        yield return new WaitForSeconds(0.2f);
        spawnGameObject.SetActive(true);
    }
}
