using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class EnemyCollisions : MonoBehaviour
{
    ParticleSystem particle;
    SpriteRenderer sr;
    public GameObject sprites, spriteLight;
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
            StartCoroutine(Destruct(1f));
        }
        if(other.CompareTag("Wall")) {
            StartCoroutine(Destruct(0.25f));
        }
        if(other.CompareTag("Bullet")) {
            StartCoroutine(Destruct(1.5f));
        }
        //give data for collateral kills, too - 400, enemy collateral - 500
        
    }
    void dataReceived(float multiplier) {
        GameManager.data = GameManager.data + (int) (GameManager.MoneyDropped * multiplier); 
        
    }
    IEnumerator Destruct(float multiplier) {
        GameManager.data = GameManager.data + (int) (GameManager.MoneyDropped * multiplier); 
        spriteLight.SetActive(false);
        sprites.SetActive(false);
        sr.enabled = false;
        bc.enabled = false;
        enemyMovement.enabled = false;
        enemy.enabled = false;
        particle.Play();
        CameraShaker.Instance.ShakeOnce(3f, 12f, 0.3f, 1f);
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0.5f;

        yield return new WaitForSeconds(0.05f);
        Time.timeScale = 1;

        yield return new WaitForSeconds (0.8f);
        Destroy(gameObject);
    }
}
