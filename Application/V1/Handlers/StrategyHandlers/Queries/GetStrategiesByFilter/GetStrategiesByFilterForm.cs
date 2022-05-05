using Domain.Entities.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.V1.Handlers.StrategyHandlers.Queries.GetStrategiesByFilter
{
    public class GetStrategiesByFilterForm
    {
        public string Type { get; set; } = "Backtest";
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Guid { get; set; }
        public IEnumerable<string> Instruments { get; set; } = new HashSet<string>();
        public IEnumerable<string> Granularities { get; set; } = new HashSet<string>();
        public int Limit { get; set; } = 10;
        public string OrderBy { get; set; } = nameof(Strategy.CreatedOn);
    }
}
