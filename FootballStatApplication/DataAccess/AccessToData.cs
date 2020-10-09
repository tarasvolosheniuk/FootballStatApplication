using FootballStatApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballStatApplication.DataAccess
{
    public class AccessToData
    {
        private Season season = new Season();

        public AccessToData( )
        {
        }

        public Season GetSeasonData(string _json)
        { 
            try
            {
                season = JsonConvert.DeserializeObject<Season>(_json);
            }
            catch (Exception e)
            {

                throw e;
            }   
            return season;
        }
    }
}
