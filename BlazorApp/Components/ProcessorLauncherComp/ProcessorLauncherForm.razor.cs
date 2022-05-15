using Application.V1.Handlers.ProcessorLauncherHandlers.APIRequest;
using Domain.Entities.ProcessorLauncher;
using Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BlazorApp.Components.ProcessorLauncherComp
{
    public partial class ProcessorLauncherForm
    {
        [Inject] public IMediator _mediator { get; set; }
        public Processor Form { get; set; }
        protected override async void OnInitialized()
        {
            Form = new Processor();
            Form.InitExampleValues();
            base.OnInitialized();
        }
        private async void Submit()
        {
            await _mediator.Send(new ProcessorLauncherRequest() { Item = Form });
        }
        private async void AddIndicator()
        {
            Form.Strategy.Indicators.Add(new Indicator()
            {
                Name = "Add Indicator"
            });
        }
        private string DictKey = string.Empty;
        private string DictValue = string.Empty;
        private void AddBrokerArgs()
        {
            Form.Broker.Args.Add(new Argument() { Key = DictKey, Value = DictValue }); 
            DictKey = string.Empty;
            DictValue = string.Empty;
            StateHasChanged();
        }
    }
}
