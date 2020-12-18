using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelControl : MonoBehaviour
{
    public bool store, finish, cutscene;
    //GameObject upgradeCanvas;
    Animator transition;
    public float transitionTime;

    void Start() {
        //upgradeCanvas = GameObject.FindGameObjectWithTag("UpgradeCanvas");
        transition = GameObject.FindGameObjectWithTag("TransitionCanvas").GetComponent<Animator>();
        if(cutscene == true) {
            transition.SetTrigger("Start2");
        }
    }

    void Update() {
        if(cutscene == true) {
            Time.timeScale = 1f;
        }

        if (transition != null) {
            transition.SetBool("cutscene", cutscene);
            transition.SetBool("finish", finish);
        }

        if(cutscene == true && Input.anyKey) {
            LoadNextLevel();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            if(finish == true) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                //LoadNextLevel();
            }
            if(store == true) {
                
            }
        }
    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex) {

        if(cutscene == true) {
            transition.SetTrigger("Start3");
        }
        else {
            transition.SetTrigger("Start");
        }
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
