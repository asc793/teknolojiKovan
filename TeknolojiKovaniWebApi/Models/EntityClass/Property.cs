using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi.Models.EntityClass
{
    public class Property
    {
        public int PropertyID { get; set; }
        public string PropertyName { get; set; }
        public PropertyType PropertyType { get; set; }
        
    }
}