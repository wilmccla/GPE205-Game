using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickUp : Pickup
{
    public SpeedPowerUp powerup;

    void OnTriggerEnter(Collider other)
    {
        PowerUpController PUC = other.GetComponent<PowerUpController>();
        if (PUC != null)
        {
            PUC.Apply(powerup);
            Destroy(gameObject);
            PUSpawn.StartCoroutine("SpawnPowerupTimer");
        }
    }
}
