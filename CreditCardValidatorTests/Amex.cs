using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditCardValidator.Networks;

namespace CreditCardValidatorTests
{
    [TestClass]
    public class AmexTest
    {
        private readonly Amex _amex;

        public AmexTest()
        {
            _amex = new Amex();
        }

        [DataTestMethod]
        [DataRow(4111111111111111)]
        [DataRow(4111111111111)]
        [DataRow(4012888888881881)]
        [DataRow(9111111111111111)]
        public void ShouldReturnFalseWhenNotAAmex(long number)
        {
            var result = _amex.IdentifiedValidator(number);

            Assert.IsFalse(result, "should not be identified");
        }

        [DataTestMethod]
        [DataRow(379164376523140)]
        [DataRow(347109680640780)]
        [DataRow(341713942350440)]
        public void ShouldBeInvalid(long number)
        {
            var result = _amex.IsValid(number);

            Assert.IsFalse(result, "should be a invalid number");
        }

        [DataTestMethod]
        [DataRow(378750930126002)]
        [DataRow(347109680640787)]
        [DataRow(378282246310005)]
        public void ShouldBeValid(long number)
        {
            var result = _amex.IsValid(number);

            Assert.IsTrue(result, "should be a valid number");
        }
    }
}
