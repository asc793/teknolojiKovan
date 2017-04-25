using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi.Domain.Device.DTOs
{
    public class DeviceRead
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MacNo { get; set; }
        public string CurrentToken { get; set; }
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public int? EnvironmentId { get; set; }
        public int DataSendInterval { get; set; }
    }
}