using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Webcam : MonoBehaviour {
    Renderer myrenderer;
    WebCamTexture mywebcam;

    void Start () {
        mywebcam = new WebCamTexture();

        myrenderer = GetComponent<Renderer>();
        myrenderer.material.mainTexture = mywebcam;
        mywebcam.Play();
	}

    // necessary when we switch or reload scenes
    void OnDestroy() {
        mywebcam.Stop();
    }
}
