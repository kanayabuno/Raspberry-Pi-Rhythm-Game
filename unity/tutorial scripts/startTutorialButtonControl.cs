using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startTutorialButtonControl : MonoBehaviour
{
    public Transform canvas;

    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void startTutorial()
    {
        if (canvas.gameObject.activeInHierarchy == true)
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            GM_tutor.songPaused = false;
        }
        //else
        //{
        //    canvas.gameObject.SetActive(false);
        //    Time.timeScale = 1;
        //    GM_tutor.songPaused = false;
        //}
    }
}
