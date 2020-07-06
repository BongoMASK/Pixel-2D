using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int data;
    public static int deaths;
    public static int enemiesKilled;

    //Stats
    int health;
    int penetration;
    int MoneyDropped;
    int powerUpTime;

    void Awake()
    {
        MakeSingleton(); 
    }

    void Update()
    {

    }
    void MakeSingleton() {
        if(instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
 }
