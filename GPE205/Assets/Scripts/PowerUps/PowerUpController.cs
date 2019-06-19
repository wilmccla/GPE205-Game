using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public List<PowerUp> powerups;

    public void Apply(PowerUp powerup)
    {
        powerups.Add(powerup);
        powerup.OnApplyPowerup(gameObject);
    }

    public void Remove(PowerUp powerup)
    {
       powerup.OnRemovePowerup(gameObject);
       powerups.Remove(powerup);
    }
}
