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
    public class MasterCardTest
    {
        private readonly MasterCard _masterCard;

        public MasterCardTest()
        {
            _masterCard = new MasterCard();
        }

        [DataTestMethod]
        [DataRow(4111111111111111)]
        [DataRow(4111111111111)]
        [DataRow(378282246310005)]
        public void ShouldReturnFalseWhenNotAMasterCard(long number)
        {
            var result = _masterCard.IdentifiedValidator(number);

            Assert.IsFalse(result, "should not be identified");
        }

        [DataTestMethod]
        [DataRow(5105105105105106)]
        [DataRow(5578274819456558)]
        [DataRow(5375371893968558)]
        public void ShouldBeInvalid(long number)
        {
            var result = _masterCard.IsValid(number);

            Assert.IsFalse(result, "should not be a valid number");
        }

        [DataTestMethod]
        [DataRow(5105105105105100)]
        [DataRow(5183416396422061)]
        [DataRow(5578274819456551)]
        public void ShouldBeValid(long number)
        {
            var result = _masterCard.IsValid(number);

            Assert.IsTrue(result, "should not be a valid number");
        }


    }
}
