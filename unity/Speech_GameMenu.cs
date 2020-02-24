using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System;
using System.Text;
using UnityEngine.SceneManagement;

public class Speech_GameMenu : MonoBehaviour
{
    [SerializeField]
    private string[] m_Keywords = new string[]
    {"start", "level one", "one", "level two", "two", "level three", "three",
        "position", "gesture", "exit"};

    private KeywordRecognizer m_Recognizer;
    protected string word = "";

    public Transform canvas;
    public Text SpeechResults;

    void Start()
    {
        if (m_Keywords != null)        {
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
        if (word == "start" || word == "level one" || word == "one")
        {
            loadFirtstLevel();
            word = "";
        }

        if (word == "level two" || word == "two")
        {
            if (GM.unlockedLvl2 == true)
            {
                loadSecondLevel();
                word = "";
            }
            else
                word = "";
        }

        if (word == "level three" || word == "three")
        {
            if (GM.unlockedLvl3 == true)
            {
                loadThirdLevel();
                word = "";
            }
            else
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

        if (word == "speech")
        {
            loadSecondTutorialSpeech();
            word = "";
        }

        if (word == "exit")
        {
            exitGame();
            word = "";
        }
    }

    //{0,1,2,3,4} scene 0 is mainmenu/ 1-3 is lvls/ 4 is tutorial
    public void loadFirtstLevel()    {
        SceneManager.LoadScene(1);
        GM.songselect = 1;
    }

    public void loadSecondLevel()    {
        SceneManager.LoadScene(2); // change to 2
        GM.songselect = 2;
    }

    public void loadThirdLevel()    {
        SceneManager.LoadScene(3); // change to 3
        GM.songselect = 3;
    }

    public void loadFirstTutorialLevel()    {
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

    //this will only work when we build the game
    public void exitGame()    {
        Application.Quit();
    }
}
