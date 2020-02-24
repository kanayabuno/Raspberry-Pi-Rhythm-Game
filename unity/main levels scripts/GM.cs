using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class GM : MonoBehaviour {

    //List<int> whichSong = new List<int> { 1, 2, 3 };
    public static int songselect = 1; // used to select one of the three songs

    // Song 1 - List of notes on the left={1,3} & right={2,4}
    static List<float> songOneL = new List<float>()
    { 1, 0, 0, 0, 0, 0, 0, 3,
        3, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        1, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        3, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        3, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        1, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        3, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        1, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        1, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        3, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        3, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        3, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        3, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        1, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        1, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        3, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        1, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        1, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        3, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 3,
        1, 0, 0, 0, 0, 0, 0, 3,
    };

    static List<float> songOneR = new List<float>()
    { 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        4, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        4, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        2, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        4, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 0, 2, 0, 0, 0,
    };


    public float sizeLOne = songOneL.Count;
    public float sizeROne = songOneR.Count;
    public float songOneLengthInSec = 230.0f;

    // Song 2
    //static List<float> songTwoL = new List<float>() { 0, 1, 0, 3, 1, 0, 3, 0, 1, 0, 0, 0, 0, 3, 1, 0, 1, 0, 0, 0, 3, 0, 1, 0, 3, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 3, 1, 0, 0, 3, 0, 1, 0, 3, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 3, 0, 0, 1, 0, 0, 3, 0, 1, 0, 3, 1, 0, 3, 0, 1, 0, 3, 1, 0, 3, 0, 1, 0, 3, 1, 0, 3, 0, 1, 0, 0, 1, 0, 3, 1, 0, 1, 0, 0, 1, 0, 0, 3, 0, 0, 1, 0, 0, 3, 0, 0, 0, 3, 1, 0, 3, 0, 1, 0, 3, 0, 0, 3, 0, 1, 0, 3, 0, 0, 3, 0, 1, 0, 3, 0, 0, 0, 0, 0, 0, 3, 0, 1, 0, 0, 1, 0, 3, 0, 1, 0, 0, 0, 3, 1, 0, 3, 0, 0, 0, 3, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 3, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 3, 0, 0, 0, 0, 1, 0, 3, 0, 0, 3, 0, 0, 0, 3, 1, 0, 3, 0, 1, 0, 3, 1, 0, 3 };
    //static List<float> songTwoR = new List<float>() { 2, 0, 4, 0, 0, 4, 0, 2, 0, 4, 2, 4, 0, 0, 0, 0, 0, 2, 2, 0, 0, 2, 0, 4, 0, 0, 4, 0, 4, 0, 0, 0, 2, 2, 0, 0, 0, 4, 0, 0, 0, 0, 4, 0, 0, 0, 4, 0, 4, 0, 0, 0, 2, 4, 0, 0, 4, 0, 4, 4, 0, 0, 4, 0, 2, 0, 4, 0, 0, 4, 0, 2, 0, 4, 0, 0, 4, 0, 2, 0, 4, 0, 0, 4, 0, 2, 0, 4, 2, 0, 4, 0, 4, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 4, 0, 4, 0, 0, 0, 2, 4, 0, 0, 0, 0, 0, 4, 0, 0, 4, 0, 2, 0, 4, 0, 0, 4, 0, 2, 0, 4, 0, 0, 4, 0, 2, 0, 4, 0, 0, 4, 0, 0, 0, 4, 0, 0, 4, 4, 0, 2, 0, 4, 0, 0, 0, 0, 2, 0, 4, 0, 0, 0, 0, 4, 0, 4, 4, 0, 0, 4, 0, 2, 0, 0, 0, 0, 4, 0, 2, 0, 0, 0, 0, 4, 0, 0, 0, 4, 0, 0, 0, 0, 0, 4, 0, 2, 0, 0, 0, 0 };

    static List<float> songTwoL = new List<float>() { 0, 0, 0, 0, 0, 0, 3, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 3, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 3, 0, 1, 0, 0, 0, 3, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 3, 0, 1, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 0, 3, 0, 1, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 3, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 3, 0, 0, 1, 0, 0, 3, 0, 0, 0, 3, 0, 1, 0, 0, 0, 3, 0, 0, 0, 1, 0, 3, 0, 0, 0, 0, 0, 3, 0, 1, 0, 3, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 3, 0, 1, 0, 3, 0, 0, 0, 0, 0, 0, 3, 0, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
    static List<float> songTwoR = new List<float>() { 2, 0, 0, 0, 4, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 4, 2, 0, 4, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 4, 0, 4, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 4, 0, 0, 0, 4, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 2, 0, 0, 0, 4, 0, 2, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 4, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 4, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 4, 0, 2, 0, 0, 0, 4, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 4, 0, 0, 0, 0, 0, 4, 0, 0, 0, 4, 0, 4, 0, 0, 0, 2, 0, 4, 0, 0, 0, 0, 0, 2, 0, 0, 4, 0, 0, 0, 0, 0, 4, 0, 4, 0, 4, 0, 0, 0, 4, 0, 2, 0, 0, 0, 0, 4, 0, 2, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 4, 0, 0, 0, 2, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0 };

    public float sizeLTwo = songTwoR.Count;
    public float sizeRTwo = songTwoR.Count;
    public float songTwoLengthInSec = 220.0f;

    // Song 3
    static List<float> songThreeL = new List<float>() { 1, 0, 1, 3, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 3, 1, 0, 0, 3, 0, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 3, 0, 0, 1, 0, 0, 3, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 1, 3, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 3, 1, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 3, 0, 1, 0, 1, 3, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 3, 1, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 3, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 3, 0, 0, 0, 1, 0, 3, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 3, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 3, 0, 1, 0, 3, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 3, 0, 0, 0, 3, 0, 1, 0, 3, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 3, 0 };
    static List<float> songThreeR = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 4, 4, 0, 4, 0, 0, 0, 0, 0, 0, 2, 0, 0, 2, 0, 4, 0, 0, 4, 0, 4, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 4, 0, 0, 0, 2, 4, 0, 0, 4, 0, 4, 4, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0, 4, 0, 2, 0, 0, 0, 0, 0, 0, 4, 0, 0, 4, 4, 0, 4, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 4, 0, 4, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 4, 0, 0, 4, 0, 4, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 4, 0, 4, 0, 0, 0, 0, 4, 0, 0, 0, 0, 4, 4, 0, 0, 0, 4, 0, 0, 2, 0, 2, 0, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 2, 0, 0, 0, 0, 0, 4, 0, 0, 4, 0, 0, 0, 0, 2, 0, 0, 4, 0, 0, 4, 0, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 4, 4, 0, 4, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 2, 4, 0, 0, 0, 0, 4, 4, 0, 0, 0 };

    public float sizeLThree = songThreeL.Count;
    public float sizeRThree = songThreeR.Count;
    public float songThreeLengthInSec = 155.0f;

    ////////////////////////////////////////////////////////////////////////////

    public static bool hasSongEnded = false;    // intially, song didn't end
    public bool spawnL = false;          // spawn note on left (1 and 3)
    public bool spawnR = false;          // spawn note on right (2 and 4)
    public static bool passedLevel = true;      // player need to pass lvl to unlock next lvl (needs to be false)
    public static bool unlockedLvl2 = true;    
    public static bool unlockedLvl3 = true;     // true for testing, change to flase at the end
    public static bool songPaused = false;      // Dont' pause song at the begining

 //   public static bool activateGesture = false; // if this is true, send a signal to kana to get gesture
 //   public static bool detectedGesture = false; // if a gesture is detected, this needs to be set to true

    public static float totalNote = 0;          // total number of note
    public static float totalScore = 0;         // # of note successful hit
    public static float normalized_score = 0;   // normalized_score = totalScore / max possible score 

    public float xPosL;                         // x position to spawn note on the left (1 and 3)
    public float yPosL;                         // y position to spawn note on the left
    public float xPosR;                         // x position to spawn note on the right (2 and 4)
    public float yPosR;                         // y position to spawn note on the right

    public int noteMark = 0;             // iterator for the note lists
    public static int currentCombo = 0;         // current successive hit on notes
    public static int maxCombo = 0;             // maximum successive hits on notes 

    public static int performance = 0;          // stores "instantaneous performance" of the player
                                                // 1='Perfect', 2='Missed Gestures', 3='Missed time', 4='Miss'

    public static int perfectCount = 0;         // number of perfect hit (1)

    public static int goodCount = 0;            // number of good hit (2)

    public static int missCount = 0;            // number of miss's (3)

    public static int BadCount = 0;             // number of bad's(4)

    public static int slowSlash = 0;            // # of slow slashes

    public static int slowRotate = 0;           // # of slow rotation

    public static int currentGesture = 0;       // current gesture: 1 = chop, 2 = rotation

    public static int performedGesture = 0;      // gesture performed by the player

    public static int TotalNumberOfNote = 0;        // total number of notes to be spawned (excluding 0's) in this level IMPORTANT!!!

    public static int badGestureCount = 0;

    public static int badPositionCount = 0;

    public static bool gameStarted = false;

    public static string rating = "";           // rating of player performance (at the end of the game)
    public string timerReset = "y";             // reset timer to spawn note object

   

    public Transform song1;                     // song objects
    public Transform song2;
    public Transform song3;
    public Transform blueNoteObj;               // blue note object
    public Transform redNoteObj;                // red note object
    public Transform endGameMenuCanvas;         // end of game menu

    Scene m_Scene;

    ////////////////////////////////////////////////////////////////////////////

    void Start () {

        Debug.Log("# of elements in songL" + songTwoL.Count());
        Debug.Log("# of elements in songR" + songTwoR.Count());


        // reset all these global variables

        totalScore = 0;
        currentCombo = 0;
        hasSongEnded = false;
        totalNote = 0;
        passedLevel = true; //please change to false for final version
        normalized_score = 0;
        rating = "";
        maxCombo = 0;
        songPaused = false;
        Time.timeScale = 1;

        performedGesture = 0;
        performance = 0;
        perfectCount = 0;         
        goodCount = 0;           
        missCount = 0;           
        BadCount = 0;
        slowSlash = 0;
        slowRotate = 0;
        badGestureCount = 0;
        badPositionCount = 0;
        currentGesture = 0;
        TotalNumberOfNote = 0;

        GM_tutor.songPaused = false; // bandit fix for now

        // select the song corresponding to the current scene
        // this is not necessary for the game but it lets you test/modify each scene individually
        m_Scene = SceneManager.GetActiveScene();

        if(m_Scene.name == "songplaylvl1") {
            songselect = 1;
        }
        else if(m_Scene.name == "songplaylvl2") {
            songselect = 2;
        }
        else if(m_Scene.name == "songplaylvl3") {
            songselect = 3;
        }

        // instanitate the song object at the start of the level
        switch (songselect) {
            case 1: // select song 1
                Instantiate(song1, new Vector3(0, 0, 0), song1.rotation);

                TotalNumberOfNote = songOneL.Count(x => x != 0) + songOneR.Count(x => x != 0);

                break;
            case 2:
                Instantiate(song2, new Vector3(0, 0, 0), song2.rotation);

                TotalNumberOfNote = songTwoL.Count(x => x != 0) + songTwoR.Count(x => x != 0);

                break;
            case 3:
                Instantiate(song3, new Vector3(0, 0, 0), song3.rotation);

                TotalNumberOfNote = songThreeL.Count(x => x != 0) + songThreeR.Count(x => x != 0);

                break;
        }

        //Debug.Log("# of notes = " + TotalNumberOfNote);

        Debug.Log("gesture mode " + performedGesture);

        StartCoroutine(waitTillSongEnds()); // wait until the song ends
    }

    void Update () {

        // load gesture mode

        if (ZeinaMoveMQTTBlue.gesture_pred == 1 || ZeinaMoveMQTTBlue.gesture_pred == 2)
        {
            performedGesture = ZeinaMoveMQTTBlue.gesture_pred;
        }
        // count the # of slow gesture.
        else if (ZeinaMoveMQTTBlue.gesture_pred == 3)
        {
            slowSlash += 1;
        }
        else if (ZeinaMoveMQTTBlue.gesture_pred == 4)
        {
            slowRotate += 1;
        }

        // count bad gesture

        badGestureCount = BadCount + goodCount;

        // count bad position

        badPositionCount = BadCount + missCount;

        Debug.Log("miss count = " + missCount);

        // the algorithim for totalScore will change, values of totalScore are added by nodecontrol.cs
        normalized_score = (int)100*totalScore / 1000000; // calculate accuracy of the player

        if (currentCombo >= maxCombo) // update player's maximum successive hits on notes
        {
            maxCombo = currentCombo;
        }

        //thresholds will be adjust in the future, rating will be = {SS, S, A, B, C, F}
        if (hasSongEnded == true) // if the song has ended, rate player's performance
        {
            if(normalized_score >= 90) {
                rating = "A";
                passedLevel = true;
            }
            else if(normalized_score >= 80) {
                rating = "B";
                passedLevel = true;
            }
            else if(normalized_score >= 70) {
                rating = "C";
                passedLevel = true;
            }
            else if(normalized_score < 70) {
                rating = "F";
                passedLevel = false;
            }

            if(passedLevel == true)  // if the player has unlocked the next level
            {
                switch(songselect) {
                    case 1:
                        unlockedLvl2 = true;
                        break;

                    case 2:
                        unlockedLvl3 = true;
                        break;
                }
            }

            // set the end of game menu canvas as active
            endGameMenuCanvas.gameObject.SetActive(true); // set end game menu as active
        }
        
        if ( timerReset == "y") // reset timer to spawn note
        {
            StartCoroutine(spawnNote());
            timerReset = "n";
        }        
    }

    IEnumerator spawnNote()
    {
        float noteInterval = 0;

        List<float> whichNoteL = new List<float>(){};
        List<float> whichNoteR = new List<float>(){};

        switch (songselect)
        {
            // bpm = bps*60      we need 1/bps = 60/bpm
            // The multiplyer reduces the number of notes spawned by increasing interval
            // wthe multiplayer will be adjust after tests with testgroup

            case 1: // bpm = 103                60/bpm = 0.582524
                noteInterval = 0.582524f * 1;   //interval between spawned notes *multiplyer

                whichNoteL = songOneL;          // select the note list for song1
                whichNoteR = songOneR; 
                break;

            case 2: // bpm = 125                60/bpm = 0.48  
                noteInterval = 0.48f * 1;

                whichNoteL = songTwoL;
                whichNoteR = songTwoR;
                break;
                 
            case 3: // bpm 163                  60/bpm = 0.368098
                noteInterval = 0.368098f *1;

                whichNoteL = songThreeL;
                whichNoteR = songThreeR;
                break;

        }

        yield return new WaitForSeconds(noteInterval);  // wait for "noteInterval" sec then spawn note, 
                                                        // adjust value to match bpm of the song
                                                        
        if (noteMark < whichNoteL.Count && noteMark < whichNoteR.Count)
        {
            // assign position to the note on the left
            if (whichNoteL[noteMark] != 0) // if the current element is not a 0, spawn a note
            {
                spawnL = true;
                totalNote = totalNote + 1;
            }
            if (whichNoteL[noteMark] == 1) {
                xPosL = -0.5f;
                yPosL = 0.3f;
            }
            if (whichNoteL[noteMark] == 3) {
                xPosL = -0.5f;
                yPosL = 1.3f;
            }

            //  assign position to the note on the right
            if (whichNoteR[noteMark] != 0) {
                spawnR = true;
                totalNote = totalNote + 1;
            }
            if (whichNoteR[noteMark] == 2) {
                xPosR = 0.5f;
                yPosR = 0.3f;               
            }
            if (whichNoteR[noteMark] == 4) {
                xPosR = 0.5f;
                yPosR = 1.3f;
            }
        }
        if (noteMark < whichNoteL.Count && noteMark < whichNoteR.Count) // if the noteMark is not at the last element of the list
        {
            timerReset = "y";

            // Left is blue, Right is red
            if(spawnL == true) {
                Instantiate(blueNoteObj, new Vector3(xPosL, yPosL, 10.0f), blueNoteObj.rotation); // spawn note on the left (blue)
                spawnL = false;
            }
            if (spawnR == true) {
                Instantiate(redNoteObj, new Vector3(xPosR, yPosR, 10.0f), redNoteObj.rotation); // spawn note on the right (red)
                spawnR = false;
            }
        }
        noteMark += 1;
    }

    IEnumerator waitTillSongEnds() // wait until the song ends, then display end game evaluation
    {
        switch(songselect) {
            case 1:
                yield return new WaitForSeconds(songOneLengthInSec);
                hasSongEnded = true; // the current song has ended
                break;
            case 2:
                yield return new WaitForSeconds(songTwoLengthInSec);
                hasSongEnded = true;
                break;
            case 3:
                yield return new WaitForSeconds(songThreeLengthInSec);
                hasSongEnded = true;
                break;
        }        
    }
}
