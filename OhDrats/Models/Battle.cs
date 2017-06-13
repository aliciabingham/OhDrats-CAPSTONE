using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace OhDrats.Models
{
    public class Battle
    {
        public string UserId { get; set;  }
        public string OpponentName {get; set;} 

        public int ShotsFired { get; set; }

        public int Hits { get; set; }
        
        public int Misses { get; set; }

        public string Gun { get; set; }

        public int Score { get; set; }

    }
}