using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FitOutApplication.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(FitOutApplication.Services.MockDataStore))]
namespace FitOutApplication.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        bool isInitialized;
        List<Item> items;

        public async Task<bool> AddItemAsync(Item item)
        {
            await InitializeAsync();

            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            await InitializeAsync();

            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            await InitializeAsync();

            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(items);
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;

            items = new List<Item>();
            var _items = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Bench-press", Description="This is bench-press and how you should do it."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Push-ups", Description="These are push-ups and how you should do them."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Squats", Description="These are squats and how you should do them."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sit-ups", Description="These are sit-ups and how you should do them."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Crunches", Description="These are crunches and how you should do them."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Arm circles", Description="These are arm circles and how you should do them."},
            };

            foreach (Item item in _items)
            {
                items.Add(item);
            }

            isInitialized = true;
        }
    }
}
