using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class Collision : MonoBehaviour
{
    public static bool destroy = false;
    public float shakeFloat = 2f;

    void Update()
    {
        //animator.SetBool("Collide", destroy);
    }
    public void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Bullet")) {
            Destroy (col.gameObject);
            CameraShaker.Instance.ShakeOnce(shakeFloat, shakeFloat, 0.1f, 1f);
            Debug.Log("destroyed " + col.gameObject.name);
            destroy = true;
        }
        if(col.CompareTag("Enemy")) {
            Destroy (col.gameObject);
            CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);
            Debug.Log("destroyed " + col.gameObject.name);
            destroy = true;
        }
        if(col.CompareTag("PlayerBullet")) {
            Destroy (col.gameObject);
            CameraShaker.Instance.ShakeOnce(shakeFloat, shakeFloat, 0.1f, 1f);
            Debug.Log("destroyed " + col.gameObject.name);
            destroy = true;
        }
    }
    public void OnTriggerExit2D(Collider2D col) {
        if(col.CompareTag("Enemy")) {
            destroy = false;
        }
        if(col.CompareTag("Bullet")) {
            destroy = false;
        }
    }
    
}
