using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public List<PowerUp> powerups;

    void Update()
    {
        PowerUpTimer();
    }

    public void PowerUpTimer()
    {
        List<PowerUp> removeThese = new List<PowerUp>();

        for (int i = 0; i < powerups.Count; i++)
        {
            powerups[i].timer -= Time.deltaTime;

            if (powerups[i].timer <= 0)
            {
                removeThese.Add(powerups[i]);
            }
        }

        for (int i = 0; i < removeThese.Count; i++)
        {
            Remove(removeThese[i]);
        }
    }

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
