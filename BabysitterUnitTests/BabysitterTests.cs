using BabysittingBusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace BabysitterUnitTests
{
    [TestClass]
    public class BabysitterTests
    {
        private int year;
        private int month;
        private int day;
        private int hour;
        private int minute;
        private int second;
        Babysitting babysitting;

        public BabysitterTests()
        {
            babysitting = new Babysitting();
            year = 2018;
            month = 4;
            day = 17;
            hour = 5;
            minute = 0;
            second = 0;
        }

        [TestMethod]
        public void StartEarlierThan5pmThrowArgumentOutOfRangeException()
        {            
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>babysitting.Start(new DateTime()));
        }

        [TestMethod]        
        public void StartAtOrAfter5pmIsAccepted()
        {           
            var start = new DateTime(year, month, day, hour, minute, second);
            Assert.AreEqual(start, babysitting.Start(start));
        }

        [TestMethod]
        public void LeavesNotLaterThan4am()
        {
            hour = 4;
            var time = new DateTime(year, month, day, hour, minute, second);
            Assert.AreEqual(time, babysitting.End(time));
        }
    }
}
