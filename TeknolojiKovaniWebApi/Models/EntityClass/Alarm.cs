using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi.Models.EntityClass
{
    public class Alarm
    {
        public int AlarmID { get; set; }
        public int DeviceID { get; set; }
        public int PropertyID { get; set; }
        public AlarmType AlarmType { get; set; }
        
    }
}