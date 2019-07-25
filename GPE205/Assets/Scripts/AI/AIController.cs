using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [Header("Components")]
    public ShipData data;
    public ShipData playerData;

    [Header("Variables")]
    public float stateStartTime;
    public float feelerDistance;
    public AIStates currentState;

    // States for FSM
    public enum AIStates
    {
        Idle, Patrol, TurnToAvoid, MoveToAvoid, Chase, Flee, Shoot, Repair
    }

    void Start()
    {
        data = GetComponent<ShipData>();
        playerData = GameObject.FindWithTag("Player").GetComponent<ShipData>();
    }

    //Method to change states
    public void ChangeState( AIStates newState)
    {
        stateStartTime = Time.time;
        currentState = newState;
    }

    public void Idle()
    {
        //Not much to do here
    }

    //Method to move the AI towards a target
    public void Seek(Transform seekTarget)
    {
        Vector3 targetVector = (seekTarget.position - data.tf.position).normalized;
        data.mover.RotateTowards(targetVector);
        data.mover.SimpleMove(data.tf.forward);
    }

    public void Flee(Transform fleeTarget)
    {
        Vector3 targetVector = (fleeTarget.position - data.tf.position);
        Vector3 awayVector = -targetVector;
        data.mover.RotateTowards(awayVector);
        data.mover.SimpleMove(data.tf.forward);
    }

    public void Patrol()
    {
        Seek(data.waypoints[data.waypointIndex]);

        if (Vector3.Distance(data.tf.position, data.waypoints[data.waypointIndex].position) <= 0.4f)
        {
            data.waypointIndex++;
        }

        if (data.waypointIndex >= data.waypoints.Length)
        {
            data.waypointIndex = 0;
        }
    }

    public bool isBlocked()
    {
        if (Physics.Raycast(data.tf.position, data.tf.forward, feelerDistance))
        {
            return true;
        }

        return false;
    }

    public void Chase()
    {
        Seek(playerData.tf);
    }

    public void Shoot()
    {
        Vector3 targetVector = (playerData.tf.position - data.tf.position).normalized;
        data.mover.RotateTowards(targetVector);

        if (data.canShoot == true)
        {
            data.mover.StartCoroutine("Shoot");
        }
    }

    public void Repair()
    {
        if (Time.time >= stateStartTime + 60f)
        {
            data.health = data.maxHealth;
        }
    }
}
