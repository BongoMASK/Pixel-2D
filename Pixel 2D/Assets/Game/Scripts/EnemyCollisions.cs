using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class EnemyCollisions : MonoBehaviour
{
    ParticleSystem particle;
    SpriteRenderer sr;
    public GameObject sprites, spriteLight, dataPoints;
    BoxCollider2D bc;
    Enemy enemy;
    EnemyMovement enemyMovement;
    public bool glitch;
    AudioSource explosionSound;

    void Awake()
    {   
        sprites.SetActive(true);
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponentInChildren<SpriteRenderer>();
        bc = GetComponentInChildren<BoxCollider2D>();
        enemyMovement = GetComponent<EnemyMovement>();
        explosionSound = GetComponent<AudioSource>();
        enemy = GetComponent<Enemy>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("PlayerBullet") && (glitch == false)) {
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

    IEnumerator Destruct(float multiplier) {
        explosionSound.Play();
        int data = (int) (GameManager.MoneyDropped * multiplier);

        EnemyCount.currentEnemyCount = EnemyCount.currentEnemyCount - 1;

        GameObject d = Instantiate(dataPoints, transform.position, Quaternion.identity) as GameObject;
        TextMesh dText = d.GetComponentInChildren<TextMesh>();
        dText.text = "+" + data;

        spriteLight.SetActive(false);
        sprites.SetActive(false);
        sr.enabled = false;
        bc.enabled = false;
        enemyMovement.enabled = false;
        enemy.enabled = false;
        particle.Play();

        CameraShaker.Instance.ShakeOnce(3f, 20f, 0.1f, 1f);
        GameManager.data = GameManager.data + data;

        yield return new WaitForSeconds (1f);
        Destroy(gameObject);
        //EnemyCount.currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length - 1;
        Destroy(d);
        
    }
}
