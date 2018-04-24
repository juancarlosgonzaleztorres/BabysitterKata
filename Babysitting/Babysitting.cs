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
            if (startTime.Hour>4 && startTime.Hour<17||default(DateTime) == startTime)
                throw new ArgumentOutOfRangeException();
            this.startTime = startTime;
            return startTime;
        }

        public DateTime BedTime(DateTime bedTime)
        {
            if (bedTime < startTime || bedTime > endTime )
                throw new ArgumentOutOfRangeException();
            this.bedTime = bedTime;
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
            int totalPayment = calculateStartToBedTimeHours()       * 12 
                             + calculateBedTimeToMidnightHours()    * 8 
                             + calculateMidnightToEndHours()        * 16;
            return totalPayment ;
        }

        public int calculateStartToBedTimeHours()
        {
            int startToBedTimeHours = 0;
            if (bedTime > startTime)
                startToBedTimeHours = (bedTime - startTime).Hours;
            return startToBedTimeHours;
        }

        public int calculateBedTimeToMidnightHours()
        {
            int bedTimeToMidnightHours = 0;
            if (bedTime == default(DateTime))
                return 0;
            if (endTime.Day > bedTime.Day)
            {
                bedTimeToMidnightHours = 24 - bedTime.Hour;                
            }
            else
            {
                bedTimeToMidnightHours = endTime.Hour - bedTime.Hour;
            }
                            
            return bedTimeToMidnightHours;
        }

        public int calculateMidnightToEndHours()
        {
            int midnightToEndHours = 0;
            if (endTime.Day > startTime.Day)
            {
                midnightToEndHours = endTime.Hour;
            }
            else if(startTime.Hour<4)
                midnightToEndHours = endTime.Hour-startTime.Hour;
            return midnightToEndHours;
        }
    }
}