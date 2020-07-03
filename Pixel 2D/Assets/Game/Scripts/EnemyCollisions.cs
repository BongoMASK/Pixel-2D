using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class EnemyCollisions : MonoBehaviour
{
    ParticleSystem particle;
    SpriteRenderer sr;
    BoxCollider2D bc;
    Enemy enemy;
    EnemyMovement enemyMovement;

    void Awake()
    {   
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponentInChildren<SpriteRenderer>();
        bc = GetComponentInChildren<BoxCollider2D>();
        enemyMovement = GetComponent<EnemyMovement>();
        enemy = GetComponent<Enemy>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("PlayerBullet") || other.CompareTag("Bullet") || other.CompareTag("Wall")) {
            StartCoroutine(Destruct());
        }
    }
    IEnumerator Destruct() {
        sr.enabled = false;
        bc.enabled = false;
        enemyMovement.enabled = false;
        enemy.enabled = false;
        particle.Play();
        CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);

        yield return new WaitForSeconds (0.8f);
        Destroy(gameObject);
    }
}
