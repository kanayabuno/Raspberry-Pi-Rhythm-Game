using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuControl : MonoBehaviour {
    public Transform canvas;

	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }       
	}

    public void Pause() {
        if(canvas.gameObject.activeInHierarchy == false) {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            GM.songPaused = true;
        }
        else {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            GM.songPaused = false;
        }
    }
}
