using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatApplication.Models
{
    public class Match
    {
        public string round { get; set; }
        public string date { get; set; }
        public string team1 { get; set; }
        public string team2 { get; set; }
        public Score score { get; set; }
    }
}
