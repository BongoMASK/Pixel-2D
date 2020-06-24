using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSpeed : MonoBehaviour
{
    public GameObject mouseObject;

    void Update() {
        //mouseObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
     void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "MouseObject") {
            Movement.playerSpeed = 0;
            Debug.Log("collided");
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == "MouseObject") {
            Movement.playerSpeed = 725f;
        }
    }
}
