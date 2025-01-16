using NUnit.Framework;
using ParkingApp.Pages.Validators;
using System;
using System.Collections.Generic;

namespace ParkingAppTests
{

    internal class CalculateParkingPricesTests
    {
        [Test]
        public void SpesificAmountTime_Success()
        {
            List<Decimal> PriceList = new List<Decimal> { 0.5m, 0.5m, 0.5m, 0.3m };
            Assert.AreEqual(1.5, ParkingPriceCalculator.CalculateParkingPrice(PriceList, 3));
        }

        [Test]
        public void DecimalAmountTime_Success()
        {
            List<Decimal> PriceList = new List<Decimal> { 0.5m, 0.5m, 0.5m, 0.3m };
            Assert.AreEqual(1.5, ParkingPriceCalculator.CalculateParkingPrice(PriceList, 2.5m));
        }

        [Test]
        public void ParkTimeIsLongerThanPriceList_Success()
        {
            List<Decimal> PriceList = new List<Decimal> { 0.5m, 0.5m, 0.5m, 0.3m };
            Assert.AreEqual(2.1, ParkingPriceCalculator.CalculateParkingPrice(PriceList, 5));
        }

        [Test]
        public void PriceListEmpty_Failure()
        {
            List<Decimal> PriceList = new List<Decimal>();
            void Action() => ParkingPriceCalculator.CalculateParkingPrice(PriceList, 5);
            Assert.Throws<ArgumentException>(Action);
        }
    }
}
