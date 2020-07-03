using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    int xPos1, xPos2, xPos3, xPos4;
    int yPos1, yPos2, yPos3, yPos4;
    float time = 0f;
    Text waveNum;
    public GameObject waveText;

    void Update() {  
        if(EnemyCount.clock > 0) {
            waveNum = waveText.GetComponent<Text>();
            waveNum.text = "Wave 1 / 3";
            time -= Time.deltaTime; 
            xPos1 = -9; yPos1 = 17;
            xPos2 = -29; yPos2 = 6;
            xPos3 = 8; yPos3 = 6;
            xPos4 = -9; yPos4 = -6;
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
        }
    }
}
