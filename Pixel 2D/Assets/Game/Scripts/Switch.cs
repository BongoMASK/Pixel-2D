using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject wall;
    public static bool isCollided = false;
    EnemyWall wallScript;
     Animator animator;

    void Start()
    {
        //wallScript.enabled = false;
        wallScript = wall.GetComponent<EnemyWall>();
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Player")) {
            if(isCollided == true) {
                wallScript.enabled = false;
                isCollided = false;
                Debug.Log("Collsion: " + isCollided);
            }
            else {
                wallScript.enabled = true;
                isCollided = true;
                Debug.Log("Collsion: " + isCollided);
            }
            animator.SetBool("ON", isCollided);
        }
    }   
}
