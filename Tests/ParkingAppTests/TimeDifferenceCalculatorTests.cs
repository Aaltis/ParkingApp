using NUnit.Framework;
using ParkingApp.Pages.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAppTests
{
    internal class TimeDifferenceCalculatorTests
    {

        [Test]
        public void BasicTimeDifferenceCalculation_Successfull()
        {
            DateTime startTime = new DateTime(2023, 12, 1, 14, 0, 0, DateTimeKind.Utc);
            DateTime endTime = new DateTime(2023, 12, 1, 17, 30, 0, DateTimeKind.Utc);

            Assert.AreEqual(3.5, TimeDifferenceCalculator.GetTimeDifferenceInHours(startTime, endTime));
        }

        [Test]
        public void DateTimeDifference_Throws()
        {
            DateTime startTime = new DateTime(2023, 12, 1, 14, 0, 0, DateTimeKind.Utc);
            DateTime endTime = new DateTime(2023, 12, 1, 17, 30, 0, DateTimeKind.Local);

            void Action() => TimeDifferenceCalculator.GetTimeDifferenceInHours(startTime, endTime);
              
            Assert.Throws<ArgumentException>(Action);
        }

        [Test]
        public void DateTimeDifference_Endtime_Before_Starttime_Throws()
        {
            DateTime startTime = new DateTime(2023, 12, 1, 14, 0, 0, DateTimeKind.Utc);
            DateTime endTime = new DateTime(2023, 12, 1, 13, 30, 0, DateTimeKind.Local);

            void Action() => TimeDifferenceCalculator.GetTimeDifferenceInHours(startTime, endTime);

            Assert.Throws<ArgumentException>(Action);
        }

    }
}
