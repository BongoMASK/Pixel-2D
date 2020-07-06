using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int data;
    public static int deaths;
    public static int enemiesKilled;
    float secondsPast;
    public static int health;
    public GameObject upgradeCanvas;

    //Stats
    public static int totalHealth = 25;
    public static int healthData = 1000;
    public static int penetration;
    public static int penetrationData;
    public static int MoneyDropped = 200;
    public static int moneyDroppedData;
    public static int powerUpTime;
    public static int powerUpTimeData;

    void Awake()
    {
        MakeSingleton(); 
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U)) {
            upgradeCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    void healthRegen() {
        if(secondsPast <= 0 && health < totalHealth) {
            health = health + 1;
            secondsPast = 1f;
        }
        secondsPast -= Time.deltaTime;
    }
    void healthUpgrade() {
        data = data - healthData;
        health = health + 25;
        healthData = healthData * 2;
    }
    void MakeSingleton() {
        if(instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
 }
