using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class Movement : MonoBehaviour
{
    public static float playerSpeed = 725f;
    public float speed = 725f, time;
    public GameObject lostCanvas, sr, spriteLight, damagePoints;
    public static bool restartBool, difficult = false, isHit = false;
    bool start;
    int health, data, MoneyDropped, powerUpTime;
    int healthData, moneyDroppedData, powerUpTimeData;
    private Rigidbody2D rb;
    private Vector2 moveVelocity4, mousePos, playerPos;
    GameObject playerCollision;
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
        Upgrades.isTripleShoot = false;
        isHit = false;
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
            StartCoroutine(damagePoint(GameManager.totalHealth, Color.red, "-"));
        }
        if(col.CompareTag("Data")) {
            Destroy(col.gameObject);
            int number = (int) GameManager.MoneyDropped * 2;
            GameManager.data = GameManager.data + number;
            StartCoroutine(damagePoint(number, Color.green, "+"));
            Debug.Log("data is: " + GameManager.data);
        }
        if(col.CompareTag("Triple Shoot")) {
            Destroy(col.gameObject);
            StartCoroutine(Upgrades.TripleShoot());
        }
    }

    IEnumerator damagePoint(int number, Color colorName, string text) {
        GameObject d = Instantiate(damagePoints, transform.position, Quaternion.identity) as GameObject;
        TextMesh dText = d.GetComponentInChildren<TextMesh>();
        dText.text = text + number;
        dText.color = colorName;

        yield return new WaitForSeconds(3f);
        Destroy(d);        
    }

    IEnumerator hit() {
        GameManager.health = GameManager.health - 26;
        CameraShaker.Instance.ShakeOnce(4f, 2.5f, 0.1f, 1f);
        spriteLight.SetActive(false);

        StartCoroutine(damagePoint(25, Color.red, "-"));
        
        isHit = true;
        bc.enabled = false;

        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0.2f;

        yield return new WaitForSeconds(0.1f);
        spriteLight.SetActive(true);
        Time.timeScale = 1;
                
        yield return new WaitForSeconds(3f);
        isHit = false;
        bc.enabled = true;
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
    public void GameLost() {
        lostCanvas.SetActive(true);        
        Time.timeScale = 0f;
    }
    IEnumerator Explosion() {
        Debug.Log("deaths: " + GameManager.deaths);
        GameManager.health = 0;
        particle.Play();

        spriteLight.SetActive(false);
        sr.SetActive(false);
        bc.enabled = false;
        speed = 0;
        restartBool = true;
        isHit = true;
        CameraShaker.Instance.ShakeOnce(1f, 20f, 0.1f, 1f);
        //CameraShaker.Instance.ShakeOnce( );
        Time.timeScale = 0.2f;

        yield return new WaitForSeconds(0.2f);
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