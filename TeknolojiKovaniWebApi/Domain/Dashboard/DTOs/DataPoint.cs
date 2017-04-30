using System;

namespace TeknolojiKovaniWebApi.Domain.Dashboard.DTOs
{
    public class DataPoint
    {
        public decimal x { get; set; }
        public decimal y { get; set; }
        public string label { get; set; }
        public string name { get; set; }
    }
}