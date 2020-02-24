using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour {
    static sceneSwitch Instance;

    void Start () {
        // ask the game to not destroy this object 
        if(Instance != null) {
            GameObject.Destroy(gameObject);
        }
        else {
            GameObject.DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    public void ReplayLevel() {
        // reload the current level
        switch (GM.songselect) {
            case 1: // select song 1
                SceneManager.LoadScene(1);
                break;
            case 2:
                SceneManager.LoadScene(2);
                break;
            case 3:
                SceneManager.LoadScene(3);
                break;
        }
    }

    public void proceedToNextLevel() {
        if (GM.songselect == 1) {
            SceneManager.LoadScene(2);           
            GM.songselect = 2;
        }
        else if (GM.songselect == 2) {
            SceneManager.LoadScene(3);
            GM.songselect = 3;
        }
        else if (GM.songselect == 3) //case will never be called (?)
        {
            SceneManager.LoadScene(1);
            GM.songselect = 1;
        }
    }

    public void BackToMainMenu() {
        SceneManager.LoadScene(0);
    }

    public void NextTutorial()  // this cycles between the two tutorial levels
    {
        switch (GM_tutor.levelselect)
        {
            case 1: // select song 1
                SceneManager.LoadScene(4);
                GM_tutor.levelselect = 2;
                break;
            case 2:
                SceneManager.LoadScene(4);
                GM_tutor.levelselect = 1;
                break;
        }
        SceneManager.LoadScene(4);
    }

    public void ReplayTutorial()
    {
        SceneManager.LoadScene(4);
    }

    public void loadTutorial_pos()
    {
        SceneManager.LoadScene(4);
        GM_tutor.levelselect = 1;
    }
    public void loadTutorial_ges()
    {
        SceneManager.LoadScene(4);
        GM_tutor.levelselect = 2;
    }

}
