using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ShipData playerData;
    public GameObject[] enemies;
    public ShipData[] enemyData;

    [Header("Level Gen")]
    public List<GameObject> Rooms;
    public GameObject[,] Grid;
    public int columns;
    public int rows;

    [Header("AI Spawning")]
    public GameObject[] AIPersonalities;
    public GameObject[] Waypoints;
    public GameObject[] PlayerSpawnPoints;
    public GameObject[] PowerUps;

    void Start()
    {
        //setting components
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyData = new ShipData[enemies.Length];
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //Adding shipdata componenets to the array
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyData[i] = enemies[i].GetComponent<ShipData>();
        }
    }

    void OnSceneLoad()
    {
        //setting components
        playerData = GameObject.FindWithTag("Player").GetComponent<ShipData>();
    }

    void Update()
    {
        if (playerData.health <= 0)
        {
            Destroy(playerData.gameObject);
            SceneManager.LoadScene("Game Over");
        }
    }

    public void GetSpawners()
    {
        PlayerSpawnPoints = GameObject.FindGameObjectsWithTag("Player Spawner");
    }

    public void GetWaypoints()
    {
        Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }

    public void SpawnPlayer()
    {
        playerData.tf.position = PlayerSpawnPoints[Random.Range(0, PlayerSpawnPoints.Length)].transform.position;
    }
}

