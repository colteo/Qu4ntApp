using Application.V1.Handlers.StrategyHandlers.Queries.GetAll;
using Application.V1.Handlers.StrategyHandlers.Queries.GetDistinctValues;
using Application.V1.Handlers.StrategyHandlers.Queries.GetStrategiesByFilter;
using Domain.Entities.Strategy;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components.StrategyComp
{
    public partial class StrategyListForm
    {
        [Inject] public IMediator _mediator { get; set; }
        [Parameter] public EventCallback<GetStrategiesByFilterForm> OnSubmit { get; set; }
        [Parameter] public GetStrategiesByFilterForm Form { get; set; }
        private string value { get; set; } = "Nothing selected";
        public IEnumerable<string> Instruments { get; set; }
        public IEnumerable<string> Granularities { get; set; }
        protected override void OnInitialized()
        {
            LoadValues();
            base.OnInitialized();
        }
        private void OnFormSubmit()
        {
            OnSubmit.InvokeAsync(Form);
        }
        private void LoadValues()
        {
            LoadInstruments();
            LoadGranularities();
        }
        private async void LoadInstruments()
        {
            Instruments = await _mediator.Send(new GetDistinctValuesRequest { Field = nameof(Strategy.Instrument) });
        }
        private async void LoadGranularities()
        {
            Granularities = await _mediator.Send(new GetDistinctValuesRequest { Field = nameof(Strategy.Granularity) });
        }
    }
}
