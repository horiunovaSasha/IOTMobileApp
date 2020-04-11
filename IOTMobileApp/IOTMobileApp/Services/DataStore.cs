using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using IOTMobileApp.Models;

namespace IOTMobileApp.Services
{
    public class DataStore 
    {
        public ObservableCollection<Item> items;
        public List<Colour> colours;

        public DataStore()
        {
            GetItems();
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
        public List<Colour> GetColours()
        {
            return colours;
        }

        public ObservableCollection<Item> GetItems()
        {
            InitColors();
            items = new ObservableCollection<Item>();
            for (var i = 0; i < colours.Count(); i = i + 6)
            {
                items.Add(new Item()
                {
                    FirtstColor = colours[i].Hex,
                    SecondColor = colours[i+1].Hex,
                    ThirdColor = colours[i+2].Hex,
                    FourthColor = colours[i +3].Hex,
                    FifthColor = colours[i + 4].Hex,
                    SixthColor = colours[i + 5].Hex
                }) ;
            }
            return items;
        }

        public void InitColors()
        {
            colours = new List<Colour>();

            colours.Add(new Colour(128, 0, 0, "#800000"));
            colours.Add(new Colour(178, 34, 34, "#B22222"));
            colours.Add(new Colour(255, 0, 0, "#FF0000"));
            colours.Add(new Colour(250, 128, 114, "#FA8072"));
            colours.Add(new Colour(255, 99, 71, "#FF6347"));
            colours.Add(new Colour(255, 127, 80, "#FF7F50"));
            colours.Add(new Colour(255, 255, 0, "#FFFF00"));
            colours.Add(new Colour(154, 205, 50, "#9ACD32"));
            colours.Add(new Colour(124, 252, 0, "#7CFC00"));
            colours.Add(new Colour(0, 128, 0, "#008000"));
            colours.Add(new Colour(50, 205, 50, "#32CD32"));
            colours.Add(new Colour(0, 250, 154, "#00FA9A"));
            colours.Add(new Colour(64, 224, 208, "#40E0D0"));
            colours.Add(new Colour(32, 178, 70, "#20B2AA"));
            colours.Add(new Colour(0, 206, 209, "#00CED1"));
            colours.Add(new Colour(0, 191, 255, "#00BFFF"));
            colours.Add(new Colour(65, 105, 225, "#4169E1"));
            colours.Add(new Colour(0, 0, 128, "#000080"));
            colours.Add(new Colour(0, 0, 205, "#0000CD"));
            colours.Add(new Colour(138, 43, 226, "#8A2BE2"));
            colours.Add(new Colour(128, 0, 128, "#800080"));
            colours.Add(new Colour(139, 0, 139, "#8B008B"));
            colours.Add(new Colour(255, 0, 255, "#FF00FF"));
            colours.Add(new Colour(199, 21, 133, "#C71585"));
            colours.Add(new Colour(255, 20, 147, "#FF1493"));
            colours.Add(new Colour(255, 105, 80, "#FF69B4"));
            colours.Add(new Colour(205, 92, 92, "#CD5C5C"));
            colours.Add(new Colour(188, 143, 143, "#BC8F8F"));
            colours.Add(new Colour(240, 128, 128, "#F08080"));
            colours.Add(new Colour(233, 150, 122, "#E9967A"));
            colours.Add(new Colour(255, 160, 122, "#FFA07A"));
            colours.Add(new Colour(107, 142, 35, "#6B8E23"));
            colours.Add(new Colour(85, 107, 47, "#556B2F"));
            colours.Add(new Colour(143, 188, 143, "#8FBC8F"));
            colours.Add(new Colour(0, 100, 0, "#006400"));
            colours.Add(new Colour(34, 139, 34, "#228B22"));
            colours.Add(new Colour(152, 251, 152, "#98FB98"));
            colours.Add(new Colour(46, 139, 87, "#2E8B57"));
            colours.Add(new Colour(60, 179, 113, "#3CB371"));
            colours.Add(new Colour(102, 205, 170, "#66CDAA"));
            colours.Add(new Colour(127, 255, 212, "#7FFFD4"));
            colours.Add(new Colour(95, 158, 160, "#5F9EA0"));
            colours.Add(new Colour(176, 224, 230, "#B0E0E6"));
            colours.Add(new Colour(70, 130, 180, "#4682B4"));
            colours.Add(new Colour(176, 196, 222, "#B0C4DE"));
            colours.Add(new Colour(106, 90, 205, "#6A5ACD"));
            colours.Add(new Colour(72, 61, 139, "#483D8B"));
            colours.Add(new Colour(123, 104, 238, "#7B68EE"));
            colours.Add(new Colour(75, 0, 130, "#4B0082"));
            colours.Add(new Colour(186, 85, 211, "#BA55D3"));
            colours.Add(new Colour(221, 160, 221, "#DDA0DD"));
            colours.Add(new Colour(219, 112, 147, "#DB7093"));
            colours.Add(new Colour(255, 192, 203, "#FFC0CB"));
            colours.Add(new Colour(105, 105, 105, "#696969"));

            for (var i = 0; i < colours.Count(); i++)
            {
                colours[i].id = i;
            }
        }
    }
}