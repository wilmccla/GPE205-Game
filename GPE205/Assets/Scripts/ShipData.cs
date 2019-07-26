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
    public ShipData playerData;

    [Header("Ship Variables")]
    public float moveSpeed;
    public float rotateSpeed;
    public float health;
    public float maxHealth;

    [Header("Player Variables")]
    public float score;
    public float bounty;

    [Header("Bullet Variables")]
    public float bulletSpeed;
    public float bulletDmg;
    public float shootCooldown;
    public bool canShoot;

    [Header("AI Variables")]
    public Transform[] waypoints;
    public int waypointIndex;
    public bool seesPlayer;
    public float pointValue;
    public float bountyValue;

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
            playerData.score += pointValue;
            playerData.bounty += bountyValue;
        }
    }
}
