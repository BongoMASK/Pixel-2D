using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    public GameObject playerCollision;
    public float clock = 3f;    //supposed to be for the slider to show time remaining for sharingan
    bool sharingan = false;
    public Slider slider;

    //initially it was kept such that after 5 real time seconds time scale would go back to one
    //the game is actually kinda hard and this would just make it a bit easier for people to play
    //plus, its cool as hell
    void Start() {   
        slider.maxValue = clock;
    }

    void Update() {
        slider.value = clock;

        if(clock < 3 && !sharingan) {
            //clock += Time.deltaTime;
            clock = clock + Time.deltaTime;
        }
        //try to not make them shoot in slo - mo
        //it will encourage people to make enemies kill each other
        if(Input.GetKey(KeyCode.S)) {
            StartCoroutine(Sharingan());
        }
        if(clock <= 0 || Input.GetKeyUp(KeyCode.S)) {
            StopCoroutine(Sharingan());
            EnemyCount.powerUp.text = "No Power Up";
            Time.timeScale = 1f;
            sharingan = false;
        }

        if(Input.GetKeyDown(KeyCode.D)) {
            StartCoroutine(Disable());
        }
    }

    //Main idea - enemies will just give up on life when this is enabled
    //This works... in a different way...
    //Basically, since the bulletSpeed = 0, the bullet still spawns and then destroys the enemy itself...
    //plus, the bullet stays there and never moves again, which if used wrongly is game-breaking
    IEnumerator Disable() {
        playerCollision.SetActive(false);
        EnemyMovement.enemySpeed = 0;
        Enemy.bulletSpeed = 0;
        EnemyCount.powerUp.text = "Disable";

        yield return new WaitForSeconds(5);

        Enemy.bulletSpeed = 30;
        EnemyMovement.enemySpeed = 200;
        EnemyCount.powerUp.text = "No Power Up";
        playerCollision.SetActive(true);
    }

    //Main Idea - become invisible to enemies
    //Make character (white area - transparent/black), (eyes - white), (apply white border as well)
    //Maybe, allow them to pass through enemies/walls (potentially OP)
    //Very similar to disable
    //not sure how its different...
    IEnumerator Cloak() {
        yield return new WaitForSeconds(5);
    }

    //Slow down time
    //other name ideas - Kronos, Slo - mo
    //works fine, just has slider issue
    //add usage limit
    //maybe, make it such that player cant shoot - gives x second cool-down
    IEnumerator Sharingan() {
        Time.timeScale = 0.6f;
        EnemyCount.powerUp.text = "Sharingan";
        clock -= Time.deltaTime;
        sharingan = true;
        yield return new WaitForSeconds(3);
    }
}
