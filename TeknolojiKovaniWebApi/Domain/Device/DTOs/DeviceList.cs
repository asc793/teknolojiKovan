using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknolojiKovaniWebApi.Domain.Device.DTOs
{
    public class DeviceList
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MacNo { get; set; }
        public string CurrentToken { get; set; }
        public string ProfileName { get; set; }
        public string UserName { get; set; }
        public string EnvironmentName { get; set; }
        public int DataSendInterval { get; set; }
    }
}
