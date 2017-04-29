using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknolojiKovaniWebApi.Domain.Device.DTOs;
using TeknolojiKovaniWebApi.Models.EntityClass;

namespace TeknolojiKovaniWebApi.Domain.Alarm.DTOs
{
    public class AlarmList
    {
        public int Id { get; set; }
        public Guid DeviceId { get; set; }
        public string DeviceName{ get; set; }
        public int PropertyId { get; set; }//
        public string PropertyName { get; set; }
        public int Level { get; set; }
        public int Min { get; set; }//
        public int Max { get; set; }//
        public int PinNo { get; set; }//
        public string AlarmParameter { get; set; }//
        public AlarmType AlarmType { get; set; }//
    }
}
