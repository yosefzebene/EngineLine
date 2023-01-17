using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot;

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
            time = 0.00m;
            
            // ****************************************
            // Create S1B1 Graph
            var S1B1Model = new PlotModel()
            {
                Title = "Sensor 1 Bank 1"
            };

            AddAxisToModel(S1B1Model);

            var s1B1Points = new List<DataPoint>();
            var s1B1Series = new LineSeries
            {
                StrokeThickness = 5,
                Color = OxyColor.Parse("#f55d42"),
                LineStyle = LineStyle.Solid,
                ItemsSource = s1B1Points
            };
            S1B1Model.Series.Add(s1B1Series);

            plotViewS1B1.Model = S1B1Model;

            // ****************************************
            // Create S2B1 Graph

            var S2B1Model = new PlotModel()
            {
                Title = "Sensor 2 Bank 1"
            };

            AddAxisToModel(S2B1Model);

            var s2B1Points = new List<DataPoint>();
            var s2B1Series = new LineSeries
            {
                StrokeThickness = 5,
                Color = OxyColor.Parse("#f55d42"),
                LineStyle = LineStyle.Solid,
                ItemsSource = s2B1Points
            };
            S2B1Model.Series.Add(s2B1Series);

            plotViewS2B1.Model = S2B1Model;

            while (isGraphing)
            {
                var s1B1Value = mainForm.vehicle.GetOxygenSensor1B1();
                s1B1Points.Add(new DataPoint(Axis.ToDouble(time), Axis.ToDouble(s1B1Value)));
                await Task.Delay(1);

                var s2B1Value = mainForm.vehicle.GetOxygenSensor2B1();
                s2B1Points.Add(new DataPoint(Axis.ToDouble(time), Axis.ToDouble(s2B1Value)));

                await Task.Delay(100);

                S2B1Model.InvalidatePlot(true);
                S1B1Model.InvalidatePlot(true);
            }
        }

        private void AddAxisToModel(PlotModel model)
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
                IsPanEnabled = false,
            };

            LinearAxis voltageAxis = new()
            {
                Title = "Voltage",
                Unit = "V",
                Position = AxisPosition.Left,
                PositionTier = 0,
                Minimum = 0,
                Maximum = 1.5,
                MinorTickSize = 0,
                IsZoomEnabled = false,
                IsPanEnabled = false,
            };

            model.Axes.Add(xAxis);
            model.Axes.Add(voltageAxis);
        }
    }
}
