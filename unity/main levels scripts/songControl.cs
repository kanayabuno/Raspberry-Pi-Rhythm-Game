using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songControl : MonoBehaviour {

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update () {
   

        if (GM.songPaused == true)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }
	}
}
