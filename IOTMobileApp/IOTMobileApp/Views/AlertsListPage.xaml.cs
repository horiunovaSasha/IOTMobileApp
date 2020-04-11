using System;
using System.Collections.Generic;
using IOTMobileApp.ViewModels;
using Xamarin.Forms;

namespace IOTMobileApp.Views
{
    public partial class AlertsListPage : ContentPage
    {
        AlertViewModel viewModel;
        public AlertsListPage()
        {
            InitializeComponent();
            viewModel = new AlertViewModel();
            BindingContext = viewModel;
        }
    }
}
