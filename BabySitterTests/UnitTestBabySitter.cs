using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BabySitterTests
{
    [TestClass]
    public class UnitTestBabySitter
    {
        [TestMethod]
        public void TestPayBeforeBedTime()
        {
            BabySitterPay babySitterPay = new BabySitterPay();
            Double totalCharge = babySitterPay.PayBeforeBedTime(startTime, endTime);
            Assert.AreEqual(1, totalCharge);

        }
    }
}
