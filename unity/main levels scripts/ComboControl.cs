using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboControl : MonoBehaviour {

    void Update () {
        GetComponent<TextMesh>().text = "Combo : " + GM.currentCombo;
    }
}
