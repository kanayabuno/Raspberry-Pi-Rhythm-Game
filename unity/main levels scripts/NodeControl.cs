using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeControl : MonoBehaviour {

    public Transform successBurstOnNote;
    private float min_distance = 100;
    //private int performance = 0;

    private bool correctLocation = false;
   
    //private bool correctTiming = false;

    private bool correctGesture = false; // false by default, true for testing w/o gesture

    private bool play_drum = false;
    AudioSource m_audio;

    private int scoreMultiplier = 0;

    private int scoreToAdd = 0;

    // int gesture = recieve 1 or 2 from topic

    void Start() {
        m_audio = GetComponent<AudioSource>();
    }
    
    void Update () {
        float xPos = transform.position.x;
        float yPos = transform.position.y;
        float zPos = transform.position.z; 
        float distance = 100;


        // when the note enters the detection region, -3.0 < z < -0.3
        if (zPos <= 3.0f && zPos >= -3.0f)
        {
            //bool hit = false;

            // change color
            if(xPos == -0.5f){
                Color newColor = new Color(0, 0.92f, 0.004f, 1); // a bright green color
                gameObject.GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.blue, Color.cyan, 0.1f)); // color change for blue

                // blue note enters detection region, set the current gesture to 1 (player needs to load gesture 1)

                GM.currentGesture = 1;

            }
            else if(xPos == 0.5f){
                Color newColor = new Color(0.886f, 0, 0, 1); // a bright red color
                gameObject.GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(newColor, Color.red, 0.1f)); // color change for red

                // red note enters detection region, set the current gesture to 2 (player needs to load gesture 2)

                GM.currentGesture = 2;
            }

             //check Zeina's MQTT script for the gesture that's being received IMPORTANT!!

            if(GM.performedGesture == GM.currentGesture)
            {
                correctGesture = true;
            }

            // now get the coordinates of the collider
            // if the node is coming on the right side, read the coordinates of the red collider
            // if the node is coming on the left side, read the coordinates of the blue collider

           // float colCoordX = 0;
           // float colCoordY = 0;

           // if (xPos == 0.5f){
           //     colCoordX = ZeinaMoveMQTTBlue.redColCoordX; 
           //     colCoordY = ZeinaMoveMQTTBlue.redColCoordY;
           // }
           // else if (xPos == -0.5f){
           //     colCoordX = ZeinaMoveMQTTBlue.blueColCoordX;
           //     colCoordY = ZeinaMoveMQTTBlue.blueColCoordY;
           // }

           // // now calculate the x-y (2D) distance between the node and the ball (collider)
           //distance = Mathf.Sqrt(Mathf.Pow((xPos - colCoordX), 2) + Mathf.Pow((yPos - colCoordY), 2));

            //if (distance <= min_distance){
            //    min_distance = distance;
            //}

            if (min_distance <= 0.7f )
            {

                //correctLocation = true;

                // at this point, the player hit the note while its inside the detection (z) region 

                //i.e correct position + correct timing ===> perfect or good

                // audioclip will play when the note is burst
                //if (play_drum == false)
                //{
                //    m_audio.Play();
                //    play_drum = true;
                //}

                ////change color to yellow
                //gameObject.GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.yellow, Color.clear, 0)); // change


                //if(correctGesture)
                //{

                //    // correct distance (position) + correct gesture + inside Z detection region (correct timing) = PERFECT 

                //    GM.performance = 1;

                //    scoreMultiplier = 100;

                //    GM.perfectCount += 1;

                //    scoreToAdd = (900000 / GM.TotalNumberOfNote * scoreMultiplier / 100) + (200000 / GM.TotalNumberOfNote / (GM.TotalNumberOfNote - 1) * GM.currentCombo);

                //    GM.totalScore += scoreToAdd; // change this


                //}
                //else if(!correctGesture)
                //{
                //    GM.performance = 2;

                //    scoreMultiplier = 63;

                //    GM.goodCount += 1;

                //    scoreToAdd = (900000 / GM.TotalNumberOfNote * scoreMultiplier / 100) + (200000 / GM.TotalNumberOfNote / (GM.TotalNumberOfNote - 1) * GM.currentCombo);

                //    GM.totalScore += scoreToAdd; // change this

                //}


                //Destroy(gameObject);

                //Instantiate(successBurstOnNote, new Vector3(xPos, yPos, zPos), successBurstOnNote.rotation);

                //// increase combo
                //GM.currentCombo += 1;

                ////this will change in the future
                //if (min_distance <= 0.3f) {
                //    performance = 1;
                //}
                //else{
                //    performance = 2;
                //}

                //if (hit && distance > min_distance) {
                //    GM.performance = performance;   //will only update final perfomance verdict to GM.cs
                //    Destroy(gameObject);

                //    Instantiate(successBurstOnNote, new Vector3(xPos, yPos, zPos), successBurstOnNote.rotation);

                //    // increase win streak and score
                //    GM.currentCombo += 1;
                //    GM.totalScore += 1;
                //}
            }

        }

        //if (zPos <= -3.5f ) // note didnt get destroyed in time, exiting detection region
        //{



        //    // check Zeina's MQTT script for the gesture that's being received IMPORTANT!!

        //    //if (ZeinaMQTTgesture.gesture == GM.currentGesture)
        //    //{
        //    //    correctGesture = true;
        //    //}


        //    if (correctGesture)
        //    {

        //        // correct distance (position) + correct gesture + inside Z detection region (correct timing) = PERFECT 

        //        GM.performance = 3;

        //        scoreMultiplier = 27;

        //        GM.missCount += 1;

        //    }
        //    else if (!correctGesture)
        //    {
        //        GM.performance = 4;

        //        scoreMultiplier = 0;

        //        GM.BadCount += 1;
        //    }


        //    GM.currentCombo = 0; // reset win streak

        //    scoreToAdd = (900000 / GM.TotalNumberOfNote * scoreMultiplier/ 100 ) + (200000 / GM.TotalNumberOfNote / (GM.TotalNumberOfNote - 1) * GM.currentCombo);

        //    GM.totalScore += scoreToAdd; // change this

        //    Destroy(gameObject); // when the cube hits the fail collider, it gets destroyed

        //}

    }

    void OnTriggerEnter(Collider other) // collider box detection
    {
        // get the current position of the game object (cube note)
        float xPos = transform.position.x;
        float yPos = transform.position.y;
        float zPos = transform.position.z;

        if (other.gameObject.name == "Fail") // if the note has collided onto the "fail" collider
        {

            if (correctGesture)
            {
                // correct distance (position) + correct gesture + inside Z detection region (correct timing) = PERFECT 
                GM.performance = 3;
                scoreMultiplier = 40;
                GM.missCount += 1;
            }
            else if (!correctGesture)
            {
                if(correctLocation)
                {
                    GM.performance = 2;
                    scoreMultiplier = 40;
                    GM.goodCount += 1;
                    //scoreToAdd = (900000 / GM.TotalNumberOfNote * scoreMultiplier / 100) + (200000 / GM.TotalNumberOfNote / (GM.TotalNumberOfNote - 1) * GM.currentCombo);
                    GM.totalScore += scoreToAdd; // change this
                }
                else
                {
                    GM.performance = 4;
                    scoreMultiplier = 0;
                    GM.BadCount += 1;
                }

            }

            GM.currentCombo = 0; // reset win streak
            scoreToAdd = (900000 / GM.TotalNumberOfNote * scoreMultiplier / 100 ) + (200000 / GM.TotalNumberOfNote / (GM.TotalNumberOfNote - 1) * GM.currentCombo);
            GM.totalScore += scoreToAdd; // change this
            Destroy(gameObject); // when the cube hits the fail collider, it gets destroyed
            //Debug.Log("Fail!");

        }
        //if ((other.gameObject.name == "successBlue" && xPos == -0.5f) || (other.gameObject.name == "successRed" && xPos == 0.5f))
        if ((other.gameObject.name == "successBlue") || (other.gameObject.name == "successRed")) // if the note has collided onto the "success" collider
        {
            correctLocation = true;
            if (play_drum == false)
            {
                m_audio.Play();
                play_drum = true;
            }

            if (correctGesture)
            {
                GM.performance = 1;
                scoreMultiplier = 100;
                GM.perfectCount += 1;
                scoreToAdd = (900000 / GM.TotalNumberOfNote * scoreMultiplier / 100 ) + (200000 / GM.TotalNumberOfNote / (GM.TotalNumberOfNote - 1) * GM.currentCombo);
                GM.totalScore += scoreToAdd; // change this
                Destroy(gameObject);
                Instantiate(successBurstOnNote, new Vector3(xPos, yPos, zPos), successBurstOnNote.rotation);
                GM.currentCombo += 1;
            }
            //else
            //{
            //    GM.performance = 2;
            //    scoreMultiplier = 63;
            //    GM.goodCount += 1;
            //    scoreToAdd = (900000 / GM.TotalNumberOfNote * scoreMultiplier / 100) + (200000 / GM.TotalNumberOfNote / (GM.TotalNumberOfNote - 1) * GM.currentCombo);
            //    GM.totalScore += scoreToAdd; // change this
            //}

           

            // instantiate the particle burst effect 
            //Instantiate(successBurstOnNote, new Vector3(xPos, yPos, zPos), successBurstOnNote.rotation);

            // increase win streak and score
            //GM.currentCombo += 1;
        }

    }
}
