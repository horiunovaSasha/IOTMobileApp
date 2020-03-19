using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using IOTMobileApp.Models;
using IOTMobileApp.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace IOTMobileApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AlarmDetailsPage : ContentPage
    {
        AlarmDetailViewModel viewModel;
        public Alarm Alarm { get; set; }

        public AlarmDetailsPage(AlarmDetailViewModel viewModel)
        {
            InitializeComponent();
            Alarm = viewModel.Alarm;
            BindingContext = this.viewModel = viewModel;
            //BindingContext = this;
        }

        public AlarmDetailsPage()
        {
            InitializeComponent();

            var item = viewModel.Alarm;

            viewModel = new AlarmDetailViewModel(item);
            BindingContext = viewModel;
        }
        async void Save_Clicked(object sender, EventArgs e)
        {
            CheckEnabledDays();
            MessagingCenter.Send(this, "UpdateAlarm", this.viewModel.Alarm);
            await Navigation.PopToRootAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
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
            this.viewModel.Alarm.DaysOfWeek = daysList;
        }
    }
}