using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelButtonControl : MonoBehaviour {
    public Button nextLvlButton;

    void Update () {
        bool isNextLvlUnlocked = false;

        switch (GM.songselect) {
            case 1:
                isNextLvlUnlocked = GM.unlockedLvl2;
                break;
            case 2:
                isNextLvlUnlocked = GM.unlockedLvl3;
                break;
            case 3:
                isNextLvlUnlocked = false; // nothing after level 3
                break;
        }

        if ((GM.passedLevel == true || isNextLvlUnlocked == true) && GM.songselect != 3) {
            nextLvlButton.interactable = true;
        }
        else {
            nextLvlButton.interactable = false;
        }
    }
}
