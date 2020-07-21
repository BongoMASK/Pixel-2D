using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGlitch : MonoBehaviour
{
    Vector2 positionOffset;
    GameObject player;
    float time = 5;
    Vector2 playerPos;
    bool glitch;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        animator.SetBool("glitch", glitch);

        playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 enemyPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 minDistance = playerPos - enemyPos;

    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Respawn")) {
            StartCoroutine(changePosition(playerPos));
        }
    }

    public IEnumerator changePosition(Vector2 playerPos) {
        yield return new WaitForSeconds(4.5f);
        positionOffset.x = Random.Range(-10, 10);
        positionOffset.y = Random.Range(-7, 7);
        glitch = true;
        Debug.Log(glitch);

        yield return new WaitForSeconds(5f);
        glitch = false;
        transform.position = playerPos + positionOffset;

        Debug.Log(glitch);
        Debug.Log("position Changed to: " + transform.position);
        Debug.Log(positionOffset);
    }
}
