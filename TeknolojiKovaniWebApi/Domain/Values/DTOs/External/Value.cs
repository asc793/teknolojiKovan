using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi.Domain.Values.DTOs.External
{
    public class DeviceValue
    {
        public Guid DeviceId { get; set; }
        public string PropertyName { get; set; }
        public float Value { get; set; }
        public DateTime DataDeviceTime { get; set; }
    }
}