﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public ShipData data;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Start the game without moving
        Vector3 directionToMove = Vector3.zero;

        //Press W and call the ship mover forward
        if (Input.GetKey(KeyCode.W))
        {
            directionToMove += data.tf.forward;
        }

        //Press S and call the ship mover backwards
        if (Input.GetKey(KeyCode.S))
        {
            directionToMove -= data.tf.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            data.mover.Rotate(-data.rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            data.mover.Rotate(data.rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            data.mover.StartCoroutine("Shoot");
        }

        // After inputs, tell mover to move the character
        data.mover.SimpleMove(directionToMove);
    }
}
