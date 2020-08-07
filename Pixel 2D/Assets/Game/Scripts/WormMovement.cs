using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : MonoBehaviour
{
    Vector2 playerPos, mousePos, moveVelocity4;
    Rigidbody2D rb;
    public float speed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        wormRotation();
    }

    public void Move() {
        playerPos = new Vector2(transform.position.x, transform.position.y);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  

        Vector2 moveInput4 = mousePos - playerPos;   
        Vector2 moveInput3 = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        moveVelocity4 = moveInput4.normalized * speed;
        //moveVelocity4 = moveInput3.normalized * speed;
        rb.velocity = moveVelocity4 * Time.fixedDeltaTime;
    }

    public void wormRotation() {
        Vector2 direction = mousePos - playerPos;
        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
    }
}
