using EngineLineLibrary.Vehicle.Enums;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EngineLine.Pages
{
    public sealed partial class Monitor : Page
    {
        private Pid[] selectedPids;
        private bool isMonitoring = false;
        private ObservableCollection<MonitoringResult> monitoringResults = new();

        public Monitor()
        {
            this.InitializeComponent();

            SupportedPidsListView.ItemsSource = ConnectionAccess.QueryManager.GetSupportedCommands();
            ContentGridView.ItemsSource = monitoringResults;
        }

        private void SupportedPidsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPids = SupportedPidsListView.SelectedItems.Cast<Pid>().ToArray();
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
                        if(monitoringResults.Count == 0 || !monitoringResults.Where(i => i.PidName == pid.ToString()).Any())
                            monitoringResults.Add(new MonitoringResult()
                            {
                                PidName = pid.ToString(),
                                Result = result,
                            });
                        else
                            monitoringResults.Where(i => i.PidName == pid.ToString()).First().Result = result;
                    }
                    catch
                    {
                        // just skip it
                    }
                }
            }
        }
    }

    public class MonitoringResult : INotifyPropertyChanged
    {
        private string pidName;
        private decimal result;

        public string PidName { get { return pidName; } set { pidName = value; OnPropertyChanged(nameof(PidName)); } }
        public decimal Result { get { return result; } set { result = value; OnPropertyChanged(nameof(Result)); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
