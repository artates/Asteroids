using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Script for handling Game scene UI
public class GameUiScript : MonoBehaviour
{
    public static GameUiScript instance; //creates an instance of this class

    //Vars for score and score test
    public int score;
    public TextMeshProUGUI scoreText;

    //Add vars for high score later

    //awake method for making the instance of this class
    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //initializes the scoreText object and score counter
        score = 0;
        scoreText = GameObject.Find("scoreText").GetComponent<TextMeshProUGUI>();
        scoreText.text = "Score " + score;
        
    }

    //methods for changing the score 
    public void increaseScore(int val)
    {
        score += val;
        scoreText.text = "Score: " + score;

        //would add stuff for high score here
    }

    //probably dont need this
    public void resetScore()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }
}
