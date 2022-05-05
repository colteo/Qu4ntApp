using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Strategy
{
    public class Outcome
    {
        public long Id { get; set; }
        public Trade Trade { get; set; }
        public Order Order { get; set; }
        public float InitialCash { get; set; }
        public float FinalCash { get; set; }
    }
}
