using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void changeScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);

    }
}

public class ExitGame : MonoBehaviour
{


    public void QuitButtonCallback()
    {
#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }

}





/* public Player player;
    public GameSettings settings;

    private void Start()
    {
        player = PersistenceManager.Instance.player;
        settings = PersistenceManager.Instance.settings;
    }*/
