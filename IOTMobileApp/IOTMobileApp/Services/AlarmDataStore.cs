using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOTMobileApp.Models;
using SQLite;

namespace IOTMobileApp.Services
{
    public class AlarmDataStore : IAlarmDataStore<Alarm>
    {
        private List<Alarm> alarms;

        public AlarmDataStore()
        {
            //var connection = new SQLiteConnection(App.DatabaseLocalion);
            //connection.DeleteAll<Alarm>();
             alarms = GetAlarmsAsync(false).Result.ToList();
        }

        public async Task<bool> AddAlarmAsync(Alarm alarm)
        {
           // alarms.Add(alarm);
            var connection = new SQLiteConnection(App.DatabaseLocalion);
            connection.CreateTable<Alarm>();
            var rows = connection.Insert(alarm);
            connection.Close();
            if (rows > 0) 
            {
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> UpdateAlarmAsync(Alarm alarm)
        {
            var connection = new SQLiteConnection(App.DatabaseLocalion);
            connection.CreateTable<Alarm>();
            var rows = connection.Update(alarm);

            if (rows > 0)
            {
                return await Task.FromResult(true);
            }
            alarms = GetAlarmsAsync(false).Result.ToList();
            //var oldItem = alarms.FirstOrDefault((arg) => arg.Id == alarm.Id);
            //alarms.Remove(oldItem);
            //alarms.Add(alarm);

            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAlarmAsync(int id)
        {
            var oldItem = alarms.FirstOrDefault(arg => arg.Id == id);
            alarms.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Alarm> GetAlarmAsync(int id)
        {
            return await Task.FromResult(alarms.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Alarm>> GetAlarmsAsync(bool forceRefresh = false)
        {
            var connection = new SQLiteConnection(App.DatabaseLocalion);
            connection.CreateTable<Alarm>();
            var alarms = (from x in connection.Table<Alarm>() select x).ToList();
            connection.Close();

            GetStringOfDays(alarms);

            return await Task.FromResult(alarms);
        }

        private void GetStringOfDays(List<Alarm> alarms)
        {
            foreach (var alarm in alarms)
            {
                alarm.DisplaDaysSting += "Повтор: ";
                if (!string.IsNullOrEmpty(alarm.SerializedDays))
                {
                    var days = alarm.SerializedDays.Replace('[', ' ').Replace(']', ' ').Trim().Split(',').ToList();
                    foreach (var day in days)
                    {
                        alarm.DisplaDaysSting += $"{GetShortDay(day)} ";
                    }

                }
                else
                {
                    alarm.DisplaDaysSting += "не встановлено";
                }
            }
        }
        private string GetShortDay(string day)
        {
            int parsedDay = int.Parse(day);
            switch (parsedDay)
            {
                case 1: return "ПН";
                case 2: return "ВТ";
                case 3: return "СР";
                case 4: return "ЧТ";
                case 5: return "ПТ";
                case 6: return "СБ";
                case 7: return "НД";
                default: return string.Empty;
            }
        }
    }
}