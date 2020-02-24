using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureTextControl_tutor : MonoBehaviour
{

    public UnityEngine.UI.Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GM_tutor.levelselect == 1)
        {
            GetComponent<UnityEngine.UI.Text>().text = "";
        }
        if(GM_tutor.levelselect == 2)
        {
            switch (GM_tutor.currentGesture)
            {
                case 0:
                    GetComponent<UnityEngine.UI.Text>().text = "";
                    break;
                case 1:
                    text.color = Color.blue; // change the color of the text
                    GetComponent<UnityEngine.UI.Text>().text = "Chop!!!";
                    break;
                case 2:
                    text.color = Color.red;
                    GetComponent<UnityEngine.UI.Text>().text = "Rotate!!!";
                    break;
            }
        }

    }
}
