using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Strategy
{
    public class Candle
    {
        public DateTime Datetime { get; set; }
        public float Ask { get; set; }
        public float Bid { get; set; }
        public Candle(DateTime datetime, float ask, float bid)
        {
            Datetime = datetime;
            Ask = ask;
            Bid = bid;
        }
    }
}
