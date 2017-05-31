using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditCardValidator.Networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidatorTests
{
    [TestClass]
    public class VisaTest
    {
        private readonly Visa _visa;

        public VisaTest()
        {
            _visa = new Visa();
        }

        [DataTestMethod]
        [DataRow(9111111111111111)]
        [DataRow(5578274819456558)]
        [DataRow(378282246310005)]
        public void ShouldReturnFalseWhenNotAVisa(long number)
        {
            var result = _visa.IdentifiedValidator(number);

            Assert.IsFalse(result, "should not be identified");
        }

        [DataTestMethod]
        [DataRow(4111111111111)]
        [DataRow(4532667655657138)]
        [DataRow(4539507507623618)]
        public void ShouldBeInvalid(long number)
        {
            var result = _visa.IsValid(number);

            Assert.IsFalse(result, "should be a invalid number");
        }

        [DataTestMethod]
        [DataRow(4111111111111111)]
        [DataRow(4012888888881881)]
        [DataRow(4532090150969103)]
        public void ShouldBeValid(long number)
        {
            var result = _visa.IsValid(number);

            Assert.IsTrue(result, "should not be a valid number");
        }


    }
}
