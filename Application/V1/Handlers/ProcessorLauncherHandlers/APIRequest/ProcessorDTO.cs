using Domain.Entities.ProcessorLauncher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.V1.Handlers.ProcessorLauncherHandlers.APIRequest
{
    public class ProcessorDTO
    {
        public string TypeOfProcessor { get; set; }
        public Strategy Strategy { get; set; }
        public DataFeedDTO Feed { get; set; }
        public Broker Broker { get; set; }
        public ProcessorDTO()
        {
            //Strategy = new Strategy();
            Feed = new DataFeedDTO();
            //Broker = new Broker();
        }
    }
}
