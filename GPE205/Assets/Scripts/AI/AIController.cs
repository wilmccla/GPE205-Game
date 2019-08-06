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
    public AIStates currentState;

    [Header("Object Avoidance")]
    public AvoidStates currentAvoidState;
    public float feelerDistance = 25f;
    public float avoidMoveTime = 4;
    public float startAvoidTime;

    // States for FSM
    public enum AIStates
    {
        Idle, Patrol, Chase, Flee, Shoot, Repair
    }

    public enum AvoidStates
    {
        None, Turn, Move
    }

    void Start()
    {
        data = GetComponent<ShipData>();
        playerData = GameObject.FindWithTag("Player").GetComponent<ShipData>();
    }

    //Method to change states
    public void ChangeState(AIStates newState)
    {
        stateStartTime = Time.time;
        currentState = newState;
    }

    public void ChangeAvoidState(AvoidStates newState)
    {
        startAvoidTime = Time.time;
        currentAvoidState = newState;
    }

    public void Idle()
    {
        //Not much to do here
    }

    //Method to move the AI towards a target
    public void Seek(Transform seekTarget)
    {
        switch (currentAvoidState)
        {
            case AvoidStates.None:

                //Here is the actual seeking
                Vector3 targetVector = (seekTarget.position - data.tf.position).normalized;
                data.mover.RotateTowards(targetVector);
                data.mover.SimpleMove(data.tf.forward);

                if (isBlocked())
                {
                    //Change the avoid state
                    ChangeAvoidState(AvoidStates.Turn);
                }
                break;

            case AvoidStates.Turn:
                //Turn to try and get around the obstacles
                data.mover.Rotate(1);
                //once were not blocked
                if (!isBlocked())
                {
                    ChangeAvoidState(AvoidStates.Move);
                }
                break;

            case AvoidStates.Move:
                //Move!
                data.mover.SimpleMove(data.tf.forward);
                //If you get blocked
                if (isBlocked())
                {
                    ChangeAvoidState(AvoidStates.Turn);
                }
                if (Time.time > startAvoidTime + avoidMoveTime)
                {
                    ChangeAvoidState(AvoidStates.None);
                }
                break;
        }
    }

    public void Flee(Transform fleeTarget)
    {
        switch (currentAvoidState)
        {
            case AvoidStates.None:

                Vector3 targetVector = (fleeTarget.position - data.tf.position);
                Vector3 awayVector = -targetVector;
                data.mover.RotateTowards(awayVector);
                data.mover.SimpleMove(data.tf.forward);

                if (isBlocked())
                {
                    ChangeAvoidState(AvoidStates.Turn);
                }
                    break;

            case AvoidStates.Turn:
                data.mover.Rotate(1);
                if (!isBlocked())
                {
                    ChangeAvoidState(AvoidStates.Move);
                }
                    break;

            case AvoidStates.Move:
                data.mover.SimpleMove(data.tf.forward);
                if (isBlocked())
                {
                    ChangeAvoidState(AvoidStates.Turn);
                }
                if (Time.time > startAvoidTime + avoidMoveTime)
                {
                    ChangeAvoidState(AvoidStates.None);
                }
                    break;
        }
    }

    public void Patrol()
    {
        Seek(data.waypoints[data.waypointIndex]);

        if (Vector3.Distance(data.tf.position, data.waypoints[data.waypointIndex].position) <= 0.3f)
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
