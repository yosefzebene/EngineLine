using CodeArtEng.Gauge;
using OxyPlot.WindowsForms;

namespace EngineLine
{
    partial class EngineLine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CodeArtEng.Gauge.Themes.ThemeColors themeColors1 = new CodeArtEng.Gauge.Themes.ThemeColors();
            CodeArtEng.Gauge.Themes.ThemeColors themeColors2 = new CodeArtEng.Gauge.Themes.ThemeColors();
            CodeArtEng.Gauge.Themes.ThemeColors themeColors3 = new CodeArtEng.Gauge.Themes.ThemeColors();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EngineLine));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageConnect = new System.Windows.Forms.TabPage();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.tabPageMonitoring = new System.Windows.Forms.TabPage();
            this.guageRPM = new CodeArtEng.Gauge.LinearGauge();
            this.labelRPM = new System.Windows.Forms.Label();
            this.buttonMonitoringTrigger = new System.Windows.Forms.Button();
            this.textBoxRPM = new System.Windows.Forms.TextBox();
            this.labelMAF = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.textBoxSpeed = new System.Windows.Forms.TextBox();
            this.textBoxMAF = new System.Windows.Forms.TextBox();
            this.textBoxTemperature = new System.Windows.Forms.TextBox();
            this.labelTPS = new System.Windows.Forms.Label();
            this.textBoxTPS = new System.Windows.Forms.TextBox();
            this.guageSpeed = new CodeArtEng.Gauge.LinearGauge();
            this.tabPageDiagnosticTroubleCodes = new System.Windows.Forms.TabPage();
            this.buttonReload = new System.Windows.Forms.Button();
            this.listBoxDiagnosticTroubleCodes = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonClearCodes = new System.Windows.Forms.Button();
            this.tabPageGraph = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelButtonOrganizer = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOpenOxygenVoltageGraph = new System.Windows.Forms.Button();
            this.buttonOpenFuelTrimGraph = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageConnect.SuspendLayout();
            this.tabPageMonitoring.SuspendLayout();
            this.tabPageDiagnosticTroubleCodes.SuspendLayout();
            this.tabPageGraph.SuspendLayout();
            this.tableLayoutPanelButtonOrganizer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPageConnect);
            this.tabControl1.Controls.Add(this.tabPageMonitoring);
            this.tabControl1.Controls.Add(this.tabPageDiagnosticTroubleCodes);
            this.tabControl1.Controls.Add(this.tabPageGraph);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semilight", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.ItemSize = new System.Drawing.Size(119, 75);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2255, 1200);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPageConnect
            // 
            this.tabPageConnect.BackColor = System.Drawing.SystemColors.Desktop;
            this.tabPageConnect.Controls.Add(this.buttonConnect);
            this.tabPageConnect.Controls.Add(this.buttonDisconnect);
            this.tabPageConnect.Controls.Add(this.textBoxStatus);
            this.tabPageConnect.Controls.Add(this.textBoxTitle);
            this.tabPageConnect.ForeColor = System.Drawing.Color.White;
            this.tabPageConnect.Location = new System.Drawing.Point(4, 79);
            this.tabPageConnect.Name = "tabPageConnect";
            this.tabPageConnect.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConnect.Size = new System.Drawing.Size(2247, 1117);
            this.tabPageConnect.TabIndex = 3;
            this.tabPageConnect.Text = "Connect";
            this.tabPageConnect.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPageConnect_Enter);
            // 
            // buttonConnect
            // 
            this.buttonConnect.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonConnect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonConnect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonConnect.Location = new System.Drawing.Point(3, 998);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(2241, 58);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "connect";
            this.buttonConnect.UseVisualStyleBackColor = false;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonDisconnect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonDisconnect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonDisconnect.Location = new System.Drawing.Point(3, 1056);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(2241, 58);
            this.buttonDisconnect.TabIndex = 3;
            this.buttonDisconnect.Text = "disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = false;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.BackColor = System.Drawing.Color.Black;
            this.textBoxStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxStatus.Font = new System.Drawing.Font("Segoe UI Semilight", 15.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxStatus.ForeColor = System.Drawing.Color.Red;
            this.textBoxStatus.Location = new System.Drawing.Point(3, 74);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxStatus.Size = new System.Drawing.Size(2241, 71);
            this.textBoxStatus.TabIndex = 1;
            this.textBoxStatus.Text = "Not Connected";
            this.textBoxStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.BackColor = System.Drawing.Color.Black;
            this.textBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxTitle.Font = new System.Drawing.Font("Segoe UI", 15.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxTitle.ForeColor = System.Drawing.Color.White;
            this.textBoxTitle.Location = new System.Drawing.Point(3, 3);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.ReadOnly = true;
            this.textBoxTitle.Size = new System.Drawing.Size(2241, 71);
            this.textBoxTitle.TabIndex = 0;
            this.textBoxTitle.Text = "Status";
            this.textBoxTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPageMonitoring
            // 
            this.tabPageMonitoring.BackColor = System.Drawing.SystemColors.Desktop;
            this.tabPageMonitoring.Controls.Add(this.guageRPM);
            this.tabPageMonitoring.Controls.Add(this.labelRPM);
            this.tabPageMonitoring.Controls.Add(this.buttonMonitoringTrigger);
            this.tabPageMonitoring.Controls.Add(this.textBoxRPM);
            this.tabPageMonitoring.Controls.Add(this.labelMAF);
            this.tabPageMonitoring.Controls.Add(this.labelSpeed);
            this.tabPageMonitoring.Controls.Add(this.labelTemperature);
            this.tabPageMonitoring.Controls.Add(this.textBoxSpeed);
            this.tabPageMonitoring.Controls.Add(this.textBoxMAF);
            this.tabPageMonitoring.Controls.Add(this.textBoxTemperature);
            this.tabPageMonitoring.Controls.Add(this.labelTPS);
            this.tabPageMonitoring.Controls.Add(this.textBoxTPS);
            this.tabPageMonitoring.Controls.Add(this.guageSpeed);
            this.tabPageMonitoring.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPageMonitoring.ForeColor = System.Drawing.Color.White;
            this.tabPageMonitoring.Location = new System.Drawing.Point(4, 79);
            this.tabPageMonitoring.Name = "tabPageMonitoring";
            this.tabPageMonitoring.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMonitoring.Size = new System.Drawing.Size(2247, 1117);
            this.tabPageMonitoring.TabIndex = 0;
            this.tabPageMonitoring.Text = "Monitor";
            // 
            // guageRPM
            // 
            this.guageRPM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guageRPM.AnimationEnabled = false;
            this.guageRPM.BottomBarHeight = 5;
            this.guageRPM.ErrorLimit = 6000D;
            this.guageRPM.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.guageRPM.FontUnitLabel = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.guageRPM.InfoMode = CodeArtEng.Gauge.GaugeInfoMode.NONE;
            this.guageRPM.InfoPage = CodeArtEng.Gauge.GaugeInfoType.Range;
            this.guageRPM.Location = new System.Drawing.Point(342, 357);
            this.guageRPM.Maximum = 7000D;
            this.guageRPM.Name = "guageRPM";
            this.guageRPM.ScaleFactor = 1D;
            this.guageRPM.SegmentGap = 1;
            this.guageRPM.Size = new System.Drawing.Size(491, 117);
            this.guageRPM.TabIndex = 13;
            this.guageRPM.Theme = CodeArtEng.Gauge.GaugeTheme.DarkBlue;
            this.guageRPM.Title = "";
            this.guageRPM.Unit = "RPM";
            this.guageRPM.UserDefinedColors.Base = themeColors1;
            themeColors2.PointerColor = System.Drawing.Color.Red;
            this.guageRPM.UserDefinedColors.Error = themeColors2;
            themeColors3.PointerColor = System.Drawing.Color.Orange;
            this.guageRPM.UserDefinedColors.Warning = themeColors3;
            this.guageRPM.Value = 0D;
            this.guageRPM.WarningLimit = 5500D;
            // 
            // labelRPM
            // 
            this.labelRPM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelRPM.AutoSize = true;
            this.labelRPM.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRPM.Location = new System.Drawing.Point(542, 111);
            this.labelRPM.Name = "labelRPM";
            this.labelRPM.Size = new System.Drawing.Size(123, 62);
            this.labelRPM.TabIndex = 1;
            this.labelRPM.Text = "RPM";
            // 
            // buttonMonitoringTrigger
            // 
            this.buttonMonitoringTrigger.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonMonitoringTrigger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonMonitoringTrigger.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonMonitoringTrigger.Location = new System.Drawing.Point(990, 880);
            this.buttonMonitoringTrigger.Name = "buttonMonitoringTrigger";
            this.buttonMonitoringTrigger.Size = new System.Drawing.Size(265, 107);
            this.buttonMonitoringTrigger.TabIndex = 10;
            this.buttonMonitoringTrigger.Text = "START";
            this.buttonMonitoringTrigger.UseVisualStyleBackColor = false;
            this.buttonMonitoringTrigger.Click += new System.EventHandler(this.buttonMonitoringTrigger_Click);
            // 
            // textBoxRPM
            // 
            this.textBoxRPM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxRPM.BackColor = System.Drawing.SystemColors.Desktop;
            this.textBoxRPM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxRPM.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxRPM.ForeColor = System.Drawing.Color.White;
            this.textBoxRPM.Location = new System.Drawing.Point(342, 202);
            this.textBoxRPM.Name = "textBoxRPM";
            this.textBoxRPM.ReadOnly = true;
            this.textBoxRPM.Size = new System.Drawing.Size(491, 142);
            this.textBoxRPM.TabIndex = 0;
            this.textBoxRPM.Text = "0";
            this.textBoxRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelMAF
            // 
            this.labelMAF.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelMAF.AutoSize = true;
            this.labelMAF.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMAF.Location = new System.Drawing.Point(1588, 748);
            this.labelMAF.Name = "labelMAF";
            this.labelMAF.Size = new System.Drawing.Size(122, 62);
            this.labelMAF.TabIndex = 9;
            this.labelMAF.Text = "MAF";
            // 
            // labelSpeed
            // 
            this.labelSpeed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSpeed.Location = new System.Drawing.Point(1575, 111);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(158, 62);
            this.labelSpeed.TabIndex = 6;
            this.labelSpeed.Text = "Speed";
            // 
            // labelTemperature
            // 
            this.labelTemperature.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTemperature.AutoSize = true;
            this.labelTemperature.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTemperature.Location = new System.Drawing.Point(990, 111);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(289, 62);
            this.labelTemperature.TabIndex = 8;
            this.labelTemperature.Text = "Temperature";
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxSpeed.BackColor = System.Drawing.SystemColors.Desktop;
            this.textBoxSpeed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSpeed.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxSpeed.ForeColor = System.Drawing.Color.White;
            this.textBoxSpeed.Location = new System.Drawing.Point(1404, 202);
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.ReadOnly = true;
            this.textBoxSpeed.Size = new System.Drawing.Size(491, 142);
            this.textBoxSpeed.TabIndex = 2;
            this.textBoxSpeed.Text = "0";
            this.textBoxSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxMAF
            // 
            this.textBoxMAF.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxMAF.BackColor = System.Drawing.SystemColors.Desktop;
            this.textBoxMAF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMAF.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxMAF.ForeColor = System.Drawing.Color.White;
            this.textBoxMAF.Location = new System.Drawing.Point(1404, 838);
            this.textBoxMAF.Name = "textBoxMAF";
            this.textBoxMAF.ReadOnly = true;
            this.textBoxMAF.Size = new System.Drawing.Size(491, 142);
            this.textBoxMAF.TabIndex = 4;
            this.textBoxMAF.Text = "0";
            this.textBoxMAF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxTemperature
            // 
            this.textBoxTemperature.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxTemperature.BackColor = System.Drawing.SystemColors.Desktop;
            this.textBoxTemperature.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTemperature.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxTemperature.ForeColor = System.Drawing.Color.White;
            this.textBoxTemperature.Location = new System.Drawing.Point(875, 202);
            this.textBoxTemperature.Name = "textBoxTemperature";
            this.textBoxTemperature.ReadOnly = true;
            this.textBoxTemperature.Size = new System.Drawing.Size(491, 142);
            this.textBoxTemperature.TabIndex = 5;
            this.textBoxTemperature.Text = "0";
            this.textBoxTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelTPS
            // 
            this.labelTPS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTPS.AutoSize = true;
            this.labelTPS.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTPS.Location = new System.Drawing.Point(525, 748);
            this.labelTPS.Name = "labelTPS";
            this.labelTPS.Size = new System.Drawing.Size(103, 62);
            this.labelTPS.TabIndex = 7;
            this.labelTPS.Text = "TPS";
            // 
            // textBoxTPS
            // 
            this.textBoxTPS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxTPS.BackColor = System.Drawing.SystemColors.Desktop;
            this.textBoxTPS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTPS.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxTPS.ForeColor = System.Drawing.Color.White;
            this.textBoxTPS.Location = new System.Drawing.Point(342, 838);
            this.textBoxTPS.Name = "textBoxTPS";
            this.textBoxTPS.ReadOnly = true;
            this.textBoxTPS.Size = new System.Drawing.Size(491, 142);
            this.textBoxTPS.TabIndex = 3;
            this.textBoxTPS.Text = "0";
            this.textBoxTPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guageSpeed
            // 
            this.guageSpeed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guageSpeed.AnimationEnabled = false;
            this.guageSpeed.BottomBarHeight = 5;
            this.guageSpeed.ErrorLimit = 250D;
            this.guageSpeed.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.guageSpeed.FontUnitLabel = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.guageSpeed.InfoMode = CodeArtEng.Gauge.GaugeInfoMode.NONE;
            this.guageSpeed.InfoPage = CodeArtEng.Gauge.GaugeInfoType.Range;
            this.guageSpeed.Location = new System.Drawing.Point(1404, 357);
            this.guageSpeed.Maximum = 300D;
            this.guageSpeed.Name = "guageSpeed";
            this.guageSpeed.ScaleFactor = 1D;
            this.guageSpeed.SegmentGap = 1;
            this.guageSpeed.Size = new System.Drawing.Size(491, 117);
            this.guageSpeed.TabIndex = 12;
            this.guageSpeed.Theme = CodeArtEng.Gauge.GaugeTheme.DarkBlue;
            this.guageSpeed.Title = "";
            this.guageSpeed.Unit = "km/h";
            this.guageSpeed.Value = 0D;
            this.guageSpeed.WarningLimit = 200D;
            // 
            // tabPageDiagnosticTroubleCodes
            // 
            this.tabPageDiagnosticTroubleCodes.BackColor = System.Drawing.SystemColors.Desktop;
            this.tabPageDiagnosticTroubleCodes.Controls.Add(this.buttonReload);
            this.tabPageDiagnosticTroubleCodes.Controls.Add(this.listBoxDiagnosticTroubleCodes);
            this.tabPageDiagnosticTroubleCodes.Controls.Add(this.textBox1);
            this.tabPageDiagnosticTroubleCodes.Controls.Add(this.buttonClearCodes);
            this.tabPageDiagnosticTroubleCodes.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPageDiagnosticTroubleCodes.ForeColor = System.Drawing.Color.White;
            this.tabPageDiagnosticTroubleCodes.Location = new System.Drawing.Point(4, 79);
            this.tabPageDiagnosticTroubleCodes.Name = "tabPageDiagnosticTroubleCodes";
            this.tabPageDiagnosticTroubleCodes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDiagnosticTroubleCodes.Size = new System.Drawing.Size(2247, 1117);
            this.tabPageDiagnosticTroubleCodes.TabIndex = 1;
            this.tabPageDiagnosticTroubleCodes.Text = "DTC";
            // 
            // buttonReload
            // 
            this.buttonReload.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonReload.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonReload.Location = new System.Drawing.Point(3, 968);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(2241, 73);
            this.buttonReload.TabIndex = 2;
            this.buttonReload.Text = "Read";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.buttonReload_Click);
            // 
            // listBoxDiagnosticTroubleCodes
            // 
            this.listBoxDiagnosticTroubleCodes.BackColor = System.Drawing.SystemColors.Desktop;
            this.listBoxDiagnosticTroubleCodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxDiagnosticTroubleCodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxDiagnosticTroubleCodes.ForeColor = System.Drawing.Color.White;
            this.listBoxDiagnosticTroubleCodes.FormattingEnabled = true;
            this.listBoxDiagnosticTroubleCodes.ItemHeight = 50;
            this.listBoxDiagnosticTroubleCodes.Location = new System.Drawing.Point(3, 79);
            this.listBoxDiagnosticTroubleCodes.Name = "listBoxDiagnosticTroubleCodes";
            this.listBoxDiagnosticTroubleCodes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBoxDiagnosticTroubleCodes.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxDiagnosticTroubleCodes.Size = new System.Drawing.Size(2241, 962);
            this.listBoxDiagnosticTroubleCodes.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Desktop;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 20.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(2241, 76);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "DIAGNOSTIC CODES";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonClearCodes
            // 
            this.buttonClearCodes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonClearCodes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonClearCodes.Location = new System.Drawing.Point(3, 1041);
            this.buttonClearCodes.Name = "buttonClearCodes";
            this.buttonClearCodes.Size = new System.Drawing.Size(2241, 73);
            this.buttonClearCodes.TabIndex = 3;
            this.buttonClearCodes.Text = "Clear";
            this.buttonClearCodes.UseVisualStyleBackColor = true;
            this.buttonClearCodes.Click += new System.EventHandler(this.buttonClearCodes_Click);
            // 
            // tabPageGraph
            // 
            this.tabPageGraph.BackColor = System.Drawing.SystemColors.Desktop;
            this.tabPageGraph.Controls.Add(this.tableLayoutPanelButtonOrganizer);
            this.tabPageGraph.ForeColor = System.Drawing.Color.White;
            this.tabPageGraph.Location = new System.Drawing.Point(4, 79);
            this.tabPageGraph.Name = "tabPageGraph";
            this.tabPageGraph.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGraph.Size = new System.Drawing.Size(2247, 1117);
            this.tabPageGraph.TabIndex = 2;
            this.tabPageGraph.Text = "Graph";
            // 
            // tableLayoutPanelButtonOrganizer
            // 
            this.tableLayoutPanelButtonOrganizer.ColumnCount = 3;
            this.tableLayoutPanelButtonOrganizer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelButtonOrganizer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanelButtonOrganizer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelButtonOrganizer.Controls.Add(this.buttonOpenOxygenVoltageGraph, 1, 0);
            this.tableLayoutPanelButtonOrganizer.Controls.Add(this.buttonOpenFuelTrimGraph, 0, 0);
            this.tableLayoutPanelButtonOrganizer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelButtonOrganizer.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelButtonOrganizer.Name = "tableLayoutPanelButtonOrganizer";
            this.tableLayoutPanelButtonOrganizer.RowCount = 2;
            this.tableLayoutPanelButtonOrganizer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelButtonOrganizer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelButtonOrganizer.Size = new System.Drawing.Size(2241, 1111);
            this.tableLayoutPanelButtonOrganizer.TabIndex = 5;
            // 
            // buttonOpenOxygenVoltageGraph
            // 
            this.buttonOpenOxygenVoltageGraph.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonOpenOxygenVoltageGraph.BackgroundImage = global::EngineLine.Properties.Resources.O2Icon;
            this.buttonOpenOxygenVoltageGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonOpenOxygenVoltageGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOpenOxygenVoltageGraph.Font = new System.Drawing.Font("Segoe UI", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonOpenOxygenVoltageGraph.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonOpenOxygenVoltageGraph.Location = new System.Drawing.Point(749, 3);
            this.buttonOpenOxygenVoltageGraph.Name = "buttonOpenOxygenVoltageGraph";
            this.buttonOpenOxygenVoltageGraph.Size = new System.Drawing.Size(741, 549);
            this.buttonOpenOxygenVoltageGraph.TabIndex = 4;
            this.buttonOpenOxygenVoltageGraph.Text = "O2 Voltage";
            this.buttonOpenOxygenVoltageGraph.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonOpenOxygenVoltageGraph.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.buttonOpenOxygenVoltageGraph.UseVisualStyleBackColor = false;
            this.buttonOpenOxygenVoltageGraph.Click += new System.EventHandler(this.buttonOpenOxygenVoltageGraph_Click);
            // 
            // buttonOpenFuelTrimGraph
            // 
            this.buttonOpenFuelTrimGraph.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonOpenFuelTrimGraph.BackgroundImage = global::EngineLine.Properties.Resources.FuelIcon;
            this.buttonOpenFuelTrimGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonOpenFuelTrimGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOpenFuelTrimGraph.Font = new System.Drawing.Font("Segoe UI", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonOpenFuelTrimGraph.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonOpenFuelTrimGraph.Location = new System.Drawing.Point(3, 3);
            this.buttonOpenFuelTrimGraph.Name = "buttonOpenFuelTrimGraph";
            this.buttonOpenFuelTrimGraph.Size = new System.Drawing.Size(740, 549);
            this.buttonOpenFuelTrimGraph.TabIndex = 3;
            this.buttonOpenFuelTrimGraph.Text = "Fuel Trim";
            this.buttonOpenFuelTrimGraph.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonOpenFuelTrimGraph.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.buttonOpenFuelTrimGraph.UseVisualStyleBackColor = false;
            this.buttonOpenFuelTrimGraph.Click += new System.EventHandler(this.buttonOpenFuelTrimGraph_Click);
            // 
            // EngineLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(2255, 1200);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EngineLine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EngineLine";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabPageConnect.ResumeLayout(false);
            this.tabPageConnect.PerformLayout();
            this.tabPageMonitoring.ResumeLayout(false);
            this.tabPageMonitoring.PerformLayout();
            this.tabPageDiagnosticTroubleCodes.ResumeLayout(false);
            this.tabPageDiagnosticTroubleCodes.PerformLayout();
            this.tabPageGraph.ResumeLayout(false);
            this.tableLayoutPanelButtonOrganizer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPageMonitoring;
        private Label labelRPM;
        private Button buttonMonitoringTrigger;
        private TextBox textBoxRPM;
        private Label labelMAF;
        private Label labelSpeed;
        private Label labelTemperature;
        private TextBox textBoxSpeed;
        private TextBox textBoxMAF;
        private TextBox textBoxTemperature;
        private Label labelTPS;
        private TextBox textBoxTPS;
        private TabPage tabPageDiagnosticTroubleCodes;
        private Button buttonReload;
        private ListBox listBoxDiagnosticTroubleCodes;
        private TextBox textBox1;
        private Button buttonClearCodes;
        private LinearGauge guageSpeed;
        private LinearGauge guageRPM;
        private TabPage tabPageGraph;
        private Button buttonOpenFuelTrimGraph;
        private TableLayoutPanel tableLayoutPanelButtonOrganizer;
        private Button buttonOpenOxygenVoltageGraph;
        private TabPage tabPageConnect;
        private Button buttonConnect;
        private TextBox textBoxStatus;
        private TextBox textBoxTitle;
        private Button buttonDisconnect;
    }
}