using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace IOTMobileApp.Models
{
    public class Alarm
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public TimeSpan Time { get; set; }
        
        [Ignore]
        public string DisplaDaysSting { get; set; }

        public string SerializedDays { get; set; }

        [TextBlob(nameof(DaysOfWeek))]
        public List<WeekDays> DaysOfWeek
        {
            get
            {
                return JsonConvert.DeserializeObject<List<WeekDays>>(SerializedDays);
            }
            set
            {
                SerializedDays = JsonConvert.SerializeObject(value);
            }
        }
    }
}
