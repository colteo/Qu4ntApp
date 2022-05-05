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
    public partial class StrategyDetailOutcomesPagination
    {
        [Parameter] public MetaData Pagination { get; set; }
        [Parameter] public EventCallback<string> Changed { get; set; }
        protected override async void OnInitialized()
        {
            base.OnInitialized();
        }
        private void NextPage()
        {
            Pagination.CurrentPage++;
            OnChanged();
        }
        private void PrevPage()
        {
            Pagination.CurrentPage--;
            OnChanged();
        }
        private void GoToPage(int page)
        {
            Pagination.CurrentPage = page;
            OnChanged();
        }
        private void PageSizeChange(ChangeEventArgs e)
        {
            Pagination.PageSize = Int32.Parse(e.Value.ToString());
            Pagination.CurrentPage = 1;
            OnChanged();
        }
        private void OnChanged()
        {
            Changed.InvokeAsync("Changed");
            StateHasChanged();
        }
    }
}
