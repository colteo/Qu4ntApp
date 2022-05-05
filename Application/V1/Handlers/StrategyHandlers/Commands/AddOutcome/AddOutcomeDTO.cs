using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.V1.Handlers.StrategyHandlers.Commands.AddOutcome
{
    public class AddOutcomeDTO
    {
        public string StrategyId { get; set; }
        public int TradeId { get; set; }
        public float TradePrice { get; set; }
        public string TradeType { get; set; }
        public DateTime TradeDatetime { get; set; }
        public DateTime TradeStreamDatetime { get; set; }
        public float TradeStreamAsk { get; set; }
        public float TradeStreamBid { get; set; }
        public int OrderId { get; set; }
        public int OrderParentId { get; set; }
        public string OrderType { get; set; }
        public float OrderPrice { get; set; }
        public DateTime OrderStreamDatetime { get; set; }
        public float OrderStreamAsk { get; set; }
        public float OrderStreamBid { get; set; }
        public float InitialCash { get; set; }
        public float FinalCash { get; set; }
    }
}
