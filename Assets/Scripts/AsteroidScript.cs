using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This script handles the asteroid logic
 */


public class AsteroidScript : MonoBehaviour
{

    //size var
    public float size = 1.0f;
    public float minSize = 0.5f;
    public float maxSize = 2.0f; //maybe switch to 1.5
    public Sprite[] sprites; //array of sprites. assigned from the editor to be chosen at random
    private SpriteRenderer spriteRenderer; //used for switching the sprites
    private Rigidbody2D rigidBody; //used for manipulating the physics of the asteroid

   

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //choose a sprite randomly from the array of sprites
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        //rotates the sprite in a random way
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size; //this.size will be changed elsewhere, creates vector with all 3 dimensions being = to the size

        //set mass proportionally to the size of the object
        rigidBody.mass = this.size;
    }

   
    
}
