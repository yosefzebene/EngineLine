using EngineLineLibrary;
using CodeArtEng.Gauge;

namespace EngineLine
{
    public partial class EngineLine : Form
    {
        public IObdConnection? Connection { get; set; }

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
            if (Connection == null)
                MessageBox.Show("Connect and try again");

            return Connection == null;
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
                var rpm = Connection.ReadRpm();
                textBoxRPM.Text = $"{rpm}";
                guageRPM.GaugeData.Value = rpm;

                await Task.Delay(1);

                var speed = Connection.ReadSpeed();
                textBoxSpeed.Text = $"{speed} KPH";
                guageSpeed.GaugeData.Value = speed;

                await Task.Delay(1);

                textBoxTPS.Text = $"{Connection.ReadTPS()}%";

                await Task.Delay(1);

                textBoxTemperature.Text = $"{Connection.ReadTemperature()} °C";

                await Task.Delay(1);

                textBoxMAF.Text = $"{Connection.ReadMAF()}";

                await Task.Delay(1);
            }
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            if (IsNotConnected())
                return;

            UpdateEngineCodes();
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
                Connection.ResetCodes();

                UpdateEngineCodes();
            }
            else
                return;
        }

        private void UpdateEngineCodes()
        {
            try
            {
                listBoxEngineCodes.DataSource = Connection.ReadEngineCodes();
            }
            catch (NoDataFoundException)
            {
                List<string> errors = new() { "No Engine codes found" };
                listBoxEngineCodes.DataSource = errors;
            }
        }
    }
}
