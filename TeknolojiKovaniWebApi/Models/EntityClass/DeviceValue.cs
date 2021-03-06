﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi.Models.EntityClass
{
    public class DeviceValue
    {
        public int Id { get; set; }
        public Guid DeviceId { get; set; }
        public Device Device { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public decimal Value { get; set; }
        public DateTime DataDeviceTime { get; set; }
        public DateTime DataServerTime { get; set; }
        public int UserId { get; set; }
        public int EnvironmentId { get; set; }
        public int? AlarmId { get; set; }
    }
}