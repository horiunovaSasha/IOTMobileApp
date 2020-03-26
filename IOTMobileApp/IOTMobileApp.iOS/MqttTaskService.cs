using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IOTMobileApp.Services;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Receiving;

namespace IOTMobileApp.iOS
{
    public class MqttTaskService
    {
        private IMqttClient _mqttClient;
        private readonly string _sessionPayedTopic;

        public MqttTaskService()
        {
            _sessionPayedTopic = "YOUR TOPIC";

            _mqttClient = new MqttClientRepository().Create(
             "MqttServer",
             9,
             "MqttUserName",
             "MqttPassword",
             new List<string> { _sessionPayedTopic });

            _mqttClient.ApplicationMessageReceivedHandler = new SubscribeCallback(_sessionPayedTopic);
        }

        public void UnSubscribe()
        {
            _mqttClient.ApplicationMessageReceivedHandler = null;
        }
    }

    public class SubscribeCallback : IMqttApplicationMessageReceivedHandler
    {
        private readonly string _sessionPayedTopic;

        public SubscribeCallback(string sessionPayedTopic)
        {
            _sessionPayedTopic = sessionPayedTopic;
        }

        public Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs e)
        {
            string message = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);

            if (e.ApplicationMessage.Topic == _sessionPayedTopic)
            {

            }

            return Task.CompletedTask;
        }
    }
}
