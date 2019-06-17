using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [Header("Components")]
    public ShipData data;

    [Header("Variables")]
    public Transform[] waypoints;
    public int waypointIndex;
    public float stateStartTime;
    public float feelerDistance;
    public AIStates currentState;

    // States for FSM
    public enum AIStates
    {
        Idle, Patrol, TurnToAvoid, MoveToAvoid, Chase, Flee
    }

    //Script to change states
    public void ChangeState( AIStates newState)
    {
        stateStartTime = Time.time;
        currentState = newState;
    }

    public void Idle()
    {
        //Not much to do here
    }

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
        Seek(waypoints[waypointIndex]);

        if (Vector3.Distance(data.tf.position, waypoints[waypointIndex].position) <= 1f)
        {
            waypointIndex++;
        }

        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
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
}
