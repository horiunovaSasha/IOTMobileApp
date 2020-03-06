using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IOTMobileApp.Services
{
    public interface IAlarmDataStore<T>
    {
        Task<bool> AddAlarmAsync(T item);
        Task<bool> UpdateAlarmAsync(T item);
        Task<bool> DeleteAlarmAsync(int id);
        Task<T> GetAlarmAsync(int id);
        Task<IEnumerable<T>> GetAlarmsAsync(bool forceRefresh = false);
    }
}
