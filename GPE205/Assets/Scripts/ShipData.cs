using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipData : MonoBehaviour
{
    [Header("Components")]
    public Transform tf;
    public ShipMover mover;
    public GameObject bullet;
    public GameObject bulletInst;

    [Header("Variables")]
    public float moveSpeed;
    public float reverseMoveSpeed;
    public float rotateSpeed;
    public float timeBewteenShots;
    public float bulletSpeed;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
