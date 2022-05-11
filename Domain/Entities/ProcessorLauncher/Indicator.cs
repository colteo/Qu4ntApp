using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ProcessorLauncher
{
    public class Indicator
    {
        public string Name { get; set; }
        public List<Argument> Args { get; set; }
        public Indicator()
        {
            Args = new List<Argument>();
        }
    }
}
