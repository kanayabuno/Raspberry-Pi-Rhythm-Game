using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreControl : MonoBehaviour {


    void Update () {

        // displays the player's scores

        string s = GM.totalScore.ToString("#,##0");

        GetComponent<TextMesh>().text = "Score : " + s + "\n(" + GM.normalized_score + "%)";
	}
}
