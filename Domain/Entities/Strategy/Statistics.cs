using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Strategy
{
    public class Statistics
    {
        public CountingTrade Trade { get; set; }
        public CountingLongShort Long { get; set; }
        public CountingLongShort Short { get; set; }
        public ConsecutiveStopLoss MaxConsecutiveStopLoss { get; set; }
        public double WinRate { get; set; }
        public double LostRate { get; set; }
        public DrawDown DrawDown { get; set; }
        public double PercentageReturn { get; set; }
        public List<MonthReturn> Monthly { get; set; }
        public double MonthlyWinRate { get; set; }
        public List<YearReturn> Yearly { get; set; }
        public double YearlyWinRate { get; set; }
    }
    public class DrawDown
    {
        public KeyValuePair<int, float> HighCash { get; set; }
        
        //Cash più basso raggiunto dopo aver toccato il picco (HighCash)
        public KeyValuePair<int, float> MinCash { get; set; }
        public float Value { get; set; }
        public float Percentage { get; set; }
    }
    public class ConsecutiveStopLoss
    {
        public int Count { get; set; }
        public List<int> Indexs { get; set; }
        public ConsecutiveStopLoss()
        {
            Count = 0;
            Indexs = new List<int>();
        }
    }
}
