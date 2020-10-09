using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatApplication.Models
{
    public class Season
    {
        public string name { get; set; }
        public List<Match> matches { get; set; }
    }
}
