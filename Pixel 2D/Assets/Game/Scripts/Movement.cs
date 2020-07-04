using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class Movement : MonoBehaviour
{
    public static float playerSpeed = 725f;
    public float speed = 725f, time;
    public GameObject lostCanvas;
    public static bool restartBool;
    public static bool difficult = false;
    bool start;
    public int health;
    private Rigidbody2D rb;
    private Vector2 moveVelocity4, mousePos, playerPos;
    GameObject playerCollision;
    ParticleSystem particle;    SpriteRenderer sr;      BoxCollider2D bc;

    void Awake() {
        start = false;
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }
    void Start() {
        health = 100;
        Time.timeScale = 0f;

        lostCanvas.SetActive(false);
        restartBool = false;

        rb = GetComponent<Rigidbody2D>();

        playerCollision = GameObject.FindGameObjectWithTag("Respawn");
    }

    void Update() {

        playerCollision.transform.position = transform.position;

        if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !start) {
            Time.timeScale = 1f;
            Pause.Canvas.SetActive(false);
            start = true;
        }

    }
    void FixedUpdate() {

        Move();
        if(health < 100) {
            health = health + 1;
        }
        if(health <= 0) {
            StartCoroutine(Explosion());
        }  
    }   
    void OnTriggerEnter2D(Collider2D col) {

        if(col.CompareTag("Bullet")) {
            if(difficult) {
                //easy difficulty
                hit();
            }
            else {
                //hard difficulty
                StartCoroutine(Explosion());
            }
        }
        if(col.CompareTag("Wall") || col.CompareTag("Enemy")) {
            StartCoroutine(Explosion());
        }
    }
    void hit() {
        health = health - 25;
    }
    public void Move() {
        playerPos = new Vector2(transform.position.x, transform.position.y);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  

        Vector2 moveInput4 = mousePos - playerPos;   
        moveVelocity4 = moveInput4.normalized * speed;
        rb.velocity = moveVelocity4 * Time.fixedDeltaTime;
    }
    public void GameLost() {
        lostCanvas.SetActive(true);        
        Time.timeScale = 0f;
    }
    IEnumerator Explosion() {
        particle.Play();
        sr.enabled = false;
        bc.enabled = false;
        speed = 0;
        restartBool = true;
        CameraShaker.Instance.ShakeOnce(8f, 8f, 0.1f, 1f); 

        yield return new WaitForSeconds(time);
        GameLost();        
    }
}