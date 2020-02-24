using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTransform : MonoBehaviour {

    public float multiplier = 0;

	void Start () {
        switch(GM.songselect)
        {
            case 1:
                multiplier = 3.0f;
                break;
            case 2:
                multiplier = 3.5f;
                break;

            case 3:
                multiplier = 4.0f;
                break;
        }		
	}
	
	void Update () 
    {
        transform.position -= transform.forward * Time.deltaTime * multiplier;
	}
}
