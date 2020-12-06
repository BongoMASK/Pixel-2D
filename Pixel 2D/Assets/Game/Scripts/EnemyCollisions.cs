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
    public bool glitch, boss;
    AudioSource explosionSound;
    int i = 0;
    public int bossHealth, damage, bossHealth2;
    public static bool bossIsDead;
    public Vector2 newPos;
    public Slider slider;

    void Awake()
    {   
        bossIsDead = false;
        sprites.SetActive(true);
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponentInChildren<SpriteRenderer>();
        bc = GetComponentInChildren<BoxCollider2D>();
        enemyMovement = GetComponent<EnemyMovement>();
        explosionSound = GetComponent<AudioSource>();
        enemy = GetComponent<Enemy>();
    }

    void Start() {
        if (boss) {
            bossHealth2 = bossHealth;
            slider.maxValue = bossHealth;
        }
    }

    void Update() {
        if (boss) {
            slider.value = bossHealth;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(boss == false) {
            if(other.CompareTag("PlayerBullet") && (glitch == false)) {
                StartCoroutine(Destruct(1f));
            }
            if(other.CompareTag("Wall")) {
                StartCoroutine(Destruct(0.25f));
            }
            if(other.CompareTag("Bullet")) {
                StartCoroutine(Destruct(1.5f));
            }
        }
        else {
            if(other.CompareTag("PlayerBullet"))  {
                Destroy(other.gameObject);
                bossHit();
            }
        }
        //TODO: give data for collateral kills, too - +10
       
    }

    void bossHit() {
        bossHealth = bossHealth - damage;
        Vector2 pos = newPos + new Vector2(transform.position.x, transform.position.y);
        damagePoint(bossHealth2 - bossHealth, Color.red, "-", pos);
        if(bossHealth <= 0) {
            StartCoroutine(Destruct(5f));
            bossIsDead = true;
        }
    }

    /*IEnumerator bossDestruct(float multiplier) {
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
        EnemyCount.currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length - 1;
        Destroy(d);
    }*/

    void damagePoint(int number, Color colorName, string text, Vector2 pos) {
        GameObject d = Instantiate(dataPoints, pos, Quaternion.identity) as GameObject;
        TextMesh dText = d.GetComponentInChildren<TextMesh>();
        dText.text = text + number;
        dText.color = colorName;
        Destroy(d, 3f);
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
        EnemyCount.currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length - 1;
        Destroy(d);
        
    }
}
