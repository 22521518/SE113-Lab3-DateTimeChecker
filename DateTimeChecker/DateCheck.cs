using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeChecker
{
    internal class DateCheck
    {

        public int DaysInMonth(sbyte month, short year)
        {

            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                return 31;
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                return 30;
            }
            else if (month == 2)
            {
                if (year % 400 == 0)
                {
                    return 29;
                }
                else if (year % 100 == 0)
                {
                    return 28;
                }
                else if (year % 4 == 0)
                {
                    return 29;
                }
                else
                {
                    return 28;
                }
            }
            else
            {
                return 0; // Invalid month
            }
        }

        public bool IsValidDate(short year, sbyte month, sbyte day)
        {
            if (year < 1 || month < 1 || month > 12 || day < 1)
            {
                return false;
            }
            return day <= DaysInMonth(month, year);
        }

        public bool IsDayInRange(sbyte day)
        {
            return day >= 1 && day <= 31;
        }

        public bool IsMonthInRange(sbyte month)
        {
            return month >= 1 && month <= 12;
        }

        public bool IsYearInRange(short year)
        {
            return year >= 1000 && year <= 3000;
        }

    }
}
