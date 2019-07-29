using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountyShipAIController : AIController
{
    void Update()
    {
        switch (currentState)
        {
            case AIStates.Idle:
                Idle();
                if (Time.time > stateStartTime + 2f)
                {
                    ChangeState(AIStates.Chase);
                }
                    break;

            case AIStates.Chase:
                Chase();
                if (Vector3.Distance(data.tf.position, playerData.tf.position) <= 50f)
                {
                    ChangeState(AIStates.Shoot);
                }
                    break;

            case AIStates.Shoot:
                Shoot();
                if (Vector3.Distance(data.tf.position, playerData.tf.position) > 50f)
                {
                    ChangeState(AIStates.Chase);
                }
                    break;
        }
    }
}
