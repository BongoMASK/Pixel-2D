﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    public GameObject bullet;
    public float bulletSpeed;
    Vector3 difference;
    public static float rotation;
    public float fireCountdown = 0.4f;
    public GameObject shooter;
    bool isShoot;

    void Awake() {
        isShoot = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update() {
        //EnemyMovement.animator.SetBool("isShoot", isShoot);
        difference = player.transform.position - transform.position;
        rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;        
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation - 15);
        difference.Normalize();      //normalize is used to not increase speed by certain calculation errors
        if(fireCountdown <= -0.4f) {  //basically, normalize is x/|x|.
            shootBullet(difference, rotation);
            fireCountdown = 2f;
        }
        if(fireCountdown <= 0 && fireCountdown >= -0.4) {
            isShoot = true;
        }
        else {
            isShoot = false;
        }

        fireCountdown -= Time.deltaTime;
    }
    void shootBullet(Vector2 direction, float rotation) {
        GameObject b = Instantiate(bullet) as GameObject;   //here, b is a subset of the bullet prefab
        b.transform.position = shooter.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
