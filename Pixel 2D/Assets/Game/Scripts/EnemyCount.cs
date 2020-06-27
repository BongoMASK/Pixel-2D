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
    public GameObject finishText;
    public GameObject finishObject;
    public GameObject powerUpText;
    Text score;
    Text time;
    Text finish;
    public static Text powerUp;

    //Replace textboxes with TextMesh Pro
    
    void Start()
    {
        clock = 30;
        totalEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void Update()
    {
        currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        clock -= Time.deltaTime;    //Countdown
        Debug.Log(currentEnemyCount + " / " + totalEnemyCount + " Enemies Left");

        time = timeText.GetComponent<Text>();
        score = scoreText.GetComponent<Text>(); 
        finish = finishText.GetComponent<Text>();
        powerUp = powerUpText.GetComponent<Text>();

        time.text = clock.ToString();                   //placed in this order because this value updates last
        score.text = currentEnemyCount.ToString() + " / " + totalEnemyCount.ToString() + " Left";   

        if(clock <= 0) {
            time.text = "0.000";
            Debug.Log("Game won!");
            finishObject.SetActive(true);
            finish.text = "Finish";
        }
    }
}
