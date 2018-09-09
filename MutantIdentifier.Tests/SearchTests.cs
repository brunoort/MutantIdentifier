using Microsoft.VisualStudio.TestTools.UnitTesting;
using MutantIdentifier.Models;
using MutantIdentifier.Repository;

namespace MutantIdentifier.Tests
{
    [TestClass]
    public class SearchTests
    {
        private SearchRepository _searchRepository;

        [TestInitialize]
        public void Initalize()
        {
            _searchRepository = new SearchRepository();
        }

        [TestMethod]
        public void IsMutantTrueTest()
        {
            //Arrange
            var dnaSequence = new string[] { "ATGCGA", "CAGTGC", "TTACGT", "AGACGG", "CACCTA", "TCACTG" };

            //Act
            var result = _searchRepository.IsMutantInDna(dnaSequence);

            //Assert
            Assert.AreEqual(result.ResultType, ResultType.Valid);
            Assert.IsTrue(result.IsMutant);
        }

        [TestMethod]
        public void IsMutantFalseTest()
        {
            //Arranger
            var dnaSequence = new string[] { "ATGCGA", "CAGTGC", "TTACTT", "AGACGG", "CACATA", "TCACTG" };

            //Act
            var result = _searchRepository.IsMutantInDna(dnaSequence);

            //Assert
            Assert.AreEqual(result.ResultType, ResultType.Valid);
            Assert.IsFalse(result.IsMutant);
        }

        [TestMethod]
        public void HasInvalidDnaSequence()
        {
            //Arrange
            var dnaSequence = new string[] { "ATBCGA" };

            //Act
            var result = _searchRepository.IsMutantInDna(dnaSequence);

            //Assert
            Assert.AreEqual(result.ResultType, ResultType.Invalid);
            Assert.IsFalse(result.IsMutant);
        }

        [TestMethod]
        public void HasNoDnaSequence()
        {
            //Arrange
            var dnaSequence = new string[] {};

            //Act
            var result = _searchRepository.IsMutantInDna(dnaSequence);

            //Assert
            Assert.AreEqual(result.ResultType, ResultType.Invalid);            
        }
    }
}
