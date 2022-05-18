using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ProcessorLauncher
{
    public class Processor
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
        public Processor()
        {
            Strategy = new Strategy();
            Feed = new DataFeed();
            Broker = new Broker();
        }

        public void InitBackTestExampleValues()
        {
            typeOfProcessor = ProcessorType.backtest;

            Broker.Name = "Qu4ntBroker";
            Broker.Args.Add(new Argument() { Key = "currency", Value = "EUR" });
            Broker.Args.Add(new Argument() { Key = "balance", Value = "1000" });
            Broker.Args.Add(new Argument() { Key = "leverage", Value = "30" });

            Strategy.Name = "EngulfingStrategy";
            Strategy.StopLoss = 30;
            Strategy.TakeProfit = 60;

            var indicator = new Indicator();
            indicator.Name = "EngulfingBullishIndicator";
            indicator.Args.Add(new Argument() { Key = "candles_three", Value = "yes" });
            indicator.Args.Add(new Argument() { Key = "candles_two", Value = "yes" });
            indicator.Args.Add(new Argument() { Key = "candles_one", Value = "yes" });
            Strategy.Indicators.Add(indicator);

            indicator = new Indicator();
            indicator.Name = "EngulfingBearishIndicator";
            indicator.Args.Add(new Argument() { Key = "candles_three", Value = "yes" });
            indicator.Args.Add(new Argument() { Key = "candles_two", Value = "yes" });
            indicator.Args.Add(new Argument() { Key = "candles_one", Value = "yes" });
            Strategy.Indicators.Add(indicator);

            Feed.Instrument = InstrumentType.EUR_USD;
            Feed.Granularity = GranularityType.D;
            Feed.StreamGranularity = GranularityType.M1;
            Feed.StartDate = new DateTime(2021, 1, 1);
            Feed.EndDate = new DateTime(2021, 2, 20);
        }

        public void InitLiveExampleValues()
        {
            typeOfProcessor = ProcessorType.live;

            Broker.Name = "OandaBroker";

            Strategy.Name = "RandomStrategy";
            Strategy.StopLoss = 30;
            Strategy.TakeProfit = 60;

            var indicator = new Indicator();
            indicator.Name = "RandomIndicator";
            Strategy.Indicators.Add(indicator);

            Feed.Instrument = InstrumentType.EUR_USD;
            Feed.Granularity = GranularityType.S15;
            Feed.Count = 10;
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
