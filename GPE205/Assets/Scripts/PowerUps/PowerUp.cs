using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class PowerUp
{
    public abstract void OnApplyPowerup(GameObject target);
    public abstract void OnRemovePowerup(GameObject target);
}
