using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupMessage : MonoBehaviour
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
        if ((ZeinaMoveMQTTBlue.redColCoordX == 0 && ZeinaMoveMQTTBlue.redColCoordY == 0) || ZeinaMoveMQTTBlue.gesture_pred == -1000)
        {
            StartMenuControl.isGameReady = false;
            text.color = Color.red;
            GetComponent<UnityEngine.UI.Text>().text = "Game not ready";
        }
        else
        {
            StartMenuControl.isGameReady = true;
            text.color = Color.green;
            GetComponent<UnityEngine.UI.Text>().text = "Game ready";
        }
    }
}
