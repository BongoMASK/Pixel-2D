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
    //There is a problem in the bullet. Its almost invisible as it is passing over text boxes 
    //Fixing it with directional light should work
    //fixed by changing colour might come back to this later

    void Awake() {
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();   
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Bullet") || col.CompareTag("PlayerBullet") || col.CompareTag("Wall")) {
            StartCoroutine(Destruct(col.gameObject));
        }
    }
    IEnumerator Destruct(GameObject collider) {
        sr.enabled = false;
        bc.enabled = false;
        particle.Play();
        CameraShaker.Instance.ShakeOnce(2f, 2f, 0.1f, 1f);

        yield return new WaitForSeconds(0.8f);
        
        Destroy(gameObject);
    }
}
