namespace EngineLine
{
    partial class Connecting
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
            this.labelOBDProtocol = new System.Windows.Forms.Label();
            this.groupBoxSerialSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxDefaultBaud = new System.Windows.Forms.CheckBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.comboBoxCOMPort = new System.Windows.Forms.ComboBox();
            this.labelBaudRate = new System.Windows.Forms.Label();
            this.labelCOMPort = new System.Windows.Forms.Label();
            this.comboBoxOBDProtocol = new System.Windows.Forms.ComboBox();
            this.groupBoxSerialSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelOBDProtocol
            // 
            this.labelOBDProtocol.AutoSize = true;
            this.labelOBDProtocol.Location = new System.Drawing.Point(121, 162);
            this.labelOBDProtocol.Name = "labelOBDProtocol";
            this.labelOBDProtocol.Size = new System.Drawing.Size(235, 41);
            this.labelOBDProtocol.TabIndex = 0;
            this.labelOBDProtocol.Text = "OBD-II protocol:";
            // 
            // groupBoxSerialSettings
            // 
            this.groupBoxSerialSettings.Controls.Add(this.checkBoxDefaultBaud);
            this.groupBoxSerialSettings.Controls.Add(this.buttonConnect);
            this.groupBoxSerialSettings.Controls.Add(this.comboBoxBaudRate);
            this.groupBoxSerialSettings.Controls.Add(this.comboBoxCOMPort);
            this.groupBoxSerialSettings.Controls.Add(this.labelBaudRate);
            this.groupBoxSerialSettings.Controls.Add(this.labelCOMPort);
            this.groupBoxSerialSettings.Location = new System.Drawing.Point(121, 297);
            this.groupBoxSerialSettings.Name = "groupBoxSerialSettings";
            this.groupBoxSerialSettings.Size = new System.Drawing.Size(856, 522);
            this.groupBoxSerialSettings.TabIndex = 1;
            this.groupBoxSerialSettings.TabStop = false;
            this.groupBoxSerialSettings.Text = "Serial port settings";
            // 
            // checkBoxDefaultBaud
            // 
            this.checkBoxDefaultBaud.AutoSize = true;
            this.checkBoxDefaultBaud.Checked = true;
            this.checkBoxDefaultBaud.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDefaultBaud.Location = new System.Drawing.Point(252, 277);
            this.checkBoxDefaultBaud.Name = "checkBoxDefaultBaud";
            this.checkBoxDefaultBaud.Size = new System.Drawing.Size(341, 45);
            this.checkBoxDefaultBaud.TabIndex = 5;
            this.checkBoxDefaultBaud.Text = "Use default baud rate";
            this.checkBoxDefaultBaud.UseVisualStyleBackColor = true;
            this.checkBoxDefaultBaud.CheckedChanged += new System.EventHandler(this.checkBoxDefaultBaud_CheckedChanged);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(283, 380);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(297, 108);
            this.buttonConnect.TabIndex = 4;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.Enabled = false;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Location = new System.Drawing.Point(252, 200);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(537, 49);
            this.comboBoxBaudRate.TabIndex = 3;
            // 
            // comboBoxCOMPort
            // 
            this.comboBoxCOMPort.FormattingEnabled = true;
            this.comboBoxCOMPort.Location = new System.Drawing.Point(252, 99);
            this.comboBoxCOMPort.Name = "comboBoxCOMPort";
            this.comboBoxCOMPort.Size = new System.Drawing.Size(537, 49);
            this.comboBoxCOMPort.TabIndex = 2;
            // 
            // labelBaudRate
            // 
            this.labelBaudRate.AutoSize = true;
            this.labelBaudRate.Location = new System.Drawing.Point(45, 203);
            this.labelBaudRate.Name = "labelBaudRate";
            this.labelBaudRate.Size = new System.Drawing.Size(151, 41);
            this.labelBaudRate.TabIndex = 1;
            this.labelBaudRate.Text = "Baud rate:";
            // 
            // labelCOMPort
            // 
            this.labelCOMPort.AutoSize = true;
            this.labelCOMPort.Location = new System.Drawing.Point(45, 102);
            this.labelCOMPort.Name = "labelCOMPort";
            this.labelCOMPort.Size = new System.Drawing.Size(155, 41);
            this.labelCOMPort.TabIndex = 0;
            this.labelCOMPort.Text = "COM Port:";
            // 
            // comboBoxOBDProtocol
            // 
            this.comboBoxOBDProtocol.FormattingEnabled = true;
            this.comboBoxOBDProtocol.Location = new System.Drawing.Point(373, 159);
            this.comboBoxOBDProtocol.Name = "comboBoxOBDProtocol";
            this.comboBoxOBDProtocol.Size = new System.Drawing.Size(604, 49);
            this.comboBoxOBDProtocol.TabIndex = 2;
            // 
            // Connecting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 874);
            this.Controls.Add(this.comboBoxOBDProtocol);
            this.Controls.Add(this.groupBoxSerialSettings);
            this.Controls.Add(this.labelOBDProtocol);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Connecting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect OBD2";
            this.Load += new System.EventHandler(this.Connecting_Load);
            this.groupBoxSerialSettings.ResumeLayout(false);
            this.groupBoxSerialSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelOBDProtocol;
        private GroupBox groupBoxSerialSettings;
        private ComboBox comboBoxBaudRate;
        private ComboBox comboBoxCOMPort;
        private Label labelBaudRate;
        private Label labelCOMPort;
        private ComboBox comboBoxOBDProtocol;
        private Button buttonConnect;
        protected internal CheckBox checkBoxDefaultBaud;
    }
}