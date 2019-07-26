using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveAIController : AIController
{
    void Update()
    {
        switch (currentState)
        {
            case AIStates.Idle:
                Idle();
                if (Time.time > stateStartTime + 1.5f)
                {
                    ChangeState(AIStates.Patrol);
                }
                    break;

            case AIStates.Patrol:
                //Run Patrol
                Patrol();
                //Transitions
                if (data.seesPlayer == true)
                {
                    ChangeState(AIStates.Flee);
                }
                    break;

            case AIStates.Flee:
                Flee(playerData.tf);
                if (Vector3.Distance(data.tf.position, playerData.tf.position) > 150f)
                {
                    ChangeState(AIStates.Idle);
                }
                    break;
        }
    }
}
