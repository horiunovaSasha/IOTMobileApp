using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IOTMobileApp.Services
{
    public interface IAlertDataStore<T>
    {
        Task<bool> AddAlarmAsync(T item);
        Task<T> GetAlarmAsync(int id);
        Task<IEnumerable<T>> GetAlarmsAsync(bool forceRefresh = false);
    }
}
