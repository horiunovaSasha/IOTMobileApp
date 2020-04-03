using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using IOTMobileApp.Models;
using IOTMobileApp.Services;
using IOTMobileApp.Views;
using Xamarin.Forms;

namespace IOTMobileApp.ViewModels
{
    public class AlertViewModel : BaseViewModel
    {
        public ObservableCollection<Alert> Alerts { get; set; }
        public Command LoadItemsCommand { get; set; }


        public AlertViewModel()
        {
            Alerts = new ObservableCollection<Alert>();
            LoadItemsCommand = new Command( () =>  ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<BrightPage, Alert>(this, "AddAlert", async (obj, item) =>
            {
                var newItem = new Alert() { Message = "Test", RecievedTime = DateTime.Now };
                Alerts.Add(newItem);
                try
                {
                    var dataStore = new AlertDataStore();
                    await dataStore.AddAlarmAsync(newItem);
                }
                catch (Exception ex) { }
            });
        }

        ObservableCollection<Alert> ExecuteLoadItemsCommand()
        {
            if (Alerts.Any())
            {
                return Alerts;
            }
            //Alerts.Clear();
            return new ObservableCollection<Alert>() { new Alert() { Message = "Test", RecievedTime = DateTime.Now} };
            //var items = await Alerts.GetAlarmsAsync(true);
            //foreach (var item in items)
            //{
            //    Alarms.Add(item);
            //}
        }

       
    }
}

