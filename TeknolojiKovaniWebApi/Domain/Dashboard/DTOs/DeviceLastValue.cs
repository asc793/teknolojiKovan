using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknolojiKovaniWebApi.Domain.Dashboard.DTOs
{
    public class DeviceLastValue
    {
        public Guid Id { get; set; }
        public string DeviceName { get; set; }
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public decimal Value { get; set; }
        public DateTime DataDeviceTime { get; set; }
    }
}
