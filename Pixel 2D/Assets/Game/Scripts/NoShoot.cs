using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoShoot : MonoBehaviour
{
    ShootBullet shootBullet;    

    void Start()
    {
        shootBullet = GetComponent<ShootBullet>();
    }

    void Update()
    {
        if(Time.timeScale == 0) {
            shootBullet.enabled = false;
        }
        else {
            shootBullet.enabled = true;
        }
    }
}
