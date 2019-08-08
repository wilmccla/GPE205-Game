using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelGenerator : MonoBehaviour
{
    public GameManager GM;

    private const int roomSize = 60;

    public bool isMapOfTheDay;

    public int DateToInt(DateTime currentDate)
    {
        // Add up all the values of date to return an int
        return currentDate.Year + currentDate.Month + currentDate.Day + currentDate.Hour + currentDate.Minute + currentDate.Second + currentDate.Millisecond;
    }

    void Awake()
    {
        if (isMapOfTheDay)
        {
            UnityEngine.Random.seed = DateToInt(DateTime.Now.Date);
            GenerateLevel();
        }
        else
        {
            UnityEngine.Random.seed = DateToInt(DateTime.Now);
            GenerateLevel();
        }
    }

    void GenerateLevel()
    {
        GM.Grid = new GameObject[GM.columns,GM.rows];

        for (int col = 0; col < GM.columns; col++)
        {
            for (int row = 0; row < GM.rows; row++)
            {
                //Instantiating, moving, naming, and childing rooms
                GM.Grid[col, row] = Instantiate(GM.Rooms[UnityEngine.Random.Range(0, GM.Rooms.Count)]);
                GM.Grid[col, row].transform.position = new Vector3(col * roomSize, 0,  row * roomSize);
                GM.Grid[col, row].name = "Room: [" + col + "," + row + "]";
                GM.Grid[col, row].GetComponent<Transform>().parent = this.transform;

                //Open the doors
                RoomScript roomScript = GM.Grid[col, row].GetComponent<RoomScript>();
                if (row != GM.rows - 1)
                {
                    roomScript.northDoor.SetActive(false);
                }

                if (row != 0)
                {
                    roomScript.southDoor.SetActive(false);
                }

                if (col != GM.columns - 1)
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
            GM.SpawnPlayer();
        }
    }
}
