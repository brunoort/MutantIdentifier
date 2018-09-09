using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MutantIdentifier.Models
{
    public class SearchResult
    {
        public ResultType ResultType { get; set; }

        public bool IsMutant { get; set; }

    }

    public enum ResultType
    {
        Invalid,
        Valid
    }
}
