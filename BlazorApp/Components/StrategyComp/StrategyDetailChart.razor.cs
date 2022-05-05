using Microsoft.AspNetCore.Components;
using Plotly.Blazor;
using Plotly.Blazor.Traces;
using Plotly.Blazor.LayoutLib;
using Domain.Entities.Strategy;
using MediatR;
using Application.V1.Handlers.StrategyHandlers.Queries.GetById;

namespace BlazorApp.Components.StrategyComp
{
    public partial class StrategyDetailChart
    {
        [Parameter] public Strategy Strategy { get; set; }
        protected override async void OnInitialized()
        {
            TradeChartInit();
            LongChartInit();
            ShortChartInit();
            base.OnInitialized();
        }

        #region TradeChart
        Config config = new Config
        {
            Responsive = true
        };
        PlotlyChart TradeChart;
        Layout TradeLayout;
        List<ITrace> TradeData;
        private void TradeChartInit()
        {
            TradeLayout = new Layout
            {
                Title = new Title
                {
                    Text = "Trade"
                },
                BarMode = BarModeEnum.Stack,
                Height = 500
            };

            TradeData = new List<ITrace>
            {
                new Bar
                {
                    X = new List<object> {
                        nameof(Strategy.Stats.Trade.Total),
                        nameof(Strategy.Stats.Trade.Long),
                        nameof(Strategy.Stats.Trade.Short),
                        nameof(Strategy.Stats.Trade.TakeProfit),
                        nameof(Strategy.Stats.Trade.StopLoss)
                    },
                    Y = new List<object> {
                        Strategy.Stats.Trade.Total,
                        Strategy.Stats.Trade.Long,
                        Strategy.Stats.Trade.Short,
                        Strategy.Stats.Trade.TakeProfit,
                        Strategy.Stats.Trade.StopLoss
                    },
                    Name = "SF Zoo"
                }
            };
        }
        #endregion

        #region LongChart
        PlotlyChart LongChart;
        Layout LongLayout;
        List<ITrace> LongData;
        private void LongChartInit()
        {
            LongLayout = new Layout
            {
                Title = new Title
                {
                    Text = "Long"
                },
                BarMode = BarModeEnum.Stack,
                Height = 500
            };

            LongData = new List<ITrace>
            {
                new Bar
                {
                    X = new List<object> {
                        nameof(Strategy.Stats.Long.Total),
                        nameof(Strategy.Stats.Long.TakeProfit),
                        nameof(Strategy.Stats.Long.StopLoss)
                    },
                    Y = new List<object> {
                        Strategy.Stats.Long.Total,
                        Strategy.Stats.Long.TakeProfit,
                        Strategy.Stats.Long.StopLoss
                    },
                    Name = "SF Zoo"
                }
            };
        }
        #endregion

        #region ShortChart
        PlotlyChart ShortChart;
        Layout ShortLayout;
        List<ITrace> ShortData;
        private void ShortChartInit()
        {
            ShortLayout = new Layout
            {
                Title = new Title
                {
                    Text = "Short"
                },
                BarMode = BarModeEnum.Stack,
                Height = 500
            };

            ShortData = new List<ITrace>
            {
                new Bar
                {
                    X = new List<object> {
                        nameof(Strategy.Stats.Short.Total),
                        nameof(Strategy.Stats.Short.TakeProfit),
                        nameof(Strategy.Stats.Short.StopLoss)
                    },
                    Y = new List<object> {
                        Strategy.Stats.Short.Total,
                        Strategy.Stats.Short.TakeProfit,
                        Strategy.Stats.Short.StopLoss
                    },
                    Name = "SF Zoo"
                }
            };
        }
        #endregion
    }
}
