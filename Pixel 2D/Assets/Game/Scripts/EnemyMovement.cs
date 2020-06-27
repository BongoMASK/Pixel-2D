using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public static Vector2 moveVelocity;
    public float enemySpeed = 200;
    public static Rigidbody2D rb;
    
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
