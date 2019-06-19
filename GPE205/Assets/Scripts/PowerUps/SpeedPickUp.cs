using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickUp : MonoBehaviour
{
    public SpeedPowerUp powerup;

    void OnTriggerEnter(Collider other)
    {
        PowerUpController tempPUC = other.GetComponent<PowerUpController>();
        if (tempPUC != null)
        {
            tempPUC.Apply(powerup);

            Destroy(gameObject);
        }
    }
}
