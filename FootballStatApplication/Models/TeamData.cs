using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatApplication.Models
{
    public class TeamData
    {
        public string Achievement { get; set; }
        public string TeamName { get; set; }
        public string LeagueName { get; set; }
        public int ScoredGoals { get; set; }
        public int MissedGoals { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BestDay { get; set; }

    }
}
