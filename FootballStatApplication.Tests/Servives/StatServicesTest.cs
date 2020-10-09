using FootballStatApplication.Services;
using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using FootballStatApplication.DataAccess;
using FootballStatApplication.Models;

namespace FootballStatApplication.Tests.Servives
{
    [TestFixture]
    public class StatServicesTest
    {
        private StatServices _statServices;
        private WebClient _webClient;
        private AccessToData _accessToData;
        [SetUp]
        public void SetUp()
        {
            _statServices = new StatServices();
            _webClient = new WebClient();
            _accessToData = new AccessToData();
        }

        [Test]
        public void GetLeagueBestAttackTeam_Test()
        {
            var correctResult = _statServices.GetLeagueBestAttackTeam(_webClient
                                                                 .DownloadString("https://raw.githubusercontent.com/openfootball/football.json/master/2019-20/en.1.json"));

            Assert.IsNotNull(correctResult);
            Assert.IsInstanceOf<TeamData>(correctResult);
        }

        [Test]
        public void GetLeagueBestDefenceTeam_Test()
        {
            var correctResult = _statServices.GetLeagueBestDefenceTeam(_webClient
                                                                .DownloadString("https://raw.githubusercontent.com/openfootball/football.json/master/2019-20/en.2.json"));



            Assert.IsNotNull(correctResult);
            Assert.IsInstanceOf<TeamData>(correctResult);

        }

        [Test]
        public void GetLeagueBestTeamByCoefficient_Test()
        {
            var correctResult = _statServices.GetLeagueBestTeamByCoefficient(_webClient
                                                    .DownloadString("https://raw.githubusercontent.com/openfootball/football.json/master/2019-20/en.2.json"));


            Assert.IsNotNull(correctResult);
            Assert.IsInstanceOf<TeamData>(correctResult);

        }

    }

}
