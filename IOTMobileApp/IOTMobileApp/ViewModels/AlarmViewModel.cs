using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using IOTMobileApp.Models;
using IOTMobileApp.Views;

namespace IOTMobileApp.ViewModels
{
    public class AlarmViewModel : BaseViewModel
    {
        public ObservableCollection<Alarm> Alarms { get; set; }
        public Command LoadItemsCommand { get; set; }

        public AlarmViewModel()
        {
            Title = "Будильники";
            Alarms = new ObservableCollection<Alarm>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewAlarmPage, Alarm>(this, "AddAlarm", async (obj, item) =>
            {
                var newItem = item as Alarm;
                Alarms.Add(newItem);
                await AlarmDataStore.AddAlarmAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Alarms.Clear();
                var items = await AlarmDataStore.GetAlarmsAsync(true);
                foreach (var item in items)
                {
                    Alarms.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}