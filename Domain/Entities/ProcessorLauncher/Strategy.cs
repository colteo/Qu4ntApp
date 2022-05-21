using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ProcessorLauncher
{
    public class Strategy
    {
        public string Name { get; set; }
        public List<Indicator> Indicators { get; set; }
        public decimal StopLoss { get; set; }
        public decimal TakeProfit { get; set; }
        public Strategy()
        {
            Indicators = new List<Indicator>();
        }
    }
}
