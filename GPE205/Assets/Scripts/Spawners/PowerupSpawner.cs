using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameManager GM;
    public float spawnTimeSec;
    private int index;
    void Start()
    {
        GM = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        Instantiate(GM.PowerUps[Random.Range(0, GM.PowerUps.Length)], gameObject.transform);
    }

    IEnumerator SpawnPowerupTimer()
    {
        yield return new WaitForSeconds(spawnTimeSec);
        Instantiate(GM.PowerUps[Random.Range(0, GM.PowerUps.Length)], gameObject.transform);
    }
}
