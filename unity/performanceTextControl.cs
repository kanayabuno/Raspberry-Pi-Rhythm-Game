using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class performanceTextControl : MonoBehaviour {

    public UnityEngine.UI.Text text;

	// Use this for initialization
	void Start () {

        text = GetComponent<UnityEngine.UI.Text>();
    }
	
	// Update is called once per frame
	void Update () {

        // this controls the text object to give the player immediate feedback

        switch(GM.performance)
        {
            case 1:
                text.color = Color.yellow; // change the color of the text
                GetComponent<UnityEngine.UI.Text>().text = "Perfect!";
                break;
            case 2:
                text.color = Color.green;
                GetComponent<UnityEngine.UI.Text>().text = "Wrong Gesture!!";
                break;
            case 3:
                text.color = Color.magenta;
                GetComponent<UnityEngine.UI.Text>().text = "Wrong Position!!";
                break;
            case 4:
                text.color = Color.red;
                GetComponent<UnityEngine.UI.Text>().text = "Bad.";
                break;
        }


    }
}
