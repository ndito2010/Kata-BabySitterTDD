using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySitter
{
    /*Assumptions
     -User enter hrs only
     -User Start between 5PM to 4AM therefore 6 ~ 6PM , 3 ~ 3AM
     - 
     */

    public class BabySitterPay
    {
        private const Double BEDTIMERATE = 12;
        public Double PayBeforeBedTime(int startTime, int endTime)
        {
            Double NightlyPay = 0.00;
            NightlyPay = (endTime - startTime) * BEDTIMERATE;
            return NightlyPay;
        }
    }
}
