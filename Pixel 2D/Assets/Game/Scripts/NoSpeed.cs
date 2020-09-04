using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSpeed : MonoBehaviour
{
    public GameObject mouseObject;
    //Main Idea - stop player movement when colliding hitbox
    //need to make changes to relation between playerSpeed and speed
    void Update() {
        //mouseObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
     void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "MouseObject") {
            Movement.playerSpeed = 0;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == "MouseObject") {
            Movement.playerSpeed = 725f;
        }
    }
}