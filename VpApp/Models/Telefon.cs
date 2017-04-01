using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VpApp.Models
{
    public class Telefon
    {
        public Guid Id { get; set; }
        public string Tel { get; set; }

        public Guid? UserId { get; set; }
        public User User { get; set; }
    }
}