using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public GameObject shootingPoint;
    public float bulletSpeed = 30.0f;
    int enemiesKilled;
    
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);

        if(Movement.restartBool) {
            mousePos = new Vector2(0, 0);
        }

        //Vector2 direction = new Vector2 (1, 0);
        Vector2 direction = mousePos - playerPos;
        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
        direction.Normalize();
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
            shootBullet(direction, rotation);
        }
    }
    void shootBullet(Vector2 direction, float rotation) {
        //yield return new WaitForSeconds(time);
        GameObject b = Instantiate(bullet) as GameObject;
        b.transform.position = shootingPoint.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        enemiesKilled = enemiesKilled + 1;
    }
}
