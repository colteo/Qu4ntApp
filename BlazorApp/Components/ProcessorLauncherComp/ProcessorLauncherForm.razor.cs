using Domain.Entities.ProcessorLauncher;
using Domain.Enum;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BlazorApp.Components.ProcessorLauncherComp
{
    public partial class ProcessorLauncherForm
    {
        public ProcessorFormModel Form { get; set; }
        protected override async void OnInitialized()
        {
            Form = new ProcessorFormModel();
            base.OnInitialized();
        }
        private void Submit()
        {
            Debug.WriteLine("sei nel submit handler");
            Debug.WriteLine(JsonConvert.SerializeObject(Form));
        }
        private async void AddIndicator()
        {
            Form.Strategy.Indicators.Add(new Indicator()
            {
                Name = "Add Indicator"
            });
        }


        private string DictKey = string.Empty;
        private string DictValue = string.Empty;
        private void AddBrokerArgs()
        {
            Form.Broker.Args.Add(new Argument() { Key = DictKey, Value = DictValue }); 
            DictKey = string.Empty;
            DictValue = string.Empty;
            StateHasChanged();
        }
    }
    public class ProcessorFormModel
    {
        private ProcessorType typeOfProcessor;
        public ProcessorType TypeOfProcessor
        {
            get { return typeOfProcessor; }
            set
            {
                typeOfProcessor = value;
                CheckProcessor(value);
            }
        }
        public Strategy Strategy { get; set; }
        public DataFeed Feed { get; set; }
        public Broker Broker { get; set; }
        public ProcessorFormModel()
        {
            Strategy = new Strategy();
            Feed = new DataFeed();
            Broker = new Broker();
        }

        private void CheckProcessor(ProcessorType value)
        {
            if (value == ProcessorType.backtest)
            {
                Feed.Count = int.MinValue;
            }
            else if (value == ProcessorType.live)
            {
                Feed.StartDate = DateTime.MinValue;
                Feed.EndDate = DateTime.MinValue;
                Feed.StreamGranularity = GranularityType.None;
            }
        }
    }
}
