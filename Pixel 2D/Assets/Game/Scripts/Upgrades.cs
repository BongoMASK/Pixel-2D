using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public static bool isTripleShoot;

    public static int value;

    /*public static void Random() {
        value = Random.Range(1,3);
        if(value == 1) {
            StartCoroutine(TripleShoot());
        }
        if(value == 2) {
           HealthRegen();
        }
        if(value == 3) {
            PowerRegen();
        }
    }*/

    public static IEnumerator TripleShoot() {
        //Gives triple shoot for x seconds
        isTripleShoot = true;

        yield return new WaitForSeconds(10);
        isTripleShoot = false;
    }
    public static void HealthRegen() {
        //Replenishes 25% health
        GameManager.health = GameManager.health + (int) (GameManager.totalHealth * 0.25);
    }
    public static void PowerRegen() {
        PowerUps.clock = PowerUps.clockInit;
        //Replenishes power bar
    }

}
