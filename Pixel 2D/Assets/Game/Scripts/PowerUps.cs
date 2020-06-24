using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    public PowerBar powerBar;
    public GameObject[] enemy;
    public GameObject playerCollision;
    public float time;
    public float clock = 5f;    //supposed to be for the slider to show time remaining for sharingan
    bool sharingan = false;
    public Slider slider;

    //for some reason clocks not being set as the slider value
    //not sure why
    //initially it was kept such that after 5 real time seconds time scale would go back to one
    //the game is actually kinda hard and this would just make it a bit easier for people to play
    //plus, its cool as hell
    void Start()
    {   
        enemy = GameObject.FindGameObjectsWithTag("Enemy");       
    }

    void Update()
    {
        powerBar.SetMaxTime(clock);
        powerBar.SetTime(clock);
        //slider.value = clock;
        EnemyCount.powerUp.text = "No Power Up";

        if(clock < 5) {
            //clock += Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.S)) {
            StartCoroutine(Sharingan());
            //clock -= Time.deltaTime;
            //powerBar.SetTime(clock);
        }
        if(Input.GetKeyUp(KeyCode.S)) {
            EnemyCount.powerUp.text = "No Power Up";
            Time.timeScale = 1f;
            //sharingan = false;
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

        yield return new WaitForSeconds(time);

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
    float SliderValue() {
        if(!sharingan) {
            clock -= Time.deltaTime;
        }
        return clock;
    }
    //Slow down time
    //other name ideas - Kronos, Slo - mo
    //works fine, just has slider issue
    //add usage limit
    //maybe, make it such that player cant shoot - gives x second cool-down
    IEnumerator Sharingan() {
        Time.timeScale = 0.6f;
        EnemyCount.powerUp.text = "Sharingan";
        //sharingan = true;
        clock -= Time.deltaTime;
        yield return new WaitForSeconds(3);

        Time.timeScale = 1f;
        EnemyCount.powerUp.text = "No Power Up";
    }
}
