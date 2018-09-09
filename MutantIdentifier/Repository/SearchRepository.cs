using MutantIdentifier.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MutantIdentifier.Repository
{
    public interface ISearchRepository
    {
        SearchResult IsMutantInDna(string[] dna);
    }

    public class SearchRepository : ISearchRepository
    {

        public SearchRepository()
        {
        }

        public SearchResult IsMutantInDna(string[] dna)
        {
            var result = new SearchResult();
            int sequenceIdentified = 0;

            //Validation
            var validation = DnaSequenceValidation(dna, result);

            try
            {
                if (validation == false)
                    throw new Exception();

                int lineNumbers = dna.Length;
                for (int i = 0; (i < lineNumbers); i++)
                {
                    for (int j = 0; (j < lineNumbers); j++)
                    {
                        if ((i < (lineNumbers - 3)))
                        {
                            //  Diagonal
                            sequenceIdentified += DiagonalVerify(dna, lineNumbers, i, j);
                            //  Vertical
                            sequenceIdentified += VerticalVerify(dna, i, j);
                        }
                        //  Horizontal
                        sequenceIdentified += HorizontalVerify(dna, lineNumbers, i, j);
                    }
                }

                if (sequenceIdentified > 1)
                {
                    result.ResultType = ResultType.Valid;
                    result.IsMutant = true;
                }
                else
                {
                    result.ResultType = ResultType.Valid;
                    result.IsMutant = false;
                }
            }
            catch
            {
                result.ResultType = ResultType.Invalid;
                result.IsMutant = false;
            }           

            return result;
        }

        private static bool DnaSequenceValidation(string[] dna, SearchResult result)
        {
            var validation = false;
            result.ResultType = ResultType.Valid;
            
            if (dna.Count() == 0)
            {
                result.ResultType = ResultType.Invalid;
                result.IsMutant = false;

                validation = false;
            }
            else
            {
                foreach (var value in dna)
                {
                    if (string.IsNullOrEmpty(value.ToString()))
                    {
                        result.ResultType = ResultType.Invalid;
                        result.IsMutant = false;

                        break;
                    }

                    foreach (char c in value)
                    {
                        var charValue = c.ToString();
                        var charResult = FindForString(charValue);

                        if(charResult == false)
                        {
                            result.ResultType = ResultType.Invalid;
                            result.IsMutant = false;

                            break;                            
                        }                            
                    }                                        
                }

                if(result.ResultType == ResultType.Valid)
                    validation = true;
            }

            return validation;
        }

        private static bool FindForString(string charValue)
        {
            if (charValue.Contains("A"))
                return true;

            if (charValue.Contains("T"))
                return true;

            if (charValue.Contains("C"))
                return true;

            if (charValue.Contains("G"))
                return true;

            return false;
        }

        private int HorizontalVerify(string[] dna, int lineNumber, int i, int j)
        {
            int dnaResult = 0;
            if ((j < (lineNumber - 3)))
            {
                string dnaSequence = "";
                char dnaGen = dna[i].ElementAt(j);
                dnaSequence = (dnaSequence + dnaGen);
                dnaSequence = (dnaSequence + dna[i].ElementAt((j + 1)));
                dnaSequence = (dnaSequence + dna[i].ElementAt((j + 2)));
                dnaSequence = (dnaSequence + dna[i].ElementAt((j + 3)));
                string replaced_string_h = dnaSequence.Replace(dnaGen, ' ');

                if (string.IsNullOrEmpty(replaced_string_h.Trim()))
                {
                    dnaResult++;
                }

            }

            return dnaResult;
        }

        private int VerticalVerify(string[] dna, int i, int j)
        {
            int dnaResult = 0;
            string dnaSequence = "";

            char dnaGen = dna[i].ElementAt(j);
            dnaSequence = (dnaSequence + dnaGen);
            dnaSequence = (dnaSequence + dna[(i + 1)].ElementAt(j));
            dnaSequence = (dnaSequence + dna[(i + 2)].ElementAt(j));
            dnaSequence = (dnaSequence + dna[(i + 3)].ElementAt(j));
            string replaced_string_v = dnaSequence.Replace(dnaGen, ' ');
            if (string.IsNullOrEmpty(replaced_string_v.Trim()))
            {
                dnaResult++;
            }

            return dnaResult;
        }

        private int DiagonalVerify(string[] dna, int lineNumber, int i, int j)
        {
            int dnaResult = 0;

            if ((j < (lineNumber - 3)))
            {
                string dnaSequence = "";
                char dnaGen = dna[i].ElementAt(j);
                dnaSequence = (dnaSequence + dnaGen);
                dnaSequence = (dnaSequence + dna[(i + 1)].ElementAt((j + 1)));
                dnaSequence = (dnaSequence + dna[(i + 2)].ElementAt((j + 2)));
                dnaSequence = (dnaSequence + dna[(i + 3)].ElementAt((j + 3)));

                string replaced_string_d = dnaSequence.Replace(dnaGen, ' ');

                if (string.IsNullOrEmpty(replaced_string_d.Trim()))
                {
                    dnaResult++;
                }

            }

            return dnaResult;
        }
    }
}