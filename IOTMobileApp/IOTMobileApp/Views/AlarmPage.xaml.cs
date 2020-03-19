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
    public partial class AlarmsPage : ContentPage
    {
        AlarmViewModel viewModel;

        public AlarmsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new AlarmViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Alarm;
            if (item == null)
                return;

            await Navigation.PushAsync(new AlarmDetailsPage(new AlarmDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewAlarmPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

           // if (viewModel.Alarms.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
       
    }
}