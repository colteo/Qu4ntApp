using Application.V1.Handlers.ProcessorLauncherHandlers.APIRequest;
using BlazorApp.Components.GenericComp;
using Domain.Entities.ProcessorLauncher;
using Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BlazorApp.Components.ProcessorLauncherComp
{
    public partial class ProcessorLauncherForm
    {
        [Inject] public IDialogService DialogService { get; set; }
        [Inject] public IMediator _mediator { get; set; }
        public Processor Form { get; set; }
        protected override async void OnInitialized()
        {
            Form = new Processor();
            base.OnInitialized();
        }
        private void InitBackTestExampleValues()
        {
            Form = new Processor();
            Form.InitBackTestExampleValues();
        }
        private void InitLiveExampleValues()
        {
            Form = new Processor();
            Form.InitLiveExampleValues();
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
            if (Form.Broker.Args.Where(x => x.Key.ToLower() == DictKey.ToLower()).Count() > 0)
            {
                var options = new DialogOptions { CloseOnEscapeKey = true };
                DialogService.Show<AlertModal>("Chiave già presente", options);
                return;
            }
            else if(string.IsNullOrEmpty(DictKey) || string.IsNullOrEmpty(DictValue))
            {
                var options = new DialogOptions { CloseOnEscapeKey = true };
                DialogService.Show<AlertModal>("Chiave o valore vuoti", options);
                return;
            }

            Form.Broker.Args.Add(new Argument() { Key = DictKey, Value = DictValue }); 
            DictKey = string.Empty;
            DictValue = string.Empty;
            StateHasChanged();
        }
        private void RemoveBrokerArgs(string key)
        {
            Form.Broker.Args.RemoveAll(x => x.Key == key);
            StateHasChanged();
        }
    }
}
