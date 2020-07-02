using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameObject player;
    Vector2 moveVelocity;
    public static float enemySpeed = 200;
    Rigidbody2D rb;
    public bool isTrigger;
    float rotation;
    
    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        enemySpeed = 200;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }
    void Move() {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, Enemy.rotation);
        Vector2 moveInput = player.transform.position - transform.position;
        rotation = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;        
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
        moveVelocity = moveInput.normalized * enemySpeed;
        if(isTrigger) {                             //used boolean coz the movement doesnt update in OnTriggerEnter
            rb.velocity = moveVelocity * Time.fixedDeltaTime;
        }
        else {
            rb.velocity = new Vector2(0,0);
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Respawn")) {
            isTrigger = true;
            GetComponent<Enemy>().enabled = true;    
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Respawn")) {
            isTrigger = true;
            GetComponent<Enemy>().enabled = false;    
        }
    }
}
