using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditCardValidator.Networks;

namespace CreditCardValidatorTests
{
    [TestClass]
    public class DiscoverTest
    {
        private readonly Discover _discover;

        public DiscoverTest()
        {
            _discover = new Discover();
        }

        [DataTestMethod]
        [DataRow(4111111111111111)]
        [DataRow(4111111111111)]
        [DataRow(4012888888881881)]
        [DataRow(9111111111111111)]
        public void ShouldReturnFalseWhenNotADiscover(long number)
        {
            var result = _discover.IdentifiedValidator(number);

            Assert.IsFalse(result, "should not be identified");
        }

        [DataTestMethod]
        [DataRow(6011190421532885)]
        [DataRow(6011603380558295)]
        [DataRow(6011829395024005)]
        public void ShouldBeInvalid(long number)
        {
            var result = _discover.IsValid(number);

            Assert.IsFalse(result, "should not be a valid number");
        }

        [DataTestMethod]
        [DataRow(6011111111111117)]
        [DataRow(6011433402437468)]
        [DataRow(6011190421532881)]
        public void ShouldBeValid(long number)
        {
            var result = _discover.IsValid(number);

            Assert.IsTrue(result, "should be a valid number");
        }
    }
}
