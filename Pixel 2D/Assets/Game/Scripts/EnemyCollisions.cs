using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class EnemyCollisions : MonoBehaviour
{
    ParticleSystem particle;
    SpriteRenderer sr;
    public GameObject sprites;
    BoxCollider2D bc;
    Enemy enemy;
    EnemyMovement enemyMovement;

    void Awake()
    {   
        sprites.SetActive(true);
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponentInChildren<SpriteRenderer>();
        bc = GetComponentInChildren<BoxCollider2D>();
        enemyMovement = GetComponent<EnemyMovement>();
        enemy = GetComponent<Enemy>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("PlayerBullet")) {
            GameManager.data = GameManager.data + 200; 
        }
        if(other.CompareTag("Wall")) {
            GameManager.data = GameManager.data + 50;
        }
        if(other.CompareTag("Bullet")) {
            GameManager.data = GameManager.data + 300;
        }
        //give data for collateral kills, too - 400, enemy collateral - 500
        if(other.CompareTag("PlayerBullet") || other.CompareTag("Bullet") || other.CompareTag("Wall")) {
            StartCoroutine(Destruct());
            Debug.Log("data is: " + GameManager.data);
        }
    }
    IEnumerator Destruct() {
        sprites.SetActive(false);
        sr.enabled = false;
        bc.enabled = false;
        enemyMovement.enabled = false;
        enemy.enabled = false;
        particle.Play();
        CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0.5f;

        yield return new WaitForSeconds(0.05f);
        Time.timeScale = 1;

        yield return new WaitForSeconds (0.8f);
        Destroy(gameObject);
    }
}
