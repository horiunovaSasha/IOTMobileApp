using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOTMobileApp.Models;

namespace IOTMobileApp.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Годинник", Description="Відображпти поточний час" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Анімація", Description="Ввімкнути світлову анімацію" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Секундомір", Description="Почати відлік секундоміра." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Термометр", Description="Показати температуру" },
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.FirstOrDefault((Item arg) => arg.Id == item.Id);
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.FirstOrDefault((Item arg) => arg.Id == id);
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

    }
}