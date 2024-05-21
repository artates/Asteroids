using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class gameOverScript : MonoBehaviour
{
    //inits all buttons on the main menu, add more inits here if main menu grows
    public Button playButtonGO, quitButtonGO;


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
        playButtonGO = GameObject.Find("playButtonGO").GetComponent<Button>();
        Debug.Log("init");
        quitButtonGO = GameObject.Find("quitButtonGO").GetComponent<Button>();

        //inits the listeners
        playButtonGO.onClick.AddListener(delegate { LoadSceneByNumber(2); });
        quitButtonGO.onClick.AddListener(delegate { QuitButtonCallback(); });
    }


    //Callback funtion for moving in between scenes
    //0 = menu
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
