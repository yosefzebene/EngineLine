namespace EngineLine.GraphForms
{
    partial class FuelTrimGraph
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
            this.plotView = new OxyPlot.WindowsForms.PlotView();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // plotView
            // 
            this.plotView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotView.Location = new System.Drawing.Point(0, 0);
            this.plotView.Name = "plotView";
            this.plotView.PanCursor = System.Windows.Forms.Cursors.PanWest;
            this.plotView.Size = new System.Drawing.Size(2069, 1087);
            this.plotView.TabIndex = 1;
            this.plotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.PanWest;
            this.plotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.No;
            this.plotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.No;
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonStartStop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonStartStop.Location = new System.Drawing.Point(0, 1029);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(2069, 58);
            this.buttonStartStop.TabIndex = 3;
            this.buttonStartStop.Text = "Start";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
            // 
            // FuelTrimGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(2069, 1087);
            this.Controls.Add(this.buttonStartStop);
            this.Controls.Add(this.plotView);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FuelTrimGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fuel Trims";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FuelTrimGraph_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private OxyPlot.WindowsForms.PlotView plotView;
        private Button buttonStartStop;
        private System.Windows.Forms.Timer timer;
    }
}