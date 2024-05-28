using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//Script for handling Game scene UI
public class GameUiScript : MonoBehaviour
{
    public static GameUiScript instance; //creates an instance of this class

    //Vars for score and score test
    public int score, lives;
    public TextMeshProUGUI scoreText;

    //life images
    Image life1, life2, life3;

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
        //init the life images in the UI
        life1 = GameObject.Find("life1").GetComponent<Image>();
        life2 = GameObject.Find("life2").GetComponent<Image>();
        life3 = GameObject.Find("life3").GetComponent<Image>();
        //set lives to 3
        lives =  3;
        
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
    public void loseLife()
    {
        //subtract lives by one if game is over lose game over scene
        lives -= 1;
        if (lives == 2)
        {
            life3.enabled = false;
        }
        if (lives == 1)
        {
            life2.enabled = false;
        }
        Debug.Log("lives = " +lives);//DELETE THIS
        if ( lives == 0) 
        {
            SceneManager.LoadScene(3);
        }
    }
}
