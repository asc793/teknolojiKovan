using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi.Domain.Alarm.DTOs
{
    public class AlarmFireDto
    {
        public int AlarmId { get; set; }
        public string Side { get; set; }
        public string Property { get; set; }
        public string Value { get; set; }
    }
}