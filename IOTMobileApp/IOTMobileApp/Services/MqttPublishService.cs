using System;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Formatter;
using MQTTnet.Protocol;

namespace IOTMobileApp.Services
{
    public class MqttPublishService
    {
        public static void SendMessage(string topic, string payload)
        {
            var message = new MqttApplicationMessageBuilder()
                    .WithTopic(topic)
                    .WithPayload(payload)
                    .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce)
                    .WithRetainFlag()
                    .Build();

            _ = GetPublisher().PublishAsync(message).Result;
        }

        private static IMqttClient GetPublisher()
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
                    Server = "5.196.95.208",
                    Port = 1883,
                    TlsOptions = tlsOptions
                }
            };

            if (options.ChannelOptions == null)
            {
                throw new InvalidOperationException();
            }

            options.CleanSession = true;
            options.KeepAlivePeriod = TimeSpan.FromSeconds(15);


            var mqttFactory = new MqttFactory();


            var factory = new MqttFactory();

            var client = factory.CreateMqttClient();

            try
            {
                client.ConnectAsync(options).Wait();
                
            }
            catch (Exception ex)
            {

            }

            return client;
        }
    }
}
