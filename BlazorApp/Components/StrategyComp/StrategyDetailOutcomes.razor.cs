using Microsoft.AspNetCore.Components;
using Plotly.Blazor;
using Plotly.Blazor.Traces;
using Plotly.Blazor.LayoutLib;
using Domain.Entities.Strategy;
using MediatR;
using Application.V1.Handlers.StrategyHandlers.Queries.GetById;
using System.Diagnostics;
using LinqKit;
using Domain.Enum;

namespace BlazorApp.Components.StrategyComp
{
    public partial class StrategyDetailOutcomes
    {
        [Parameter] public Strategy Strategy { get; set; }
        public MetaData Pagination { get; set; }
        public OutcomeForm Form { get; set; }
        protected override async void OnInitialized()
        {
            Form = new OutcomeForm();
            Pagination = new MetaData(Strategy.Outcomes.Count(), 10);
            base.OnInitialized();
        }
        private IEnumerable<Outcome> GetOutcomeFiltered()
        {
            var predicate = PredicateBuilder.True<Outcome>();

            if (Form.Id is not null)
                predicate = predicate.And(d => d.Id == Form.Id);

            if (Form.TypesOfTrade.Count() > 0)
                predicate = predicate.And(d => Form.TypesOfTrade.Contains(d.Trade.Type));

            if (Form.TypesOfOrder.Count() > 0)
                predicate = predicate.And(d => Form.TypesOfOrder.Contains(d.Order.Type));

            return Strategy.Outcomes
                .Where(predicate.Compile());
        }
        private IEnumerable<Outcome> GetOutcome()
        {
            return GetOutcomeFiltered()
                .Skip((Pagination.CurrentPage - 1) * Pagination.PageSize)
                .Take(Pagination.PageSize);
        }
        private async void ChangedHandler()
        {
            StateHasChanged();
        }
        private async void SubmitHandler(OutcomeForm form)
        {
            StateHasChanged();
            Debug.WriteLine("sei nel submit handler");
        }
    }
    public class MetaData
    {
        public int CurrentPage { get; set; }

        private int pageSize;
        public int PageSize
        {
            get { return pageSize; }
            set
            {
                pageSize = value;
                TotalPages = TotalCount / pageSize;
            }
        }

        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public MetaData(int totalCount, int pageSize)
        {
            CurrentPage = 1;
            TotalCount = totalCount;
            PageSize = pageSize;
        }
    }
    public class OutcomeForm
    {
        public int? Id { get; set; }
        public IEnumerable<TradeType> TypesOfTrade { get; set; } = Enumerable.Empty<TradeType>();
        public IEnumerable<OrderType> TypesOfOrder { get; set; } = Enumerable.Empty<OrderType>();
    }
}
