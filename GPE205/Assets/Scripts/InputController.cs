using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public ShipData data;

    private void Awake()
    {
        data = GameObject.FindWithTag("Player").GetComponent<ShipData>();
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

        if (Input.GetKey(KeyCode.Space) && data.canShoot == true)
        {
            data.mover.StartCoroutine("Shoot");
        }

        // After inputs, tell mover to move the character
        data.mover.SimpleMove(directionToMove);
    }
}
