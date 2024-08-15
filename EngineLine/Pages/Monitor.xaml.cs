using EngineLine.Models;
using EngineLineLibrary.Vehicle.Enums;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace EngineLine.Pages
{
    public sealed partial class Monitor : Page
    {
        private Pid[] selectedPids;
        private bool isMonitoring = false;
        private readonly ObservableCollection<MonitoringResult> monitoringResults = new();

        public Monitor()
        {
            this.InitializeComponent();

            Dictionary<Pid, string> supportedPidsWithNames = new();
            var supportedPids = ConnectionAccess.QueryManager.GetSupportedCommands();

            foreach (var pid in supportedPids)
            {
                supportedPidsWithNames.Add(pid, pid.GetName());
            }

            SupportedPidsListView.ItemsSource = supportedPidsWithNames;
            SupportedPidsListView.DisplayMemberPath = "Value";
            ContentGridView.ItemsSource = monitoringResults;
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
            monitoringResults.Clear();

            while (isMonitoring)
            {
                foreach (Pid pid in selectedPids)
                {
                    try
                    {
                        var task = Task.Factory.StartNew(() => ConnectionAccess.QueryManager.GetCurrentData(pid));
                        var result = await task;

                        if (monitoringResults.Count == 0 || !monitoringResults.Where(i => i.PidName == pid.GetName()).Any())
                            monitoringResults.Add(new MonitoringResult()
                            {
                                PidName = result.PidName,
                                Result = (double)result.Result,
                                Unit = result.Unit,
                            });
                        else
                            monitoringResults.Where(i => i.PidName == pid.GetName()).First().Result = (double)result.Result;
                    }
                    catch
                    {
                        // just skip it
                    }
                }
            }
        }

        private void Page_Unloaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            isMonitoring = false;
        }
    }
}
