using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOTMobileApp.Models;
using SQLite;

namespace IOTMobileApp.Services
{
    public class AlertDataStore 
    {
        private List<Alert> alerts;

        public AlertDataStore()
        {
            alerts = GetAlarmsAsync(false).Result.ToList();
        }

        public async Task<bool> AddAlarmAsync(Alert alarm)
        {
            var connection = new SQLiteConnection(App.DatabaseLocalion);
            connection.CreateTable<Alert>();
            var rows = connection.Insert(alarm);
            connection.Close();
            if (rows > 0) 
            {
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
       
        public async Task<Alert> GetAlarmAsync(int id)
        {
            return await Task.FromResult(alerts.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Alert>> GetAlarmsAsync(bool forceRefresh = false)
        {
            var connection = new SQLiteConnection(App.DatabaseLocalion);
            connection.CreateTable<Alarm>();
            var alarms = (from x in connection.Table<Alert>() select x).ToList();
            connection.Close();
            return await Task.FromResult(alarms);
        }
    }
}