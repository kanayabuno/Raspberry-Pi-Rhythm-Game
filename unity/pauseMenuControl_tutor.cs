using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenuControl_tutor : MonoBehaviour
{
    public Transform canvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            GM_tutor.songPaused = true;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            GM_tutor.songPaused = false;
        }
    }

}
