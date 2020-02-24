using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public Button lvl3Button;
    public Button lvl2Button;
    public Button startGameButton;

    void Update(){
        if (GM.unlockedLvl3 == true) {
            lvl3Button.interactable = true;
        }
        else {
            lvl3Button.interactable = false;
        }

        if (GM.unlockedLvl2 == true) {
            lvl2Button.interactable = true;
        }
        else {
            lvl2Button.interactable = false;
        }
        if(StartMenuControl.isGameReady == true)
        {
            startGameButton.interactable = true;
        }
        else
        {
            startGameButton.interactable = false;
        }
    }
}
