using System.ComponentModel;

namespace EngineLine.Models
{
    public class MonitoringResult : INotifyPropertyChanged
    {
        private string pidName;
        private double result;
        private string unit;

        public string PidName { get { return pidName; } set { pidName = value; OnPropertyChanged(nameof(PidName)); } }
        public double Result { get { return result; } set { result = value; OnPropertyChanged(nameof(Result)); } }
        public string Unit { get { return unit; } set { unit = value; OnPropertyChanged(nameof(Unit)); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
