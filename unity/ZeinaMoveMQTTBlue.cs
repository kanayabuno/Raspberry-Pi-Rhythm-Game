using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;

using System;

public class ZeinaMoveMQTTBlue : MonoBehaviour
{
    //create an instance of MqttClient class 
    private MqttClient client;

    static string myLog = ""; //intalize a log of messages on topic 

    public GameObject target; //chose target gameobject
    public static float[] myFloatArray = new float[2]; //float for transform.position
    public static int gesture_pred = -1000;     //-1000 value is for error

    private float xPos = 0;
    private float yPos = 0;

    private float gameCoordX_red;
    private float gameCoordY_red;

    // the node control script needs access to the variables below
    public static float blueColCoordX = 0;              // the coordinates of blue collider
    public static float blueColCoordY = 0;

    public static float redColCoordX = 0;               // the coordinates of red collider
    public static float redColCoordY = 0;

    void Start()
    {
        //create MqttClient object
        client = new MqttClient(IPAddress.Parse("131.179.8.132"), 1883, false, null);
    
        //When was the message published to the Broker
        client.MqttMsgPublished += client_MqttMsgPublished;

        //to be notified about recieved messages published on the subscribed topic
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;


        //call the Connect Method to connect to the broker
        string clientId = Guid.NewGuid().ToString();

        //connect
        client.Connect(clientId);

        // subscribe to the topic "topic" with QoS 0, can subscribe to any number of topics 
        //adding red
        client.Subscribe(new string[] { "topic/red" },
            new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        //adding gesture
        client.Subscribe(new string[] { "topic/gesture" },
            new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
    }

    void client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
    {
      //  Debug.Log("Subscribed for id = " + e.MessageId);
    }

    void client_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
    {
        //Debug.Log("MessageId = " + e.MessageId + " Published = " + e.IsPublished);
        //Debug.Log("MessageId = " + e.MessageId);
    }

    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
        bool red = false;
        bool gesture = false;
        //this function is called everytime you receive message
        //e.Message is a byte[]
        var str = System.Text.Encoding.UTF8.GetString(e.Message);
        myLog += str + "\n";

        Debug.Log("received a message");

        if (String.Equals(e.Topic, "topic/red")){ 
            //you receive message for red color
            red = true;
            Debug.Log("red is true");
        }
        if (String.Equals(e.Topic, "topic/gesture")){
            //you receive message for gesture
            gesture = true;
            Debug.Log("gesture is true");
        }

        Debug.Log("entering if statement");

        if (red == true) { 

            string[] messageParts = str.Split(',');
            myFloatArray[0] = float.Parse(messageParts[0]);
            myFloatArray[1] = float.Parse(messageParts[1]);

            if (red == true){
                float camCoordX_red = myFloatArray[0];
                float camCoordY_red = myFloatArray[1];

                // real time coordinate mapping
                float xGameMin = -1.3f;
                float xGameMax = 1.3f;

                float yGameMin = 0.1f;
                float yGameMax = 1.5f;

                float xCamMin = 0;
                float xCamMax = 640;

                float yCamMin = 0;
                float yCamMax = 480;

                float xStep = (xGameMax - xGameMin) / (xCamMax - xCamMin); // = 1.6 / 640
                float yStep = (yGameMax - yGameMin) / (yCamMax - yCamMin); // = 1.4 / 480

                gameCoordX_red = xGameMin + xStep * camCoordX_red;
                gameCoordY_red = yGameMax - yStep * camCoordY_red;
            }
        }

        if(gesture == true){
                gesture_pred = Int32.Parse(str);
                //Debug.Log("gesture_pred is " + gesture_pred);
        }
    }


    void Update()
    {
        // because we're using one single script to move both colliders, and the coordinates of both colliders are stored
        // using only one pair of x-y varaibles (gameCoordX and gameCoordY), we need to store the coordinates of each 
        // collider separately. 
        if(!GM.songPaused && !GM_tutor.songPaused) // song has to be playing in both the normal level and the tutorial level
        {
                if ((gameObject.name == "successRed"))
                //move red ball
                {
                    transform.position = new Vector3(gameCoordX_red, gameCoordY_red, -2.5f);
                    /// store coordinates of red collider separately 
                    redColCoordX = gameCoordX_red;
                    redColCoordY = gameCoordY_red;
                }
        }
    }
}
