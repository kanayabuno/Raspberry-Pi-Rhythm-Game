using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowgestureWarning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GM_tutor.levelselect == 2)
        {
            if (ZeinaMoveMQTTBlue.gesture_pred == 3)
            {
                if (GM_tutor.performedGesture != 1)
                {
                    GetComponent<TextMesh>().text = "Chop Faster!";
                }
                else
                {
                    GetComponent<TextMesh>().text = "";
                }
            }
            else if (ZeinaMoveMQTTBlue.gesture_pred == 4)
            {
                if (GM_tutor.performedGesture != 2)
                {
                    GetComponent<TextMesh>().text = "Rotate Faster!!";
                }
                else
                {
                    GetComponent<TextMesh>().text = "";
                }
            }
            else if (ZeinaMoveMQTTBlue.gesture_pred == 1 || ZeinaMoveMQTTBlue.gesture_pred == 2)
            {
                GetComponent<TextMesh>().text = "";
            }
        }
        else
        {
            GetComponent<TextMesh>().text = "";
        }

    }
}
