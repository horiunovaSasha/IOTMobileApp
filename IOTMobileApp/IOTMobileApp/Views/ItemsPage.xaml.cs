using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using IOTMobileApp.Models;
using IOTMobileApp.Views;
using IOTMobileApp.ViewModels;

namespace IOTMobileApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        void ClokSwitch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            if (ClokSwitch.IsToggled)
            {
                TempSwitch.IsToggled = false;
                AnimationSwitch.IsToggled = false;
            }
        }

        void AnimationSwitch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            if (AnimationSwitch.IsToggled)
            {
                TempSwitch.IsToggled = false;
                ClokSwitch.IsToggled = false;
            }
        }

        void TempSwitch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            if (TempSwitch.IsToggled)
            {
                ClokSwitch.IsToggled = false;
                AnimationSwitch.IsToggled = false;
            }
        }
    }
}