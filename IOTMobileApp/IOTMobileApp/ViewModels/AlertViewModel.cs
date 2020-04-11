using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using IOTMobileApp.Models;
using IOTMobileApp.Services;
using IOTMobileApp.Views;
using Xamarin.Forms;

namespace IOTMobileApp.ViewModels
{
    public class AlertViewModel : BaseViewModel
    {
        public List<Alert> Alerts { get; set; }
        public Command LoadItemsCommand { get; set; }


        public AlertViewModel()
        {
            var dataSore = new AlertDataStore();
            Alerts = dataSore.GetAlarmsAsync().Result;
           // LoadItemsCommand = new Command( () =>  ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<BrightPage, Alert>(this, "AddAlert", async (obj, item) =>
            {
                var newItem = new Alert() { Message = "Спрацювання сигналізації", RecievedTime = DateTime.Now };
                Alerts.Add(newItem);
                try
                {
                    var dataStore = new AlertDataStore();
                    await dataStore.AddAlarmAsync(newItem);
                }
                catch (Exception ex) { }
            });
        }

        List<Alert> ExecuteLoadItemsCommand()
        {
            var dataStore = new AlertDataStore();
            var items = dataStore.GetAlarmsAsync();
            return items.Result;
        }

       
    }
}

