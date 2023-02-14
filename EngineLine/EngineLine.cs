using EngineLineLibrary;
using EngineLine.GraphForms;

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

        // Connection Tab
        private void tabPageConnect_Enter(object sender, EventArgs e)
        {
            if (vehicle == null)
            {
                textBoxStatus.Text = "Not Connected";
                textBoxStatus.ForeColor = Color.Red;
                buttonConnect.Enabled = true;
                buttonDisconnect.Enabled = false;
            }
            else
            {
                textBoxStatus.Text = "Connected";
                textBoxStatus.ForeColor = Color.Green;
                buttonConnect.Enabled = false;
                buttonDisconnect.Enabled = true;
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            Connecting connecting = new(this);
            connecting.Show(this);
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            vehicle.Disconnect();
            vehicle = null;
        }

        // Monitoring Tab
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
                textBoxSpeed.Text = $"{speed} KM/H";
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

        // DTCs Tab
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
                "Are you sure you want to clear codes? This is not reversible!",
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

        // Graphs Tab
        private void buttonOpenFuelTrimGraph_Click(object sender, EventArgs e)
        {
            if (IsNotConnected())
                return;

            FuelTrimGraph fuelTrimGraph = new(this);
            fuelTrimGraph.Show(this);
        }

        private void buttonOpenOxygenVoltageGraph_Click(object sender, EventArgs e)
        {
            if (IsNotConnected())
                return;

            OxygenVoltageGraph oxygenVoltageGraph = new(this);
            oxygenVoltageGraph.Show(this);
        }

        private bool IsNotConnected()
        {
            if (vehicle == null)
                MessageBox.Show("Connect and try again");

            return vehicle == null;
        }

        internal void UpdateMonitorChecks()
        {
            if (IsNotConnected())
                return;

            try
            {
                var MonitorStatusData = vehicle.GetMonitorStatuses().Where(x => x.Available == true);

                if (!MonitorStatusData.Any())
                    throw new NoDataFoundException();

                dataGridViewMonitorStatuses.DataSource = MonitorStatusData;
                dataGridViewMonitorStatuses.Columns["Available"].Visible = false;
                dataGridViewMonitorStatuses.Columns["CurrentDriveCheckAvailable"].Visible = false;
                dataGridViewMonitorStatuses.Columns["Incomplete"].HeaderText = "Status";
                dataGridViewMonitorStatuses.Columns["IncompleteCurrentDriveCycle"].HeaderText = "Status this drive cycle";

                if (!MonitorStatusData.FirstOrDefault().CurrentDriveCheckAvailable)
                {
                    dataGridViewMonitorStatuses.Columns["IncompleteCurrentDriveCycle"].Visible = false;
                }
            }
            catch (NoDataFoundException)
            {
                List<string> errors = new() { "No status checks available" };
                dataGridViewMonitorStatuses.DataSource = errors.Select(s => new { error = s }).ToList();
            }
        }
    }
}
