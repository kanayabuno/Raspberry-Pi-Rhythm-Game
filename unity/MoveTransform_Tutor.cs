using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransform_Tutor : MonoBehaviour
{
  
    void Start()
    {
      
    }

    void Update()
    {
        transform.position -= transform.forward * Time.deltaTime * GM_tutor.speedMultiplier;
    }
}
