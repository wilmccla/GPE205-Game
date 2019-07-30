using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<GameObject> Rooms;
    public GameObject[,] Grid;

    public int columns;
    public int rows;

    private const int roomSize = 60;


    void GenerateLevel()
    {
        Grid = new GameObject[columns,rows];

        for (int col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                Grid[col, row] = Instantiate(Rooms[Random.Range(0, Rooms.Count)]);
                Grid[col, row].transform.position = new Vector3(col * roomSize, -row * roomSize);
            }
        }
    }
}
