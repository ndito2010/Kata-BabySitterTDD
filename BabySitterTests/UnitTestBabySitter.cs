using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BabySitterTests
{
    
    [TestClass]
    public class UnitTestBabySitter
    {
        [TestMethod]
        public void TestCalcBabySitterPay()
        {
            BabySitterPay.BabySitterPay babySitterPay = new BabySitterPay.BabySitterPay();
            DateTime startTime = new DateTime(2018,6,8,18,0,0); // hours in 24hr format to handle AM/PM
            DateTime endTime = new DateTime(2018, 6, 8, 20, 0, 0);
            DateTime bedTime = new DateTime(2018, 6, 8, 21, 0, 0);
            double totalCharge = babySitterPay.CalcBabySitterPay(startTime, endTime, bedTime );
            Assert.AreEqual(24, totalCharge);


        }
    }
}
