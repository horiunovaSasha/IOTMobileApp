using System;
using System.Collections.Generic;
using IOTMobileApp.ViewModels;
using Xamarin.Forms;

namespace IOTMobileApp.Views
{
    public partial class FindFlightsView : ContentPage
    {
        public List<string> Colours { get; set; }       

        ItemsViewModel viewModel;
        public FindFlightsView()
        {
            InitializeComponent();
            Colours = new List<string>() { "Red", "Blue" }; 
        }
    }
}
