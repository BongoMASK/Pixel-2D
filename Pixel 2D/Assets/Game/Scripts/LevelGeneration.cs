using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] startingPositions;
    public GameObject[] rooms;  // 0 --> LR, 1 --> LRB, 2 --> LRT, 3 --> LRTB 

    private int direction, prevDirection;
    public float moveAmount;

    public float startTimeBtwRoom = 0.25f;
    private float timeBtwRoom;

    public float minX;
    public float maxX;
    public float minY;

    private bool stopGeneration;

    void Start()
    {
        int randStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartingPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);

        direction = Random.Range(1, 5);
    }

    void Update()
    {
        if(timeBtwRoom <= 0 && stopGeneration == false) {
            Move();
            timeBtwRoom = startTimeBtwRoom;
        } 
        else {
            timeBtwRoom -= Time.deltaTime;   
        }
    }
 
    void Move()
    {
        prevDirection = direction;

        if (direction == 1 || direction == 2) {  //Move Right
            if (transform.position.x < maxX) {
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);


                direction = Random.Range(1, 5);
                if(direction == 3 || direction == 4) {
                    direction = 2;
                }
            }
            else if (prevDirection == 5) {
                direction = 3;
            }
            else {
                direction = 5;
            }
            Debug.Log("Current: " + prevDirection + " / " + "Next: " + direction + " (Right)");
        }

        else if (direction == 3 || direction == 4) {   //Move Left
            if (transform.position.x > minX) {
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);
                
                direction = Random.Range(3, 5); 
            }
            if (prevDirection == 5) {
                direction = 2;
            }
            else {
                direction = 5;
            }
            Debug.Log("Current: " + prevDirection + " / " + "Next: " + direction + " (Left)");
        }

        else if (direction == 5) {   //Move Down
            if (transform.position.y > minY) {
                /*if (prevDirection == 5) {
                    direction = Random.Range(1, 5);
                }
                else {*/
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                    transform.position = newPos;

                    int rand = Random.Range(2, 4);
                    Instantiate(rooms[rand], transform.position, Quaternion.identity);

                    direction = Random.Range(1, 6);
                //}
            }
            if(transform.position.y < minY) { //STOP!! 
                stopGeneration = true;
            }
            Debug.Log("Current: " + prevDirection + " / " + "Next: " + direction + " (Down)");
        }

        //Instantiate(rooms[0], transform.position, Quaternion.identity);
        //Debug.Log(prevDirection + " / " + direction);
    }
}
