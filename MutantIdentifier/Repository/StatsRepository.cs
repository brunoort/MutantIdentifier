using MutantIdentifier.ContextDatabase;
using MutantIdentifier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MutantIdentifier.Repository
{
    public interface IStatsRepository
    {
        void GenerateStats(bool isMutant);
        StatsResultModel GetStats();
    }

    public class StatsRepository : IStatsRepository
    {
        private readonly MutantContext _context;

        public StatsRepository(MutantContext context)
        {
            this._context = context;
        }

        public void GenerateStats(bool isMutant)
        {
            var stats = new StatsModel()
            {
                IsMutant = isMutant,
                Date = DateTime.Now
            };

            _context.Stats.Add(stats);
            _context.SaveChanges();
        }

        public StatsResultModel GetStats()
        {
            var stats = _context.Stats.ToList();

            int qtdSearch = stats.Count();
            int qtdMutants = stats.Where(x => x.IsMutant == true).Count();
            int qtdHumans = (qtdSearch - qtdMutants);
            double ratioCalc;

            if (qtdHumans == 0)
                ratioCalc = 1;
            else
                ratioCalc = (double)qtdMutants/qtdHumans;

            var result = new StatsResultModel()
            {
                count_human_dna = qtdHumans,
                count_mutant_dna = qtdMutants,
                ratio = ratioCalc
            };

            return result;
        }

    }
}
