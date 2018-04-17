using System;

namespace BabysittingBusinessLogic
{
    public class Babysitting
    {
        public DateTime Start(DateTime dateTime)
        {
            if (dateTime.Hour<5)
                throw new ArgumentOutOfRangeException();
            return dateTime;
        }
    }
}
