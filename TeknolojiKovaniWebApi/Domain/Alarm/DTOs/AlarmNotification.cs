using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi.Domain.Alarm.DTOs
{
    public class AlarmNotification
    {
        public string DeviceName { get; set; }
        public string Property { get; set; }
        public decimal Value { get; set; }
        public string NotificationParameter { get; set; }
        public decimal Min { get; set; }
        public decimal Max { get; set; }
    }
}