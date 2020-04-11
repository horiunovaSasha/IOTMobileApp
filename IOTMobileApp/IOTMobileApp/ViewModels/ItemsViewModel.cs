using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using IOTMobileApp.Models;
using IOTMobileApp.Views;
using System.Collections.Generic;
using IOTMobileApp.Services;

namespace IOTMobileApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public List<Colour> Colors { get; set; }
        public Command LoadItemsCommand { get; set; }

        public string SelectedColor = "Red";

        public ItemsViewModel()
        {
            var datastore = new DataStore();

            Title = "Ефекти";
            Items = datastore.GetItems();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            Colors = datastore.GetColours();
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
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