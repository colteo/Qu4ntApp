using Domain.Entities.ProcessorLauncher;
using Domain.Enum;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace BlazorApp.Components.ProcessorLauncherComp
{
    public partial class ProcessorLauncherFormIndicator
    {
        [Parameter] public Indicator Indicator { get; set; }
        public ArgsType TypeOfArgs { get; set; }
        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
        private string DictKey = string.Empty;
        private string DictValue = string.Empty;
        private void AddIndicatorArgs()
        {
            Indicator.Args.Add(new Argument() { Key = DictKey, Value = DictValue });
            DictKey = string.Empty;
            DictValue = string.Empty;
            StateHasChanged();
        }
    }
}
