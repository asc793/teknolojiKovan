using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi.Domain.Device.DTOs
{
    public class DeviceConfig
    {
        [JsonProperty(PropertyName = "ssid")]
        public string WifiSSID { get; set; }
        
        [JsonProperty(PropertyName = "password")]
        public string WifiPassword { get; set; }

        [JsonProperty(PropertyName = "readinterval")]
        public int ReadInterval { get; set; }

        [JsonProperty(PropertyName = "sendinterval")]
        public int SendInterval { get; set; }

        [JsonProperty(PropertyName = "commands")]
        public string[] Commands { get; set; }

        [JsonProperty(PropertyName = "sensorconfig")]
        public SensorConfig[] SensorConfig { get; set; }

        [JsonProperty(PropertyName = "alarms")]
        public Alarm[] Alarms { get; set; }
    }

    public class SensorConfig
    {
        [JsonProperty(PropertyName = "sensorType")]
        public int SensorType { get; set; }

        [JsonProperty(PropertyName = "pinnumber")]
        public int PinNumber { get; set; }
    }

    public class Alarm
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "side")]
        public string Side { get; set; }

        [JsonProperty(PropertyName = "devicePinNo")]
        public int PinNo { get; set; }

        [JsonProperty(PropertyName = "property")]
        public string Property { get; set; }

        [JsonProperty(PropertyName = "level")]
        public int Level { get; set; }

        [JsonProperty(PropertyName = "min")]
        public decimal Min { get; set; }

        [JsonProperty(PropertyName = "max")]
        public decimal Max { get; set; }
    }
}