using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameMessageControl : MonoBehaviour {

   
    void Start () {

        string s = GM.totalScore.ToString("#,##0");
        string s1 = "";
        string s2 = "";

        switch (GM.songselect)
        {
            case 1:
                if(GM.badGestureCount >= 20 || (GM.slowSlash + GM.slowRotate >=20))
                {
                    s1 = "we recommend practicing gesture in tutorial.";
                }
                if(GM.badPositionCount >= 10)
                {
                    s2 = "we recommend practicing position in tutorial.";
                }
                break;
            case 2:
                if (GM.badGestureCount >= 25 ||(GM.slowSlash + GM.slowRotate >= 25))
                {
                    s1 = "we recommend practicing gesture in tutorial.";
                }
                if (GM.badPositionCount >= 15)
                {
                    s2 = "we recommend practicing position in tutorial.";
                }
                break;
            case 3:
                if (GM.badGestureCount >= 30 || (GM.slowSlash + GM.slowRotate >= 30))
                {
                    s1 = "we recommend practicing gesture in tutorial.";
                }
                if (GM.badPositionCount >= 20)
                {
                    s2 = "we recommend practicing position in tutorial.";
                }
                break;


        }


        GetComponent<UnityEngine.UI.Text>().text = "Scores: " + s + " (" + GM.normalized_score + "%)" + "\nRating: " + GM.rating + "\nMax Combo: " + GM.maxCombo + "\nPerfect: "
            + GM.perfectCount + "\nCorrect position only: " + GM.goodCount + "\nCorrect gesture only: " + GM.missCount + "\nBad Position and Wrong Gesuture: " + GM.BadCount + "\n" + s1 + "\n" + s2;
    }
}
