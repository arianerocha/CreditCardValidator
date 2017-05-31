using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditCardValidator.Services;
using CreditCardValidator.Exceptions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidatorTests
{
    [TestClass]
    public class ValidatorServiceTest
    {
        private readonly ValidatorService _service;
        const string amex = "AMEX";
        const string discover = "Discover";
        const string mastercard = "MasterCard";
        const string visa = "VISA";

        public ValidatorServiceTest()
        {
            _service = new ValidatorService();
        }

        [TestMethod]
        public void ShouldReturnAmexValidator()
        {
            var validator = _service.GetValidator(378282246310005);
            Assert.IsTrue(validator.Name == amex, "should be a AMEX validator");
        }

        [TestMethod]
        public void ShouldReturnDiscoverValidator()
        {
            var validator = _service.GetValidator(6011111111111117);
            Assert.IsTrue(validator.Name == discover, "should be a Discover validator");
        }

        [TestMethod]
        public void ShouldReturnMasterCardValidator()
        {
            var validator = _service.GetValidator(5105105105105100);
            Assert.IsTrue(validator.Name == mastercard, "should be a MasterCard validator");
        }

        [TestMethod]
        public void ShouldReturnVisaValidator()
        {
            var validator = _service.GetValidator(4111111111111111);
            Assert.IsTrue(validator.Name == visa, "should be a VISA validator");
        }
    }
}
