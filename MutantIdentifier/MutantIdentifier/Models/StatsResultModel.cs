using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MutantIdentifier.Models
{
    public class StatsResultModel
    {
        public int count_mutant_dna { get; set; }

        public int count_human_dna { get; set; }

        public double ratio { get; set; }
    }
}
