using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System;
using System.Text;
using System.Collections;
using UnityEngine.SceneManagement;


public class Speech_Tutorial : MonoBehaviour
{
    [SerializeField]
    private string[] Key = new string[]
    {"start", "level one", "one", "level two", "two", "level three", "three",
        "position", "gesture", "tutorial one", "exit",
     "stop", "continue", "back", "restart", "next"};
   
    List<string> names = new List<string>() //0,1,2,...
    { "select a word", "start", "level one", "one", "level two", "two", "level three", "three",
        "position", "gesture", "tutorial one", "exit",
     "stop", "continue", "back", "restart", "next"};

    private KeywordRecognizer m_Recognizer;
    protected string word = "";
    public Dropdown dropdown;
    public Text selectedName;
    public Text SpeechResults;

    void Start()    {
        if (Key != null)    {
            m_Recognizer = new KeywordRecognizer(Key);
            m_Recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            m_Recognizer.Start();
        }
        FillDropList();
    }
    
    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        SpeechResults.text = "You said: "+ args.text+ "\n" +
            "Level of Confidence: " + args.confidence + "\n" ;

        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());
    }

    void FillDropList()    {
        dropdown.AddOptions(names);
    }

    public void Dropdown_IndexChanged(int index)
    {
        selectedName.text = names[index];
    }

    public void loadMainMenu()    {
        SceneManager.LoadScene(0);
    }
}
