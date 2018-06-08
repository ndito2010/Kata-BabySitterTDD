using System;
using System.CodeDom;
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
        private const Double AFTERBEDTIMERATE = 8;
        private const Double AFTERMIDNIGHTRATE = 16;
        private const int MIDNIGHT = 6;

        public Double CalcBabySitterPay(int startTime, int endTime, int bedTime)
        {
                Double totalPay = 0.00;
            try
            {
                if (endTime <= bedTime)
                {
                    totalPay = CalcPayBeforeBedTime(startTime, endTime);
                }

                if (endTime > bedTime && endTime <= MIDNIGHT)
                {
                    totalPay = CalcPayBeforeBedTime(startTime, bedTime) + CalcPayAfterBedTime(bedTime, endTime);
                }

                if (endTime > MIDNIGHT)
                {
                    totalPay = CalcPayBeforeBedTime(startTime, bedTime) + CalcPayAfterBedTime(bedTime, endTime) +
                               CalcPayAfterMidNight(endTime);
                }
            }
            catch (Exception ex)
            {
                throw ex; // TO DO capture specific exception and Log 
            }
                return totalPay;
        }
        public Double CalcPayBeforeBedTime(int startTime, int endTime)
        {
            return 0;
        }

        public Double CalcPayAfterBedTime(int bedTime, int endTime)
        {
            return 0;
        }

        public Double CalcPayAfterMidNight(int endTime)
        {
            return 0;
        }
    }
}
