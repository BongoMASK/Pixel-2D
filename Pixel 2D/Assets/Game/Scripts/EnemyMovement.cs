﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameObject player;
    Vector2 moveVelocity, playerPos;
    public float enemySpeed1;
    public static float enemySpeed = 110;
    Rigidbody2D rb;
    public bool isTrigger;
    public static bool isTriggered;
    float rotation;
    public Animator animator;
    
    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        enemySpeed = enemySpeed1;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        playerPos = new Vector2(player.transform.position.x, player.transform.position.y);

        Move();
        animator.SetBool("isTrigger", isTrigger);
    }
    void Move() {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, Enemy.rotation);
        Vector2 moveInput = player.transform.position - transform.position;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
        moveVelocity = moveInput.normalized * enemySpeed;
        if(isTrigger) {                             //used boolean coz the movement doesnt update in OnTriggerEnter
            rb.velocity = moveVelocity * Time.fixedDeltaTime;
            rotation = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;        
        }
        else {
            rb.velocity = new Vector2(0,0);
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Respawn")) {
            isTrigger = true;
            isTriggered = true;
            GetComponent<Enemy>().enabled = true;    
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Respawn")) {
            isTrigger = true;
            isTriggered = false;
            GetComponent<Enemy>().enabled = false;    
        }
    }
}
