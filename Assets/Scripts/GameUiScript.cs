using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script for handling Game scene UI
public class GameUiScript : MonoBehaviour
{
    //Vars for score and score test
    public int score;
    public Text scoreText;
   
    // Start is called before the first frame update
    void Start()
    {
        //initializes the scoreText object and score counter
        score = 0;
        scoreText = GameObject.Find("scoreText").GetComponent<Text>();
        
    }

    //methods for changing the score 
    public void increaseScore(int val)
    {
        score += val;
        scoreText.text = "Score: " + score;
    }

    public void resetScore()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }
}
