using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShootPowerup : PowerUp
{
    public float oldCooldown;
    public float newCooldown;

    public override void OnApplyPowerup(GameObject target)
    {
        ShipData data = target.GetComponent<ShipData>();
        oldCooldown = data.shootCooldown;
        data.shootCooldown = newCooldown;
    }

    public override void OnRemovePowerup(GameObject target)
    {
        ShipData data = target.GetComponent<ShipData>();
        data.shootCooldown = oldCooldown;
    }
}
