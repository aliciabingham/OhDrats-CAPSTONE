using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OhDrats.Models
{
    public class Gun
    {
        public string UserId { get; set; }
        public string GunName { get; set; }

        public int AmountOfAmmo { get; set; }
    }
}