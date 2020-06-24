using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    int xPos1;
    int xPos2;
    int xPos3;
    int xPos4;
    int yPos1;
    int yPos2;
    int yPos3;
    int yPos4;
    int enemyCount;
    int totalEnemyCount = 0;
    float time = 0f;
    Text waveNum;
    public GameObject waveText;

    void Update() {  
        if(EnemyCount.clock > 0) {
            waveNum = waveText.GetComponent<Text>();
            waveNum.text = "Wave 1 / 3";
            time -= Time.deltaTime; 
            xPos1 = -9; yPos1 = 19;
            xPos2 = -31; yPos2 = 6;
            xPos3 = 9; yPos3 = 6;
            xPos4 = -9; yPos4 = -8;
            if(time <= 0) {
                Instantiate(enemy, new Vector2(xPos1, yPos1), Quaternion.identity);
                Instantiate(enemy, new Vector2(xPos2, yPos2), Quaternion.identity);
                Instantiate(enemy, new Vector2(xPos3, yPos3), Quaternion.identity);
                Instantiate(enemy, new Vector2(xPos4, yPos4), Quaternion.identity);
                EnemyCount.totalEnemyCount += 4;
                time = 10;
            }
            if(EnemyCount.clock <= 21) {
                waveNum.text = "Wave 2 / 3";
            }
            if(EnemyCount.clock <= 11) {
                waveNum.text = "Wave 3 / 3";
            }

            Debug.Log(EnemyCount.currentEnemyCount + " / " + EnemyCount.totalEnemyCount);
        }
    }
}
