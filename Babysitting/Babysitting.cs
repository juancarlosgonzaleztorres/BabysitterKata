using System;

namespace BabysittingBusinessLogic
{
    public class Babysitting
    {
        DateTime startTime, endTime, bedTime;

        public Babysitting()
        {
            startTime = new DateTime();
            endTime = new DateTime();
            bedTime = new DateTime();
        }

        public DateTime StartTime(DateTime startTime)
        {
            if (startTime.Hour<5)
                throw new ArgumentOutOfRangeException();
            this.startTime = startTime;
            return startTime;
        }

        public DateTime BedTime(DateTime bedTime)
        {
            if (bedTime < startTime || bedTime > endTime )
                throw new ArgumentOutOfRangeException();
            return bedTime;
        }

        public DateTime EndTime(DateTime endTime)
        {
            if (endTime.Hour >= 4 && endTime.Minute>0)
                throw new ArgumentOutOfRangeException();
            this.endTime = endTime;
            return endTime;
        }

        public int CalculatePayment()
        {
            return 48;
        }
    }
}
