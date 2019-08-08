using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : Pickup
{
    public HealthPowerup powerup;

    void OnTriggerEnter(Collider other)
    {
        PowerUpController PUC = other.GetComponent<PowerUpController>();
        if (PUC != null)
        {
            Destroy(gameObject);
            PUSpawn.StartCoroutine("SpawnPowerupTimer");
        }
    }
}
