using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class GM_tutor : MonoBehaviour
{

    public static int levelselect = 2; // used to select tutorial level

    // Song 1 - List of notes on the left={1,3} & right={2,4}
    static List<float> NoteL = new List<float>()
    { 
        //0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
        1, 0, 0, 0, 0, 0, 0, 3,
        3, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        1, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        3, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        3, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        1, 0, 0, 0, 0, 0, 0, 3,
        3, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        1, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        3, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        3, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
    };

    static List<float> NoteR = new List<float>() // 88 in total
    {
        //2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0,2,0
        0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        4, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        4, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
    };


    public float NoteLlength = NoteL.Count;
    public float NoteRlength = NoteR.Count;
    public float levelDuration = 175.0f;

    public bool hasLVLEnded = false;

    public bool spawnL = false;          // spawn note on left (1 and 3)
    public bool spawnR = false;          // spawn note on right (2 and 4)

    public static bool songPaused = false;

    public float xPosL;                         // x position to spawn note on the left (1 and 3)
    public float yPosL;                         // y position to spawn note on the left
    public float xPosR;                         // x position to spawn note on the right (2 and 4)
    public float yPosR;                         // y position to spawn note on the right

    public int noteMark = 0;             // iterator for the note lists

    public static int performance = 0;          // stores "instantaneous performance" of the player
                                                // success = 1, fail = 2
    public static int successCount = 0;         // number of success (1)

    public static int failCount = 0;             // number of fail's(2)

    public static int currentGesture = 0;       // current gesture: 1 = slashing, 2 = rotation

    public static int performedGesture = 0;     // gesture performed by the player

    public static float speedMultiplier = 3.0f; // speed multiplier for notes 

    public string timerReset = "y";

    public Transform song1;                     // song objects
    public Transform blueNoteObj;               // blue note object
    public Transform redNoteObj;                // red note object
    public Transform endGameMenuCanvas;         // end of game menu

    // Scene m_Scene;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("level = " + levelselect); 

       // reset global variable 
        songPaused = true;
        Time.timeScale = 0;

        performedGesture = 0;
        performance = 0;
        successCount = 0;
        failCount = 0;
        currentGesture = 0;

        Instantiate(song1, new Vector3(0, 0, 0), song1.rotation);

        StartCoroutine(waitTillSongEnds()); // wait until the song ends
    }

    // Update is called once per frame
    void Update()
    {

        if (ZeinaMoveMQTTBlue.gesture_pred == 1 || ZeinaMoveMQTTBlue.gesture_pred == 2)
        {
            performedGesture = ZeinaMoveMQTTBlue.gesture_pred;
        }

        if (hasLVLEnded == true) // if the song has ended, rate player's performance
        {
            // set the end of game menu canvas as active
            endGameMenuCanvas.gameObject.SetActive(true); // set end game menu as active
        }

        if (timerReset == "y") // reset timer to spawn note
        {
            StartCoroutine(spawnNote());
            timerReset = "n";
        }
    }

    IEnumerator spawnNote()
    {
        float noteInterval = 0.582524f;

        //List<float> whichNoteL = new List<float>() { };
        //List<float> whichNoteR = new List<float>() { };

        //switch (songselect)
        //{
        //    // bpm = bps*60      we need 1/bps = 60/bpm
        //    // The multiplyer reduces the number of notes spawned by increasing interval
        //    // wthe multiplayer will be adjust after tests with testgroup

        //    case 1: // bpm = 103                60/bpm = 0.582524
        //        noteInterval = 0.582524f * 1;   //interval between spawned notes *multiplyer

        //        whichNoteL = songOneL;          // select the note list for song1
        //        whichNoteR = songOneR;
        //        break;

        //    case 2: // bpm = 125                60/bpm = 0.48  
        //        noteInterval = 0.48f * 1;

        //        whichNoteL = songTwoL;
        //        whichNoteR = songTwoR;
        //        break;

        //    case 3: // bpm 163                  60/bpm = 0.368098
        //        noteInterval = 0.368098f * 1;

        //        whichNoteL = songThreeL;
        //        whichNoteR = songThreeR;
        //        break;

        //}

        yield return new WaitForSeconds(noteInterval);  // wait for "noteInterval" sec then spawn note, 
                                                        // adjust value to match bpm of the song
        if (noteMark < NoteL.Count && noteMark < NoteR.Count)
        {
            // assign position to the note on the left
            if (NoteL[noteMark] != 0) // if the current element is not a 0, spawn a note
            {
                spawnL = true;
            }
            if (NoteL[noteMark] == 1)
            {
                xPosL = -0.5f;
                yPosL = 0.3f;
            }
            if (NoteL[noteMark] == 3)
            {
                xPosL = -0.5f;
                yPosL = 1.3f;
            }

            //  assign position to the note on the right
            if (NoteR[noteMark] != 0)
            {
                spawnR = true;
            }
            if (NoteR[noteMark] == 2)
            {
                xPosR = 0.5f;
                yPosR = 0.3f;
            }
            if (NoteR[noteMark] == 4)
            {
                xPosR = 0.5f;
                yPosR = 1.3f;
            }
        }
        if (noteMark < NoteL.Count && noteMark < NoteR.Count) // if the noteMark is not at the last element of the list
        {
            timerReset = "y";

            // Left is blue, Right is red
            if (spawnL == true)
            {
                Instantiate(blueNoteObj, new Vector3(xPosL, yPosL, 10.0f), blueNoteObj.rotation); // spawn note on the left (blue)
                spawnL = false;
            }
            if (spawnR == true)
            {
                Instantiate(redNoteObj, new Vector3(xPosR, yPosR, 10.0f), redNoteObj.rotation); // spawn note on the right (red)
                spawnR = false;
            }
        }
        noteMark += 1;
    }

    IEnumerator waitTillSongEnds() // wait until the song ends, then display end game evaluation
    {
        yield return new WaitForSeconds(levelDuration);
        hasLVLEnded = true; // the current song has ended
    }
}
