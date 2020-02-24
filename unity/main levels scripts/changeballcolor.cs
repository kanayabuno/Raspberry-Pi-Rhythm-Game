using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeballcolor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GM.performedGesture = 0;
        GM_tutor.performedGesture = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Color32 objColor;
        objColor = gameObject.GetComponent<MeshRenderer>().material.color;
        if (GM.performedGesture == 1 || GM_tutor.performedGesture == 1)
        {

            //gameObject.GetComponentInChildren<Renderer>().material.SetColor("_Color",Color.Lerp(Color.blue, objColor, 0.1f));
            gameObject.GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.blue);


        }
        else if(GM.performedGesture == 2 || GM_tutor.performedGesture == 2)
        {
            Color newColor = new Color(1, 0.266f, 0.993f, 1); // a bright green color
            //gameObject.GetComponentInChildren<Renderer>().material.SetColor(Color.Lerp(Color.red, objColor, 0.1f));
            gameObject.GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.red);
        }
	
    }
}
