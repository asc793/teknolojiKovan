﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi.Models.EntityClass
{
    public class Alarm
    {
        public int Id { get; set; }
        public Guid DeviceId { get; set; }
        public Device Device { get; set; }
        public int PropertyId { get; set; }
        public AlarmType AlarmType { get; set; }
        
    }
}