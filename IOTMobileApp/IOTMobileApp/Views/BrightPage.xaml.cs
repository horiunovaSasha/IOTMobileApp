using System;
using System.ComponentModel;
using IOTMobileApp.Models;
using IOTMobileApp.ViewModels;
using MQTTnet.Client;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IOTMobileApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class BrightPage : ContentPage
    {
        AlertViewModel viewModel;
        public BrightPage()
        {
            InitializeComponent();
            viewModel = new AlertViewModel();
            BindingContext = this;
            MessagingCenter.Subscribe<IMqttClient>(this, "Alarm", (sender) =>
            {
                try
                {
                    MessagingCenter.Send(this, "AddAlert", new Alert() { Message = "Спрацювання датчику руху, зафіксовано рух в преміщені", RecievedTime = DateTime.Now});
                }
                catch (Exception ex) { }
                
            });
        }
    }
}