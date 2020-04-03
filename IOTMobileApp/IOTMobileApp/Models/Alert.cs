using System;
namespace IOTMobileApp.Models
{
    public class Alert
    {
       public int Id { get; set; } 
       public string Message { get; set; }
       public DateTime RecievedTime { get; set; }
    }
}
