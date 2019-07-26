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
        }
    }
}
