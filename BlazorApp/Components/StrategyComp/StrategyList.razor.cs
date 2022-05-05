using Application.V1.Handlers.StrategyHandlers.Commands.Remove;
using Application.V1.Handlers.StrategyHandlers.Queries.GetAll;
using Application.V1.Handlers.StrategyHandlers.Queries.GetStrategiesByFilter;
using Domain.Entities.Strategy;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Diagnostics;

namespace BlazorApp.Components.StrategyComp
{
    public partial class StrategyList
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] public IMediator _mediator { get; set; }
        [Inject] public IJSRuntime jsRuntime { get; set; }
        public GetStrategiesByFilterForm Form { get; set; } = new GetStrategiesByFilterForm();
        public IEnumerable<Strategy> Strategies { get; set; }
        private HashSet<Strategy> selectedItems = new HashSet<Strategy>();
        protected override async void OnInitialized()
        {
            base.OnInitialized();
        }
        private async void ShowDetail(Strategy strategy)
        {
            string url = "strategy-detail/" + strategy.Id;
            //await jsRuntime.InvokeAsync<object>("open", url, "_blank");
            NavigationManager.NavigateTo(url);
        }
        private async void SubmitHandler()
        {
            Strategies = await _mediator.Send(new GetStrategiesByFilterRequest { Form = Form });
        }
        private async void Delete()
        {
            await _mediator.Send(new RemoveStrategiesRequest { Strategies = selectedItems });
            Strategies = await _mediator.Send(new GetStrategiesByFilterRequest { Form = Form });
        }
    }
}
