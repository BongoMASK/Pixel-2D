using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilePositionFinder : MonoBehaviour
{
    GameObject player;
    //GameObject tileHighlight;

    Vector2 playerPos;
    Vector2 tilePos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        tilePos = new Vector2(transform.position.x, transform.position.y);


        // declare array of different vector2 var for positions of tiles
        // make for loop
        // make it depend on bool which says whether player is which piece

        if (Player.knight == true) {    // KNIGHT
            Vector2[] newPos = {
                new Vector2(1.25f, 2.50f),
                new Vector2(-1.25f, 2.50f),
                new Vector2(1.25f, -2.50f),
                new Vector2(-1.25f, -2.50f),
                new Vector2(2.50f, 1.25f),
                new Vector2(-2.50f, 1.25f),
                new Vector2(2.50f, -1.25f),
                new Vector2(-2.50f, -1.25f)
            };

            for (int i = 0; i < newPos.Length; i++) {
                if (tilePos == playerPos + newPos[i]) {
                    Debug.Log(this.name);
                    // highlight tile
                }
            }
        }

        //check if there is a tile on the right or top or whatever. 
        //if not then break.
        if (Player.rook == true) {    // ROOK
        
            Vector2 currentPos = playerPos;
            Vector2 posIncrementX = new Vector2(1.25f, 0);
            for (int i = 0; i < 11; i++) {
            //Debug.Log("i: " + i);
                if(tilePos == playerPos + (posIncrementX * (i+1))) {
                    //currentPos = tilePos;
                    Debug.Log(this.name); 
                    //highlight tile
                }
                else {
                    break;
                }
            }
        } 

        if (Player.pawn == true) {    // PAWN
            
            Vector2[] newPos = {
                new Vector2(0, 2.50f),
                new Vector2(0, 1.25f)
            };

            for (int i = 0; i < newPos.Length; i++) {
                if (tilePos == playerPos + newPos[i]) {
                    Debug.Log(this.name);
                    // highlight tile
                }
            }
        }
    }
}
