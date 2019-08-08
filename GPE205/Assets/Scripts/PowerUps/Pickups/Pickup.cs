using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public PowerupSpawner PUSpawn;

    void Start()
    {
        PUSpawn = GetComponentInParent<PowerupSpawner>();
    }
}
