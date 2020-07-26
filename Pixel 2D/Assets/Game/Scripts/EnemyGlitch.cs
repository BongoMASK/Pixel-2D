using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGlitch : MonoBehaviour
{
    Vector2 positionOffset, enemyPos;
    static Vector2 playerLastPosition;
    public GameObject enemy;
    GameObject player;
    float time = 5;
    Vector2 playerPos;
    bool glitch, isColliding;
    Animator animator;
    public ParticleSystem particle;
    public static bool isShoot;

    void Awake()
    {
        animator = enemy.GetComponentInParent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        animator.SetBool("glitch", glitch);
        
        StartCoroutine(setPosition());
        transform.position = enemy.transform.position;

        //playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        //enemyPos = new Vector2(enemy.transform.position.x, enemy.transform.position.y);
        //Vector2 minDistance = playerPos - enemyPos;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Respawn")) {
            StartCoroutine(executePositionChange(1.5f));
        }
        if(col.CompareTag("PlayerBullet")) {
            StartCoroutine(executePositionChange(0f));
        }
    }

    IEnumerator executePositionChange(float time) {
        Instantiate(particle, playerLastPosition, Quaternion.identity);
        glitch = true;
        Vector2 playerLastPositionFinal = playerLastPosition;

        yield return new WaitForSeconds(time);
        enemy.transform.position = playerLastPositionFinal;
        glitch = false;
    }
    
    public IEnumerator setPosition() {
        Vector2 playerPos = player.transform.position;
        yield return new WaitForSeconds(0.25f);           
        playerLastPosition = playerPos;
    }
}
