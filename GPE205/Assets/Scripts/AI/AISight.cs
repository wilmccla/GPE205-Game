using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will enable the AI to see the player

public class AISight : MonoBehaviour
{
    [Header("Components")]
    public ShipData data;

    [Header("Variables")]
    public float radius;
    [Range(0,360)]
    public float angle;
    public LayerMask objectMask;
    public LayerMask ObstacleMask;
    public List<Transform> visibleObjects = new List<Transform>();

    void Awake()
    {
        data = GetComponent<ShipData>();
        StartCoroutine("FindObjectsDelay", .2f);
    }

    IEnumerator FindObjectsDelay(float delay)
    {

    }
}
