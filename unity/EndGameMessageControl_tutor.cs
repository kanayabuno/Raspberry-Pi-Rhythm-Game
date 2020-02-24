using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameMessageControl_tutor : MonoBehaviour
{
    public string s = "";
    // Start is called before the first frame update
    void Start()
    {
        switch(GM_tutor.levelselect)
        {
            case 1:
                s = "\nFail (bad position): ";
                break;
            case 2:
                s = "\nFail (wrong gesture): ";
                break;
        }
        GetComponent<UnityEngine.UI.Text>().text = "Success: " + GM_tutor.successCount + s + GM_tutor.failCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
