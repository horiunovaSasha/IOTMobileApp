﻿using System;
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

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            //var item = args.SelectedItem as Item;
            //if (item == null)
            //    return;

            //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            //// Manually deselect item.
            //ItemsListView.SelectedItem = null;
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
             DisplayAlert("Clock","Clock switched", "Cancel" );
        }

        void AnimationSwitch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            DisplayAlert("Animation", "Animation switched", "Cancel");
        }

        void TempSwitch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            DisplayAlert("Temp", "Temp switched", "Cancel");
        }
    }
}