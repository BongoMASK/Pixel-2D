using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrayGenerator : MonoBehaviour
{
    public int num;
    bool isCollided = false, isSame = false;
    ParticleSystem particle;
    /*public GameObject numberText; 
    Text number;*/

    void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        //number = numberText.GetComponent<Text>();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Player")) {
            if(isCollided == true) {
                isCollided = false;
                removeFromArray();
            }
            else {
                isCollided = true;
                addToArray();
            }
            //Debug.Log("collision: " + isCollided);
            
        }
    }

    /*void compareArray() {
        if(CodeGenerator.i >= 6) {
            for(int j = 0; j < CodeGenerator.arr2.Length; j++) {
                if(CodeGenerator.arr2[j] - 1 == CodeGenerator.arr1[j]) {
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
    }*/

    void addToArray() {
        particle.Play();
        CodeGenerator.arr2[CodeGenerator.i] = num;
        for(int i = 0; i < 6; i++) {
            CodeGenerator.number[i].text = CodeGenerator.arr2[i].ToString();
        }
        for(int j = 0; j < CodeGenerator.arr2.Length; j++) {
            Debug.Log("Array Added: " + CodeGenerator.arr2[j] + " ");
        }
        Debug.Log("is same: " + isSame);
        CodeGenerator.i++;
    }

    void removeFromArray() {
        if(CodeGenerator.arr2[CodeGenerator.i - 1] == num) {
            particle.Stop();
            //CodeGenerator.number[num].text = "0";
            for(int j = 0; j < CodeGenerator.arr2.Length; j++) {
                if(CodeGenerator.arr2[j] == num) {
                    Debug.Log("Before" + CodeGenerator.i);
                    CodeGenerator.i--;
                    Debug.Log("After" + CodeGenerator.i);
                }
            }
        }
        else {
            Debug.Log("wrong number");
        }
    }
}
