using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Strategy
{
    public class Strategy : BaseEntity
    {
        public StrategyType Type { get; set; }
        public string Name { get; set; }
        public string Instrument { get; set; }
        public string Granularity { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public float InitialCash { get; set; }
        public float FinalCash { get; set; }
        public float Leverage { get; set; }
        public List<Outcome> Outcomes { get; set; }
        public Statistics Stats { get; set; }
        public List<Meta> Meta { get; set; }
        public bool Completed { get; set; } = false;
        public Strategy()
            : base()
        {
            Outcomes = new List<Outcome>();
        }
        public void CalcStats()
        {
            Stats = new Statistics();
            Stats.Trade = new CountingTrade(
                Outcomes.Count(),
                Outcomes.FindAll(x => x.Trade.Type == PositionType.Long).Count(),
                Outcomes.FindAll(x => x.Trade.Type == PositionType.Short).Count(),
                Outcomes.FindAll(x => x.Order.Type == OrderType.take_profit).Count(),
                Outcomes.FindAll(x => x.Order.Type == OrderType.stop_loss).Count()
                );
            Stats.Long = new CountingLongShort(
                Outcomes.FindAll(x => x.Trade.Type == PositionType.Long).Count(),
                Outcomes.FindAll(x => x.Trade.Type == PositionType.Long && x.Order.Type == OrderType.take_profit).Count(),
                Outcomes.FindAll(x => x.Trade.Type == PositionType.Long && x.Order.Type == OrderType.stop_loss).Count()
                );
            Stats.Short = new CountingLongShort(
                Outcomes.FindAll(x => x.Trade.Type == PositionType.Short).Count(),
                Outcomes.FindAll(x => x.Trade.Type == PositionType.Short && x.Order.Type == OrderType.take_profit).Count(),
                Outcomes.FindAll(x => x.Trade.Type == PositionType.Short && x.Order.Type == OrderType.stop_loss).Count()
                );
            Stats.MaxConsecutiveStopLoss = FindMaxConsecutiveStopLoss();
            
            Stats.WinRate = Math.Round(Stats.Trade.TakeProfit / (double)Stats.Trade.Total * 100, 2);
            Stats.LostRate = Math.Round(Stats.Trade.StopLoss / (double)Stats.Trade.Total * 100, 2);

            Stats.DrawDown = CalcDrawDown();

            Stats.PercentageReturn = Math.Round(((FinalCash - InitialCash) / InitialCash) * 100, 2);

            Stats.Monthly = CalcMonthReturn();
            Stats.MonthlyWinRate = Stats.Monthly.Average(x => x.WinRate);
            Stats.Yearly = CalcYearReturn();
            Stats.YearlyWinRate = Stats.Yearly.Average(x => x.WinRate);
        }

        private List<YearReturn> CalcYearReturn()
        {
            return Outcomes
                .GroupBy(
                    u => (
                        u.Trade.Datetime.Year
                    )
                )
                .Select(
                    grp =>
                    {
                        int year = grp.First().Trade.Datetime.Year;
                        Counting counting = new Counting(
                            grp.Count(),
                            grp.Where(x => x.Order.Type == OrderType.take_profit).Count(),
                            grp.Where(x => x.Order.Type == OrderType.stop_loss).Count()
                        );
                        float initialCash = grp.First().InitialCash;
                        float finalCash = grp.Last().InitialCash;
                        float finalCashAVG = grp.Average(x => x.FinalCash);
                        double winRate = Math.Round(
                            (counting.TakeProfit / (double)counting.Total) * 100, 2);
                        double percentageReturn = Math.Round((finalCash - initialCash) / finalCash * 100, 2);
                        return new YearReturn()
                        {
                            Year = year,
                            Counting = counting,
                            InitialCash = initialCash,
                            FinalCash = finalCash,
                            FinalCashAVG = finalCashAVG,
                            WinRate = winRate,
                            PercentageReturn = percentageReturn
                        };
                    }
                )
                .ToList();
        }

        private List<MonthReturn> CalcMonthReturn()
        {
            return Outcomes
                .GroupBy(
                    u => (
                        u.Trade.Datetime.Year,
                        u.Trade.Datetime.Month
                    )
                )
                .Select(
                    grp =>
                    {
                        int year = grp.First().Trade.Datetime.Year;
                        int month = grp.First().Trade.Datetime.Month;
                        Counting counting = new Counting(
                            grp.Count(),
                            grp.Where(x => x.Order.Type == OrderType.take_profit).Count(),
                            grp.Where(x => x.Order.Type == OrderType.stop_loss).Count()
                        );
                        float initialCash = grp.First().InitialCash;
                        float finalCash = grp.Last().FinalCash;
                        float finalCashAVG = grp.Average(x => x.FinalCash);
                        double winRate = Math.Round(
                            (counting.TakeProfit / (double)counting.Total) * 100, 2);
                        double percentageReturn = Math.Round((finalCash - initialCash) / finalCash * 100, 2);
                        return new MonthReturn()
                        {
                            Year = year,
                            Month = month,
                            Counting = counting,
                            InitialCash = initialCash,
                            FinalCash = finalCash,
                            FinalCashAVG = finalCashAVG,
                            WinRate = winRate,
                            PercentageReturn = percentageReturn
                        };
                    }
                )
                .ToList();
        }

        private DrawDown CalcDrawDown()
        {
            DrawDown drawDown = new DrawDown();
            drawDown.HighCash = FindHighCash();
            drawDown.MinCash = FindMinCashDrawDown(drawDown);
            drawDown.Value = drawDown.HighCash.Value - drawDown.MinCash.Value;
            drawDown.Percentage = ((drawDown.HighCash.Value - drawDown.MinCash.Value) / drawDown.HighCash.Value) * 100;
            return drawDown;
        }

        private KeyValuePair<int, float> FindMinCashDrawDown(DrawDown drawDown)
        {
            int value = Math.Max(0, drawDown.HighCash.Key);
            IEnumerable<Outcome> outcomes = Outcomes.Skip(value);
            Outcome outcome = outcomes.OrderBy(x => x.FinalCash).First();
            int index = Outcomes.IndexOf(outcome);
            return new(index, outcome.FinalCash);
        }

        private KeyValuePair<int, float> FindHighCash()
        {
            Outcome outcome = Outcomes.OrderByDescending(x => x.FinalCash).First();
            int index = Outcomes.IndexOf(outcome);
            return new(index, outcome.FinalCash);
        }

        private ConsecutiveStopLoss FindMaxConsecutiveStopLoss()
        {
            List<ConsecutiveStopLoss> total = new List<ConsecutiveStopLoss>();
            ConsecutiveStopLoss count = new ConsecutiveStopLoss();
            foreach (var item in Outcomes.Select((value, i) => new { i, value }))
            //foreach (Outcome outcome in Outcomes)
            {
                if (item.value.Order.Type == OrderType.take_profit)
                {
                    if (count.Count > 0)
                    {
                        total.Add(count);
                        count = new ConsecutiveStopLoss();
                    }
                }
                else if (item.value.Order.Type == OrderType.stop_loss)
                {
                    count.Count++;
                    count.Indexs.Add(item.i);
                }
            }

            return total.Count() > 0 ? total.OrderByDescending(x => x.Count).First() : new ConsecutiveStopLoss();
        }
    }
}
