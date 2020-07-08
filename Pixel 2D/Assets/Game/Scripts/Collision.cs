using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class Collision : MonoBehaviour
{
    ParticleSystem particle;    
    SpriteRenderer sr;      
    BoxCollider2D bc;
    TrailRenderer trail;
    //There is a problem in the bullet. Its almost invisible as it is passing over text boxes 
    //Fixing it with directional light should work
    //fixed by changing colour might come back to this later

    void Awake() {
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();  
        trail = GetComponentInChildren<TrailRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Bullet") || col.CompareTag("PlayerBullet") 
         || col.CompareTag("Wall") || col.CompareTag("Player")) {
            StartCoroutine(Destruct());
        }
    }
    IEnumerator Destruct() {
        GameManager.enemiesKilled = 0;
        trail.enabled = false;
        sr.enabled = false;
        bc.enabled = false;
        particle.Play();
        CameraShaker.Instance.ShakeOnce(1f, 1f, 0.1f, 1f);

        yield return new WaitForSeconds(0.8f);
        
        Destroy(gameObject);
    }
}
