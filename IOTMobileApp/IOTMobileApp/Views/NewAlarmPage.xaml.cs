using System;
using System.ComponentModel;
using Xamarin.Forms;

using IOTMobileApp.Models;
using System.Collections.Generic;
using System.Globalization;

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
               Time = new TimeSpan(12, 05, 00),
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            CheckEnabledDays();
            Alarm.Time = TimeSpan.ParseExact(Alarm.Time.ToString(), @"hh\:mm\:ss", CultureInfo.InvariantCulture);

            //alarm.Time = new TimeSpan();
            
            MessagingCenter.Send(this, "AddAlarm", Alarm);
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
            Alarm.DaysOfWeek = daysList;
        }
    }
}