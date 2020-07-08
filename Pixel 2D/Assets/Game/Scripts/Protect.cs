using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Protect : MonoBehaviour
{
    public GameObject[] Wall;
    public float time;
    public float clock;
    float clockInit;
    public Slider slider;

    void Awake()
    {
        clock = 2f;  
        clockInit = clock;
        slider.maxValue = 2f;
        Wall = GameObject.FindGameObjectsWithTag("PlayerProtect");
    }

    // Update is called once per frame
    void Update()
    {
        ClockRegen();
        
        if(Input.GetKeyDown(KeyCode.S) || Input.GetMouseButton(1)) {
            StartCoroutine(Protection());
        }
    }
    void ClockRegen() {
        if(clock < clockInit) {
            clock = clock + (Time.deltaTime * 0.4f);
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
