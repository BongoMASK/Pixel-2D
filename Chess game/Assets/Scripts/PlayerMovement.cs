using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int horseX, horseY;
    GameObject mousePointer;
    bool canMove;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void horseMovement() {
        Vector2 tilePos1 = new Vector2((transform.position.x + horseX * 2), transform.position.y + horseY * 1);
        Vector2 tilePos2 = new Vector2((transform.position.x + horseX * -2), transform.position.y + horseY * 1);
        Vector2 tilePos3 = new Vector2((transform.position.x + horseX * 1), transform.position.y + horseY * -2);
        Vector2 tilePos4 = new Vector2((transform.position.x + horseX * -1), transform.position.y + horseY * 2);
        
        if(canMove == true) {
              
        }
    }

    void queenMovement() {

    }

    void bishopMovement() {

    }

    void rookMovement() {

    }

    void kingMovement() {

    }

    void pawnMovement() {
            
    }
}
