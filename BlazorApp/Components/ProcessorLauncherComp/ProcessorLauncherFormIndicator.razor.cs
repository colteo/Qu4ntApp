using BlazorApp.Components.GenericComp;
using Domain.Entities.ProcessorLauncher;
using Domain.Enum;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Diagnostics;

namespace BlazorApp.Components.ProcessorLauncherComp
{
    public partial class ProcessorLauncherFormIndicator
    {
        [Inject] public IDialogService DialogService { get; set; }
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
            if (Indicator.Args.Where(x => x.Key.ToLower() == DictKey.ToLower()).Count() > 0)
            {
                var options = new DialogOptions { CloseOnEscapeKey = true };
                DialogService.Show<AlertModal>("Chiave già presente", options);
                return;
            }
            else if (string.IsNullOrEmpty(DictKey) || string.IsNullOrEmpty(DictValue))
            {
                var options = new DialogOptions { CloseOnEscapeKey = true };
                DialogService.Show<AlertModal>("Chiave o valore vuoti", options);
                return;
            }

            Indicator.Args.Add(new Argument() { Key = DictKey, Value = DictValue });
            DictKey = string.Empty;
            DictValue = string.Empty;
            StateHasChanged();
        }
        private void RemoveIndicatorArgs(string key)
        {
            Indicator.Args.RemoveAll(x => x.Key == key);
            StateHasChanged();
        }
    }
}
