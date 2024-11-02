using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DateTimeChecker
{
    [TestFixture]
    internal class DateCheckUnitTest
    {
        struct Date
        {
            public short year;
            public sbyte month;
            public sbyte day;
        }

        private readonly DateCheck dateCheck = new DateCheck();
        private readonly int[] DayInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private readonly short[] Year = { 2400, 2100, 2004, 2003 };

        private readonly sbyte[] InvalidDay = { -1, 0, 32, 33 };
        private readonly sbyte[] InvalidMonth = { -1, 0, 13, 14 };
        private readonly short[] InvalidYear = { 998, 999, 3001, 3002 };


        private readonly Date[] ValidDates = {
            new Date { year = 2021, month = 1, day = 31 },
            new Date { year = 2021, month = 4, day = 30 },
            new Date { year = 2000, month = 2, day = 29 },
            new Date { year = 2100, month = 2, day = 28 },
            new Date { year = 2004, month = 2, day = 29 },
            new Date { year = 2003, month = 2, day = 28 },
        };  

        private readonly Date[] InvalidDates = {
            new Date { year = 2021, month = 4, day = 31 },
            new Date { year = 2000, month = 2, day = 30 },
            new Date { year = 2100, month = 2, day = 29 },
            new Date { year = 2004, month = 2, day = 30 },
            new Date { year = 2003, month = 2, day = 29 },
        };

        private bool isLeapYear(short year)
        {
            return year % 400 == 0 || (year % 100 != 0 && year % 4 == 0);
        }

        [Test]
        public void IsValidDate_InvalidDay_ReturnsFalse()
        {
            for (int i = 0; i < InvalidDay.Length; i++)
            {
                Assert.That(dateCheck.IsDayInRange(InvalidDay[i]), Is.False);
            }
        }

        [Test]
        public void IsValidDate_InvalidMonth_ReturnsFalse()
        {
            for (int i = 0; i < InvalidMonth.Length; i++)
            {
                Assert.That(dateCheck.IsMonthInRange(InvalidMonth[i]), Is.False);
            }
        }


        [Test]
        public void IsValidDate_InvalidYear_ReturnsFalse()
        {
            for (int i = 0; i < InvalidYear.Length; i++)
            {
                Assert.That(dateCheck.IsYearInRange(InvalidYear[i]), Is.False);
            }
        }

        [Test]
        public void IsValidDate_DayInMonth()
        {
            DateCheck dateCheck = new DateCheck();
            for (int i = -1; i < 13; i++)
            {
                for (int y = 0; y < Year.Length; y++)
                {
                    int d = 0;
                    if (i >= 0 && i <= 11)
                    {
                        d = DayInMonth[i];
                    }
                    if (isLeapYear(Year[y]) && i == 1)
                    {
                        d++;
                    }

                    Assert.That(dateCheck.DaysInMonth((sbyte)(i + 1), Year[y]), Is.EqualTo(d));
                }
            }

        }

        [Test]
        public void IsValidDate_ValidDates_ReturnsTrue()
        {
            for (int i = 0; i < ValidDates.Length; i++)
            {
                Assert.That(dateCheck.IsValidDate(ValidDates[i].year, ValidDates[i].month, ValidDates[i].day), Is.True);
            }
        }

        [Test]
        public void IsValidDate_InvalidDates_ReturnsFalse()
        {
            for (int i = 0; i < InvalidDates.Length; i++)
            {
                Assert.That(dateCheck.IsValidDate(InvalidDates[i].year, InvalidDates[i].month, InvalidDates[i].day), Is.False);
            }
        }
    }
}
