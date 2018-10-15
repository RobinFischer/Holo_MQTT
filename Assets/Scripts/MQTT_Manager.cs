using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Manager : MonoBehaviour {

    public mqttTest MQTT_in;
    public TextMesh Mqtt_out;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Mqtt_out.text = "Received MQTT Value:" + MQTT_in.MQTT_val;
	}
}
