using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class handles player movement. May try to move away from this method to be more dynamic at handling different input methods 
 */

public class PlayerController : MonoBehaviour
{
    
    //vars for movement
    Rigidbody2D rigidB;
    private bool thrust; 
    private float turn;
    public float thrustS = 1.0f;
    public float turnS = 1.0f;

    //used to initialize the rigid body
    private void Awake()
    {
        rigidB = GetComponent<Rigidbody2D>();
    }
    //updates every frame, used for checking button presses
    private void Update()
    {
        thrust = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        //input left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turn = 1.0f;
        }

        //input right
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turn = -1.0f;
        }
        else turn = 0.0f;

    }

    //implements the keystrokes on the player object
    private void FixedUpdate()
    {
        if (thrust)
        {
            rigidB.AddForce(this.transform.up * this.thrustS);
        }

        if(turn != 0)
        {
            rigidB.AddTorque(turn * this.turnS);
        }
    }
}
