using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System;
using System.Text;
using UnityEngine.SceneManagement;


public class Speech_positionTutorial : MonoBehaviour
{
    [SerializeField]
    private string[] m_Keywords = new string[]
    {"stop", "continue", "back", "restart", "next"
    ,"position", "gesture"};

    private KeywordRecognizer m_Recognizer;
    protected string word = "";

    public Transform canvas;
    public Text SpeechResults;

    void Start()
    {
        if (m_Keywords != null)
        {
            m_Recognizer = new KeywordRecognizer(m_Keywords);
            m_Recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            m_Recognizer.Start();
        }
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());

        word = args.text;
        SpeechResults.text = "You said: <b>" + word + "</b>";
    }

    private void Update()
    {
        if (word == "stop" || word == "continue")
        {
            Pause();
            word = "";
        }

        if (word == "restart")
        {
            ReplayTutorial();
            word = "";
        }

        if (word == "back")
        {
            BackToMainMenu();
            word = "";
        }

        if (word == "next")
        {
            NextTutorial();
            word = "";
        }

        if (word == "position")
        {
            loadFirstTutorialLevel();
            word = "";
        }

        if (word == "gesture")
        {
            loadSecondTutorialLevel();
            word = "";
        }

    }


    public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            GM_tutor.songPaused = true;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            GM_tutor.songPaused = false;
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReplayLevel()
    {
        // reload the current level
        switch (GM.songselect)
        {
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

    public void proceedToNextLevel()
    {
        if (GM.songselect == 1)
        {
            SceneManager.LoadScene(2);
            GM.songselect = 2;
        }
        else if (GM.songselect == 2)
        {
            SceneManager.LoadScene(3);
            GM.songselect = 3;
        }
        else if (GM.songselect == 3) //case will never be called (?)
        {
            SceneManager.LoadScene(1);
            GM.songselect = 1;
        }
    }

    public void loadFirstTutorialLevel()
    {
        SceneManager.LoadScene(4);
        GM_tutor.levelselect = 1;
    }

    public void loadSecondTutorialLevel()
    {
        SceneManager.LoadScene(4);
        GM_tutor.levelselect = 2;
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

}

