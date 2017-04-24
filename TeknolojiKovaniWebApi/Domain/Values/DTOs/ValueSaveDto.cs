using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi.Domain.Values.DTOs
{
    public class ValueSaveDto
    {
        public int DeviceId { get; set; }
        public DateTime DataDeviceTime { get; set; }
    }
}