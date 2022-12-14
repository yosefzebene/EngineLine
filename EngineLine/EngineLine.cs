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
                if (Connection == null)
                {
                    MessageBox.Show("Connect and try again");
                    return;
                }

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
    }
}
