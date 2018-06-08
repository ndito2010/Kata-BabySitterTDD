using System;
using BabySitter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BabySitterTests
{
    
    [TestClass]
    public class UnitTestBabySitter
    {
        [TestMethod]
        public void TestCalcBabySitterPay()
        {
            BabySitterPay babySitterPay = new BabySitterPay();
            Double totalCharge = babySitterPay.CalcBabySitterPay("12:00", "7:00", "9:00");
            Assert.AreEqual(24, totalCharge);


        }
    }
}
