#! /usr/bin/env python
#####################################
# https://github.com/pradeesi/MQTT_Broker_On_Raspberry_Pi/blob/master/publisher.py
#####################################
from gesture_pred import read_IMU
# Import package
import IMU
import paho.mqtt.client as mqtt
import paho.mqtt.publish as publish
# Define Variables
MQTT_BROKER = "131.179.8.132"
MQTT_PORT = 1883
MQTT_KEEPALIVE_INTERVAL = 60
MQTT_TOPIC = "topic/gesture"

# Define on_connect event Handler
def on_connect(mosq, obj, rc):
    print "Connected to MQTT Broker"

# Define on_publish event Handler
def on_publish(client, userdata, mid):
    print "Message Published..."

# initialize IMU
IMU.detectIMU()     #Detect if BerryIMUv1 or BerryIMUv2 is connected.
IMU.initIMU()       #Initialise the accelerometer, gyroscope and compass

# Initiate MQTT Client
mqttc = mqtt.Client()

# Register Event Handlers
mqttc.on_publish = on_publish
mqttc.on_connect = on_connect

# Connect with MQTT Broker
mqttc.connect(MQTT_BROKER, MQTT_PORT, MQTT_KEEPALIVE_INTERVAL)
while True:
    # Publish message to MQTT Topic 
    #mqttc.publish(MQTT_TOPIC,MQTT_MSG)
    pred = read_IMU()
    print pred
    publish.single(MQTT_TOPIC, pred, hostname=MQTT_BROKER)

# Disconnect from MQTT_Broker
mqttc.disconnect()



