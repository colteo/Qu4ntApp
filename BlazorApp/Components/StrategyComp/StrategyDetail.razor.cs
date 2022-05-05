using Microsoft.AspNetCore.Components;
using Plotly.Blazor;
using Plotly.Blazor.Traces;
using Plotly.Blazor.LayoutLib;
using Domain.Entities.Strategy;
using MediatR;
using Application.V1.Handlers.StrategyHandlers.Queries.GetById;

namespace BlazorApp.Components.StrategyComp
{
    public partial class StrategyDetail
    {
        [Inject] public IMediator _mediator { get; set; }
        [Parameter] public string StrategyId { get; set; }
        public Strategy Strategy { get; set; }
        protected override async void OnInitialized()
        {
            Strategy = await _mediator.Send(new GetStrategyByIdRequest() { Id = StrategyId });
            base.OnInitialized();
        }
        private void RecalcStats()
        {
            Strategy.CalcStats();
            StateHasChanged();
        }
    }
}
