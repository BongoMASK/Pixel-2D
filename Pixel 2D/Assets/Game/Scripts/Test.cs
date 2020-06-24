using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public float bulletSpeed = 30;
    public float enemySpeed;
    private Rigidbody2D rb;
    Vector3 difference;
    float rotation;
    private bool collide = false;
    public float fireRate = 1.0f;
    public float fireCountdown = 0.0f;
    public GameObject enemy;
    public GameObject shooter;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        difference = player.transform.position - enemy.transform.position;
        rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;        
        enemy.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
        transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

        /*float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();*/
        difference.Normalize();
        if(collide && fireCountdown <= 0.0f) {
            rb.velocity = difference * enemySpeed * Time.deltaTime;
            StartCoroutine(shootBullet(difference, rotation));
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }
    public void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player") {
            collide = true;
            Debug.Log("collided " + collider.gameObject.name);
        }
    }
    public void OnTriggerExit2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player") {
            collide = false;
            Debug.Log("collided " + collider.gameObject.name);
        }
    }
    IEnumerator shootBullet(Vector2 direction, float rotation) {
        yield return new WaitForSeconds(time);
        GameObject b = Instantiate(bullet) as GameObject;
        b.transform.position = shooter.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        StopCoroutine(shootBullet(direction, rotation));
    }
}
