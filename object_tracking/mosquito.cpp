//  mosquito.cpp
//  mosquito_trial

#include "mosquito.h"
#include <sstream>
#include <string>
#include <iostream>

myMosq::myMosq(const char * _id,const char * _topic, const char * _host, int _port) : mosquittopp(_id)
{
    mosqpp::lib_init();      // Mandatory initialization for mosquitto library
    this->keepalive = 60;    // Basic configuration setup for myMosq class
    this->id = _id;
    this->port = _port;
    this->host = _host;
    this->topic = _topic;
    int ret;
    ret = connect(host,port,keepalive);
    while(ret != MOSQ_ERR_SUCCESS)
        ret = connect(host, port, keepalive);
    if (ret == MOSQ_ERR_SUCCESS)
        std::cout << "sccessfully connected to a broker" << std::endl;
};

void myMosq::on_disconnect(int rc) {
    std::cout << ">> myMosq - disconnection(" << rc << ")" << std::endl;
}

void myMosq::on_connect(int rc)
{
    if ( rc == 0 ) {
        std::cout << ">> myMosq - connected with server" << std::endl;
        int ret = subscribe(NULL, "topic/state");
        if (ret == MOSQ_ERR_SUCCESS)
            std::cout << ">> rc is " << rc << ". Subscribed to a topic " << "topic/state" << std::endl;
    } else {
        std::cout << ">> myMosq - Impossible to connect with server(" << rc << ")" << std::endl;
    }
}

void myMosq::on_publish(int mid)
{
    std::cout << ">> myMosq - Message (" << mid << ") succeed to be published " << std::endl;
}

bool myMosq::send_message(const  char * _message)
{
    int ret = publish(NULL,this->topic,(int)strlen(_message),_message,1,false);
    return ( ret == MOSQ_ERR_SUCCESS );
}

myMosq::~myMosq() {
    loop_stop();              // Kill the thread
    mosqpp::lib_cleanup();    // Mosquitto library cleanup
}
