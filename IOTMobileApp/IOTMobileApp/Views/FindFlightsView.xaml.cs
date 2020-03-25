using System;
using System.Collections.Generic;
using IOTMobileApp.ViewModels;
using Xamarin.Forms;

namespace IOTMobileApp.Views
{
    public partial class FindFlightsView : ContentPage
    {
        public List<string> Monkeys { get; set; }       

        ItemsViewModel viewModel;
        public FindFlightsView()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
            Monkeys = new List<string>() { "Red", "Blue" }; 
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        void BrightnessSwitch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            BrightnessSlider.IsEnabled = BrightnessSwitch.IsToggled;
        }

        void BrightnessSlider_PropertyChanging(System.Object sender, Xamarin.Forms.PropertyChangingEventArgs e)
        {

        }

        void RainbowSwitch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            BackgroundSwitch.IsToggled = !RainbowSwitch.IsToggled;
            SetBackgroundLayoutOpacity();
        }

        void BackgroundSwitch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            RainbowSwitch.IsToggled = !BackgroundSwitch.IsToggled;
            SetBackgroundLayoutOpacity();
        }

        void SetBackgroundLayoutOpacity()
        {
            if (BackgroundSwitch.IsToggled)
            {
                BackgroundLayout.Opacity = 1;   
            } else
            {
                BackgroundLayout.Opacity = 0.3;
            }
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            if (BackgroundLayout.Opacity == 1)
            {
                DisplayAlert("test", "yoo hoo", "see you");
            }
        }
    }
}
    