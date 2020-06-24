using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnabler : MonoBehaviour
{
    GameObject player;
    public GameObject[] enemy;
    int n;
    int l;
    private bool collide;
    string enemyName = "Enemy (Moving) (1)";

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        for(n = 0; n <= enemy.Length; n++) {
            enemy[n].GetComponent<Enemy>().enabled = false;
        }
    }

    void Update()
    {
        transform.position = player.transform.position;

        if(collide) {
            for(n = l; n <= l; n++) {
                enemy[n].GetComponent<Enemy>().enabled = true;
                enemy[n].GetComponent<EnemyMovement>().enabled = true;
                //enemyName.Replace(l.ToString(), (l + 1).ToString());
                Debug.Log(enemyName + " enabled");
            }
        }
        if(!collide) {
            for(n = l; n <= l; n++) {
                enemy[n].GetComponent<Enemy>().enabled = false;
                enemy[n].GetComponent<EnemyMovement>().enabled = false;
                //enemyName.Replace(l.ToString(), l + 1.ToString());
                Debug.Log(enemyName + " disabled");
            }
        }
    }
    //Very stupid way of coding this
    //Takes way too much time to make changes
    //tried string editing to change it 
    //Spoiler Alert: didnt work
    //very inefficient
    //sorry, Zuckerberg! I suck at coding lmao!
    void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.name == "Enemy (Moving)") {
            l = 0;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (1)") {
            l = 1;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (2)") {
            l = 2;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (3)") {
            l = 3;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (4)") {
            l = 4;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (5)") {
            l = 5;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (6)") {
            l = 6;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (7)") {
            l = 7;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (8)") {
            l = 8;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (9)") {
            l = 9;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (10)") {
            l = 10;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (11)") {
            l = 11;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (12)") {
            l = 12;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (13)") {
            l = 13;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (14)") {
            l = 14;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (15)") {
            l = 15;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (16)") {
            l = 16;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (17)") {
            l = 17;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (18)") {
            l = 18;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (19)") {
            l = 19;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (20)") {
            l = 20;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (21)") {
            l = 21;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (22)") {
            l = 22;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (23)") {
            l = 23;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (24)") {
            l = 24;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (25)") {
            l = 25;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (26)") {
            l = 26;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (27)") {
            l = 27;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (28)") {
            l = 28;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (29)") {
            l = 29;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (30)") {
            l = 30;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (31)") {
            l = 31;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (32)") {
            l = 32;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (33)") {
            l = 33;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (34)") {
            l = 34;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (35)") {
            l = 35;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (36)") {
            l = 36;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (37)") {
            l = 37;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (38)") {
            l = 38;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (39)") {
            l = 39;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (40)") {
            l = 40;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (41)") {
            l = 41;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (42)") {
            l = 42;
            collide = true;
        }
        if(other.gameObject.name == "Enemy (Moving) (43)") {
            l = 43;
            collide = true;
        }
    }
    void OnTriggerExit2D (Collider2D other) {
        //this is the string editing i tried
        //results showed that string did not change in the first place

        /*string enemyName = "Enemy (Moving) (1)";
        for(int i = 1; i <= enemy.Length; i++) {
            if(other.gameObject.name.Equals(enemyName)) {
                l = i;
                collide = false;
            }
        }*/
        if(other.gameObject.name == "Enemy (Moving)") {
            l = 0;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving)") {
            l = 0;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (1)") {
            l = 1;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (2)") {
            l = 2;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (3)") {
            l = 3;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (4)") {
            l = 4;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (5)") {
            l = 5;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (6)") {
            l = 6;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (7)") {
            l = 7;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (8)") {
            l = 8;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (9)") {
            l = 9;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (10)") {
            l = 10;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (11)") {
            l = 11;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (12)") {
            l = 12;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (13)") {
            l = 13;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (14)") {
            l = 14;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (15)") {
            l = 15;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (16)") {
            l = 16;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (17)") {
            l = 17;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (18)") {
            l = 18;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (19)") {
            l = 19;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (20)") {
            l = 20;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (21)") {
            l = 21;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (22)") {
            l = 22;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (23)") {
            l = 23;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (24)") {
            l = 24;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (25)") {
            l = 25;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (26)") {
            l = 26;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (27)") {
            l = 27;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (28)") {
            l = 28;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (29)") {
            l = 29;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (30)") {
            l = 30;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (31)") {
            l = 31;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (32)") {
            l = 32;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (33)") {
            l = 33;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (34)") {
            l = 34;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (35)") {
            l = 35;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (36)") {
            l = 36;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (37)") {
            l = 37;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (38)") {
            l = 38;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (39)") {
            l = 39;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (40)") {
            l = 40;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (41)") {
            l = 41;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (42)") {
            l = 42;
            collide = false;
        }
        if(other.gameObject.name == "Enemy (Moving) (43)") {
            l = 43;
            collide = false;
        }
    }
}
