using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public GameManager GM;

    public GameObject northDoor;
    public GameObject southDoor;
    public GameObject eastDoor;
    public GameObject westDoor;

    public Transform AISpawner;
    public Transform PowerupSpawnerTransform;
    public GameObject PowerUpSpawner;
    public Transform[] Waypoints;

    void Awake()
    {
        GM = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        SpawnAI();
    }

    public void SpawnAI()
    {
        GameObject AI = Instantiate(GM.AIPersonalities[Random.Range(0, GM.AIPersonalities.Length)], AISpawner);
        AI.GetComponent<ShipData>().waypoints = Waypoints;
    }
}
