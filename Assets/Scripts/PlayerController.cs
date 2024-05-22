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

    private Rigidbody2D rigidBody; //used for manipulating the physics of the asteroid

    //bullet vars
    public Bullet bulletPrefab;

    //for screen bounds ***
    //public ScreenBounds screenBounds;

    //used to initialize the rigid body
    private void Awake()
    {
        rigidB = GetComponent<Rigidbody2D>();
    }
    //updates every frame, used for checking button presses
    /*
     * current list of inputs to later put in control screen
     * W and Uparrow for thrust
     * A & LA and D & RA for turning
     * *may want to add a stop on S or DA
     * space and keypad and left click enter for fire
     */
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

        //handles the firing on spacebar or keypad enter
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetMouseButtonDown(0))
        {
            Fire();
        }

        //for screen bounds ****
        //if (screenBounds.isOutOfBounds(transform.localPosition))
        //{
           // Vector2 newPos = screenBounds.CalculateWrappedPosistion(transform.localPosition);
            //transform.position = newPos;
        //}
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

    //method to handle the firing of the gun
    private void Fire()
    {
        Vector3 pos = (this.transform.position + this.transform.up /3) ;
        Bullet bullet = Instantiate(this.bulletPrefab, pos , this.transform.rotation); //initiates the bullet, (prefab to use, player position, player roation)this.transform.position 
        bullet.Direction(this.transform.up); //calls direction method in bullet, uses the "forward" direction from player as the vector2 arg
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check what is colliding with asteroid(bullet or asteroid)
        if (collision.gameObject.tag == "Asteroid")
        {
            GameUiScript.instance.loseLife();
            Debug.Log("");//DELETE THIS
            //Destroy(this.gameObject); //always destroys asteroid
            //GameUiScript.instance.increaseScore(1);
        }
    }

}
