using BabysittingBusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BabysitterUnitTests
{
    [TestClass]
    public class BabysitterTests
    {
        [TestMethod]
        public void StartEarlierThan5pmThrowArgumentOutOfRangeException()
        {
            Babysitting babysitting = new Babysitting();

            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>babysitting.Start(new DateTime()));
        }
    }
}
