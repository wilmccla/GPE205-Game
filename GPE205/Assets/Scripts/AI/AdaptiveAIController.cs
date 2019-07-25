using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptiveAIController : AIController
{
    void Update()
    {
        //Switch states based on current state
        switch (currentState)
        {
            case AIStates.Idle:
                //Run Idle
                Idle();
                //Switch the state after 3 seconds
                if (Time.time > stateStartTime + 1.5f)
                {
                    ChangeState(AIStates.Patrol);
                }
                    break;

            case AIStates.Patrol:
                //Run Patrol
                Patrol();
                //Transitions
                if (data.seesPlayer == true && data.health > data.maxHealth / 2)
                {
                    ChangeState(AIStates.Chase);
                }
                if (data.seesPlayer == true && data.health < data.maxHealth / 2)
                {
                    ChangeState(AIStates.Flee);
                }
                    break;
            
            case AIStates.Chase:
                //Do Chase
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
                if (data.health < data.maxHealth / 2)
                {
                    ChangeState(AIStates.Flee);
                }
                    break;

            case AIStates.Shoot:
                //Do Shoot
                Shoot();
                //Transition
                if (Vector3.Distance(data.tf.position, playerData.tf.position) > 50f && data.seesPlayer == true)
                {
                    ChangeState(AIStates.Chase);
                }
                if (data.health < data.maxHealth / 2)
                {
                    ChangeState(AIStates.Flee);
                }
                    break;

            case AIStates.Flee:
                //Do Flee
                Flee(playerData.tf);
                //Transition
                if (Vector3.Distance(data.tf.position, playerData.tf.position) > 200f)
                {
                    ChangeState(AIStates.Repair);
                }
                    break;

            case AIStates.Repair:
                //Do Repair
                Repair();
                //Transition
                if (data.health == data.maxHealth)
                {
                    ChangeState(AIStates.Patrol);
                }
                break;
        }
    }
}
