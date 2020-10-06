using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImage : MonoBehaviour
{
    GameObject player;
    static Vector2 playerPrevPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
       StartCoroutine(setPos());
    }
    IEnumerator setPos() {
        Vector2 playerPos = player.transform.position;      //same as above
        yield return new WaitForSeconds(0.25f);
        playerPrevPosition = playerPos;
        transform.position = playerPrevPosition;
    }
}
