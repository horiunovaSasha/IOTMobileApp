using System;

using IOTMobileApp.Models;

namespace IOTMobileApp.ViewModels
{
    public class AlarmDetailViewModel : BaseViewModel
    {
        public Alarm Item { get; set; }
        public AlarmDetailViewModel(Alarm item = null)
        {
            Item = item;
        }
    }
}
