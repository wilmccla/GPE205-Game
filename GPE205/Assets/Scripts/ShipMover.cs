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

    public void RotateTowards(Vector3 lookVector)
    {
        //Find Vector to target
        Vector3 vectorToTarget = lookVector;

        // Find quaternion to look down that vector
        Quaternion targetQuaternion = Quaternion.LookRotation(vectorToTarget, Vector3.up);

        // set out reortaion to "parway towards" that quaternion
        data.tf.rotation = Quaternion.RotateTowards(data.tf.rotation, targetQuaternion, data.rotateSpeed * Time.deltaTime);
    }

    public void Shoot()
    {
        //Instantiate the bullet
        GameObject newBullet = Instantiate(data.bullet, data.bulletInst.transform.position, data.tf.rotation);
        //Move the bullet to the player's forward
        newBullet.GetComponent<Rigidbody>().AddForce(data.tf.transform.forward * data.bulletSpeed);
        //Destroy the gameobject in 3 seconds
        Destroy(newBullet, 3.0f);
    }
}
