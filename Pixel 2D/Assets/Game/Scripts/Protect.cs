using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protect : MonoBehaviour
{
    public GameObject[] Wall;
    public float time;

    void Awake()
    {
        Wall = GameObject.FindGameObjectsWithTag("PlayerProtect");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) || Input.GetMouseButton(1)) {
            StartCoroutine(Protection());
        }
    }
    IEnumerator Protection() {
        for(int i = 0; i<= Wall.Length; i++) {
            Wall[i].SetActive(true);
        }
        yield return new WaitForSeconds(time);
        for(int i = 0; i<= Wall.Length; i++) {
            Wall[i].SetActive(false);
        }
    }
}
