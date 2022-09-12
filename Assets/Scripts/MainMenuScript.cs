using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    //inits all buttons on the main menu, add more inits here if main menu grows
    public Button playButton, settingsButton, quitButton;



    //start, this is called before the first frame update
    private void Start()
    {
        InitializeGameObjectsMenu();
    }

    /*
     * initializes the game objects, called at the start
     * uses gameobject.find to link the button in the scene to the button in the code
     * adds listener to call LoadSceneByNumber
    */
    public void InitializeGameObjectsMenu()
    {
        //inits buttons
        playButton = GameObject.Find("playButton").GetComponent<Button>();
        settingsButton = GameObject.Find("settingsButton").GetComponent<Button>();
        quitButton = GameObject.Find("quitButton").GetComponent<Button>();

        //inits the listeners
        playButton.onClick.AddListener(delegate { LoadSceneByNumber(2); });
        settingsButton.onClick.AddListener(delegate { LoadSceneByNumber(1); });
        quitButton.onClick.AddListener(delegate { QuitButtonCallback(); });
    }


    //Callback funtion for moving in between scenes
    //0 = menu
    //1 = settings
    //2 = game
    public void LoadSceneByNumber(int SceneNumber)
    {
        Debug.Log("Scene Number index to be loaded is " + SceneNumber);
        SceneManager.LoadScene(SceneNumber);
    }

    /*
     * quit function, also exists within ChangeScene.cs(that one is more universal.
     */
    public void QuitButtonCallback()
    {
#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }
}
