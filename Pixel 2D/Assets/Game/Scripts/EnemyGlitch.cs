using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGlitch : MonoBehaviour
{
    Vector2 positionOffset, enemyPos;
    public static Vector2 playerLastPosition;  //static variables have only 1 copy of themselves throughout the code
    public GameObject enemy;
    GameObject player;
    public float time;
    Vector2 playerPos;
    bool glitch, isColliding;
    Animator animator;
    //public GameObject afterImage;
    public ParticleSystem particle;
    public static bool isShoot;

    void Awake()
    {
        //playerLastPosition = player.transform.position;
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
        /*if(col.CompareTag("Respawn")) {
            StartCoroutine(executePositionChange(1.5f));
        }*/
        if(col.CompareTag("PlayerBullet")) {
            StartCoroutine(executePositionChange(0f));
        }
    }

    IEnumerator executePositionChange(float time) {
        //GameObject _particleGameObject = Instantiate(particle, playerLastPosition, Quaternion.identity) as GameObject;
        //ParticleSystem _particle = _particleGameObject.GetComponentInChildren<ParticleSystem>();
        //Instantiate(particle, playerLastPosition, Quaternion.identity);
        //particle.transform.position = playerLastPosition;
        //particle.Play();
        glitch = true;                                          //playerLastPosition updates more in the process
        Vector2 playerLastPositionFinal = playerLastPosition;   //so declaring a new variable will not update it

        yield return new WaitForSeconds(time);
        enemy.transform.position = playerLastPositionFinal;     //since, there is only 1 copy of playerLastPosition
        glitch = false;                                         //the variable updates in all finctions.
        //Destroy(_particleGameObject);
    }
    
    public IEnumerator setPosition() {
        Vector2 playerPos = player.transform.position;      //same as above
        yield return new WaitForSeconds(time);
        //afterImage.transform.position = playerLastPosition;
        playerLastPosition = playerPos;        //player.transform.position denotes current playerPosition, not 1 second ago
    }
}
