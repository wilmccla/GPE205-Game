using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipData : MonoBehaviour
{
    [Header("Components")]
    public Transform tf;
    public ShipMover mover;

    [Header("Variables")]
    public float moveSpeed;
    public float reverseMoveSpeed;
    public float rotateSpeed;
    public float shotsPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
