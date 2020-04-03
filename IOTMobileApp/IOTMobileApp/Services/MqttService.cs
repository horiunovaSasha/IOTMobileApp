using System;
using System.Threading;
using System.Threading.Tasks;
using IOTMobileApp.Views;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Protocol;
using Xamarin.Forms;

namespace IOTMobileApp.Services
{
    public class MqttService
    {
        public static async Task SendMessage(string topic, string payload)
        {
            var message = new MqttApplicationMessageBuilder()
                    .WithTopic(topic)
                    .WithPayload(payload)
                    .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce)
                    .WithRetainFlag()
                    .Build();

            var factory = new MqttFactory();
            var client = factory.CreateMqttClient();

            try
            {
                await client.ConnectAsync(GetOptions("publish-client-id"), CancellationToken.None);
                await client.PublishAsync(message);
            }
            catch
            {
            }
        }

        public static async Task Init()
        {
            bool isInit = true;
            var options = GetOptions("main-client-id");

            var factory = new MqttFactory();
            var client = factory.CreateMqttClient();

            client.UseConnectedHandler(async e =>
            {
                await client.SubscribeAsync(new TopicFilterBuilder().WithTopic(Topics.RAISE_ALARM_TOPIC).Build());
            });

            client.UseDisconnectedHandler(async e =>
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                try
                {
                    await client.ConnectAsync(options, CancellationToken.None);
                }
                catch
                {
                }
            });

            client.UseApplicationMessageReceivedHandler(e =>
            {
                if (!isInit && e.ApplicationMessage.Topic == Topics.RAISE_ALARM_TOPIC)
                {
                    
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        MessagingCenter.Send(client, "Alarm");
                        await Application.Current.MainPage.DisplayAlert("Спрацювання сигналізації", "Спрацювання датчику руху, зафіксовано рух в преміщені", "OK");
                        
                    });
                }

                isInit = false;
            });

            try
            {
                await client.ConnectAsync(options, CancellationToken.None);
            }
            catch
            {
            }
        }

        private static MqttClientOptions GetOptions(string clientId)
        {
            return new MqttClientOptions
            {
                CleanSession = false,
                ClientId = clientId,
                ChannelOptions = new MqttClientTcpOptions
                {
                    Server = "broker.mqttdashboard.com",
                    Port = 1883,
                    TlsOptions = new MqttClientTlsOptions
                    {
                        UseTls = false,
                        IgnoreCertificateChainErrors = true,
                        IgnoreCertificateRevocationErrors = true,
                        AllowUntrustedCertificates = true
                    }
                }
            };
        }
    }
}
