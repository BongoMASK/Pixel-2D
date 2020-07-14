using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public static bool isTripleShoot;

    public static IEnumerator TripleShoot() {
        //Gives triple shoot for x seconds
        isTripleShoot = true;

        yield return new WaitForSeconds(10);
        isTripleShoot = false;
    }
    void HealthRegen() {
        //Replenishes 25% health
        GameManager.health = GameManager.health + (int) (GameManager.totalHealth * 0.25);
    }
    void PowerRegen() {
        //Replenishes power bar
    }
}
