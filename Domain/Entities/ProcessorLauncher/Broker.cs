using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ProcessorLauncher
{
    public class Broker
    {
        public string Name { get; set; }
        public List<Argument> Args { get; set; }
        public Dictionary<string, string> Arguments { get; set; }
        public Broker()
        {
            Args = new List<Argument>();

            Arguments = new Dictionary<string, string>();
            Arguments.Add("ciao", "qwerty");
            Arguments.Add("asdf", "poiuy");
        }
    }
}
