using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot;
using EngineLineLibrary;

namespace EngineLine.GraphForms
{
    public partial class OxygenVoltageGraph : Form
    {
        private readonly EngineLine mainForm;

        private bool isGraphing = false;
        const int MaxSecondsToShow = 20;

        public OxygenVoltageGraph(EngineLine parent)
        {
            InitializeComponent();

            mainForm = parent;
        }

        private void OxygenVoltageGraph_FormClosing(object sender, FormClosingEventArgs e)
        {
            isGraphing = false;
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

        private async void StartGraphing()
        {
            bool s1B1Available = true, s2B1Available = true, s1B2Available = true, s2B2Available = true;
            
            // ****************************************
            // Create S1B1 Graph
            var s1B1Model = new PlotModel()
            {
                Title = "Sensor 1 Bank 1",
                TextColor = OxyColors.White
            };
            SetupPlotModel(s1B1Model);
            var s1B1Points = s1B1Model.Series.OfType<LineSeries>().First();

            plotViewS1B1.Model = s1B1Model;

            // ****************************************
            // Create S2B1 Graph
            var s2B1Model = new PlotModel()
            {
                Title = "Sensor 2 Bank 1",
                TextColor = OxyColors.White
            };
            SetupPlotModel(s2B1Model);
            var s2B1Points = s2B1Model.Series.OfType<LineSeries>().First();

            plotViewS2B1.Model = s2B1Model;

            // ****************************************
            // Create S1B2 Graph
            var s1B2Model = new PlotModel()
            {
                Title = "Sensor 1 Bank 2",
                TextColor = OxyColors.White
            };
            SetupPlotModel(s1B2Model);
            var s1B2Points = s1B2Model.Series.OfType<LineSeries>().First();

            plotViewS1B2.Model = s1B2Model;

            // ****************************************
            // Create S2B2 Graph
            var s2B2Model = new PlotModel()
            {
                Title = "Sensor 2 Bank 2",
                TextColor = OxyColors.White
            };
            SetupPlotModel(s2B2Model);
            var s2B2Points = s2B2Model.Series.OfType<LineSeries>().First();

            plotViewS2B2.Model = s2B2Model;

            List<DateTimeAxis> allDateTimeAxes = new()
            {
                s1B1Model.Axes.OfType<DateTimeAxis>().First(),
                s2B1Model.Axes.OfType<DateTimeAxis>().First(),
                s1B2Model.Axes.OfType<DateTimeAxis>().First(),
                s2B2Model.Axes.OfType<DateTimeAxis>().First()
            };

            while (isGraphing)
            {
                var dateTimeNow = DateTime.Now;

                if (s1B1Available)
                {
                    try
                    {
                        var s1B1Value = mainForm.vehicle.GetOxygenSensor1B1();
                        s1B1Points.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dateTimeNow), Axis.ToDouble(s1B1Value)));
                        s1B1Model.InvalidatePlot(true);
                    }
                    catch (NoDataFoundException)
                    {
                        s1B1Available = false;
                        s1B1Model.Title = "Unavailable";
                        s1B1Model.InvalidatePlot(false);
                    }
                }

                if (s2B1Available)
                {
                    try
                    {
                        var s2B1Value = mainForm.vehicle.GetOxygenSensor2B1();
                        s2B1Points.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dateTimeNow), Axis.ToDouble(s2B1Value)));
                        s2B1Model.InvalidatePlot(true);
                    }
                    catch (NoDataFoundException)
                    {
                        s2B1Available = false;
                        s2B1Model.Title = "Unavailable";
                        s2B1Model.InvalidatePlot(false);
                    }
                }

                if (s1B2Available)
                {
                    try
                    {
                        var s1B2Value = mainForm.vehicle.GetOxygenSensor1B2();
                        s1B2Points.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dateTimeNow), Axis.ToDouble(s1B2Value)));
                        s1B2Model.InvalidatePlot(true);
                    }
                    catch (NoDataFoundException)
                    {
                        s1B2Available = false;
                        s1B2Model.Title = "Unavailable";
                        s1B2Model.InvalidatePlot(false);
                    }
                }

                if (s2B2Available)
                {
                    try
                    {
                        var s2B2Value = mainForm.vehicle.GetOxygenSensor2B2();
                        s2B2Points.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dateTimeNow), Axis.ToDouble(s2B2Value)));
                        s2B2Model.InvalidatePlot(true);
                    }
                    catch(NoDataFoundException)
                    {
                        s2B2Available = false;
                        s2B2Model.Title = "Unavailable";
                        s2B2Model.InvalidatePlot(false);
                    }
                }

                //Check if graph has run out of room and pan it
                if (DateTimeAxis.ToDateTime(allDateTimeAxes.First().Maximum) < dateTimeNow)
                {
                    allDateTimeAxes.ForEach(axis =>
                    {
                        axis.Minimum = DateTimeAxis.ToDouble(dateTimeNow.AddSeconds(-1 * MaxSecondsToShow));
                        axis.Maximum = DateTimeAxis.ToDouble(dateTimeNow);
                        axis.Reset();
                    });
                }

                await Task.Delay(20);
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

            LinearAxis voltageAxis = new()
            {
                Title = "Voltage",
                Unit = "V",
                Position = AxisPosition.Left,
                PositionTier = 0,
                Minimum = 0,
                Maximum = 1.5,
                MinorTickSize = 3,
                IsZoomEnabled = false,
                IsPanEnabled = false,
                MajorGridlineColor = OxyColor.Parse("#4d4d4d"),
                AxislineColor = OxyColors.White,
                TicklineColor = OxyColors.White
            };

            var series = new LineSeries
            {
                StrokeThickness = 5,
                Color = OxyColor.Parse("#f55d42"),
                LineStyle = LineStyle.Solid,
            };

            model.Axes.Add(xAxis);
            model.Axes.Add(voltageAxis);
            model.Series.Add(series);
        }
    }
}
