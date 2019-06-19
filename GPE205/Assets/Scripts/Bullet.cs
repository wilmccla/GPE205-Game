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
        //delete the bullet when colliding with something
        Destroy(this.gameObject);

        //if the thing hit is tagged as enemy subtract their health by the bullet damage
        if (enemy.gameObject.tag == "Enemy")
        {
            enemy.gameObject.GetComponent<ShipData>().health -=data.bulletDmg;
        }

        //if the thing hit is a meteor, delete the metor and give the player a bit of score
        if (enemy.gameObject.tag == "Meteor")
        {
            Destroy(enemy.gameObject);
            data.score += 5;
        }
    }
}
