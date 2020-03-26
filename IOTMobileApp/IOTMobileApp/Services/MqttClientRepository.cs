using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Formatter;

namespace IOTMobileApp.Services
{
    public class MqttClientRepository
    {
        Dictionary<string, TopicFilter> _topicFilter;

        private static IMqttClient client;

        public IMqttClient Create(string server, int port, string userName, string password, List<string> topics)
        {
            _topicFilter = new Dictionary<string, TopicFilter>();

            foreach (var topic in topics)
            {
                TopicFilter topicFilter = new TopicFilter
                {
                    Topic = topic,
                    QualityOfServiceLevel = MQTTnet.Protocol.MqttQualityOfServiceLevel.AtMostOnce
                };

                _topicFilter.Add(topic, topicFilter);
            }

            Task.Run(() => MqttClientRunAsync(server, port, userName, password)).Wait();

            return client;
        }

        private async Task MqttClientRunAsync(string server, int port, string userName, string password)
        {
            try
            {
                var tlsOptions = new MqttClientTlsOptions
                {
                    UseTls = false,
                    IgnoreCertificateChainErrors = true,
                    IgnoreCertificateRevocationErrors = true,
                    AllowUntrustedCertificates = true
                };

                var options = new MqttClientOptions
                {
                    ClientId = "ClientPublisher",
                    ProtocolVersion = MqttProtocolVersion.V311,
                    ChannelOptions = new MqttClientTcpOptions
                    {
                        Server = server,
                        Port = port,
                        TlsOptions = tlsOptions
                    }
                };

                if (options.ChannelOptions == null)
                {
                    throw new InvalidOperationException();
                }

                options.CleanSession = true;
                options.KeepAlivePeriod = TimeSpan.FromSeconds(5);


                var mqttFactory = new MqttFactory();


                var factory = new MqttFactory();

                client = factory.CreateMqttClient();

                try
                {
                    await client.ConnectAsync(options);
                }
                catch (Exception ex)
                {

                }
            }
            catch (Exception ex)
            {

            }
        }
    }

}
