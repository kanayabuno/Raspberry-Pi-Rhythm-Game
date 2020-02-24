using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteControl_Tutor : MonoBehaviour
{
    public Transform successBurstOnNote;
    private float min_distance = 100;
    //private int performance = 0;

    private bool correctDistance = false;

    //private bool correctTiming = false;

    private bool correctGesture = false; // false by default, true for testing w/o gesture

    private bool play_drum = false;
    AudioSource m_audio;

    //private int scoreMultiplier = 0;

    //private int scoreToAdd = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = transform.position.x;
        float yPos = transform.position.y;
        float zPos = transform.position.z;
        float distance = 100;


        // when the note enters the detection region, -3.0 < z < -0.3
        if (zPos <= 3.0f && zPos >= -3.0f)
        {

            //Debug.Log("IM IN THE REGION!!");

            // change color
            if (xPos == -0.5f)
            {
                Color newColor = new Color(0, 0.92f, 0.004f, 1); // a bright green color
                gameObject.GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.blue, Color.cyan, 0.1f)); // color change for blue

                // blue note enters detection region, set the current gesture to 1 (player needs to load gesture 1)

                GM_tutor.currentGesture = 1;

            }
            else if (xPos == 0.5f)
            {
                Color newColor = new Color(0.886f, 0, 0, 1); // a bright red color
                gameObject.GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(newColor, Color.red, 0.1f)); // color change for red

                // red note enters detection region, set the current gesture to 2 (player needs to load gesture 2)

                GM_tutor.currentGesture = 2;
            }


            //check Zeina's MQTT script for the gesture that's being received IMPORTANT!!
            Debug.Log("\n");

            Debug.Log("Current Gesture " + GM_tutor.currentGesture);
            Debug.Log("ZEINAMOVE!!!!: " + ZeinaMoveMQTTBlue.gesture_pred);
            //int curr = GM_tutor.currentGesture;
            //int pred = 

            if (GM_tutor.currentGesture == GM_tutor.performedGesture)
            {
                Debug.Log("CORRECT GESTURE");
                correctGesture = true;
            }



             //now get the coordinates of the collider
             //if the node is coming on the right side, read the coordinates of the red collider
             //if the node is coming on the left side, read the coordinates of the blue collider

            float colCoordX = 0;
            float colCoordY = 0;

            if (xPos == 0.5f)
            {
                colCoordX = ZeinaMoveMQTTBlue.redColCoordX;
                colCoordY = ZeinaMoveMQTTBlue.redColCoordY;
            }
            else if (xPos == -0.5f)
            {
                colCoordX = ZeinaMoveMQTTBlue.blueColCoordX;
                colCoordY = ZeinaMoveMQTTBlue.blueColCoordY;
            }


            //// now calculate the x-y (2D) distance between the node and the ball (collider)
            //distance = Mathf.Sqrt(Mathf.Pow((xPos - colCoordX), 2) + Mathf.Pow((yPos - colCoordY), 2));

            //if (distance <= min_distance)
            //{
            //    min_distance = distance;
            //}


            //if(GM_tutor.levelselect == 1)
            //{
            //    if (min_distance <= 0.7f)
            //    {

            //        correctDistance = true;

            //        // audioclip will play when the note is burst
            //        if (play_drum == false)
            //        {
            //            m_audio.Play();
            //            play_drum = true;
            //        }

            //        // correct distance  = success 

            //        GM_tutor.performance = 1;

            //        GM_tutor.successCount += 1;


            //        Destroy(gameObject);

            //        Instantiate(successBurstOnNote, new Vector3(xPos, yPos, zPos), successBurstOnNote.rotation);

            //    }

            //}
            if(GM_tutor.levelselect == 2)
            {
                if(correctGesture)
                {
                    GM_tutor.performance = 1;
                    GM_tutor.successCount += 1;
                    Debug.Log("success count: " + GM_tutor.successCount);
                    Destroy(gameObject);
                    Instantiate(successBurstOnNote, new Vector3(xPos, yPos, zPos), successBurstOnNote.rotation);
                }
            }
        }

        //if (zPos <= -3.5f) // note didnt get destroyed in time, exiting detection region
        //{
        //    GM_tutor.performance = 2;
        //    GM_tutor.failCount += 1;
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
            GM_tutor.performance = 2;
            GM_tutor.failCount += 1;
            Destroy(gameObject); // when the cube hits the fail collider, it gets destroyed

        }

        //if ((other.gameObject.name == "successBlue" && xPos == -0.5f) || (other.gameObject.name == "successRed" && xPos == 0.5f))

        if ((other.gameObject.name == "successBlue") || (other.gameObject.name == "successRed")) // if the note has collided onto the "success" collider
        {
            if(GM_tutor.levelselect == 1)
            {
                if (play_drum == false)
                {
                    m_audio.Play();
                    play_drum = true;
                }
                GM_tutor.performance = 1;
                GM_tutor.successCount += 1;
                Destroy(gameObject);
                Instantiate(successBurstOnNote, new Vector3(xPos, yPos, zPos), successBurstOnNote.rotation);
            }
        }
    }
}

