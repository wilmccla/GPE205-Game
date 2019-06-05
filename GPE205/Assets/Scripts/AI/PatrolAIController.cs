using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAIController : AIController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Switch states based on current state
        switch (currentState)
        {
            case AIStates.Idle:
                //Run Idle
                Idle();
                //Check time for switching states
                if (Time.time > stateStartTime + 3.0f)
                {
                    ChangeState(AIStates.Patrol);
                }
                break;

            case AIStates.Patrol:
                //Run Patrol
                Patrol();
                //Check for transition
                //TODO: Add Transitions
        }
    }
}
