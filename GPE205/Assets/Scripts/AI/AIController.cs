using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public ShipData data;
    public float stateStartTime;
    public float feelerDistance;

    public enum AIStates
    {
        Idle, Patrol, TurnToAvoid, MoveToAvoid, Chase, Flee
    }

    public void ChangeState( AIStates newState)
    {
        stateStartTime = Time.time;
        currentState = newState;
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
