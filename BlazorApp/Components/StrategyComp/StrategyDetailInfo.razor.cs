using Microsoft.AspNetCore.Components;
using Plotly.Blazor;
using Plotly.Blazor.Traces;
using Plotly.Blazor.LayoutLib;
using Domain.Entities.Strategy;
using MediatR;
using Application.V1.Handlers.StrategyHandlers.Queries.GetById;

namespace BlazorApp.Components.StrategyComp
{
    public partial class StrategyDetailInfo
    {
        [Parameter] public Strategy Strategy { get; set; }
        protected override async void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}
