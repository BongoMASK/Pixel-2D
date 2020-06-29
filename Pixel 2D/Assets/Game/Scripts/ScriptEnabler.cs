using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnabler : MonoBehaviour
{
    public EnemyMovement enemyMovement;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = player.transform.position;
    }

    /*void OnTriggerEnter2D(Collider2D other) {
        /*if(other.CompareTag("Shooter")) {
            other.gameObject.SetActive(true);
            //other.GetComponent<Enemy>().enabled = true;         //enabling Scripts
            other.GetComponent<EnemyMovement>().enabled = true;
        }
        if(other.CompareTag("Enemy")) {

            other.GetComponent<Enemy>().enabled = true;
            enemyMovement.enemySpeed = 0;
        }
    }
    void OnTriggerExit2D (Collider2D other) {
        /*if(other.CompareTag("Shooter")) {
            other.gameObject.SetActive(false);
            //other.GetComponent<Enemy>().enabled = false;            //enabling Scripts
            other.GetComponent<EnemyMovement>().enabled = false;
        }
        if(other.CompareTag("Enemy")) {
            other.GetComponent<Enemy>().enabled = false;
            enemyMovement.enemySpeed = 200;
        }
    }*/
}
