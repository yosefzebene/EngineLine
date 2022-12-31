using CodeArtEng.Gauge;

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
            CodeArtEng.Gauge.Themes.ThemeColors themeColors4 = new CodeArtEng.Gauge.Themes.ThemeColors();
            CodeArtEng.Gauge.Themes.ThemeColors themeColors5 = new CodeArtEng.Gauge.Themes.ThemeColors();
            CodeArtEng.Gauge.Themes.ThemeColors themeColors6 = new CodeArtEng.Gauge.Themes.ThemeColors();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OnConnectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
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
            this.tabPageEngineCodes = new System.Windows.Forms.TabPage();
            this.buttonClearCodes = new System.Windows.Forms.Button();
            this.buttonReload = new System.Windows.Forms.Button();
            this.listBoxEngineCodes = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageMonitoring.SuspendLayout();
            this.tabPageEngineCodes.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OnConnectionMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2255, 49);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OnConnectionMenuItem
            // 
            this.OnConnectionMenuItem.Name = "OnConnectionMenuItem";
            this.OnConnectionMenuItem.Size = new System.Drawing.Size(153, 45);
            this.OnConnectionMenuItem.Text = "Connect";
            this.OnConnectionMenuItem.Click += new System.EventHandler(this.OnConnectionMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageMonitoring);
            this.tabControl1.Controls.Add(this.tabPageEngineCodes);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 49);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2255, 1151);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPageMonitoring
            // 
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
            this.tabPageMonitoring.Location = new System.Drawing.Point(10, 58);
            this.tabPageMonitoring.Name = "tabPageMonitoring";
            this.tabPageMonitoring.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMonitoring.Size = new System.Drawing.Size(2235, 1083);
            this.tabPageMonitoring.TabIndex = 0;
            this.tabPageMonitoring.Text = "Monitor";
            this.tabPageMonitoring.UseVisualStyleBackColor = true;
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
            this.guageRPM.Location = new System.Drawing.Point(354, 334);
            this.guageRPM.Maximum = 7000D;
            this.guageRPM.Name = "guageRPM";
            this.guageRPM.ScaleFactor = 1D;
            this.guageRPM.SegmentGap = 1;
            this.guageRPM.Size = new System.Drawing.Size(491, 117);
            this.guageRPM.TabIndex = 13;
            this.guageRPM.Theme = CodeArtEng.Gauge.GaugeTheme.DarkBlue;
            this.guageRPM.Title = "";
            this.guageRPM.Unit = "RPM";
            this.guageRPM.UserDefinedColors.Base = themeColors4;
            themeColors5.PointerColor = System.Drawing.Color.Red;
            this.guageRPM.UserDefinedColors.Error = themeColors5;
            themeColors6.PointerColor = System.Drawing.Color.Orange;
            this.guageRPM.UserDefinedColors.Warning = themeColors6;
            this.guageRPM.Value = 0D;
            this.guageRPM.WarningLimit = 5500D;
            // 
            // labelRPM
            // 
            this.labelRPM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelRPM.AutoSize = true;
            this.labelRPM.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRPM.Location = new System.Drawing.Point(554, 88);
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
            this.buttonMonitoringTrigger.Location = new System.Drawing.Point(1002, 857);
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
            this.textBoxRPM.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxRPM.Location = new System.Drawing.Point(354, 179);
            this.textBoxRPM.Name = "textBoxRPM";
            this.textBoxRPM.ReadOnly = true;
            this.textBoxRPM.Size = new System.Drawing.Size(491, 149);
            this.textBoxRPM.TabIndex = 0;
            this.textBoxRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelMAF
            // 
            this.labelMAF.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelMAF.AutoSize = true;
            this.labelMAF.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMAF.Location = new System.Drawing.Point(1600, 725);
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
            this.labelSpeed.Location = new System.Drawing.Point(1587, 88);
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
            this.labelTemperature.Location = new System.Drawing.Point(1002, 88);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(289, 62);
            this.labelTemperature.TabIndex = 8;
            this.labelTemperature.Text = "Temperature";
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxSpeed.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxSpeed.Location = new System.Drawing.Point(1416, 179);
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.ReadOnly = true;
            this.textBoxSpeed.Size = new System.Drawing.Size(491, 149);
            this.textBoxSpeed.TabIndex = 2;
            this.textBoxSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxMAF
            // 
            this.textBoxMAF.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxMAF.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxMAF.Location = new System.Drawing.Point(1416, 815);
            this.textBoxMAF.Name = "textBoxMAF";
            this.textBoxMAF.ReadOnly = true;
            this.textBoxMAF.Size = new System.Drawing.Size(491, 149);
            this.textBoxMAF.TabIndex = 4;
            this.textBoxMAF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxTemperature
            // 
            this.textBoxTemperature.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxTemperature.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxTemperature.Location = new System.Drawing.Point(887, 179);
            this.textBoxTemperature.Name = "textBoxTemperature";
            this.textBoxTemperature.ReadOnly = true;
            this.textBoxTemperature.Size = new System.Drawing.Size(491, 149);
            this.textBoxTemperature.TabIndex = 5;
            this.textBoxTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelTPS
            // 
            this.labelTPS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTPS.AutoSize = true;
            this.labelTPS.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTPS.Location = new System.Drawing.Point(537, 725);
            this.labelTPS.Name = "labelTPS";
            this.labelTPS.Size = new System.Drawing.Size(103, 62);
            this.labelTPS.TabIndex = 7;
            this.labelTPS.Text = "TPS";
            // 
            // textBoxTPS
            // 
            this.textBoxTPS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxTPS.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxTPS.Location = new System.Drawing.Point(354, 815);
            this.textBoxTPS.Name = "textBoxTPS";
            this.textBoxTPS.ReadOnly = true;
            this.textBoxTPS.Size = new System.Drawing.Size(491, 149);
            this.textBoxTPS.TabIndex = 3;
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
            this.guageSpeed.Location = new System.Drawing.Point(1416, 334);
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
            // tabPageEngineCodes
            // 
            this.tabPageEngineCodes.Controls.Add(this.buttonClearCodes);
            this.tabPageEngineCodes.Controls.Add(this.buttonReload);
            this.tabPageEngineCodes.Controls.Add(this.listBoxEngineCodes);
            this.tabPageEngineCodes.Controls.Add(this.textBox1);
            this.tabPageEngineCodes.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPageEngineCodes.Location = new System.Drawing.Point(10, 58);
            this.tabPageEngineCodes.Name = "tabPageEngineCodes";
            this.tabPageEngineCodes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEngineCodes.Size = new System.Drawing.Size(2235, 1083);
            this.tabPageEngineCodes.TabIndex = 1;
            this.tabPageEngineCodes.Text = "Engine Codes";
            this.tabPageEngineCodes.UseVisualStyleBackColor = true;
            // 
            // buttonClearCodes
            // 
            this.buttonClearCodes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonClearCodes.Location = new System.Drawing.Point(2075, 977);
            this.buttonClearCodes.Name = "buttonClearCodes";
            this.buttonClearCodes.Size = new System.Drawing.Size(144, 73);
            this.buttonClearCodes.TabIndex = 3;
            this.buttonClearCodes.Text = "Clear";
            this.buttonClearCodes.UseVisualStyleBackColor = true;
            this.buttonClearCodes.Click += new System.EventHandler(this.buttonClearCodes_Click);
            // 
            // buttonReload
            // 
            this.buttonReload.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonReload.Location = new System.Drawing.Point(1915, 977);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(144, 73);
            this.buttonReload.TabIndex = 2;
            this.buttonReload.Text = "Read";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.buttonReload_Click);
            // 
            // listBoxEngineCodes
            // 
            this.listBoxEngineCodes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.listBoxEngineCodes.FormattingEnabled = true;
            this.listBoxEngineCodes.ItemHeight = 50;
            this.listBoxEngineCodes.Location = new System.Drawing.Point(3, 76);
            this.listBoxEngineCodes.Name = "listBoxEngineCodes";
            this.listBoxEngineCodes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBoxEngineCodes.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxEngineCodes.Size = new System.Drawing.Size(2229, 1004);
            this.listBoxEngineCodes.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 20.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(2229, 76);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "DIAGNOSTIC CODES";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EngineLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2255, 1200);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EngineLine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EngineLine";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageMonitoring.ResumeLayout(false);
            this.tabPageMonitoring.PerformLayout();
            this.tabPageEngineCodes.ResumeLayout(false);
            this.tabPageEngineCodes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem OnConnectionMenuItem;
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
        private TabPage tabPageEngineCodes;
        private Button buttonReload;
        private ListBox listBoxEngineCodes;
        private TextBox textBox1;
        private Button buttonClearCodes;
        private LinearGauge guageSpeed;
        private LinearGauge guageRPM;
    }
}