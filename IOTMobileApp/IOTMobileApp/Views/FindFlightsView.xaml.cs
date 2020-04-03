using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IOTMobileApp.Services;
using IOTMobileApp.ViewModels;
using MQTTnet.Client;
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
            Task.Run(() => MqttService.SendMessage(Topics.RAINBOW_CLOCK_TOPIC, ""));
            SelectedColor.BackgroundColor = Color.Maroon;
        }

        void BrightnessSwitch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            if (BrightnessSwitch.IsToggled)
            {
                BrightnessSlider.IsEnabled = true;
                MqttService.SendMessage(Topics.SET_AUTO_BRIGHTNESS_TOPIC, "0");
            }
            else
            {
                MqttService.SendMessage(Topics.SET_AUTO_BRIGHTNESS_TOPIC, "1");
            }
        }

        void BrightnessSlider_PropertyChanging(System.Object sender, Xamarin.Forms.PropertyChangingEventArgs e)
        {
            var brightnessValue = BrightnessSlider.Value.ToString();
            MqttService.SendMessage(Topics.COLOR_CLOCK_TOPIC, brightnessValue);

        }

        void RainbowSwitch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            if (RainbowSwitch.IsToggled)
            {
                MqttService.SendMessage(Topics.RAINBOW_CLOCK_TOPIC, "");
            }
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
                var item = (Frame)sender;

                var gesture = (TapGestureRecognizer)item.GestureRecognizers[0];
                var color = gesture.CommandParameter.ToString();
                var rgbColor = viewModel.Colors.Find(x => x.Hex == color);

                MqttService.SendMessage(Topics.COLOR_CLOCK_TOPIC, string.Format("{0},{1},{2}", rgbColor.R, rgbColor.G, rgbColor.B));
            }
        }

        void TapGestureRecognizer_Text_Tapped(System.Object sender, System.EventArgs e)
        {
            var item = (Frame)sender;
            

            var gesture = (TapGestureRecognizer)item.GestureRecognizers[0];
            var color = gesture.CommandParameter.ToString();
            var rgbColor = viewModel.Colors.Find(x => x.Hex == color);

            MqttService.SendMessage(Topics.TEXT_COLOR_TOPIC, string.Format("{0},{1},{2}", rgbColor.R, rgbColor.G, rgbColor.B));
            SelectedColor.BackgroundColor = Color.FromHex(color);
        }
    }
}
    