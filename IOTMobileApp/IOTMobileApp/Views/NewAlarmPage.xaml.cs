using System;
using System.ComponentModel;
using Xamarin.Forms;

using IOTMobileApp.Models;
using System.Collections.Generic;

namespace IOTMobileApp.Views
{
    [DesignTimeVisible(false)]
    public partial class NewAlarmPage : ContentPage
    {
        public Alarm alarm { get; set; }

        public NewAlarmPage()
        {
            InitializeComponent();

            alarm = new Alarm
            {
                Time = new TimeSpan(12, 05, 00),
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            CheckEnabledDays();
            MessagingCenter.Send(this, "AddAlarm", alarm);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void CheckEnabledDays() 
        {
            var daysList = new List<WeekDays>();

            if (MondaynCheckbox.IsChecked)
                daysList.Add(WeekDays.Monday);
            if (TuesdayCheckbox.IsChecked)
                daysList.Add(WeekDays.Tuesday);
            if (WednesdayCheckbox.IsChecked)
                daysList.Add(WeekDays.Wednesday);
            if (ThursdayCheckbox.IsChecked)
                daysList.Add(WeekDays.Thursday);
            if (FridayCheckbox.IsChecked)
                daysList.Add(WeekDays.Friday);
            if (SaturdayCheckbox.IsChecked)
                daysList.Add(WeekDays.Saturday);
            if (SundayCheckbox.IsChecked)
                daysList.Add(WeekDays.Sunday);
            alarm.DaysOfWeek = daysList;
        }
    }
}