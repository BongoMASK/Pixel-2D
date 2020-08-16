using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class EnemyWall : MonoBehaviour
{
    public float thrust, time;
    Rigidbody2D rb;
    ParticleSystem particle;
    public bool horizontal;
    bool wallTrigger;
    public int rightLeft = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        particle = GetComponentInChildren<ParticleSystem>();
        StartCoroutine(wallMovement());
    }

    void Update() {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Wall")) {
            particle.Play();
            //CameraShaker.Instance.ShakeOnce(4f, 2.5f, 0.1f, 1f);
        }
    }

    //This GameObject is supposed to restrict certain areas in order to force the player to fight the enemies within that area.
    //It is also meant to represent a compress vibe in a computer. So make the player go through a said dangerous part of the computer aka Compressor

    IEnumerator wallMovement() {
        while(1==1) {
            float fallTime = Random.Range(time, time + 2);
            if(horizontal == true) {
                rb.AddForce(transform.right * -4 * thrust * rightLeft);
            }

            else {
                rb.AddForce(transform.up * -4 * thrust * rightLeft);
            }

            yield return new WaitForSeconds(fallTime);

            if(horizontal == true) {
                rb.AddForce(transform.right * 4 * thrust * rightLeft);
            }

            else {
                rb.AddForce(transform.up * thrust * 4 * rightLeft);
            }

            yield return new WaitForSeconds(fallTime);
        }
    }
}