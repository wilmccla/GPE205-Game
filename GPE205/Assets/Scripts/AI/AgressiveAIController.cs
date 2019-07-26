using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveAIController : AIController
{
    void Update()
    {
        switch (currentState)
        {
            case AIStates.Idle:
                //Idle
                Idle();
                //Transitions
                if (Time.time > stateStartTime + 1.5f)
                {
                    ChangeState(AIStates.Patrol);
                }
                    break;

            case AIStates.Patrol:
                //Patrol
                Patrol();
                //Transitions
                if (data.seesPlayer == true)
                {
                    ChangeState(AIStates.Chase);
                }
                    break;

            case AIStates.Chase:
                //Chase
                Chase();
                //Transition
                if (data.seesPlayer == false)
                {
                    ChangeState(AIStates.Idle);
                }
                if (Vector3.Distance(data.tf.position, playerData.tf.position) <= 50f)
                {
                    ChangeState(AIStates.Shoot);
                }
                    break;

            case AIStates.Shoot:
                //Shoot
                Shoot();
                //Transition
                if (Vector3.Distance(data.tf.position, playerData.tf.position) > 50f && data.seesPlayer == true)
                {
                    ChangeState(AIStates.Chase);
                }
                     break;
        }
    }
}
