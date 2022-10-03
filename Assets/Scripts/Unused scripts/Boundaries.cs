using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class handles the boundaries of the gamespace. it keeps the players and other objects within the gamespace as well as handles the wrapping effects
 */
public class Boundaries : MonoBehaviour
{
    public Camera MainCamera;
    private Vector2 screenBounds;
    private float objWidth, objHeight;

    // Start is called before the first frame update
    void Start()
    {
        //calculates the screen bounds on start, gives x and y value that are half of the screen width and height,
        //but are negative due to screen coordinate system being opposite of the world coordinate system
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));

        //calculates the boundaries of the sprite /2
        objWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        
    }

    // Lateupdate called after movement 
    void LateUpdate()
    {
        //*** this is an initial solution but need to implement wrapping 
        //calculates new player position and clamps it within the screen
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -1 * screenBounds.x + objWidth, screenBounds.x - objWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, -1 * screenBounds.y + objHeight, screenBounds.y - objHeight);

        //if (viewPos.x < -1 * screenBounds.x || viewPos.x > screenBounds.x )
        //{
        //    viewPos.x = viewPos.x * -1;
        //}
        //if (viewPos.y < -1 * screenBounds.y  || viewPos.y > screenBounds.y )
        //{
        //    viewPos.y = viewPos.y * -1;
        //}


        transform.position = viewPos;
    }
}
