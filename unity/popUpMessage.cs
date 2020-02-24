﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUpMessage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ZeinaMoveMQTTBlue.gesture_pred == 3)
        {
            if(GM.performedGesture != 1)
            {
                GetComponent<UnityEngine.UI.Text>().text = "Chop Faster!!";
            }
            else
            {
                GetComponent<UnityEngine.UI.Text>().text = "";
            }
        }
        else if(ZeinaMoveMQTTBlue.gesture_pred == 4)
        {
            if(GM.performedGesture != 2)
            {
                GetComponent<UnityEngine.UI.Text>().text = "Rotate faster!!";
            }
            else
            {
                GetComponent<UnityEngine.UI.Text>().text = "";
            }
        }
        else if (ZeinaMoveMQTTBlue.gesture_pred == 1 || ZeinaMoveMQTTBlue.gesture_pred == 2)
        {
            GetComponent<UnityEngine.UI.Text>().text = "";
        }
    }
}
