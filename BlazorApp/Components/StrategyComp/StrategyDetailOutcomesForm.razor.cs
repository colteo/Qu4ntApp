using Microsoft.AspNetCore.Components;
using Plotly.Blazor;
using Plotly.Blazor.Traces;
using Plotly.Blazor.LayoutLib;
using Domain.Entities.Strategy;
using MediatR;
using Application.V1.Handlers.StrategyHandlers.Queries.GetById;
using System.Diagnostics;

namespace BlazorApp.Components.StrategyComp
{
    public partial class StrategyDetailOutcomesForm
    {
        [Parameter] public EventCallback<OutcomeForm> OnSubmit { get; set; }
        [Parameter] public OutcomeForm Form { get; set; }
        private void OnFormSubmit()
        {
            OnSubmit.InvokeAsync(Form);
        }

    }
}
