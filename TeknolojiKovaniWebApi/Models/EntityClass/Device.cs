using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi.Models.EntityClass
{
    public class Device
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MacNo { get; set; }
        public string CurrentToken { get; set; }
        public int ProfileId { get; set; }
        [ForeignKey("ProfileId")]
        public Profile Profile { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users User { get; set; }
        public Environment Environment { get; set; }
        public int? EnvironmentId { get; set; }
        public int DataSendInterval { get; set; }

    }
}