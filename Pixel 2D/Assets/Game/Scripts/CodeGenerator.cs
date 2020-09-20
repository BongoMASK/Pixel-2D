using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeGenerator : MonoBehaviour
{
    public GameObject[] tilemaps;
    Vector2[] roomPosition;
    public static int[] arr2 = new int[6],arr1 = {0, 1, 2, 3, 4, 5};
    public static int i = 0;
    EnemyWall wallScript;
    public GameObject wall;
    bool isSame;
    public GameObject[] numberText;
    public static Text[] number;
    
    void Start()
    {
        wallScript = wall.GetComponent<EnemyWall>();
        roomPosition = new Vector2[] {
            new Vector2(-60.7f, -2.3f),
            new Vector2(-53.99f, -47.26f),
            new Vector2(-9.02f, -47.26f),
            new Vector2(0f, 0f),
            new Vector2(-42.72f, 33.78f),
            new Vector2(-83.3f, 29.3f)
        };

        randomize(arr1, arr1.Length);

        placeTilemaps();
        
        /*
        public static int[] arr2 = {0, 1, 2, 3, 4, 5};

        void Start() {
            for(int j = 0; j < 6; j++) {
                number[j] = numberText[j].GetComponent<Text>();
            }
        }

        void Update() {
            number[i].text = arr2[i].ToString();
            for(int i = 0; i < 6; i++) {
                CodeGenerator.number[i].text = CodeGenerator.arr2[i].ToString();
            }
        }
        */
    }
    
    void Update() {
        compareArray();
    }

    void randomize(int[] arr, int n)
    {  
        // Start from the last element and 
        // swap one by one. We don't need to 
        // run for the first element  
        // that's why i > 0 
        for (int i = n - 1; i > 0; i--)  
        {   
            // Pick a random index
            // from 0 to i
            int j = Random.Range(0, i+1); //this is so that the last element is left untouched
              
            // Swap arr[i] with the 
            // element at random index 
            int temp = arr[i]; 
            arr[i] = arr[j]; 
            arr[j] = temp; 
        } 
        // Prints the random array 
        for (int i = 0; i < n; i++) {
            Debug.Log(arr[i] + 1);
        }
    }

    void placeTilemaps() {
        for(int i = 0; i < 6; i++) {
            tilemaps[arr1[i]].transform.position = roomPosition[i]; //assigning the appropriate tilemap to the ith room position
        }
    }

    void compareArray() {
        if(i >= 6) {
            for(int j = 0; j < arr2.Length; j++) {
                if(arr2[j] - 1 == arr1[j]) {
                    isSame = true;
                }
                else {
                    isSame = false;
                }
            }

            if(isSame == true) {
                Debug.Log("Correct code!");
                wallScript.enabled = true;
            }
            else {
                Debug.Log("Wrong code");
            }
            
        }
    }
}
