﻿using System;
using System.Globalization;

namespace BabySitterPay
{
    /*Assumptions
     -User Start between 5PM to 4AM therefore 6 ~ 6PM , 3 ~ 3AM
     */

    public class BabySitterPay
    {
        private const Double BEDTIMERATE = 12;
        private const Double AFTERBEDTIMERATE = 8;
        private const Double AFTERMIDNIGHTRATE = 16;
        private const string MIDNIGHT = "2018-06-08 00:00 PM";
        private const string OFFICIALSTARTTIME = "2018-06-08 17:00 PM";
        private const string OFFICIALENDTIME = "2018-06-08 4:00 AM";


        public double CalcBabySitterPay(DateTime startTime, DateTime endTime, DateTime bedTime)
        {
            double totalPay = 0.00;
            try
            {
                if  (startTime< DateTime.ParseExact(OFFICIALSTARTTIME, "yyyy-MM-dd HH:mm tt", CultureInfo.InvariantCulture) ||
                     endTime> DateTime.ParseExact(OFFICIALENDTIME, "yyyy-MM-dd HH:mm tt", CultureInfo.InvariantCulture))
                {
                    Console.WriteLine("Error: Start Time / End Time should be between 5PM and 4AM");
                    return 0;
                }
                if (endTime <= bedTime)
                {
                    totalPay = CalcPayBeforeBedTime(startTime, endTime);
                }

                else if (endTime > bedTime && endTime <= DateTime.ParseExact(MIDNIGHT, "yyyy-MM-dd HH:mm tt", CultureInfo.InvariantCulture))
                {
                    totalPay = CalcPayBeforeBedTime(startTime, bedTime) + CalcPayAfterBedTime(bedTime, endTime);
                }

                else if (endTime > DateTime.ParseExact(MIDNIGHT, "yyyy-MM-dd HH:mm tt", CultureInfo.InvariantCulture))
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
        public double CalcPayBeforeBedTime(DateTime startTime, DateTime endTime)
        {
            var nightlyPay = CalcWorkHours(startTime, endTime) * BEDTIMERATE;
            return nightlyPay;
        }

        public double CalcPayAfterBedTime(DateTime bedTime, DateTime endTime)
        {
            var nightlyPay = CalcWorkHours(bedTime, endTime) * AFTERBEDTIMERATE;
            return nightlyPay;
        }

        public double CalcPayAfterMidNight(DateTime endTime)
        {
            var nightlyPay = CalcWorkHours(DateTime.ParseExact(MIDNIGHT, "yyyy-MM-dd HH:mm tt", CultureInfo.InvariantCulture), endTime) * AFTERMIDNIGHTRATE;
            return nightlyPay;
        }

        public int CalcWorkHours(DateTime startTime, DateTime endTime)
        {
           
                TimeSpan ts = endTime - startTime;
                int totalHours = ts.Hours;
                int mins = ts.Minutes;

                if (mins > 0)
                    totalHours++;

                return totalHours;
            
        }
    }
}
