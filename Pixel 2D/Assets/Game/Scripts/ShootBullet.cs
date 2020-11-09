using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ShootBullet : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public GameObject shootingPoint;
    public float bulletSpeed = 30.0f, fireCountdown;
    int enemiesKilled;
    Animator animator;
    bool isShoot = false;
    
    void Awake() {
        animator = GetComponent<Animator>();
    }
    void Update() {
        animator.SetBool("isShoot", isShoot);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);

        if (Movement.restartBool) {
            mousePos = new Vector2(0, 0);
        }

        //Vector2 direction = new Vector2 (1, 0);
        Vector2 direction = mousePos - playerPos;

        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
        direction.Normalize();
        
        //insane bullet amount
        if((Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) && GameManager.bulletNo > 0) {  //bulletShoot
            EnemyGlitch.isShoot = true;
            if (fireCountdown <= 0f) {
                shootBullet(direction, rotation);
                CameraShaker.Instance.ShakeOnce(1f, 10f, 0.1f, 0.5f);
                GameManager.bulletNo = GameManager.bulletNo - 1;
                //Debug.Log("Bullets: " + GameManager.bulletNo + "/" + GameManager.totalBullets + " left");
                fireCountdown = 0.1f;
            }

            //shootBullet(direction, rotation);
            
        }
        fireCountdown -= Time.deltaTime;
/*
        //lesser bullets
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && GameManager.bulletNo > 0) {  //bulletShoot
            EnemyGlitch.isShoot = true;
            shootBullet(direction, rotation);
            //CameraShaker.Instance.ShakeOnce(1f, 20f, 0.1f, 1f);
            GameManager.bulletNo = GameManager.bulletNo - 1;
            //Debug.Log("Bullets: " + GameManager.bulletNo + "/" + GameManager.totalBullets + " left");
        }*/
    }

    void shootBullet(Vector2 direction, float rotation) {
        //yield return new WaitForSeconds(time);
        Vector3 offset = new Vector3(0, 1, 0);

        if(Upgrades.isTripleShoot == true) {
            GameObject b1 = Instantiate(bullet) as GameObject;   //here, b is a subset of the bullet prefab
            b1.transform.position = shootingPoint.transform.position - offset;
            b1.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation - 45);
            b1.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed; 

            GameObject b2 = Instantiate(bullet) as GameObject;   //here, b is a subset of the bullet prefab
            b2.transform.position = shootingPoint.transform.position + offset;
            b2.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation + 45);
            b2.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed; 

            GameObject b3 = Instantiate(bullet) as GameObject;   //here, b is a subset of the bullet prefab
            b3.transform.position = shootingPoint.transform.position;
            b3.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
            b3.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed; 
        }
        else {
            GameObject b = Instantiate(bullet) as GameObject;
            b.transform.position = shootingPoint.transform.position;
            b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
            b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }

    
    /*void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Enemy")) {
            GameManager.enemiesKilled = GameManager.enemiesKilled + 1;
            Debug.Log("collateral Kill: X" + GameManager.enemiesKilled);
        }
    }*/
}
