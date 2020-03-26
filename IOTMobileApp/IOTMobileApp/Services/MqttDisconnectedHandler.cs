using System;
using System.Threading.Tasks;
using MQTTnet.Client;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;

namespace IOTMobileApp.Services
{
    public class MqttDisconnectedHandler 
    {
        private IMqttClient _client;
        private MqttClientOptions _options;

        public MqttDisconnectedHandler(MqttClientOptions options, IMqttClient client)
        {
            _options = options;
            _client = client;
        }

        public async Task HandleDisconnectedAsync(MqttClientDisconnectedEventArgs eventArgs)
        {
            await Task.Delay(TimeSpan.FromSeconds(5));

            try
            {

            }
            catch
            {

            }
        }
    }

}
