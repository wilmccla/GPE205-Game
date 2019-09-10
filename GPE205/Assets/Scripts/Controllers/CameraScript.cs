using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform camera;
    public Transform player;

    void Update()
    {
        camera.position = new Vector3(player.position.x, 50, player.position.z);
    }
}
