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
        private decimal time = 0.00m;

        public OxygenVoltageGraph(EngineLine parent)
        {
            InitializeComponent();

            mainForm = parent;
        }

        private void graphTimer_Tick(object sender, EventArgs e)
        {
            time += (decimal)graphTimer.Interval / 1000;
        }

        private void OxygenVoltageGraph_FormClosing(object sender, FormClosingEventArgs e)
        {
            isGraphing = false;
            graphTimer.Stop();
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

        private async void StartGraphing()
        {
            bool s1B1Available = true, s2B1Available = true, s1B2Available = true, s2B2Available = true;
            time = 0.00m;
            
            // ****************************************
            // Create S1B1 Graph
            var s1B1Model = new PlotModel()
            {
                Title = "Sensor 1 Bank 1",
                TextColor = OxyColors.White
            };
            var s1B1Points = new List<DataPoint>();

            SetupPlotModel(s1B1Model, s1B1Points);
            plotViewS1B1.Model = s1B1Model;

            // ****************************************
            // Create S2B1 Graph
            var s2B1Model = new PlotModel()
            {
                Title = "Sensor 2 Bank 1",
                TextColor = OxyColors.White
            };
            var s2B1Points = new List<DataPoint>();

            SetupPlotModel(s2B1Model, s2B1Points);
            plotViewS2B1.Model = s2B1Model;

            // ****************************************
            // Create S1B2 Graph
            var s1B2Model = new PlotModel()
            {
                Title = "Sensor 1 Bank 2",
                TextColor = OxyColors.White
            };
            var s1B2Points = new List<DataPoint>();

            SetupPlotModel(s1B2Model, s1B2Points);
            plotViewS1B2.Model = s1B2Model;

            // ****************************************
            // Create S2B2 Graph
            var s2B2Model = new PlotModel()
            {
                Title = "Sensor 2 Bank 2",
                TextColor = OxyColors.White
            };
            var s2B2Points = new List<DataPoint>();

            SetupPlotModel(s2B2Model, s2B2Points);
            plotViewS2B2.Model = s2B2Model;

            while (isGraphing)
            {
                if (s1B1Available)
                {
                    try
                    {
                        var s1B1Value = mainForm.vehicle.GetOxygenSensor1B1();
                        s1B1Points.Add(new DataPoint(Axis.ToDouble(time), Axis.ToDouble(s1B1Value)));
                        s1B1Model.InvalidatePlot(true);
                        await Task.Delay(1);
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
                        s2B1Points.Add(new DataPoint(Axis.ToDouble(time), Axis.ToDouble(s2B1Value)));
                        s2B1Model.InvalidatePlot(true);
                        await Task.Delay(1);
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
                        s1B2Points.Add(new DataPoint(Axis.ToDouble(time), Axis.ToDouble(s1B2Value)));
                        s1B2Model.InvalidatePlot(true);
                        await Task.Delay(1);
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
                        s2B2Points.Add(new DataPoint(Axis.ToDouble(time), Axis.ToDouble(s2B2Value)));
                        s2B2Model.InvalidatePlot(true);
                    }
                    catch(NoDataFoundException)
                    {
                        s2B2Available = false;
                        s2B2Model.Title = "Unavailable";
                        s2B2Model.InvalidatePlot(false);
                    }
                }

                await Task.Delay(100);
            }
        }

        private void SetupPlotModel(PlotModel model, List<DataPoint> dataPoints)
        {
            LinearAxis xAxis = new()
            {
                Title = "Time",
                Unit = "Seconds",
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Maximum = 60,
                MajorGridlineStyle = LineStyle.Dot,
                MinorTickSize = 0,
                IsZoomEnabled = false,
                IsPanEnabled = true,
                MajorGridlineColor = OxyColor.Parse("#4d4d4d"),
                AxislineColor = OxyColors.White,
                TicklineColor = OxyColors.White
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
                ItemsSource = dataPoints
            };

            model.Axes.Add(xAxis);
            model.Axes.Add(voltageAxis);
            model.Series.Add(series);
        }
    }
}
