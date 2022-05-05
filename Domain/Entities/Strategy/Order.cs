using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Strategy
{
    public class Order
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public OrderType Type { get; set; }
        public float Price { get; set; }
        public Candle Candle { get; set; }
        public Order(int id, int parentId, OrderType type, float price, Candle candle)
        {
            Id = id;
            ParentId = parentId;
            Type = type;
            Price = price;
            Candle = candle;
        }
    }
}
