using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerup : PowerUp
{
    public override void OnApplyPowerup(GameObject target)
    {
        ShipData data = target.GetComponent<ShipData>();
        data.health = data.maxHealth;
    }
}
