using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountyHunterSpawner : MonoBehaviour
{
    public ShipData playerData;
    public GameObject BountyShip;

    void Update()
    {
        if (playerData.bounty >= 4)
        {
            SpawnBountyHunter();
        }
    }

    void SpawnBountyHunter()
    {

    }
}
