using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbAIController : AIController
{
    // Update is called once per frame
    void Update()
    {
        
        data.mover.SimpleMove(data.tf.forward);

    }
}
