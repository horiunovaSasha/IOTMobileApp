using System;
using System.ComponentModel;
using Xamarin.Forms;

using IOTMobileApp.Models;

namespace IOTMobileApp.Views
{
    [DesignTimeVisible(false)]
    public partial class NewAlarmPage : ContentPage
    {
        public Alarm Alarm { get; set; }

        public NewAlarmPage()
        {
            InitializeComponent();

            Alarm = new Alarm
            {
                Time = new TimeSpan(12, 05, 00)
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddAlarm", Alarm);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}