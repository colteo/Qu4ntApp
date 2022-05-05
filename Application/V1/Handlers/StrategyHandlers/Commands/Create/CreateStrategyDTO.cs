using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.V1.Handlers.StrategyHandlers.Commands.Create
{
    public class CreateStrategyDTO
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public Dictionary<string, object> Meta { get; set; }
        public string Instrument { get; set; }
        public string Granularity { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public float InitialCash { get; set; }
        public float Leverage { get; set; }
    }
}
