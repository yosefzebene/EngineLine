using EngineLineLibrary.Vehicle.Enums;
using Microsoft.UI.Xaml.Controls;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EngineLine.Pages
{
    public sealed partial class Plot : Page
    {
        private Pid[] selectedPids;
        private bool isMonitoring = false;
        private const int MaxSecondsToShow = 20;

        public Plot()
        {
            this.InitializeComponent();

            PopulateSupportedPidsListView();
            SetupPlotViewPlaceHolderModel();
        }

        private void PopulateSupportedPidsListView()
        {
            Dictionary<Pid, string> supportedPidsWithNames = new();
            var supportedPids = ConnectionAccess.QueryManager.GetSupportedCommands();

            foreach (var pid in supportedPids)
            {
                supportedPidsWithNames.Add(pid, pid.GetName());
            }
            SupportedPidsListView.ItemsSource = supportedPidsWithNames;
            SupportedPidsListView.DisplayMemberPath = "Value";
        }

        private void SetupPlotViewPlaceHolderModel()
        {
            PlotModel placeHolderModel = new()
            {
                PlotAreaBorderColor = OxyColors.Transparent,
                Axes =
                {
                    new DateTimeAxis {
                        Title = "Time",
                        Position = AxisPosition.Bottom,
                        StringFormat = "hh:mm:ss",
                        Angle = -45,
                        Minimum = DateTimeAxis.ToDouble(DateTime.Now),
                        Maximum = DateTimeAxis.ToDouble(DateTime.Now.AddSeconds(MaxSecondsToShow)),
                        IsPanEnabled = true,
                        IsZoomEnabled = false,
                        IntervalType = DateTimeIntervalType.Seconds,
                        MajorGridlineStyle = LineStyle.Dot,
                        MajorGridlineColor = OxyColor.Parse("#4d4d4d"),
                        AxislineColor = OxyColors.White,
                        TicklineColor = OxyColors.White,
                    }
                }
            };

            plotView.Model = placeHolderModel;
        }

        private void SupportedPidsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPids = SupportedPidsListView.SelectedItems.Cast<KeyValuePair<Pid, string>>().Select(kv => kv.Key).ToArray();
        }

        private void StartStopButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            splitView.IsPaneOpen = !splitView.IsPaneOpen;
            isMonitoring = !isMonitoring;

            startStopButton.Content = isMonitoring ? "STOP" : "START";

            if (isMonitoring)
            {
                StartMonitoring();
            }
        }

        private async void StartMonitoring()
        {
            PlotModel plotModel = CreateAndSetupModel();

            plotView.Model = plotModel;

            var dateTimeAxis = plotModel.Axes.OfType<DateTimeAxis>().First();

            while (isMonitoring)
            {
                foreach (Pid pid in selectedPids)
                {
                    try
                    {
                        var task = Task.Factory.StartNew(() => ConnectionAccess.QueryManager.GetCurrentData(pid));
                        var result = await task;

                        var dateTimeNow = DateTime.Now;

                        var pidLineSeries = (LineSeries)plotModel.Series.Where(s => s.Title == pid.GetName()).First();
                        pidLineSeries.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dateTimeNow), Decimal.ToDouble(result.Result)));

                        CheckIfTimeAxesHasRunOutOfRoomAndPanIt(dateTimeAxis, dateTimeNow);

                        plotModel.InvalidatePlot(true);
                    }
                    catch
                    {
                        // just skip it
                    }
                }
            }
        }

        private PlotModel CreateAndSetupModel()
        {
            PlotModel plotModel = new()
            {
                PlotAreaBorderColor = OxyColors.Transparent,
                Axes =
                {
                    new DateTimeAxis {
                        Title = "Time",
                        Position = AxisPosition.Bottom,
                        StringFormat = "hh:mm:ss",
                        Angle = -45,
                        Minimum = DateTimeAxis.ToDouble(DateTime.Now),
                        Maximum = DateTimeAxis.ToDouble(DateTime.Now.AddSeconds(MaxSecondsToShow)),
                        IsPanEnabled = true,
                        IsZoomEnabled = false,
                        IntervalType = DateTimeIntervalType.Seconds,
                        MajorGridlineStyle = LineStyle.Dot,
                        MajorGridlineColor = OxyColor.Parse("#4d4d4d"),
                        AxislineColor = OxyColors.White,
                        TicklineColor = OxyColors.White,
                    }
                }
            };

            AddAxisAndLineSeriesOnTheModel(plotModel);

            return plotModel;
        }

        private void AddAxisAndLineSeriesOnTheModel(PlotModel model)
        {
            Random random = new();

            int positionTierCounter = 0;
            foreach (Pid pid in selectedPids)
            {
                var name = pid.GetName();

                model.Axes.Add(new LinearAxis()
                {
                    Title = name,
                    Unit = pid.GetUnit(),
                    Position = AxisPosition.Right,
                    PositionTier = positionTierCounter,
                    Key = name,
                    Minimum = pid.GetMin(),
                    Maximum = pid.GetMax(),
                    IsZoomEnabled = false,
                    IsPanEnabled = false,
                    AxislineColor = OxyColors.White,
                    TicklineColor = OxyColors.White
                });

                byte r = Convert.ToByte(random.Next(0, 256));
                byte g = Convert.ToByte(random.Next(0, 256));
                byte b = Convert.ToByte(random.Next(0, 256));

                model.Series.Add(new LineSeries()
                {
                    Title = name,
                    StrokeThickness = 2,
                    Color = OxyColor.FromRgb(r, g, b),
                    LineStyle = LineStyle.Solid,
                    YAxisKey = name
                });

                positionTierCounter++;
            }
        }

        private static void CheckIfTimeAxesHasRunOutOfRoomAndPanIt(DateTimeAxis dateTimeAxis, DateTime dateTimeNow)
        {
            if (DateTimeAxis.ToDateTime(dateTimeAxis.Maximum) < dateTimeNow)
            {
                dateTimeAxis.Minimum = DateTimeAxis.ToDouble(dateTimeNow.AddSeconds(-1 * MaxSecondsToShow));
                dateTimeAxis.Maximum = DateTimeAxis.ToDouble(dateTimeNow);
                dateTimeAxis.Reset();
            }
        }

        private void Page_Unloaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            isMonitoring = false;
        }
    }
}
