using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MutantIdentifier.Models;
using MutantIdentifier.Models.ModelView;
using MutantIdentifier.Repository;
using Newtonsoft.Json;

namespace MutantIdentifier.Controllers
{

    [Route("stats")]
    public class StatsController : Controller
    {
        //Repositories
        private readonly IStatsRepository _statsRepository;

        public StatsController(IStatsRepository statsRepository)
        {            
            this._statsRepository = statsRepository;
        }

        [HttpGet]
        public StatsResultModel GetStats()
        {
            return _statsRepository.GetStats();
        }

    }
}
