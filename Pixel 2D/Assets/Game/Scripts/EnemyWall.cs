using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWall : MonoBehaviour
{
    float x1, x2, y1, y2;
    Animator animator;
    public Vector2 wallFall;
    Rigidbody2D rb;
    public bool wallTrigger;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        x2 = transform.position.x;
        y2 = transform.position.y;
    }

    void FixedUpdate()
    {
        //animator.SetBool("wallTrigger", wallTrigger);   

        if(wallTrigger) {
            rb.velocity = wallFall * Time.fixedDeltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Respawn")) {
            wallTrigger = true;
            //fall();
        }
    }
    void fall() {
        //rb.gravityScale = 1;
        rb.velocity = wallFall * Time.deltaTime;
    }
}
