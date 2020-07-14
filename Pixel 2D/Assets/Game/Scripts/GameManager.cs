using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int data;
    public static int deaths;
    public static int enemiesKilled;
    public float secondsPast = 1f;
    public static int health;
    public GameObject upgradeCanvas;
    public static GameObject canvas;
    bool isUpgrade = false;

    //Text
    Text currentHealth, currentPowerUpTime, currentMoneyDrop, currentHealthData;
    Text currentPowerUpTimeData, currentMoneyDropData, currentData;
    public GameObject healthText, powerUpText, MoneyDropText, healthDataText;
    public GameObject moneyDroppedDataText, powerUpTimeDataText, dataText, dataReceived1;
    public static Text dataReceivedEnemy;
    public static GameObject dataReceived;


    //Stats
    public static int totalHealth = 25;
    public static int healthData = 100;
    public static int penetration;
    public static int penetrationData;
    public static float MoneyDropped = 20;
    public static int moneyDroppedData = 250;
    public static int powerUpTime = 3;
    public static int powerUpTimeData = 175;

    void Awake()
    {
        dataReceived = dataReceived1; 
        dataReceivedEnemy = dataReceived.GetComponent<Text>();
        canvas = upgradeCanvas;
        MakeSingleton(); 
    }

    void Update()
    {
        healthRegen();

        if(Input.GetKeyDown(KeyCode.U)) {
            if(!isUpgrade) {
                upgradeMenu();
            }
            else {
                resume();
            }
        }
        currentHealth = healthText.GetComponent<Text>();
        currentPowerUpTime = powerUpText.GetComponent<Text>();
        currentMoneyDrop = MoneyDropText.GetComponent<Text>();
        currentData = dataText.GetComponent<Text>();
        currentHealthData = healthDataText.GetComponent<Text>();
        currentMoneyDropData = moneyDroppedDataText.GetComponent<Text>();
        currentPowerUpTimeData = powerUpTimeDataText.GetComponent<Text>();
        
        currentHealth.text = totalHealth.ToString();
        currentPowerUpTime.text = powerUpTime.ToString();
        currentMoneyDrop.text = MoneyDropped.ToString();
        currentData.text = "Data:   " + data.ToString();
        currentHealthData.text = healthData.ToString();
        currentMoneyDropData.text = moneyDroppedData.ToString();
        currentPowerUpTimeData.text = powerUpTimeData.ToString();
    }
    void resume() {
        upgradeCanvas.SetActive(false);
        Time.timeScale = 1;
        isUpgrade = false;
    }
    void upgradeMenu () {
        upgradeCanvas.SetActive(true);
        Time.timeScale = 0;
        isUpgrade = true;
    }
    void healthRegen() {
        if(secondsPast <= 0 && health < totalHealth) {
            health = health + 1;
            secondsPast = 1f;
        }
        secondsPast -= Time.deltaTime;
    }
    public void healthUpgrade() {
        if(data >= healthData)  {
            data = data - healthData;
            totalHealth = totalHealth + 25;
            health = health + 25;
            healthData = healthData * 2;
        }
        else {
            Debug.Log("Not enough data");
        }
    }
    public void moneyUpgrade() {
        if(data >= moneyDroppedData)  {
            data = data - moneyDroppedData;
            MoneyDropped = MoneyDropped + 10;
            moneyDroppedData = moneyDroppedData * 2;
        }
        else {
            Debug.Log("Not enough data");
        }
    }
    public void powerUpgrade() {
        if(data >= powerUpTimeData)  {
            data = data - powerUpTimeData;
            powerUpTime = powerUpTime + 1;
            powerUpTimeData = powerUpTimeData * 2;
        }
        else {
            Debug.Log("Not enough data");
        }
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
