using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknolojiKovaniWebApi.Domain.Values.DTOs
{
    public class DeviceValues
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string PropertyName { get; set; }
        public decimal Value { get; set; }
        public DateTime DataDeviceTime { get; set; }
        
    }
}
