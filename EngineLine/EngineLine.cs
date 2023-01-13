using EngineLineLibrary;
using CodeArtEng.Gauge;

namespace EngineLine
{
    public partial class EngineLine : Form
    {
        public Vehicle vehicle { get; set; }

        private bool isMonitoring = false;

        public EngineLine()
        {
            InitializeComponent();
        }

        private void OnConnectionMenuItem_Click(object sender, EventArgs e)
        {
            Connecting connecting = new(this);
            connecting.ShowDialog();
        }

        private bool IsNotConnected()
        {
            if (vehicle == null)
                MessageBox.Show("Connect and try again");

            return vehicle == null;
        }

        private void buttonMonitoringTrigger_Click(object sender, EventArgs e)
        {
            if (isMonitoring)
            {
                isMonitoring = false;

                buttonMonitoringTrigger.Text = "START";
                buttonMonitoringTrigger.BackColor = Color.Green;
            }
            else
            {
                if (IsNotConnected())
                    return;

                buttonMonitoringTrigger.Text = "STOP";
                buttonMonitoringTrigger.BackColor = Color.Red;

                isMonitoring = true;

                StartMonitoring();
            }
        }

        private async void StartMonitoring()
        {
            while (isMonitoring)
            {
                var rpm = vehicle.GetRpm();
                textBoxRPM.Text = $"{rpm}";
                guageRPM.GaugeData.Value = rpm;

                await Task.Delay(1);

                var speed = vehicle.GetSpeed();
                textBoxSpeed.Text = $"{speed} KPH";
                guageSpeed.GaugeData.Value = speed;

                await Task.Delay(1);

                textBoxTPS.Text = $"{vehicle.GetTPS()}%";

                await Task.Delay(1);

                textBoxTemperature.Text = $"{vehicle.GetTemperature()} °C";

                await Task.Delay(1);

                textBoxMAF.Text = $"{vehicle.GetMAF()}";

                await Task.Delay(1);
            }
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            if (IsNotConnected())
                return;

            UpdateDtcs();
        }

        private void buttonClearCodes_Click(object sender, EventArgs e)
        {
            if (IsNotConnected())
                return;

            var confirm = MessageBox.Show(
                "Are you sure you want to clear codes? This is not reversable!",
                "Confirm clearing",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );

            if (confirm == DialogResult.Yes)
            {
                vehicle.ResetCodes();

                UpdateDtcs();
            }
            else
                return;
        }

        private void UpdateDtcs()
        {
            try
            {
                listBoxDiagnosticTroubleCodes.DataSource = vehicle.GetDiagnosticTroubleCodes();
            }
            catch (NoDataFoundException)
            {
                List<string> errors = new() { "No DTCs found" };
                listBoxDiagnosticTroubleCodes.DataSource = errors;
            }
        }
    }
}
