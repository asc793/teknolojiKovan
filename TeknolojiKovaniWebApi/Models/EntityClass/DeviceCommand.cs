using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi.Models.EntityClass
{
    public class DeviceCommand
    {
        public int Id { get; set; }
        public Device Device { get; set; }
        public Guid DeviceId { get; set; }
        public string Command { get; set; }
        public bool Executed { get; set; }
        public DateTime ExecutionTime { get; set; }
    }
}