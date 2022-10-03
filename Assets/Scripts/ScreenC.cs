using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenC : MonoBehaviour
{
    //vars needed
    float leftCon = Screen.width;
    float rightCon = Screen.width;
    float topCon = Screen.height;
    float botCon = Screen.height;
    float buffer = 00.0f;
    float distanceZ;
    Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        distanceZ = Mathf.Abs(MainCamera.transform.position.z + transform.position.z);
        leftCon = MainCamera.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightCon = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
        botCon = MainCamera.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
        topCon = MainCamera.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distanceZ)).y;
    }

    private void FixedUpdate()
    {
        //goes left
        if (transform.position.x <= leftCon - buffer)
        {
            transform.position = new Vector3(rightCon - 0.10f, transform.position.y, transform.position.z);
        }

        //goes right
        if (transform.position.x >= rightCon)
        {
            transform.position = new Vector3(leftCon, transform.position.y, transform.position.z);
        }

        //goes bottom
        if (transform.position.y < botCon - buffer)
        {
            transform.position = new Vector3(transform.position.x ,topCon + buffer, transform.position.z);
        }

        //goes top
        if (transform.position.y > topCon + buffer)
        {
            transform.position = new Vector3(transform.position.x, botCon, transform.position.z);
        }
    }

   
}
