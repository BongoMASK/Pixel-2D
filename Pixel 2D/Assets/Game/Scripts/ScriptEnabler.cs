using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnabler : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = player.transform.position;
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")) {
            other.GetComponent<Enemy>().enabled = true;
            other.GetComponent<EnemyMovement>().enabled = true;
        }
    }
    void OnTriggerExit2D (Collider2D other) {
        if(other.CompareTag("Enemy")) {
            other.GetComponent<Enemy>().enabled = false;
            other.GetComponent<EnemyMovement>().enabled = false;
        }
    }
}
