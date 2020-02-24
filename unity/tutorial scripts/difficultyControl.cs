using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficultyControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSpeedtoLVL1()
    {
        GM_tutor.speedMultiplier = 3.0f;
    }

    public void setSpeedtoLVL2()
    {
        GM_tutor.speedMultiplier = 3.5f;
    }

    public void setSpeedtoLVL3()
    {
        GM_tutor.speedMultiplier = 4.0f;
    }
}
