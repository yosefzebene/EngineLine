using EngineLineLibrary;

namespace EngineLine
{
    public partial class EngineLine : Form
    {
        public IObdConnection? Connection { get; set; }

        public EngineLine()
        {
            InitializeComponent();
        }

        private void OnConnectionMenuItem_Click(object sender, EventArgs e)
        {
            Connecting connecting = new(this);
            connecting.ShowDialog();
        }
    }
}
