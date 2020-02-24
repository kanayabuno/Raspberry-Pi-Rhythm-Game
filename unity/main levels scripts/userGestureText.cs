using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userGestureText : MonoBehaviour
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
        switch (GM.performedGesture)
        {
            case 0:
                GetComponent<UnityEngine.UI.Text>().text = "";
                break;
            case 1:
                text.color = Color.blue;
                GetComponent<UnityEngine.UI.Text>().text = "Your gesture: Chop ";
                break;
            case 2:
                text.color = Color.red;
                GetComponent<UnityEngine.UI.Text>().text = "Your gesture: Rotation";
                break;
           
        }
    }
}
