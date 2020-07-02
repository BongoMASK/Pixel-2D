using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Cloak : MonoBehaviour
{
    GameObject playerCollision;
    float clock = 2f;    //supposed to be for the slider to show time remaining for sharingan
    bool cloak = false;
    float clockInit;
    public Slider slider;
    EnemyMovement EnemyMovement;
    public Animator animator;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        clock = 3f;  
        clockInit = clock;
        slider.maxValue = 2f;
        playerCollision = GameObject.FindGameObjectWithTag("Respawn");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D) || Input.GetMouseButton(2)) {
            StartCoroutine(CloakPower());
        }
        if(clock <= 0 || Input.GetKeyUp(KeyCode.D) || Input.GetMouseButtonUp(2)) {
            StopCoroutine(CloakPower());
            cloak = false;
            playerCollision.SetActive(true);
            EnemyCount.powerUp.text = "No Power Up";
            Time.timeScale = 1f;
            //EnemyMovement.rb.velocity = EnemyMovement.moveVelocity;
        }
    }
    IEnumerator CloakPower() {
        playerCollision.SetActive(false);
        int number = (int) (clockInit) + 1;
        EnemyCount.powerUp.text = "Cloak " + number.ToString();
        clock -= Time.deltaTime;
        cloak = true;
        yield return new WaitForSeconds(clockInit);
    }
}
