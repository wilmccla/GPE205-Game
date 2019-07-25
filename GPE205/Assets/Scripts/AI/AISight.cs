using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will enable the AI to see the player

public class AISight : MonoBehaviour
{
    [Header("Components")]
    public ShipData data;
    public Transform tf;

    [Header("Variables")]
    public float radius;
    [Range(0,360)]
    public float angle;
    public LayerMask objectMask;
    public LayerMask ObstacleMask;
    public List<Transform> visibleObjects = new List<Transform>();

    void Awake()
    {
        data = GetComponent<ShipData>();
        tf = GetComponent<Transform>();
        StartCoroutine("FindObjectsDelay", .2f);
    }

    IEnumerator FindObjectsDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleObjects();
        }
    }

    void FindVisibleObjects()
    {
        visibleObjects.Clear();
        Collider[] objectsInViewRadius = Physics.OverlapSphere(transform.position, radius, objectMask);
        for (int i = 0; i < objectsInViewRadius.Length; i++)
        {
            Transform objects = objectsInViewRadius[i].transform;
            Vector3 dirToObjects = (objects.position - tf.position).normalized;
            if (Vector3.Angle(tf.forward, dirToObjects) < angle / 2)
            {
                float dstToObjects = Vector3.Distance(tf.position, objects.position);
                if (!Physics.Raycast(tf.position, dirToObjects, dstToObjects, ObstacleMask))
                {
                    visibleObjects.Add(objects);
                }
            }
        }

        if (visibleObjects.Contains(GameObject.FindWithTag("Player").transform))
        {
            data.seesPlayer = true;
        }
        else
        {
            data.seesPlayer = false;
        }

    }


    public Vector3 DirfromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            //angle of degrees
            angleInDegrees += transform.eulerAngles.y;
            //(note unity always has 0 on top and clockwise till sin (90-X) = cos (X) )
        }

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

}
