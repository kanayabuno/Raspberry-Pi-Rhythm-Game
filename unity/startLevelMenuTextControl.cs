using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startLevelMenuTextControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GM_tutor.levelselect == 1)
        {
            GetComponent<UnityEngine.UI.Text>().text = "Welcome to Raspberry Pi Rhythms :D \n" +
                "This is the Localization Tutorial. \n" +
                "Carefully position the ball to inctercept the incoming capsules. \n" +
                "the ball won't move if you go out of bounds! \n" +
                "Practice till you're good then press the Escape key or say stop.\n" +
                "You can check your performance at the end!";
        }
        else if(GM_tutor.levelselect == 2)
        {
            GetComponent<UnityEngine.UI.Text>().text = "This is the Gestures Tutorial. \n" +
                "Change the color of the ball by performing the correct gesture to match the color of the coming capsule. \n" +
                "Change the color to RED by performing a ROTATION. \n" +
                "Change the color to Blue by performing a CHOP. \n" +
                "If the gesture is too slow, the ball won't switch colors. \n" +
                "Practice till you're good then press the Escape key or say stop.\n" +
                "You can check your performance at the end!";
        }
    }
}
