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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OnConnectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMonitoringInfo = new System.Windows.Forms.Panel();
            this.buttonMonitoringTrigger = new System.Windows.Forms.Button();
            this.labelMAF = new System.Windows.Forms.Label();
            this.labelTempreture = new System.Windows.Forms.Label();
            this.labelTPS = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.textBoxTempreture = new System.Windows.Forms.TextBox();
            this.textBoxMAF = new System.Windows.Forms.TextBox();
            this.textBoxTPS = new System.Windows.Forms.TextBox();
            this.textBoxSpeed = new System.Windows.Forms.TextBox();
            this.labelRPM = new System.Windows.Forms.Label();
            this.textBoxRPM = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.panelMonitoringInfo.SuspendLayout();
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
            // panelMonitoringInfo
            // 
            this.panelMonitoringInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelMonitoringInfo.Controls.Add(this.buttonMonitoringTrigger);
            this.panelMonitoringInfo.Controls.Add(this.labelMAF);
            this.panelMonitoringInfo.Controls.Add(this.labelTempreture);
            this.panelMonitoringInfo.Controls.Add(this.labelTPS);
            this.panelMonitoringInfo.Controls.Add(this.labelSpeed);
            this.panelMonitoringInfo.Controls.Add(this.textBoxTempreture);
            this.panelMonitoringInfo.Controls.Add(this.textBoxMAF);
            this.panelMonitoringInfo.Controls.Add(this.textBoxTPS);
            this.panelMonitoringInfo.Controls.Add(this.textBoxSpeed);
            this.panelMonitoringInfo.Controls.Add(this.labelRPM);
            this.panelMonitoringInfo.Controls.Add(this.textBoxRPM);
            this.panelMonitoringInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMonitoringInfo.Location = new System.Drawing.Point(0, 49);
            this.panelMonitoringInfo.Name = "panelMonitoringInfo";
            this.panelMonitoringInfo.Size = new System.Drawing.Size(2255, 1151);
            this.panelMonitoringInfo.TabIndex = 2;
            // 
            // buttonMonitoringTrigger
            // 
            this.buttonMonitoringTrigger.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonMonitoringTrigger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonMonitoringTrigger.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonMonitoringTrigger.Location = new System.Drawing.Point(950, 976);
            this.buttonMonitoringTrigger.Name = "buttonMonitoringTrigger";
            this.buttonMonitoringTrigger.Size = new System.Drawing.Size(250, 107);
            this.buttonMonitoringTrigger.TabIndex = 10;
            this.buttonMonitoringTrigger.Text = "START";
            this.buttonMonitoringTrigger.UseVisualStyleBackColor = false;
            this.buttonMonitoringTrigger.Click += new System.EventHandler(this.buttonMonitoringTrigger_Click);
            // 
            // labelMAF
            // 
            this.labelMAF.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelMAF.AutoSize = true;
            this.labelMAF.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMAF.Location = new System.Drawing.Point(1409, 653);
            this.labelMAF.Name = "labelMAF";
            this.labelMAF.Size = new System.Drawing.Size(122, 62);
            this.labelMAF.TabIndex = 9;
            this.labelMAF.Text = "MAF";
            // 
            // labelTempreture
            // 
            this.labelTempreture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTempreture.AutoSize = true;
            this.labelTempreture.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTempreture.Location = new System.Drawing.Point(604, 653);
            this.labelTempreture.Name = "labelTempreture";
            this.labelTempreture.Size = new System.Drawing.Size(265, 62);
            this.labelTempreture.TabIndex = 8;
            this.labelTempreture.Text = "Tempreture";
            // 
            // labelTPS
            // 
            this.labelTPS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTPS.AutoSize = true;
            this.labelTPS.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTPS.Location = new System.Drawing.Point(1675, 202);
            this.labelTPS.Name = "labelTPS";
            this.labelTPS.Size = new System.Drawing.Size(103, 62);
            this.labelTPS.TabIndex = 7;
            this.labelTPS.Text = "TPS";
            // 
            // labelSpeed
            // 
            this.labelSpeed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSpeed.Location = new System.Drawing.Point(1008, 202);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(158, 62);
            this.labelSpeed.TabIndex = 6;
            this.labelSpeed.Text = "Speed";
            // 
            // textBoxTempreture
            // 
            this.textBoxTempreture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxTempreture.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxTempreture.Location = new System.Drawing.Point(472, 718);
            this.textBoxTempreture.Name = "textBoxTempreture";
            this.textBoxTempreture.ReadOnly = true;
            this.textBoxTempreture.Size = new System.Drawing.Size(491, 149);
            this.textBoxTempreture.TabIndex = 5;
            this.textBoxTempreture.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxMAF
            // 
            this.textBoxMAF.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxMAF.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxMAF.Location = new System.Drawing.Point(1215, 718);
            this.textBoxMAF.Name = "textBoxMAF";
            this.textBoxMAF.ReadOnly = true;
            this.textBoxMAF.Size = new System.Drawing.Size(491, 149);
            this.textBoxMAF.TabIndex = 4;
            this.textBoxMAF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxTPS
            // 
            this.textBoxTPS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxTPS.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxTPS.Location = new System.Drawing.Point(1471, 263);
            this.textBoxTPS.Name = "textBoxTPS";
            this.textBoxTPS.ReadOnly = true;
            this.textBoxTPS.Size = new System.Drawing.Size(491, 149);
            this.textBoxTPS.TabIndex = 3;
            this.textBoxTPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxSpeed.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxSpeed.Location = new System.Drawing.Point(830, 263);
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.ReadOnly = true;
            this.textBoxSpeed.Size = new System.Drawing.Size(491, 149);
            this.textBoxSpeed.TabIndex = 2;
            this.textBoxSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelRPM
            // 
            this.labelRPM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelRPM.AutoSize = true;
            this.labelRPM.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRPM.Location = new System.Drawing.Point(461, 202);
            this.labelRPM.Name = "labelRPM";
            this.labelRPM.Size = new System.Drawing.Size(123, 62);
            this.labelRPM.TabIndex = 1;
            this.labelRPM.Text = "RPM";
            // 
            // textBoxRPM
            // 
            this.textBoxRPM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxRPM.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxRPM.Location = new System.Drawing.Point(267, 263);
            this.textBoxRPM.Name = "textBoxRPM";
            this.textBoxRPM.ReadOnly = true;
            this.textBoxRPM.Size = new System.Drawing.Size(491, 149);
            this.textBoxRPM.TabIndex = 0;
            this.textBoxRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EngineLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2255, 1200);
            this.Controls.Add(this.panelMonitoringInfo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EngineLine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EngineLine";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelMonitoringInfo.ResumeLayout(false);
            this.panelMonitoringInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem OnConnectionMenuItem;
        private Panel panelMonitoringInfo;
        private Label labelRPM;
        private TextBox textBoxRPM;
        private TextBox textBoxSpeed;
        private TextBox textBoxTPS;
        private TextBox textBoxMAF;
        private TextBox textBoxTempreture;
        private Label labelSpeed;
        private Label labelTPS;
        private Label labelTempreture;
        private Label labelMAF;
        private Button buttonMonitoringTrigger;
    }
}