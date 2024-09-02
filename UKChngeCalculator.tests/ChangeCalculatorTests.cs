using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UKChangeCalculator
{
    [TestClass]
    public class ChangeCalculatorTests
    {
        private IChangeCalculator _changeCalculator;

        [TestInitialize]
        public void Setup()
        {
            var denominations = new Dictionary<string, double>
            {
                { "£50" , 50.00 },
                { "£20" , 20.00 },
                { "£10" , 10.00 },
                { "£5" , 5.00 },
                { "£2" , 2.00 },
                { "£1" , 1.00 },
                { "50p", 0.50 },
                { "20p", 0.20 },
                { "10p", 0.10 },
                { "5p", 0.05 },
                { "2p", 0.02 },
                { "1p", 0.01 }
            };

            _changeCalculator = new ChangeCalculator(denominations);
        }

        [TestMethod]
        public void CalculateChange_ShouldReturnCorrectChange()
        {
            double totalAmount = 10.00;
            double purchasePrice = 0.01;

            var expectedChange = new Dictionary<string, int>
            {
                {"£5", 1},
                {"£2", 2},
                {"50p", 1 },
                {"20p", 2 },
                {"5p", 1 },
                {"2p", 2 }
            };

            var actualChange = _changeCalculator.CalculateChange(totalAmount, purchasePrice);

            CollectionAssert.AreEquivalent(expectedChange, actualChange);
        }

        [TestMethod]
        public void CalculateChange_ShouldReturnNull_whenInsufficientFunds()
        {
            double totalAmount = 5.00;
            double purchasePrice = 10.00;

            var result = _changeCalculator.CalculateChange(totalAmount, purchasePrice);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void CalculateChange_ShouldReturnEmptyDict_WhenTotalAmountEqualsPurchasePrice()
        {
            double totalAmount = 5.00;
            double purchasePrice = 5.00;

            var expectedChange = new Dictionary<string, int>();

            var actualChange = _changeCalculator.CalculateChange(totalAmount, purchasePrice);

            CollectionAssert.AreEquivalent(expectedChange, actualChange);
        }

    }
}
