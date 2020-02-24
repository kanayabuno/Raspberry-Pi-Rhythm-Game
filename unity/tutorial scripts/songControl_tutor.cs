using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songControl_tutor : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update () {


        if (GM_tutor.songPaused == true)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }
    }
}
