using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 * handles the screen bounds
 */

[RequireComponent(typeof(BoxCollider2D))] //requires component boxcollider, automatically adds box collider2d to any object that I add the screen bounds script
public class ScreenBounds : MonoBehaviour
{
    public Camera MainCamera; //reference to the main camera which is the screen bounds
    BoxCollider2D boxCollider;

    public UnityEvent<Collider2D> ExitTriggerFired;//sends information to a listener

    [SerializeField]
    private float teleportOffset = 0.2f; //offset for teleporting

    //called on awake
    private void Awake()
    {
        this.MainCamera.transform.localScale = Vector3.one; //avoid bugs on calculations
        boxCollider = GetComponent<BoxCollider2D>();//inits boxCollider
        boxCollider.isTrigger = true;
    }

    //called on start
    private void Start()
    {
        transform.position = Vector3.zero; //puts box in center of the screen
        UpdateBoundsSize();
    }
    //updates the bounds of the screen
    public void UpdateBoundsSize()
    {
        //orthographicSize = half the size of the height of the screen
        float y = MainCamera.orthographicSize * 2;//for height

        //width of the camer depends on the aspect ratio and the height
        Vector2 boxColliderSize = new Vector2(y * MainCamera.aspect, y);
        boxCollider.size = boxColliderSize;
        
    }

    //invoke unity event to send a reference to the collider2d to any script that is listening for it
    private void OnTriggerExit2D(Collider2D collision)
    {
        ExitTriggerFired?.Invoke(collision);
    }

    //check is out of bounds
    public bool isOutOfBounds(Vector3 worldPosition)
    {
        return 
            Math.Abs(worldPosition.x) > Mathf.Abs(boxCollider.bounds.min.x) ||
            Math.Abs(worldPosition.y) > Mathf.Abs(boxCollider.bounds.min.y);
    }

    public Vector2 CalculateWrappedPosistion (Vector2 worldPosition)
    {
        bool xBoundResult =
            Mathf.Abs(worldPosition.x) > Mathf.Abs(boxCollider.bounds.min.x);
        bool yBoundResult =
            Mathf.Abs(worldPosition.y) > Mathf.Abs(boxCollider.bounds.min.y);
        Vector2 signWorldPos = new Vector2(Mathf.Sign(worldPosition.x), Mathf.Sign(worldPosition.y));

        if (xBoundResult && yBoundResult)
        {
            return Vector2.Scale(worldPosition, Vector2.one * -1) + Vector2.Scale(new Vector2(teleportOffset, teleportOffset), signWorldPos);
        }
        else if (xBoundResult)
        {
            return new Vector2(worldPosition.x * -1, worldPosition.y) + new Vector2(teleportOffset * signWorldPos.x, teleportOffset);
        }
        else if (yBoundResult)
        {
            return new Vector2(worldPosition.x, worldPosition.y * 1) + new Vector2(teleportOffset , teleportOffset * signWorldPos.y );
        }
        else return worldPosition;
    }
}
