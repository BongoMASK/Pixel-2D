using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public static bool isTripleShoot;

    public static int value;

    /*public static void random() {
        if(GameManager.health < GameManager.totalHealth * 0.75) {
            value = Random.Range(1,7);
        }
        if(PowerUps.clock < PowerUps.clockInit * 0.5) {
            value = Random.Range(-1,5);
        }
        else {
            value = Random.Range(2,5);
        }

        if(value >= 2 && value <= 3) {
            StartCoroutine(TripleShoot());
            StartCoroutine(Movement.damagePoint(0, Color.white, "Triple Shoot"));
        }
        if(value < 7 && value > 3) {
            HealthRegen();
            StartCoroutine(damagePoint(0, Color.white, "+25% Health"));
        }
        if(value >= -1 && value < 2) {
            PowerRegen();
            StartCoroutine(damagePoint(0, Color.white, "Power Regenerated"));
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
    public static void BulletRegen() {
        GameManager.bulletNo = GameManager.totalBullets;
    }

}
