using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FootballStatApplication.Models;
using FootballStatApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FootballStatApplication.Controllers
{
    public class HomeController : Controller
    {
        private StatServices _statServices = new StatServices();
        private WebClient _webClient = new WebClient();

        public IActionResult Index()
        {
            


            List<string> jsons = new List<string>{ _webClient.DownloadString("https://raw.githubusercontent.com/openfootball/football.json/master/2019-20/en.1.json") ,
                                                   _webClient.DownloadString("https://raw.githubusercontent.com/openfootball/football.json/master/2019-20/en.2.json"),
                                                   _webClient.DownloadString("https://raw.githubusercontent.com/openfootball/football.json/master/2019-20/en.3.json")
            };


            List<TeamData> teamDatas = FormStatistics(jsons);

            return View(teamDatas);
        }


        private List<TeamData> FormStatistics(List<string> jsons)
        {
            List<TeamData> datas = new List<TeamData>();

            foreach (string json in jsons)
            {
                datas.AddRange(new List<TeamData> {
                    _statServices.GetLeagueBestAttackTeam(json),
                    _statServices.GetLeagueBestDefenceTeam(json),
                    _statServices.GetLeagueBestTeamByCoefficient(json),
                    _statServices.GetLeagueBestDayByGoals(json)
                });
            }

            return datas;

        }

    }
}
