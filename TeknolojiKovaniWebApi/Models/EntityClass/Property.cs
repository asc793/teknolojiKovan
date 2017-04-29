using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi.Models.EntityClass
{
    public class Property
    {
        public int Id { get; set; }
        public Sensor Sensor { get; set; }
        public int SensorId { get; set; }
        public string Name { get; set; }
        public PropertyType Type { get; set; }
        
    }
}