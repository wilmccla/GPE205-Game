using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerUp
{
    public float timer = 10f;

    public virtual void OnApplyPowerup(GameObject target)
    {

    }

    public virtual void OnRemovePowerup(GameObject target)
    {

    }
}
