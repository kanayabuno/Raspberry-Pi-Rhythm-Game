using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faillocationMessage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GM_tutor.levelselect == 1)
        {
            if (GM_tutor.performance == 2)
            {
                GetComponent<TextMesh>().text = "Bad location!";
            }
            else
            {
                GetComponent<TextMesh>().text = "";
            }
        }
        else if(GM_tutor.levelselect == 2)
        {
            if (GM_tutor.performance == 2)
            {
                GetComponent<TextMesh>().text = "Wrong gesture!";
            }
            else
            {
                GetComponent<TextMesh>().text = "";
            }
        }
    }
}
