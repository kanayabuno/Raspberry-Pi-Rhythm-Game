using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songNameControl : MonoBehaviour {
    
    private string songinfo1 = "Song 1: Zedd & Alessia Cara\n - Stay";
    private string songinfo2 = "Song 2: Imagine Dragons\n  - Believer";
    private string songinfo3 = "Song 3: Nightcore\n -Rockefeller Street";
    
    void Start () {

        // this controls the text to display the information of the song of each stage

        switch (GM.songselect)
        {
            case 1:
                GetComponent<UnityEngine.UI.Text>().text = songinfo1;
                break;
            case 2:
                GetComponent<UnityEngine.UI.Text>().text = songinfo2;
                break;

            case 3:
                GetComponent<UnityEngine.UI.Text>().text = songinfo3;
                break;
        }
    }

}
