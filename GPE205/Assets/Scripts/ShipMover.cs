using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMover : MonoBehaviour
{
    public ShipData data;
    private CharacterController CharacterController;

    // Start is called before the first frame update
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SimpleMove(Vector3 directionToMove)
    {
        //Move the character
        CharacterController.SimpleMove(directionToMove * data.moveSpeed);
    }

    public void Rotate(float direction)
    {
        //Rotate the character
        data.tf.Rotate(new Vector3(0, direction * data.rotateSpeed * Time.deltaTime, 0));
    }
}
