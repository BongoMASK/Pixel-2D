using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    public GameObject bullet;
    public static float bulletSpeed = 30;
    Vector3 difference;
    public static float rotation;
    public float fireRate = 1.0f;
    public float fireCountdown = 0.0f;
    public GameObject shooter;
    public float time;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        bulletSpeed = 30f;
    }
    void Update()
    {
        difference = player.transform.position - transform.position;
        rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;        
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
        difference.Normalize();      //normalize is used to not increase speed by certain calculation errors
        if(fireCountdown <= 0.0f) {   //basically, normalize is x/|x|.
            StartCoroutine(shootBullet(difference, rotation));
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }
    IEnumerator shootBullet(Vector2 direction, float rotation) {
        yield return new WaitForSeconds(time);
        GameObject b = Instantiate(bullet) as GameObject;   //here, b is a subset of the bullet prefab
        b.transform.position = shooter.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        StopCoroutine(shootBullet(direction, rotation));
    }
}
