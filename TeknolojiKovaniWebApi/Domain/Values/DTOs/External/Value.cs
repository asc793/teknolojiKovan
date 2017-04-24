using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi.Domain.Values.DTOs.External
{
    public class Value
    {
        public Guid DeviceId { get; set; }
        public string PropertyName { get; set; }
        public string ValueString { get; set; }
        public DateTime DataDeviceTime { get; set; }
    }
}