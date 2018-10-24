using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;

using System;
using System.Timers;
using System.Text;
using System.Collections.Generic;

public class mqttTest : MonoBehaviour
{
    public string MQTT_val;

    private MqttClient client;
    private testJSON testMessage;
    bool firstFlag;
    // Use this for initialization
    void Start()
    {
        firstFlag = true;
        // create client instance 
        client = new MqttClient(IPAddress.Parse("127.0.0.1"), 1883, false, null);

        // register to message received 
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

        string clientId = Guid.NewGuid().ToString();
        client.Connect(clientId);

        // subscribe to the topic "/home/temperature" with QoS 2 
        client.Subscribe(new string[] { "hello/world" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        client.Subscribe(new string[] { "#" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
    }
    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
        //Debug.Log(e.Message.ToString());

        // if (firstFlag)
        // {
        //     testMessage = JsonUtility.FromJson<testJSON>(Encoding.UTF8.GetString(e.Message));
        //     firstFlag = false;
        //     Debug.Log("First Message Received!");
        // }
        // else
        //     JsonUtility.FromJsonOverwrite(Encoding.UTF8.GetString(e.Message), testMessage);


        // Debug.Log(testMessage.testVal);
        MQTT_val = Encoding.UTF8.GetString(e.Message);

        Debug.Log("Received: " + Encoding.UTF8.GetString(e.Message));
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(20, 40, 80, 20), "Level 1"))
        {
            Debug.Log("sending...");
            client.Publish("hello/world", System.Text.Encoding.UTF8.GetBytes("Hello Holo"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
            Debug.Log("sent");
        }
    }


    // Update is called once per frame
    void Update()
    {



    }

    [Serializable]
    public class testJSON
    {
        public string testVal;
    }
}