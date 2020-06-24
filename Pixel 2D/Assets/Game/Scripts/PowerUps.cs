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
    public float clock = 5f;
    int n = 0;
    int l;
    bool sharingan = false;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {   
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        //l = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //powerBar.SetMaxTime(clock);
        //powerBar.SetTime(clock);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = SliderValue();

        EnemyCount.powerUp.text = "No Power Up";
        l = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if(clock < 5) {
            clock += Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.S)) {
            //Sharingan();
            //clock -= Time.deltaTime;
            //powerBar.SetTime(clock);
            Time.timeScale = 0.6f;
        }
        if(Input.GetKeyUp(KeyCode.S)) {
            EnemyCount.powerUp.text = "No Power Up";
            Time.timeScale = 1f;
            sharingan = false;
        }

        if(Input.GetKeyDown(KeyCode.D)) {
            StartCoroutine(Disable());
        }
    }
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
    IEnumerator Cloak() {
        yield return new WaitForSeconds(5);
        //player;
    }
    float SliderValue() {
        if(sharingan) {
            clock -= Time.deltaTime;
        }
        return clock;
    }
    void Sharingan() {
        Time.timeScale = 0.6f;
        EnemyCount.powerUp.text = "Sharingan";
        sharingan = true;
        /*yield return new WaitForSeconds(3);

        Time.timeScale = 1f;
        EnemyCount.powerUp.text = "No Power Up";*/
    }
}
