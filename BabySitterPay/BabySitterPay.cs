using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySitter
{
    /*Assumptions
     -User Start between 5PM to 4AM therefore 6 ~ 6PM , 3 ~ 3AM
     */

    public class BabySitterPay
    {
        private const Double BEDTIMERATE = 12;
        private const Double AFTERBEDTIMERATE = 8;
        private const Double AFTERMIDNIGHTRATE = 16;
        private const string MIDNIGHT = "12:00";
        private const string OFFICIALSTARTTIME = "5:00";
        private const string OFFICIALENDTIME = "4:00";

        public Double CalcBabySitterPay(string startTime, string endTime, string bedTime)
        {
            Double totalPay = 0.00;
            try
            {
                if (DateTime.ParseExact(startTime, "hh:mm", CultureInfo.InvariantCulture) < DateTime.ParseExact(OFFICIALSTARTTIME, "hh:mm", CultureInfo.InvariantCulture) ||
                    DateTime.ParseExact(endTime, "hh:mm", CultureInfo.InvariantCulture) > DateTime.ParseExact(OFFICIALENDTIME, "hh:mm", CultureInfo.InvariantCulture))
                {
                    Console.WriteLine("Error: Start Time / End Time should be between 5PM and 4AM");
                    return 0;
                }
                if (DateTime.ParseExact(endTime, "hh:mm", CultureInfo.InvariantCulture) <= DateTime.ParseExact(bedTime, "hh:mm", CultureInfo.InvariantCulture))
                {
                    totalPay = CalcPayBeforeBedTime(startTime, endTime);
                }

                else if (DateTime.ParseExact(endTime, "hh:mm", CultureInfo.InvariantCulture) > DateTime.ParseExact(bedTime, "hh:mm", CultureInfo.InvariantCulture) && DateTime.ParseExact(endTime, "hh:mm", CultureInfo.InvariantCulture) <= DateTime.ParseExact(MIDNIGHT, "hh:mm", CultureInfo.InvariantCulture))
                {
                    totalPay = CalcPayBeforeBedTime(startTime, bedTime) + CalcPayAfterBedTime(bedTime, endTime);
                }

                else if (DateTime.ParseExact(endTime, "hh:mm", CultureInfo.InvariantCulture) > DateTime.ParseExact(MIDNIGHT, "hh:mm", CultureInfo.InvariantCulture))
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
        public Double CalcPayBeforeBedTime(string startTime, string endTime)
        {
            var nightlyPay = CalcWorkHours(startTime, endTime) * BEDTIMERATE;
            return nightlyPay;
        }

        public Double CalcPayAfterBedTime(string bedTime, string endTime)
        {
            var nightlyPay = CalcWorkHours(bedTime, endTime) * AFTERBEDTIMERATE;
            return nightlyPay;
        }

        public Double CalcPayAfterMidNight(string endTime)
        {
            var nightlyPay = CalcWorkHours(MIDNIGHT, endTime) * AFTERMIDNIGHTRATE;
            return nightlyPay;
        }

        public int CalcWorkHours(string startTime, string endTime)
        {
            int totalHours;
            DateTime startHour;
            DateTime endHour;

            if (DateTime.TryParseExact(startTime, "hh:mm", null, DateTimeStyles.None, out startHour) && DateTime.TryParseExact(endTime, "hh:mm", null, DateTimeStyles.None, out endHour))
            {
                TimeSpan ts = endHour - startHour;
                totalHours = ts.Hours;
                int mins = ts.Minutes;

                if (mins > 0)
                    totalHours++;

                return totalHours;
            }

            return 0;

        }
    }
}
