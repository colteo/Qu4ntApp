using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ProcessorLauncher
{
    public class DataFeed
    {
        public InstrumentType Instrument { get; set; }
        public GranularityType Granularity { get; set; }
        public int Count { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public GranularityType StreamGranularity { get; set; }
    }
}
