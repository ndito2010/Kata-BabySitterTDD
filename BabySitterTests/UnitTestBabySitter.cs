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
            Double totalCharge = babySitterPay.CalcBabySitterPay(5, 7, 9);
            Assert.AreEqual(24, totalCharge);

        }
    }
}
