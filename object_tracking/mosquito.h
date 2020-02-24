//  mosquito.h
//  mosquito_trial

#ifndef mosquito_h
#define mosquito_h

#include <mosquittopp.h>
#include <mosquitto.h>
#include <mosquitto_broker.h>
#include <mosquitto_plugin.h>

class myMosq : public mosqpp::mosquittopp
{
private:
    const char* host;
    const char* id;
    const char* topic;
    int port;
    int keepalive;
    
    void on_connect(int rc);
    void on_disconnect(int rc);
    void on_publish(int mid);
public:
    myMosq(const char *id, const char * _topic, const char *host, int port);
    ~myMosq();
    bool send_message(const char * _message);
};
#endif /* mosquito_h */
