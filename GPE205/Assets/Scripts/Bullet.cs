using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simple Bullet Script

public class Bullet : MonoBehaviour
{
    public ShipData data;

    void Awake()
    {
        data = GameObject.FindWithTag("Player").GetComponent<ShipData>();
    }

    void OnCollisionEnter(Collision enemy)
    {
        Destroy(this.gameObject);

        if (enemy.gameObject.tag == "Enemy")
        {
            enemy.gameObject.GetComponent<ShipData>().health -=data.bulletDmg;
        }

        if (enemy.gameObject.tag == "Meteor")
        {
            Destroy(enemy.gameObject);
            data.score += 5;
        }
    }
}
