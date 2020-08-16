using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : MonoBehaviour
{
    Vector2 playerPos, mousePos, moveVelocity4, wormPosition;
    Vector2[] playerLastPosition;
    Rigidbody2D rb;
    public GameObject[] subset;
    public float speed;
    public float time;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        wormRotation();
        StartCoroutine(setPosition());
        subsetPosition();
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
    
    public IEnumerator setPosition() {
        Vector2 playerPos = transform.position;      //same as above
        for(int i = 0; i <= 5; i++) {
            yield return new WaitForSeconds(time * (i+1));          
            playerLastPosition[i] = transform.position;
        }
    }

    public void subsetPosition() {
        for(int i = 0; i <= subset.Length; i++) {
            subset[i].transform.position = playerLastPosition[i];
        }
    }
    /*public List<transform> BodyParts = new List<transform>();
    public float minDistance = 0.25f;

    public float speed = 1;
    public float rotationSpeed = 50;

    public GameObject bodyPrefab;

    private float dis;
    private transform curBodyPart;
    private transform PrevBodyPart;

    void Start() {

    }

    void Update() {

    }

    public void AddBodyPart() {
        transform newPart = (Instantiate(bodyPrefab, BodyParts[BodyParts.Count - 1].position, [BodyParts.Count - 1].rotation) as GameObject).transform;
        newPart.SetParent(transform);
        BodyParts.Add(newPart);
    }*/
}