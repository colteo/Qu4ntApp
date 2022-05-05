using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Strategy
{
    public class Trade
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public TradeType Type { get; set; }
        public DateTime Datetime { get; set; }
        public Candle Candle { get; set; }
        public Trade(int id, float price, TradeType type, DateTime dateTime, Candle candle)
        {
            Id = id;
            Price = price;
            Type = type;
            Datetime = dateTime;
            Candle = candle;
        }
    }
}
