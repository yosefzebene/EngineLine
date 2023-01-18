namespace EngineLine.GraphForms
{
    partial class OxygenVoltageGraph
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
            this.components = new System.ComponentModel.Container();
            this.plotViewS1B1 = new OxyPlot.WindowsForms.PlotView();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.graphTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanelO2SensorGraphs = new System.Windows.Forms.TableLayoutPanel();
            this.plotViewS2B2 = new OxyPlot.WindowsForms.PlotView();
            this.plotViewS1B2 = new OxyPlot.WindowsForms.PlotView();
            this.plotViewS2B1 = new OxyPlot.WindowsForms.PlotView();
            this.tableLayoutPanelO2SensorGraphs.SuspendLayout();
            this.SuspendLayout();
            // 
            // plotViewS1B1
            // 
            this.plotViewS1B1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotViewS1B1.Location = new System.Drawing.Point(3, 3);
            this.plotViewS1B1.Name = "plotViewS1B1";
            this.plotViewS1B1.PanCursor = System.Windows.Forms.Cursors.PanWest;
            this.plotViewS1B1.Size = new System.Drawing.Size(2659, 351);
            this.plotViewS1B1.TabIndex = 2;
            this.plotViewS1B1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.PanWest;
            this.plotViewS1B1.ZoomRectangleCursor = System.Windows.Forms.Cursors.No;
            this.plotViewS1B1.ZoomVerticalCursor = System.Windows.Forms.Cursors.No;
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonStartStop.Location = new System.Drawing.Point(0, 1430);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(2665, 58);
            this.buttonStartStop.TabIndex = 4;
            this.buttonStartStop.Text = "Start";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
            // 
            // graphTimer
            // 
            this.graphTimer.Tick += new System.EventHandler(this.graphTimer_Tick);
            // 
            // tableLayoutPanelO2SensorGraphs
            // 
            this.tableLayoutPanelO2SensorGraphs.BackColor = System.Drawing.SystemColors.Desktop;
            this.tableLayoutPanelO2SensorGraphs.ColumnCount = 1;
            this.tableLayoutPanelO2SensorGraphs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelO2SensorGraphs.Controls.Add(this.plotViewS2B2, 0, 3);
            this.tableLayoutPanelO2SensorGraphs.Controls.Add(this.plotViewS1B2, 0, 2);
            this.tableLayoutPanelO2SensorGraphs.Controls.Add(this.plotViewS1B1, 0, 0);
            this.tableLayoutPanelO2SensorGraphs.Controls.Add(this.plotViewS2B1, 0, 1);
            this.tableLayoutPanelO2SensorGraphs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelO2SensorGraphs.ForeColor = System.Drawing.Color.White;
            this.tableLayoutPanelO2SensorGraphs.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelO2SensorGraphs.Name = "tableLayoutPanelO2SensorGraphs";
            this.tableLayoutPanelO2SensorGraphs.RowCount = 4;
            this.tableLayoutPanelO2SensorGraphs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelO2SensorGraphs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelO2SensorGraphs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelO2SensorGraphs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelO2SensorGraphs.Size = new System.Drawing.Size(2665, 1430);
            this.tableLayoutPanelO2SensorGraphs.TabIndex = 5;
            // 
            // plotViewS2B2
            // 
            this.plotViewS2B2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotViewS2B2.Location = new System.Drawing.Point(3, 1074);
            this.plotViewS2B2.Name = "plotViewS2B2";
            this.plotViewS2B2.PanCursor = System.Windows.Forms.Cursors.PanWest;
            this.plotViewS2B2.Size = new System.Drawing.Size(2659, 353);
            this.plotViewS2B2.TabIndex = 5;
            this.plotViewS2B2.ZoomHorizontalCursor = System.Windows.Forms.Cursors.PanWest;
            this.plotViewS2B2.ZoomRectangleCursor = System.Windows.Forms.Cursors.No;
            this.plotViewS2B2.ZoomVerticalCursor = System.Windows.Forms.Cursors.No;
            // 
            // plotViewS1B2
            // 
            this.plotViewS1B2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotViewS1B2.Location = new System.Drawing.Point(3, 717);
            this.plotViewS1B2.Name = "plotViewS1B2";
            this.plotViewS1B2.PanCursor = System.Windows.Forms.Cursors.PanWest;
            this.plotViewS1B2.Size = new System.Drawing.Size(2659, 351);
            this.plotViewS1B2.TabIndex = 4;
            this.plotViewS1B2.ZoomHorizontalCursor = System.Windows.Forms.Cursors.PanWest;
            this.plotViewS1B2.ZoomRectangleCursor = System.Windows.Forms.Cursors.No;
            this.plotViewS1B2.ZoomVerticalCursor = System.Windows.Forms.Cursors.No;
            // 
            // plotViewS2B1
            // 
            this.plotViewS2B1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotViewS2B1.Location = new System.Drawing.Point(3, 360);
            this.plotViewS2B1.Name = "plotViewS2B1";
            this.plotViewS2B1.PanCursor = System.Windows.Forms.Cursors.PanWest;
            this.plotViewS2B1.Size = new System.Drawing.Size(2659, 351);
            this.plotViewS2B1.TabIndex = 3;
            this.plotViewS2B1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.PanWest;
            this.plotViewS2B1.ZoomRectangleCursor = System.Windows.Forms.Cursors.No;
            this.plotViewS2B1.ZoomVerticalCursor = System.Windows.Forms.Cursors.No;
            // 
            // OxygenVoltageGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2665, 1488);
            this.Controls.Add(this.tableLayoutPanelO2SensorGraphs);
            this.Controls.Add(this.buttonStartStop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "OxygenVoltageGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Oxygen Voltage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OxygenVoltageGraph_FormClosing);
            this.tableLayoutPanelO2SensorGraphs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OxyPlot.WindowsForms.PlotView plotViewS1B1;
        private Button buttonStartStop;
        private System.Windows.Forms.Timer graphTimer;
        private TableLayoutPanel tableLayoutPanelO2SensorGraphs;
        private OxyPlot.WindowsForms.PlotView plotViewS2B1;
        private OxyPlot.WindowsForms.PlotView plotViewS2B2;
        private OxyPlot.WindowsForms.PlotView plotViewS1B2;
    }
}