using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyCount : MonoBehaviour
{
    public static int currentEnemyCount;
    public static int totalEnemyCount; 
    public static float clock = 30;
    public GameObject scoreText;
    public GameObject timeText;
    public GameObject finishText, healthText;
    public GameObject finishObject;
    public GameObject powerUpText;
    Text score;
    Text time;
    Text finish;
    Text health;
    public static Text powerUp;
    public Slider slider;

    //Replace textboxes with TextMesh Pro
    
    void Start()
    {
        clock = 30;
        totalEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
    void Update()
    {
        slider.maxValue = GameManager.totalHealth;
        slider.value = GameManager.health;
        
        currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        clock -= Time.deltaTime;    //Countdown

        time = timeText.GetComponent<Text>();
        score = scoreText.GetComponent<Text>(); 
        finish = finishText.GetComponent<Text>();
        powerUp = powerUpText.GetComponent<Text>();
        health = healthText.GetComponent<Text>();

        time.text = clock.ToString();                   //placed in this order because this value updates last
        score.text = currentEnemyCount.ToString() + " / " + totalEnemyCount.ToString() + " Enemies Left"; 
        health.text = "Health: " + GameManager.health + " / " + GameManager.totalHealth;  

        if(clock <= 0) {
            time.text = "0.000";
            finishObject.SetActive(true);
            finish.text = "Finish";
        }
    }
}
