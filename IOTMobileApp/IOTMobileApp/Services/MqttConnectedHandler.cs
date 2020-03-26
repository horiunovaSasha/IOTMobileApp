using System.Collections.Generic;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;

namespace IOTMobileApp.Services
{
    internal class MqttConnectedHandler 
    {
        private Dictionary<string, TopicFilter> _topicFilter;
        private IMqttClient client;

        public MqttConnectedHandler(Dictionary<string, TopicFilter> topicFilter, IMqttClient client)
        {
            _topicFilter = topicFilter;
            this.client = client;
        }
    }
}