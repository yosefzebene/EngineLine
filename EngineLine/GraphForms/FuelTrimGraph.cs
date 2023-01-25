using OxyPlot.Axes;
using OxyPlot;
using OxyPlot.Legends;
using OxyPlot.Series;
using EngineLineLibrary;

namespace EngineLine.GraphForms
{
    public partial class FuelTrimGraph : Form
    {
        private readonly EngineLine mainForm;

        private bool isGraphing = false;
        const int MaxSecondsToShow = 20;

        public FuelTrimGraph(EngineLine parent)
        {
            InitializeComponent();

            mainForm = parent;
        }

        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            if (isGraphing)
            {
                isGraphing = false;
                buttonStartStop.Text = "Start";
            }
            else
            {
                isGraphing = true;
                buttonStartStop.Text = "Stop";

                StartGraphing();
            }
        }

        private void FuelTrimGraph_FormClosing(object sender, FormClosingEventArgs e)
        {
            isGraphing = false;
        }

        private async void StartGraphing()
        {
            bool shortTermB1Available = true, longTermB1Available = true, shortTermB2Available = true, longTermB2Available = true;

            var fuelTrimModel = new PlotModel()
            {
                TextColor = OxyColors.White
            };

            SetupPlotModel(fuelTrimModel);

            // Add rpm
            var rpmSeries = new LineSeries
            {
                Title = "RPM",
                StrokeThickness = 2,
                Color = OxyColor.Parse("#cfcfcf"),
                LineStyle = LineStyle.Solid,
                YAxisKey = "rpmAxis"
            };
            fuelTrimModel.Series.Add(rpmSeries);

            // Add B1 Trims
            var shortTermFuelTrimB1Series = new LineSeries
            {
                Title = "Short term fuel trim B1",
                StrokeThickness = 5,
                Color = OxyColor.Parse("#b100fc"),
                LineStyle = LineStyle.Solid,
                YAxisKey = "fuelTrimAxis"
            };
            fuelTrimModel.Series.Add(shortTermFuelTrimB1Series);

            var longTermFuelTrimB1Series = new LineSeries
            {
                Title = "Long term fuel trim B1",
                StrokeThickness = 5,
                Color = OxyColor.Parse("#00fcb5"),
                LineStyle = LineStyle.Solid,
                YAxisKey = "fuelTrimAxis"
            };
            fuelTrimModel.Series.Add(longTermFuelTrimB1Series);

            // Add B2 Trims
            var shortTermFuelTrimB2Series = new LineSeries
            {
                Title = "Short term fuel trim B2",
                StrokeThickness = 5,
                Color = OxyColor.Parse("#fc0000"),
                LineStyle = LineStyle.Solid,
                YAxisKey = "fuelTrimAxis"
            };
            fuelTrimModel.Series.Add(shortTermFuelTrimB2Series);

            var longTermFuelTrimB2Series = new LineSeries
            {
                Title = "Long term fuel trim B2",
                StrokeThickness = 5,
                Color = OxyColor.Parse("#00fc19"),
                LineStyle = LineStyle.Solid,
                YAxisKey = "fuelTrimAxis"
            };
            fuelTrimModel.Series.Add(longTermFuelTrimB2Series);

            fuelTrimModel.Legends.Add(new Legend()
            {
                LegendPosition = LegendPosition.BottomCenter
            });

            plotView.Model = fuelTrimModel;

            var dateTimeAxis = fuelTrimModel.Axes.OfType<DateTimeAxis>().First();

            while (isGraphing)
            {
                var dateTimeNow = DateTime.Now;
                var rpmValue = mainForm.vehicle.GetRpm();
                rpmSeries.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dateTimeNow), rpmValue));

                if (shortTermB1Available)
                {
                    try
                    {
                        var shortTermFuelTrimB1 = mainForm.vehicle.GetShortTermFuelTrimB1();
                        shortTermFuelTrimB1Series.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dateTimeNow), (double)shortTermFuelTrimB1));
                    }
                    catch (NoDataFoundException)
                    {
                        shortTermB1Available = false;
                        shortTermFuelTrimB1Series.Title += " (Unavailable)";
                    }
                }

                if (longTermB1Available)
                {
                    try
                    {
                        var longTermFuelTrimB1 = mainForm.vehicle.GetLongTermFuelTrimB1();
                        longTermFuelTrimB1Series.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dateTimeNow), (double)longTermFuelTrimB1));
                    }
                    catch (NoDataFoundException)
                    {
                        longTermB1Available = false;
                        longTermFuelTrimB1Series.Title += " (Unavailable)";
                    }
                }

                if (shortTermB2Available)
                {
                    try
                    {
                        var shortTermFuelTrimB2 = mainForm.vehicle.GetShortTermFuelTrimB2();
                        shortTermFuelTrimB2Series.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dateTimeNow), (double)shortTermFuelTrimB2));
                    }
                    catch (NoDataFoundException)
                    {
                        shortTermB2Available = false;
                        shortTermFuelTrimB2Series.Title += " (Unavailable)";
                    }
                }

                if (longTermB2Available)
                {
                    try
                    {
                        var longTermFuelTrimB2 = mainForm.vehicle.GetLongTermFuelTrimB2();
                        longTermFuelTrimB2Series.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dateTimeNow), (double)longTermFuelTrimB2));
                    }
                    catch (NoDataFoundException)
                    {
                        longTermB2Available = false;
                        longTermFuelTrimB2Series.Title += " (Unavailable)";
                    }
                }

                //Check if graph has run out of room and pan it
                if (DateTimeAxis.ToDateTime(dateTimeAxis.Maximum) < dateTimeNow)
                {
                    dateTimeAxis.Minimum = DateTimeAxis.ToDouble(dateTimeNow.AddSeconds(-1 * MaxSecondsToShow));
                    dateTimeAxis.Maximum = DateTimeAxis.ToDouble(dateTimeNow);
                    dateTimeAxis.Reset();
                }

                fuelTrimModel.InvalidatePlot(true);

                await Task.Delay(50);
            }
        }
        
        private static void SetupPlotModel(PlotModel model)
        {
            DateTimeAxis xAxis = new()
            {
                Title = "TimeStamp",
                Position = AxisPosition.Bottom,
                StringFormat = "hh:mm:ss",
                Angle = -45,
                IntervalLength = 60,
                Minimum = DateTimeAxis.ToDouble(DateTime.Now),
                Maximum = DateTimeAxis.ToDouble(DateTime.Now.AddSeconds(MaxSecondsToShow)),
                IsPanEnabled = true,
                IsZoomEnabled = false,
                IntervalType = DateTimeIntervalType.Seconds,
                MajorGridlineStyle = LineStyle.Dot,
                MajorGridlineColor = OxyColor.Parse("#4d4d4d"),
                AxislineColor = OxyColors.White,
                TicklineColor = OxyColors.White,
            };

            LinearAxis fuelTrimAxis = new()
            {
                Title = "Fuel Trim",
                Unit = "%",
                Position = AxisPosition.Left,
                PositionTier = 0,
                Minimum = -100,
                Maximum = 100,
                Key = "fuelTrimAxis",
                MinorTickSize = 0,
                IsZoomEnabled = false,
                IsPanEnabled = false,
                MajorGridlineColor = OxyColor.Parse("#4d4d4d"),
                AxislineColor = OxyColors.White,
                TicklineColor = OxyColors.White
            };

            LinearAxis rpmAxis = new()
            {
                Title = "Engine RPM",
                Unit = "RPM",
                Position = AxisPosition.Right,
                PositionTier = 0,
                Minimum = 0,
                Maximum = 10000,
                Key = "rpmAxis",
                MinorTickSize = 0,
                IsZoomEnabled = false,
                IsPanEnabled = false,
                MajorGridlineColor = OxyColor.Parse("#4d4d4d"),
                AxislineColor = OxyColors.White,
                TicklineColor = OxyColors.White
            };

            model.Axes.Add(xAxis);
            model.Axes.Add(fuelTrimAxis);
            model.Axes.Add(rpmAxis);
        }
    }
}
