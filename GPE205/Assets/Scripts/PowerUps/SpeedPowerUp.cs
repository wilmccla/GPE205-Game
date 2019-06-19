using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpeedPowerUp : PowerUp
{

    public float boostSpeed;

    public override void OnApplyPowerup(GameObject target)
    {
        ShipData data = target.GetComponent<ShipData>();
        data.moveSpeed += boostSpeed;
    }

    public override void OnRemovePowerup(GameObject target)
    {
        ShipData data = target.GetComponent<ShipData>();
        data.moveSpeed -= boostSpeed;
    }
}
