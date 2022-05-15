using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.V1.Handlers.ProcessorLauncherHandlers.APIRequest
{
    public class DataFeedDTO
    {
        public string Instrument { get; set; }
        public string Granularity { get; set; }
        public int Count { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string StreamGranularity { get; set; }
    }
}
