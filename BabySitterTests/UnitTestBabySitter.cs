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
            Double totalCharge = babySitterPay.CalcBabySitterPay(6, 7, 9);
            Assert.AreEqual(12, totalCharge);

        }
    }
}
