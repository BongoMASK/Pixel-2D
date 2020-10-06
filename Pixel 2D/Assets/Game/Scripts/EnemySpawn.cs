using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy, waveText;
    public float xPos1, xPos2, xPos3, xPos4;
    public float yPos1, yPos2, yPos3, yPos4;
    float time = 0f;
    public int timeFixed;
    Text waveNum;
    public bool boss;

    void Update() {  
        if(boss == false) {
            if(EnemyCount.clock > 0) {
                waveNum = waveText.GetComponent<Text>();
                waveNum.text = "Wave 1 / 3";
                time -= Time.deltaTime;
                if(time <= 0) {
                    Instantiate(enemy, new Vector2(xPos1, yPos1), Quaternion.identity);
                    Instantiate(enemy, new Vector2(xPos2, yPos2), Quaternion.identity);
                    Instantiate(enemy, new Vector2(xPos3, yPos3), Quaternion.identity);
                    Instantiate(enemy, new Vector2(xPos4, yPos4), Quaternion.identity);
                    EnemyCount.totalEnemyCount += 4;
                    time = timeFixed;
                }
                if(EnemyCount.clock <= 21) {
                    waveNum.text = "Wave 2 / 3";
                }
                if(EnemyCount.clock <= 11) {
                    waveNum.text = "Wave 3 / 3";
                }
            }
        }
        else {
            time -= Time.deltaTime;
            if(time <= 0) {
                Instantiate(enemy, new Vector2(xPos1, yPos1), Quaternion.identity);
                Instantiate(enemy, new Vector2(xPos2, yPos2), Quaternion.identity);
                Instantiate(enemy, new Vector2(xPos3, yPos3), Quaternion.identity);
                Instantiate(enemy, new Vector2(xPos4, yPos4), Quaternion.identity);
                EnemyCount.totalEnemyCount += 4;
                time = timeFixed;
            }
        }
    }
}
