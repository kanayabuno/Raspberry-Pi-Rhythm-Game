using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class performanceTextControl_tutor : MonoBehaviour
{
    public UnityEngine.UI.Text text;

    // Use this for initialization
    void Start () {

        text = GetComponent<UnityEngine.UI.Text>();
    }
    
    // Update is called once per frame
    void Update () {

        // this controls the text object to give the player immediate feedback

        switch(GM_tutor.performance)
        {
            case 1:
                text.color = Color.yellow; // change the color of the text
                GetComponent<UnityEngine.UI.Text>().text = "Success!";
                break;
            case 2:
                text.color = Color.red;
                if(GM_tutor.levelselect == 1)
                {
                    GetComponent<UnityEngine.UI.Text>().text = "Fail. (bad postion!)";
                }
                if(GM_tutor.levelselect == 2)
                {
                    GetComponent<UnityEngine.UI.Text>().text = "Fail. (wrong gesture!)";
                }
                break;
        }
    }
}
