using Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBurguerValueRCL.Helpers
{
    public record PeriodRange(DateTime Start, DateTime End);

    public static class PeriodHelper
    {
        public static PeriodRange GetPeriod(EPeriod period)
        {
            var today = DateTime.UtcNow.Date;

            return period switch
            {
                EPeriod.LastWeek => new PeriodRange(today.AddDays(-7), today),
                EPeriod.LastFourWeeks => new PeriodRange(today.AddDays(-30), today),
                EPeriod.LastSemester => new PeriodRange(today.AddMonths(-6), today),
                EPeriod.LastYear => new PeriodRange(today.AddYears(-1), today),
                EPeriod.SinceTheBeginning => new PeriodRange(DateTime.MinValue, today),
                _ => throw new ArgumentOutOfRangeException(nameof(period), period, null)
            };
        }

        public static PeriodRange GetPreviousPeriod(EPeriod period)
        {
            var current = GetPeriod(period);
            var rangeLength = current.End - current.Start;
            return new PeriodRange(current.Start.AddDays(-rangeLength.Days), current.Start);
        }
    }
}
