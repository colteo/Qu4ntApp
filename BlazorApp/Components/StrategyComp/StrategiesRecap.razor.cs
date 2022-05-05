using Application.V1.Handlers.StrategyHandlers.Queries.CountStrategies;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components.StrategyComp
{
    public partial class StrategiesRecap
    {
        [Inject] public IMediator _mediator { get; set; }
        public CountStrategiesDTO Count { get; set; }
        protected override void OnInitialized()
        {
            GetCounts();
            base.OnInitialized();
        }
        private async void GetCounts()
        {
            Count = await _mediator.Send(new CountStrategiesRequest());
        }
    }
}
