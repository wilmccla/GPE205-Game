using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject pawn;
    public Transform pawnTf;
    public ShipMover mover;

    private void Awake()
    {
        pawnTf = pawn.GetComponent<Transform>();
        mover = pawn.GetComponent<ShipMover>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Start with the assumption that I'm not moving
        Vector3 directionToMove = Vector3.zero;

        //If the W key is down -- Add "forward" to the dirrection I'm moving
        if (Input.GetKey(KeyCode.W))
        {
            directionToMove += pawnTf.forward;
        }

        //If the S key is down -- Add "reverse" to the direction I'm moving
        if (Input.GetKey(KeyCode.S))
        {
            directionToMove -= pawnTf.forward;
        }

        // After I've checked all my inputs, tell my mover to move in the final direction
        mover.PawnMover(directionToMove);


    }
}
