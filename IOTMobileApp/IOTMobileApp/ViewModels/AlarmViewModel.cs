﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using IOTMobileApp.Models;
using IOTMobileApp.Views;

//namespace IOTMobileApp.ViewModels
//{
//    public class AlarmViewModel : BaseViewModel
//    {
//        public ObservableCollection<Alarm> Alarms { get; set; }
//        public Command LoadItemsCommand { get; set; }

       

//        public AlarmViewModel()
//        {
//            Title = "Будильники";
//            Alarms = new ObservableCollection<Alarm>();
//            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

          
//        }

//        async Task ExecuteLoadItemsCommand()
//        {
//            if (IsBusy)
//                return;

//            IsBusy = true;

//            try
//            {
//                Alarms.Clear();
//               // var items = await AlarmDataStore.GetAlarmsAsync(true);
//                //foreach (var item in items)
//                //{
//                //    Alarms.Add(item);
//                //}
//            }
//            catch (Exception ex)
//            {
//                Debug.WriteLine(ex);
//            }
//            finally
//            {
//                IsBusy = false;
//            }
//        }

//        public async Task Delete(int id)
//        {
//            if (IsBusy)
//                return;

//            IsBusy = true;

//            //try
//            //{
//            //    await AlarmDataStore.DeleteAlarmAsync(id);
               
//            //}
//            //catch (Exception ex)
//            //{
//            //    Debug.WriteLine(ex);
//            //}
//            //finally
//            //{
//            //    IsBusy = false;
//            //}
//        }
//    }
//}