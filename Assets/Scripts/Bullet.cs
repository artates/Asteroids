using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Script that controls the bullet objects. Handles physics and collisions
 */
public class Bullet : MonoBehaviour
{
    private Rigidbody2D rigidB;
    private float pSpeed = 600.0f; //projectile speed
    private float mLife = 1.5f; //projectile lifetime

    private void Awake()
    {
        //inits rigidB to the associated component
        rigidB = GetComponent<Rigidbody2D>();

    }
    //sets the direction to be fired. Called by the player object
    public void Direction(Vector2 direction)
    {
        rigidB.AddForce(direction * this.pSpeed); //sets the fire direction and speed
        Destroy(this.gameObject, this.mLife); //destroys the object
    }
    
    //method for handling collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Destroy(this.gameObject);
       
    }
}
