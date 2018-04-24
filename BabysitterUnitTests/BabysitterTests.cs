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
        DateTime startTime, endTime, bedTime;

        public BabysitterTests()
        {            
            babysitting = new Babysitting();
            year = 2018;
            month = 4;
            day = 17;
            hour = 17;
            minute = 0;
            second = 0;
            startTime = new DateTime(year, month, 17, 17, minute, second);
            endTime = new DateTime(year, month, 18, 4, minute, second);
            bedTime = new DateTime(year, month, 17, 21, minute, second);
        }

        [TestMethod]
        public void StartEarlierThan5pmThrowArgumentOutOfRangeException()
        {            
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>babysitting.StartTime(new DateTime()));
        }

        [TestMethod]        
        public void StartAtOrAfter5pmIsAccepted()
        {           
            var start = new DateTime(year, month, day, hour, minute, second);
            Assert.AreEqual(start, babysitting.StartTime(start));
        }

        [TestMethod]
        public void LeavesNotLaterThan4am()
        {
            hour = 4;
            var time = new DateTime(year, month, day, hour, minute, second);
            Assert.AreEqual(time, babysitting.EndTime(time));
        }

        [TestMethod]
        public void LeavesAfter4amThrowArgumentOutOfRangeException()
        {
            hour = 4;
            minute = 1;
            var time = new DateTime(year, month, day, hour, minute, second);
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>babysitting.EndTime(time));
        }

        [TestMethod]
        public void SetBedTime()
        {
            var startTime = new DateTime(year, month, 17, 17, minute, second);
            babysitting.StartTime(startTime);
            var endTime = new DateTime(year, month, 18, 4, minute, second);
            babysitting.EndTime(endTime);
            var bedTime = new DateTime(year, month, 17, 20, minute, second);

            Assert.AreEqual(bedTime, babysitting.BedTime(bedTime));
        }

        [TestMethod]
        public void BedTimeOutOfBabysittingHoursThrowsException()
        {
            hour = 5;
            var time = new DateTime(year, month, day, hour, minute, second);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => babysitting.BedTime(time));
        }

        [TestMethod]
        public void GetsPaid12PerHourFromStartToBedtime()
        {            
            babysitting.StartTime(startTime);
            endTime = bedTime;
            babysitting.EndTime(endTime);
            babysitting.BedTime(bedTime);

            Assert.AreEqual(12*4, babysitting.CalculatePayment());
        }

        [TestMethod]
        public void GetsPaid8PerHourFromBedtimeToMidnight()
        {
            startTime = bedTime;
            babysitting.StartTime(startTime);
            endTime = new DateTime(year, month, 18, 0, minute, second);
            babysitting.EndTime(endTime);            
            babysitting.BedTime(bedTime);

            Assert.AreEqual(8*3, babysitting.CalculatePayment());
        }

        [TestMethod]
        public void GetsPaid16PerHourFromMidnightToEndJob()
        {
            startTime = new DateTime(year, month, 18, 0, minute, second);
            babysitting.StartTime(startTime);
            babysitting.EndTime(endTime);            

            Assert.AreEqual(16*4, babysitting.CalculatePayment());
        }
    }
}
