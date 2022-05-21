using Domain;
using Domain.Entities.ProcessorLauncher;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.V1.Handlers.ProcessorLauncherHandlers.APIRequest
{
    public class ProcessorLauncherRequest : IRequest<Empty>
    {
        public Processor Item { get; set; }
    }
    public class ProcessorLauncherHandler : IRequestHandler<ProcessorLauncherRequest, Empty>
    {
        private readonly ILogger<ProcessorLauncherHandler> _logger;
        public ProcessorLauncherHandler(ILogger<ProcessorLauncherHandler> logger)
        {
            _logger = logger;
        }
        public async Task<Empty> Handle(ProcessorLauncherRequest request, CancellationToken cancellationToken)
        {

            Debug.WriteLine("sei nel ProcessorLauncherHandler handler");
            Debug.WriteLine(JsonConvert.SerializeObject(request.Item));

            ProcessorDTO dto = new ProcessorDTO();
            dto.TypeOfProcessor = request.Item.TypeOfProcessor.ToString();
            
            dto.Strategy = request.Item.Strategy;

            dto.Feed.Instrument = request.Item.Feed.Instrument.ToString();
            dto.Feed.Granularity = request.Item.Feed.Granularity.ToString();
            dto.Feed.Count = request.Item.Feed.Count;
            dto.Feed.StartDate = request.Item.Feed.StartDate;
            dto.Feed.EndDate = request.Item.Feed.EndDate;
            dto.Feed.StreamGranularity = request.Item.Feed.StreamGranularity.ToString();
            
            dto.Broker = request.Item.Broker;

            Debug.WriteLine(JsonConvert.SerializeObject(dto));

            using (var client = new HttpClient())
            {
                // This would be the like http://www.uber.com
                client.BaseAddress = new Uri("http://qu4nt-processor-api:8082/");
                // client.BaseAddress = new Uri("http://127.0.0.1:8082");

                // serialize your json using newtonsoft json serializer then add it to the StringContent
                var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

                // method address would be like api/callUber:SomePort for example
                var result = await client.PostAsync("run_qu4nt", content);
                string resultContent = await result.Content.ReadAsStringAsync();
            }

            return new Empty();
        }
    }
}
