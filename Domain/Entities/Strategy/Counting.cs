using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Strategy
{
    public class Counting
    {
        public int Total { get; set; }
        public int TakeProfit { get; set; }
        public int StopLoss { get; set; }
        public Counting(int total, int takeProfit, int stopLoss)
        {
            Total = total;
            TakeProfit = takeProfit;
            StopLoss = stopLoss;
        }
    }
    public class CountingLongShort : Counting
    {
        public CountingLongShort(int total, int takeProfit, int stopLoss)
            : base(total, takeProfit, stopLoss)
        {

        }
    }
    public class CountingTrade : Counting
    {
        public int Long { get; set; }
        public int Short { get; set; }
        public CountingTrade(int total,
            int _long,
            int _short,
            int takeProfit,
            int stopLoss
            )
            : base(total, takeProfit, stopLoss)
        {
            Long = _long;
            Short = _short;
        }
    }
}
