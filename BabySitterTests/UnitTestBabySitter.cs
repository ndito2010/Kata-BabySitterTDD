using System;
using BabySitter;
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
            Double totalCharge = babySitterPay.PayBeforeBedTime(6, 7);
            Assert.AreEqual(12, totalCharge);

        }
    }
}
