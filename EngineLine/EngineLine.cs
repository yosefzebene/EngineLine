using EngineLineLibrary;

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
                textBoxRPM.Text = $"{Connection.ReadRpm()}";

                await Task.Delay(10);

                textBoxSpeed.Text = $"{Connection.ReadSpeed()} KPH";

                await Task.Delay(10);

                textBoxTPS.Text = $"{Connection.ReadTPS()}%";

                await Task.Delay(10);

                textBoxTempreture.Text = $"{Connection.ReadTempreture()}";

                await Task.Delay(10);

                textBoxMAF.Text = $"{Connection.ReadMAF()}";
            }
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            if (IsNotConnected())
                return;

            listBoxEngineCodes.DataSource = Connection.ReadEngineCodes();
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

                listBoxEngineCodes.DataSource = Connection.ReadEngineCodes();
            }
            else
                return;
        }
    }
}
