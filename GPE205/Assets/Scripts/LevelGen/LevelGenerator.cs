using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameManager GM;

    public int columns;
    public int rows;

    private const int roomSize = 60;

    void Awake()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        GM.Grid = new GameObject[columns,rows];

        for (int col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                //Instantiating, moving, naming, and childing rooms
                GM.Grid[col, row] = Instantiate(GM.Rooms[Random.Range(0, GM.Rooms.Count)]);
                GM.Grid[col, row].transform.position = new Vector3(col * roomSize, 0,  row * roomSize);
                GM.Grid[col, row].name = "Room: [" + col + "," + row + "]";
                GM.Grid[col, row].GetComponent<Transform>().parent = this.transform;

                //Open the doors
                RoomScript roomScript = GM.Grid[col, row].GetComponent<RoomScript>();
                if (row != rows - 1)
                {
                    roomScript.northDoor.SetActive(false);
                }

                if (row != 0)
                {
                    roomScript.southDoor.SetActive(false);
                }

                if (col != columns - 1)
                {
                    roomScript.eastDoor.SetActive(false);
                }

                if (col != 0)
                {
                    roomScript.westDoor.SetActive(false);
                }
            }

            GM.GetWaypoints();
            GM.GetSpawners();
        }
    }
}
