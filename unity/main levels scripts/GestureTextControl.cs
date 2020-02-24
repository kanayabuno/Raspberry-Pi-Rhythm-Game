using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureTextControl : MonoBehaviour
{
    public UnityEngine.UI.Text text;

    // Use this for initialization
    void Start()
    {

        text = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (GM.currentGesture)
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
