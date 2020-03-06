using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOTMobileApp.Models;

namespace IOTMobileApp.Services
{
    public class AlarmDataStore : IAlarmDataStore<Alarm>
    {
        private List<Alarm> alarms;

        public AlarmDataStore()
        {
            alarms = new List<Alarm>()
            {
                new Alarm {Id = 0, Time = new DateTime(2020, 03, 06, 12, 0, 0)},
                new Alarm {Id = 1, Time = new DateTime(2020, 03, 06, 13, 10, 0)},
                new Alarm {Id = 2, Time = new DateTime(2020, 03, 06, 14, 15, 0)},
                new Alarm {Id = 3, Time = new DateTime(2020, 03, 06, 15, 30, 0)},
            };
        }

        public async Task<bool> AddAlarmAsync(Alarm item)
        {
            alarms.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAlarmAsync(Alarm alarm)
        {
            var oldItem = alarms.FirstOrDefault((arg) => arg.Id == alarm.Id);
            alarms.Remove(oldItem);
            alarms.Add(alarm);

            return await Task.FromResult(true);
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
            return await Task.FromResult(alarms);
        }
    }
}