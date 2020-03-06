using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using IOTMobileApp.Models;
using IOTMobileApp.ViewModels;

namespace IOTMobileApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AlarmDetailsPage : ContentPage
    {
        AlarmDetailViewModel viewModel;

        public AlarmDetailsPage(AlarmDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public AlarmDetailsPage()
        {
            InitializeComponent();

            var item = new Alarm()
            {
                Time = DateTime.Now
            };

            viewModel = new AlarmDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}