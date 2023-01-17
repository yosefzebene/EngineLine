using OxyPlot.Axes;
using OxyPlot;
using OxyPlot.Legends;
using OxyPlot.Series;

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
            time += (decimal)graphTimer.Interval/1000;
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
            time = 0.00m;

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

            LinearAxis fuelTrimB1Axis = new()
            {
                Title = "Fuel Trim B1",
                Unit = "%",
                Position = AxisPosition.Left,
                PositionTier = 0,
                Minimum = -100,
                Maximum = 100,
                Key = "fuelTrimB1Axis",
                MinorTickSize = 0,
                IsZoomEnabled = false,
                IsPanEnabled = false,
            };

            var myModel = new PlotModel();

            myModel.Axes.Add(xAxis);
            myModel.Axes.Add(fuelTrimB1Axis);

            var shortTermFuelTrimB1Points = new List<DataPoint>();
            var shortTermFuelTrimB1Series = new LineSeries
            {
                Title = "Short term fuel trim",
                StrokeThickness = 5,
                Color = OxyColor.Parse("#f55d42"),
                LineStyle = LineStyle.Solid,
                ItemsSource = shortTermFuelTrimB1Points,
                YAxisKey = "fuelTrimB1Axis"
            };
            myModel.Series.Add(shortTermFuelTrimB1Series);

            var longTermFuelTrimB1Points = new List<DataPoint>();
            var longTermFuelTrimB1Series = new LineSeries
            {
                Title = "Long term fuel trim",
                StrokeThickness = 5,
                Color = OxyColor.Parse("#fcba03"),
                LineStyle = LineStyle.Solid,
                ItemsSource = longTermFuelTrimB1Points,
                YAxisKey = "fuelTrimB1Axis"
            };
            myModel.Series.Add(longTermFuelTrimB1Series);

            myModel.Legends.Add(new Legend()
            {
                LegendPosition = LegendPosition.BottomCenter
            });

            plotView.Model = myModel;

            while (isGraphing)
            {
                var shortTermFuelTrimB1 = mainForm.vehicle.GetShortTermFuelTrimB1();
                shortTermFuelTrimB1Points.Add(new DataPoint(Axis.ToDouble(time), Axis.ToDouble(shortTermFuelTrimB1)));
                await Task.Delay(1);

                var longTermFuelTrimB1 = mainForm.vehicle.GetLongTermFuelTrimB1();
                longTermFuelTrimB1Points.Add(new DataPoint(Axis.ToDouble(time), Axis.ToDouble(longTermFuelTrimB1)));

                await Task.Delay(100);

                myModel.InvalidatePlot(true);
            }
        }
    }
}
