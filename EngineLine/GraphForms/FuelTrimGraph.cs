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
        private decimal time = 0.00m;

        public FuelTrimGraph(EngineLine parent)
        {
            InitializeComponent();

            mainForm = parent;
        }

        private void graphTimer_Tick(object sender, EventArgs e)
        {
            time += (decimal)graphTimer.Interval / 1000;
        }

        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            if (isGraphing)
            {
                isGraphing = false;
                graphTimer.Stop();

                buttonStartStop.Text = "Start";
            }
            else
            {
                buttonStartStop.Text = "Stop";

                isGraphing = true;
                graphTimer.Start();

                StartGraphing();
            }
        }

        private void FuelTrimGraph_FormClosing(object sender, FormClosingEventArgs e)
        {
            isGraphing = false;
            graphTimer.Stop();
        }

        private async void StartGraphing()
        {
            bool shortTermB1Available = true, longTermB1Available = true, shortTermB2Available = true, longTermB2Available = true;
            time = 0.00m;

            var fuelTrimModel = new PlotModel()
            {
                TextColor = OxyColors.White
            };

            SetupPlotModel(fuelTrimModel);

            // Add rpm
            var rpmPoints = new List<DataPoint>();
            var rpmSeries = new LineSeries
            {
                Title = "RPM",
                StrokeThickness = 2,
                Color = OxyColor.Parse("#cfcfcf"),
                LineStyle = LineStyle.Solid,
                ItemsSource = rpmPoints,
                YAxisKey = "rpmAxis"
            };
            fuelTrimModel.Series.Add(rpmSeries);

            // Add B1 Trims
            var shortTermFuelTrimB1Points = new List<DataPoint>();
            var shortTermFuelTrimB1Series = new LineSeries
            {
                Title = "Short term fuel trim B1",
                StrokeThickness = 5,
                Color = OxyColor.Parse("#b100fc"),
                LineStyle = LineStyle.Solid,
                ItemsSource = shortTermFuelTrimB1Points,
                YAxisKey = "fuelTrimAxis"
            };
            fuelTrimModel.Series.Add(shortTermFuelTrimB1Series);

            var longTermFuelTrimB1Points = new List<DataPoint>();
            var longTermFuelTrimB1Series = new LineSeries
            {
                Title = "Long term fuel trim B1",
                StrokeThickness = 5,
                Color = OxyColor.Parse("#00fcb5"),
                LineStyle = LineStyle.Solid,
                ItemsSource = longTermFuelTrimB1Points,
                YAxisKey = "fuelTrimAxis"
            };
            fuelTrimModel.Series.Add(longTermFuelTrimB1Series);

            // Add B2 Trims
            var shortTermFuelTrimB2Points = new List<DataPoint>();
            var shortTermFuelTrimB2Series = new LineSeries
            {
                Title = "Short term fuel trim B2",
                StrokeThickness = 5,
                Color = OxyColor.Parse("#fc0000"),
                LineStyle = LineStyle.Solid,
                ItemsSource = shortTermFuelTrimB2Points,
                YAxisKey = "fuelTrimAxis"
            };
            fuelTrimModel.Series.Add(shortTermFuelTrimB2Series);

            var longTermFuelTrimB2Points = new List<DataPoint>();
            var longTermFuelTrimB2Series = new LineSeries
            {
                Title = "Long term fuel trim B2",
                StrokeThickness = 5,
                Color = OxyColor.Parse("#00fc19"),
                LineStyle = LineStyle.Solid,
                ItemsSource = longTermFuelTrimB2Points,
                YAxisKey = "fuelTrimAxis"
            };
            fuelTrimModel.Series.Add(longTermFuelTrimB2Series);

            fuelTrimModel.Legends.Add(new Legend()
            {
                LegendPosition = LegendPosition.BottomCenter
            });

            plotView.Model = fuelTrimModel;

            while (isGraphing)
            {
                var rpmValue = mainForm.vehicle.GetRpm();
                rpmPoints.Add(new DataPoint((double)time, rpmValue));

                if (shortTermB1Available)
                {
                    try
                    {
                        var shortTermFuelTrimB1 = mainForm.vehicle.GetShortTermFuelTrimB1();
                        shortTermFuelTrimB1Points.Add(new DataPoint((double)time, (double)shortTermFuelTrimB1));
                        await Task.Delay(1);
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
                        longTermFuelTrimB1Points.Add(new DataPoint((double)time, (double)longTermFuelTrimB1));
                        await Task.Delay(1);
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
                        shortTermFuelTrimB2Points.Add(new DataPoint((double)time, (double)shortTermFuelTrimB2));
                        await Task.Delay(1);
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
                        longTermFuelTrimB2Points.Add(new DataPoint((double)time, (double)longTermFuelTrimB2));
                    }
                    catch (NoDataFoundException)
                    {
                        longTermB2Available = false;
                        longTermFuelTrimB2Series.Title += " (Unavailable)";
                    }
                }

                fuelTrimModel.InvalidatePlot(true);

                await Task.Delay(30);
            }
        }

        private static void SetupPlotModel(PlotModel model)
        {
            LinearAxis xAxis = new()
            {
                Title = "Time",
                Unit = "Seconds",
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Maximum = 60,
                Key = "xAxis",
                MajorGridlineStyle = LineStyle.Dot,
                MinorTickSize = 0,
                IsZoomEnabled = false,
                IsPanEnabled = true,
                MajorGridlineColor = OxyColor.Parse("#4d4d4d"),
                AxislineColor = OxyColors.White,
                TicklineColor = OxyColors.White
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
