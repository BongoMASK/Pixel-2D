using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class Movement : MonoBehaviour
{
    public static float playerSpeed = 725f;
    public float speed = 725f, time;
    public GameObject lostCanvas, sr, powerParticle, spriteLight, electricity;
    public static bool restartBool, difficult = false;
    bool start;
    public int health, data, MoneyDropped, powerUpTime;
    public int healthData, moneyDroppedData, powerUpTimeData;
    private Rigidbody2D rb;
    private Vector2 moveVelocity4, mousePos, playerPos;
    GameObject playerCollision;     public ParticleSystem particle1;
    ParticleSystem particle;      BoxCollider2D bc;     

    void Awake() {
        health = GameManager.totalHealth;
        data = GameManager.data;

        MoneyDropped = (int) GameManager.MoneyDropped;
        powerUpTime = GameManager.powerUpTime;
        GameManager.health = GameManager.totalHealth;

        healthData = GameManager.healthData;
        moneyDroppedData = GameManager.moneyDroppedData;
        powerUpTimeData = GameManager.powerUpTimeData;
        
        start = true;
        
        particle = GetComponentInChildren<ParticleSystem>();
        bc = GetComponent<BoxCollider2D>();
    }
    void Start() {
        Time.timeScale = 0f;
        lostCanvas.SetActive(false);
        restartBool = false;

        rb = GetComponent<Rigidbody2D>();

        playerCollision = GameObject.FindGameObjectWithTag("Respawn");
    }

    void Update() {

        Debug.Log("Health:" + GameManager.health);
        playerCollision.transform.position = transform.position;

        if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !start) {
            Time.timeScale = 1f;
            Pause.Canvas.SetActive(false);
            start = true;
        }

    }
    void FixedUpdate() {

        Move();

        if(GameManager.health <= 0) {
            StartCoroutine(Explosion());
        }
    }   
    void OnTriggerEnter2D(Collider2D col) {

        if(col.CompareTag("Bullet")) {
            StartCoroutine(hit());   
        }
        if(col.CompareTag("Wall") || col.CompareTag("Enemy")) {
            StartCoroutine(Explosion());
        }
        if(col.CompareTag("Data")) {
            Destroy(col.gameObject);
            GameManager.data = GameManager.data + 50;
            Debug.Log("data is: " + GameManager.data);
        }
    }
    IEnumerator hit() {
        GameManager.health = GameManager.health - 26;
        CameraShaker.Instance.ShakeOnce(4f, 2.5f, 0.1f, 1f);
        //CameraShaker.Instance.ShakeOnce( );
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0.2f;

        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 1;
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
        Debug.Log("deaths: " + GameManager.deaths);
        particle.Play();

        spriteLight.SetActive(false);
        sr.SetActive(false);
        bc.enabled = false;
        speed = 0;
        restartBool = true;
        CameraShaker.Instance.ShakeOnce(4f, 12f, 0.1f, 1f);
        //CameraShaker.Instance.ShakeOnce( );
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0.2f;

        yield return new WaitForSeconds(0.3f);
        GameLost();        
        GameManager.deaths = GameManager.deaths + 1;
        GameManager.data = data;
        
        GameManager.totalHealth = health;
        GameManager.MoneyDropped = MoneyDropped;
        GameManager.powerUpTime = powerUpTime;

        GameManager.healthData = healthData;
        GameManager.moneyDroppedData = moneyDroppedData;
        GameManager.powerUpTimeData = powerUpTimeData;

    }
}