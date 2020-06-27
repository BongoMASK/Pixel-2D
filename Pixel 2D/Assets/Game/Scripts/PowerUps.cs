﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    public GameObject playerCollision;
    float clock = 2f;    //supposed to be for the slider to show time remaining for sharingan
    bool sharingan = false;
    float clockInit;
    public Slider slider;
    GameObject[] enemy;

    //initially it was kept such that after 5 real time seconds time scale would go back to one
    //the game is actually kinda hard and this would just make it a bit easier for people to play
    //plus, its cool as hell
    void Start() { 
        clock = 2f;  
        clockInit = clock;
        slider.maxValue = 2f;
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update() {
        slider.value = clock;

        if(clock < clockInit && !sharingan) {
            clock = clock + (Time.deltaTime * 0.4f);
        }
        //try to not make them shoot in slo - mo
        //it will encourage people to make enemies kill each other
        if(Input.GetKey(KeyCode.S) || Input.GetMouseButton(1)) {
            StartCoroutine(Sharingan());
        }
        if(clock <= 0 || Input.GetKeyUp(KeyCode.S) || Input.GetMouseButtonUp(1) || 
          Input.GetKeyUp(KeyCode.D) || Input.GetMouseButtonUp(2)) {
            StopCoroutine(Sharingan());
            StopCoroutine(Disable());
            EnemyCount.powerUp.text = "No Power Up";
            Time.timeScale = 1f;
            //EnemyMovement.rb.velocity = EnemyMovement.moveVelocity;
            playerCollision.SetActive(true);
            sharingan = false;
        }

        if(Input.GetKey(KeyCode.D) || Input.GetMouseButton(2)) {
            StartCoroutine(Cloak());
        }
    }

    //Main idea - enemies will shoot but not move
    //This works... in a different way...
    //Basically, since the bulletSpeed = 0, the bullet still spawns and then destroys the enemy itself...
    //plus, the bullet stays there and never moves again, which if used wrongly is game-breaking
    IEnumerator Disable() {
        int number = (int) (clock * 1.5f) + 1;
        EnemyCount.powerUp.text = "Disable" + number.ToString();
        clock -=Time.deltaTime;
        EnemyMovement.rb.velocity = new Vector2(0, 0);
        sharingan = true;
        yield return new WaitForSeconds(5);
    }

    //Main Idea - become invisible to enemies
    //Make character (white area - transparent/black), (eyes - white), (apply white border as well)
    //Maybe, allow them to pass through enemies/walls (potentially OP)
    //not sure how its different...
    IEnumerator Cloak() {
        playerCollision.SetActive(false);
        int number = (int) (clock * 1.5f) + 1;
        EnemyCount.powerUp.text = "Cloak" + number.ToString();
        clock -= Time.deltaTime;
        yield return new WaitForSeconds(3);
    }
    //Main Idea - make certain enemies good, makes other enemies target that enemy
    //Number of people touching playerCollision will be made good.
    IEnumerator Glitch() {
        yield return new WaitForSeconds(5);
    }

    //Slow down time
    //other name ideas - Kronos, Slo - mo
    IEnumerator Sharingan() {
        Time.timeScale = 0.6f;
        int number = (int) (clock * 1.5f) + 1;
        EnemyCount.powerUp.text = "Sharingan " + number.ToString();
        clock -= Time.deltaTime;
        sharingan = true;
        yield return new WaitForSeconds(clockInit);
    }
}
