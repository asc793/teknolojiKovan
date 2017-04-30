using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknolojiKovaniWebApi.Domain.Dashboard.DTOs
{
    public class Data
    {
        public string type { get; set; }
        public string name { get; set; }
        public bool showInLegend { get; set; }
        public List<DataPoint> dataPoints { get; set; }
    }
}
