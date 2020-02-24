using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuControl : MonoBehaviour {

    public Transform canvasStartMsg;
    public Transform menuCanvas;

    public static bool isGameReady = false;

    //{0,1,2,3,4,5} ; 0 is mainmenu, 1-3 is lvls, 4 is tutorial position & gestures, 5 is tutorial speech

    void Start()
    {
        isGameReady = false;
        if(GM.gameStarted == true)
        {
            canvasStartMsg.gameObject.SetActive(false);
            menuCanvas.gameObject.SetActive(true);
        }
    }
    
    public void loadFirtstLevel() {
        SceneManager.LoadScene(1);
        GM.songselect = 1;
    }

    public void loadSecondLevel() {
        SceneManager.LoadScene(2); // change to 2
        GM.songselect = 2;
    }

    public void loadThirdLevel() {
        SceneManager.LoadScene(3); // change to 3
        GM.songselect = 3;
    }

    public void loadFirstTutorialLevel() {
        SceneManager.LoadScene(4);
        GM_tutor.levelselect = 1;
    }

    public void loadSecondTutorialLevel()    {
        SceneManager.LoadScene(4);
        GM_tutor.levelselect = 2;
    }

    public void loadSecondTutorialSpeech()    {
        SceneManager.LoadScene(5);
    }

    public void startTheGame()    {
        canvasStartMsg.gameObject.SetActive(false);
        menuCanvas.gameObject.SetActive(true);
        GM.gameStarted = true;
    }

    //this will only work when we build the game
    public void exitGame() {
        Application.Quit();
    }    
 }
