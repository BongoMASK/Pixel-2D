using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour { 

    public static bool knight, queen, king, rook, bishop, pawn;

    void Start() {
        knight = true;
        queen = false;
        king = false;
        rook = false;
        bishop = false;
        pawn = false;
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.K)) {  //knight
            knight = true;
            queen = false;
            king = false;
            rook = false;
            bishop = false;
            pawn = false;
            // change sprites
        }
        if (Input.GetKeyDown(KeyCode.L)) {  //queen
            knight = false;
            queen = true;
            king = false;
            rook = false;
            bishop = false;
            pawn = false;
            // change sprites
        }
        if (Input.GetKeyDown(KeyCode.J)) {  //king
            knight = false;
            queen = false;
            king = true;
            rook = false;
            bishop = false;
            pawn = false;
            // change sprites
        }
        if (Input.GetKeyDown(KeyCode.I)) {  //rook
            knight = false;
            queen = false;
            king = false;
            rook = true;
            bishop = false;
            pawn = false;
            // change sprites
        }
        if (Input.GetKeyDown(KeyCode.M)) {  //bishop
            knight = false;
            queen = false;
            king = false;
            rook = false;
            bishop = true;
            pawn = false;
            // change sprites
        }
        if (Input.GetKeyDown(KeyCode.N)) {  //pawn
            knight = true;
            queen = false;
            king = false;
            rook = false;
            bishop = false;
            pawn = true;
            // change sprites
        }
    }
}