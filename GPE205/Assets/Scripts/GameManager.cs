using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ShipData playerData;
    public GameObject[] enemies;
    public ShipData[] enemyData;

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

        //setting components
        playerData = GameObject.FindWithTag("Player").GetComponent<ShipData>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyData = new ShipData[enemies.Length];

        //Adding shipdata componenets to the array
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyData[i] = enemies[i].GetComponent<ShipData>();
        }

    }
}
