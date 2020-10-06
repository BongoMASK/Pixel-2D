using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLastPosition : MonoBehaviour
{
    GameObject player;
    static Vector2 playerPrevPosition; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       setPos();
    }
    IEnumerator setPos() {
        Vector2 playerPos = player.transform.position;      //same as above
        yield return new WaitForSeconds(0.25f);
        playerPrevPosition = playerPos;
        this.transform.position = playerPrevPosition;
    }
}
