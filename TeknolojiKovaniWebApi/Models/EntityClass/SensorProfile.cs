using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi.Models.EntityClass
{
    public class SensorProfile
    {
        [Key, Column(Order = 0)]
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }

        [Key, Column(Order = 1)]
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        public int PinNumber { get; set; }
    }
}