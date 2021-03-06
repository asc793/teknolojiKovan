﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi.Domain.Alarm.DTOs
{
    public class AlarmFireDto
    {
        public int AlarmId { get; set; }
        public string Side { get; set; }
        public string PropertyName { get; set; }
        public decimal Value { get; set; }
        public Guid DeviceId { get; set; }
    }
}