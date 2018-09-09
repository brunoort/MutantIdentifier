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
    public interface ISearchController
    {
        IActionResult MutantIdentifier(dynamic value);
    }

    [Route("mutant")]
    public class SearchController : Controller, ISearchController
    {
        //Repositories
        private readonly ISearchRepository _searchRepository;
        private readonly IStatsRepository _statsRepository;
                
        public SearchController(ISearchRepository searchRepository, IStatsRepository statsRepository)
        {
            this._searchRepository = searchRepository;
            this._statsRepository = statsRepository;
        }
        
        [HttpPost]
        public IActionResult MutantIdentifier([FromBody] dynamic dnaSequenceViewModel)
        {
            try
            {
                if (dnaSequenceViewModel != null)
                {
                    var dnaSequence = JsonConvert.DeserializeObject<string[]>(dnaSequenceViewModel.dna.ToString());
                    var result = _searchRepository.IsMutantInDna(dnaSequence);

                    _statsRepository.GenerateStats(result.IsMutant);

                    if (result.ResultType == ResultType.Valid && result.IsMutant == true)
                        return StatusCode(200);
                    else
                        return StatusCode(403);
                }

                return StatusCode(404);
            }
            catch (Exception ex)
            {
                return StatusCode(404);
            }
        }

    }
}
