using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi.Models.EntityClass
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SensorType SensorType { get; set; }
        public ICollection<Property> Properties { get; set; }
        public ICollection<SensorProfile> SensorProfiles { get; set; }
    }
    public enum SensorType
    {
        DHT11 = 1
    }
}