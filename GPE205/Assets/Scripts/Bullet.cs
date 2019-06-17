using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision enemy)
    {
        Destroy(this.gameObject);

        if (enemy.gameObject.tag == "Enemy")
        {
            enemy.gameObject.GetComponent<ShipData>().health -= damage;
        }
    }
}
