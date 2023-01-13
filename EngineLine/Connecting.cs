using EngineLineLibrary;
using System.IO.Ports;

namespace EngineLine
{
    public partial class Connecting : Form
    {
        private readonly List<KeyValuePair<string, string>> protocols = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("Automatic", "AT SP 0"),
            new KeyValuePair<string, string>("SAE J1850 PMW (41.6 kbaud)", "AT SP 1"),
            new KeyValuePair<string, string>("SAE J1850 VPW (10.4 kbaud)", "AT SP 2"),
            new KeyValuePair<string, string>("ISO 9141-2 (5 baud init, 10.4 kbaud)", "AT SP 3"),
            new KeyValuePair<string, string>("ISO 14230 - 4 KWP(5 baud init, 10.4 kbaud)", "AT SP 4"),
            new KeyValuePair<string, string>("ISO 14230 - 4 KWP(fast init, 10.4 kbaud)", "AT SP 5"),
            new KeyValuePair<string, string>("ISO 15765 - 4 CAN(11 bit ID, 500 kbaud)", "AT SP 6"),
            new KeyValuePair<string, string>("ISO 15765 - 4 CAN(29 bit ID, 500 kbaud)", "AT SP 7")
        };

        private int[] BaudRate = new int[] { 9600, 19200, 38400, 57600, 115200 };

        private EngineLine mainForm;

        public Connecting(EngineLine parent)
        {
            InitializeComponent();

            mainForm = parent;
        }

        private void Connecting_Load(object sender, EventArgs e)
        {
            // Populate the protocol comboBox
            comboBoxOBDProtocol.DataSource = protocols;
            comboBoxOBDProtocol.DisplayMember = "Key";
            comboBoxOBDProtocol.ValueMember = "Value";

            // Populate COM ports
            string[] ports = SerialPort.GetPortNames();
            comboBoxCOMPort.DataSource = ports;

            // Populate BAUD Rate
            comboBoxBaudRate.DataSource = BaudRate;
        }

        private void checkBoxDefaultBaud_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxBaudRate.Enabled = !checkBoxDefaultBaud.Checked;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            string? protocol = comboBoxOBDProtocol.SelectedValue as string;
            string? COMPort = comboBoxCOMPort.SelectedValue as string;
            int BaudRate = (int)comboBoxBaudRate.SelectedValue;

            if (protocol == null || COMPort == null)
                return;

            try
            {
                if (checkBoxDefaultBaud.Checked)
                {
                    var connection = new ObdConnection(COMPort, protocol);
                    mainForm.vehicle = new Vehicle(connection);
                }
                else
                {
                    var connection = new ObdConnection(COMPort, protocol, BaudRate);
                    mainForm.vehicle = new Vehicle(connection);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
