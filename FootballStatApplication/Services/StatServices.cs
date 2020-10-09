using FootballStatApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballStatApplication.DataAccess;
using System.Security.Cryptography.X509Certificates;

namespace FootballStatApplication.Services
{
    public class StatServices
    {

        private AccessToData dataAccess;

        public StatServices()
        {
            dataAccess = new AccessToData();
        }

         public TeamData GetLeagueBestAttackTeam(string _json)
        {
            var data = dataAccess.GetSeasonData(_json);
            TeamData teamDatas = new TeamData();
            try
            {

                data.matches.RemoveAll(item => item.score == null);
                var res = from s in data.matches
                          group s by s.team1 into g
                          select new TeamData
                          {
                              TeamName = g.Key,
                              Achievement = "Best scoring team",
                              LeagueName = data.name,
                              ScoredGoals = g.Sum(y => y.score.ft[0]),
                              MissedGoals = g.Sum(y => y.score.ft[1])
                          };
                teamDatas = res.OrderByDescending(x => x.ScoredGoals).First();
            }
            catch (Exception e)
            {

                throw e;
            }
            return teamDatas;
        }

        public TeamData GetLeagueBestDefenceTeam(string _json)
        {
            var data = dataAccess.GetSeasonData(_json);
            TeamData teamDatas = new TeamData();
            try
            {

                data.matches.RemoveAll(item => item.score == null);
                var res = from s in data.matches
                          group s by s.team1 into g
                          select new TeamData
                          {
                              TeamName = g.Key,
                              LeagueName = data.name,
                              Achievement =  "Best defencive team",
                              ScoredGoals = g.Sum(y => y.score.ft[0]),
                              MissedGoals = g.Sum(y => y.score.ft[1])
                          };
                teamDatas = res.OrderByDescending(x => x.MissedGoals).First();
            }
            catch (Exception e)
            {

                throw e;
            }
            return teamDatas;
        }

        public TeamData GetLeagueBestTeamByCoefficient(string _json)
        {
            var data = dataAccess.GetSeasonData(_json);
            TeamData teamDatas = new TeamData();
            try
            {

                data.matches.RemoveAll(item => item.score == null);
                var res = from s in data.matches
                          group s by s.team1 into g
                          select new TeamData
                          {
                              TeamName = g.Key,
                              LeagueName = data.name,
                              Achievement = "Best team by index",
                              ScoredGoals = g.Sum(y => y.score.ft[0]),
                              MissedGoals = g.Sum(y => y.score.ft[1])
                          };
                teamDatas =  res.OrderByDescending(x => x.ScoredGoals)
                    .OrderByDescending(x=>(x.ScoredGoals/x.MissedGoals))
                    .First();
            }
            catch (Exception e)
            {

                throw e;
            }
            return teamDatas;
        }

        public TeamData GetLeagueBestDayByGoals(string _json)
        {
            var data = dataAccess.GetSeasonData(_json);
            TeamData teamDatas = new TeamData();
            try
            {

                data.matches.RemoveAll(item => item.score == null);
                var res = from s in data.matches
                          group s by new { s.date } into g
                          select new TeamData
                          {
                              BestDay = DateTime.Parse(g.Key.date),
                              LeagueName = data.name,
                              ScoredGoals = g.Sum(y => y.score.ft[0])
                          };
                teamDatas = res.OrderByDescending(x=>x.ScoredGoals).First();
            }
            catch (Exception e)
            {

                throw e;
            }
            return teamDatas;
        }


    }
}
