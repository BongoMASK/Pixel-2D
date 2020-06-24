using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    private Vector2 moveVelocity;
    public static float enemySpeed = 200;
    private Rigidbody2D rb;
    
    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        rb = enemy.GetComponent<Rigidbody2D>();
        enemySpeed = 200f;
    }

    void FixedUpdate()
    {
        Vector2 moveInput = player.transform.position - enemy.transform.position;
        moveVelocity = moveInput.normalized * enemySpeed;
        rb.velocity = moveVelocity * Time.fixedDeltaTime; 
    }
}
