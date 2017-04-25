using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi.Models.EntityClass
{
    public class Environment
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
        public Users User { get; set; }

    }
}