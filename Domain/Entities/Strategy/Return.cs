using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Strategy
{
    public class MonthReturn : YearReturn
    {
        public int Month { get; set; }
    }

    public class YearReturn : Return
    {
        public int Year { get; set; }
    }

    public class Return
    {
        public Counting Counting { get; set; }
        public float InitialCash { get; set; }
        public float FinalCash { get; set; }
        public float FinalCashAVG { get; set; }
        public double WinRate { get; set; }
        public double PercentageReturn { get; set; }
    }
}
