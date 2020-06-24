using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class Movement : MonoBehaviour
{
    public static float playerSpeed = 725f;
    public float speed = 725f;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Vector2 moveVelocity2;
    private Vector2 moveVelocity3;
    private Vector2 moveVelocity4;
    private Vector2 mousePos;
    private Vector2 playerPos;
    public static bool restartBool;
    private bool isLost = false;
    private Animator animator;
    public float time;
    public GameObject lostCanvas;

    void Start() {
        Time.timeScale = 0f;
        lostCanvas.SetActive(false);
        restartBool = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        //speed = playerSpeed;
        if(Input.GetKeyDown(KeyCode.Space)) {
            Time.timeScale = 1f;
            Pause.Canvas.SetActive(false);
            Debug.Log("Start");
        }
        if(Input.GetMouseButtonDown(0)) {
            Time.timeScale = 1f;
            Pause.Canvas.SetActive(false);
        }
        animator.SetBool("Collide", restartBool);

        if(isLost) {
            GameLost();
        }
    }
    void FixedUpdate() {
        playerPos = new Vector2(transform.position.x, transform.position.y);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Vector2 moveInput = new Vector2(1, 0);
        Vector2 moveInput = new Vector2(1, -1);
        //Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // here only for testing
        Vector2 moveInput2 = new Vector2(1, 1);
        Vector2 moveInput3 = new Vector2(1, -1);
        Vector2 moveInput4 = mousePos - playerPos;
        
        moveVelocity = moveInput.normalized * speed;
        moveVelocity2 = moveInput2.normalized * speed;
        moveVelocity3 = moveInput3.normalized * speed;
        moveVelocity4 = moveInput4.normalized * speed;

        //rbPosition = new Vector2(rb.position.x, rb.position.y);
        //rb.MovePosition(rbPosition + moveVelocity * Time.fixedDeltaTime);
        //rb.MovePosition(rbPosition + moveVelocity4 * Time.fixedDeltaTime);
        rb.velocity = moveVelocity4 * Time.fixedDeltaTime;
 
        /*if(Input.GetKey(KeyCode.Space)) 
           rb.MovePosition(rbPosition + moveVelocity2 * Time.fixedDeltaTime);
        if(Input.GetKey(KeyCode.W)) 
            rb.MovePosition(rbPosition + moveVelocity2 * Time.fixedDeltaTime);
        if(Input.GetKey(KeyCode.S)) 
            rb.MovePosition(rbPosition + moveVelocity3 * Time.fixedDeltaTime);*/
    }   
    void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Wall")) {
            speed = 0;
            restartBool = true;
            CameraShaker.Instance.ShakeOnce(8f, 8f, 0.1f, 1f);
            Debug.Log("destroyed " + col.gameObject.name);
            StartCoroutine(explosion());         
        }
        if(col.CompareTag("Bullet")) {
            speed = 0;
            restartBool = true;     
            CameraShaker.Instance.ShakeOnce(8f, 8f, 0.1f, 1f);
            Destroy(col.gameObject);
            Debug.Log("destroyed " + col.gameObject.name);
            StartCoroutine(explosion());
        }
        if(col.CompareTag("Enemy")) {
            speed = 0;
            restartBool = true;     
            CameraShaker.Instance.ShakeOnce(8f, 8f, 0.1f, 1f);
            Destroy(col.gameObject);
            Debug.Log("destroyed " + col.gameObject.name);
            StartCoroutine(explosion());
        }
    }
    public void GameLost() {
        lostCanvas.SetActive(true);        
        Time.timeScale = 0f;
    }
    IEnumerator explosion() {
        yield return new WaitForSeconds(time);
        isLost = true;
        //SceneManager.LoadScene("Level 1");
        //SceneManager.LoadScene("Restart");
        StopCoroutine(explosion());
    }
}