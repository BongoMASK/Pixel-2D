using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    GameObject playerCollision, protectRing;

    public static float clock, clockInit;        //supposed to be for the slider to show time remaining for sharingan
    public float sloMoTime;

    public static bool sharingan = false;

    public Slider slider;
    EnemyMovement EnemyMovement;
    Animator animator;

    //initially it was kept such that after 5 real time seconds time scale would go back to one
    //the game is actually kinda hard and this would just make it a bit easier for people to play
    //plus, its cool as hell
    void Start() { 
        clock = GameManager.powerUpTime;
        clockInit = clock;

        slider.maxValue = clockInit;

        playerCollision = GameObject.FindGameObjectWithTag("Respawn");
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        protectRing = GameObject.FindGameObjectWithTag("Protect");

        protectRing.SetActive(false);
    }

    void Update() {
        slider.value = clock;

        animator.SetBool("sharingan", sharingan);
        animator.SetBool("isHit", Movement.isHit);

        ClockRegen();

        if((Input.GetKey(KeyCode.S) || Input.GetMouseButton(1)) /*&& Movement.start == true*/) {
            StartCoroutine(Sharingan());
        }

        if(Input.GetKeyDown(KeyCode.D) || Input.GetMouseButtonDown(2)) {
            StartCoroutine(Disable());
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            StartCoroutine(Protect());
        }

        if ((clock <= 0 || Input.GetKeyUp(KeyCode.S) || Input.GetMouseButtonUp(1)) /*&& Movement.start == true*/ /*|| 
          Input.GetKeyUp(KeyCode.D) || Input.GetMouseButtonUp(2)*/) {
            StopCoroutine(Disable());
            StopCoroutine(Sharingan());
            sharingan = false;
            playerCollision.SetActive(true);
            EnemyCount.powerUp.text = "Slo-Mo";
            Time.timeScale = 1f;
        }
    }

    //Slow down time
    //other name ideas - Kronos, Slo - mo
    IEnumerator Sharingan() {
        Time.timeScale = sloMoTime;
        int number = (int) (clock * 1.5f) + 1;
        EnemyCount.powerUp.text = "Slo-Mo " + number.ToString();
        clock -= Time.deltaTime;
        sharingan = true;
        yield return new WaitForSeconds(clockInit);
    }

    //Main idea - enemies will shoot but not move
    //the other way will make the protect powerup useless
    //This works... in a different way...
    //Basically, since the bulletSpeed = 0, the bullet still spawns and then destroys the enemy itself...
    //plus, the bullet stays there and never moves again, which if used wrongly is game-breaking
    IEnumerator Disable() {
        if(clock < slider.maxValue) {
            Debug.Log("not enough");
        }
        else {
            while(clock > 0) {
                yield return new WaitForSeconds(0f);
                int number = (int) (clock) + 1;
                EnemyCount.powerUp.text = "Disable " + number.ToString();
                Debug.Log("disable");
                EnemyMovement.enemySpeed = 0;
                sharingan = true;
                clock -= Time.deltaTime;
            }
            EnemyMovement.enemySpeed = 110;
        }
    }


    IEnumerator Protect() {
        protectRing.SetActive(true);

        yield return new WaitForSeconds(10f);
        protectRing.SetActive(false);
    }

    //Main Idea - make certain enemies good, makes other enemies target that enemy
    //Number of people touching playerCollision will be made good.
    //(maybe) will follow you and kill enemies near you until dead
    // OR will kill closest enemy to it
    IEnumerator Glitch() {
        
        yield return new WaitForSeconds(5);
    }

    //Main Idea - become invisible to enemies
    //Make character (white area - transparent/black), (eyes - white), (apply white border as well)
    //Maybe, allow them to pass through enemies/walls (potentially OP)
    //not sure how its different...
    IEnumerator Cloak() {
        playerCollision.SetActive(false);
        int number = (int) (clockInit) + 1;
        EnemyCount.powerUp.text = "Cloak  " + number.ToString();
        clock -= Time.deltaTime;
        sharingan = true;
        yield return new WaitForSeconds(clockInit);
    }

    void ClockRegen() {
        if(clock < clockInit && !sharingan) {
            clock = clock + (Time.deltaTime * 0.4f);
        }
    }
}
