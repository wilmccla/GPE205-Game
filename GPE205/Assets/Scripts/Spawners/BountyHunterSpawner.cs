using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountyHunterSpawner : MonoBehaviour
{
    public ShipData playerData;
    public GameObject BountyShip;
    public bool hasSpawned;

    void Update()
    {
        if (playerData.bounty >= 4 && hasSpawned == false)
        {
            SpawnBountyHunter();
            hasSpawned = true;
        }
    }

    void SpawnBountyHunter()
    {
        Instantiate(BountyShip, this.gameObject.transform);
    }
}
