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
    public float score;
    public float moveSpeed;
    public float reverseMoveSpeed;
    public float rotateSpeed;
    public float timeBewteenShots;
    public float bulletSpeed;
    public float bulletDmg;
    public float health;
    public bool canShoot;
    public float pointValue;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && this.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            GameObject.FindWithTag("Player").GetComponent<ShipData>().score += pointValue;
        }
    }
}
