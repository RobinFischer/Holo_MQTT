# Holo_MQTT

Unity application is based on: https://github.com/vovacooper/Unity3d_MQTT

## Testing MQTT Communication between am Mosquitto broker and a HoloLens.

Install Mosquitto: https://www.eclipse.org/mosquitto/download/
When testing the service locally on a Windows device it's advised to use a Virtual Machine for the Mosquitto broker. The setup is explained here: http://www.abrandao.com/2018/03/running-mosquitto-mqtt-on-windows-10-super-easy/

Before uploading app to the HoloLens change the IP address in the mqttTest.cs script to the IP address to device where the MQTT broker is running.
In case of a successful connection a "Hello Holo" echo-response should be displayed on the HoloLens.
