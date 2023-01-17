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
            this.plotViewS1B1.Size = new System.Drawing.Size(2075, 575);
            this.plotViewS1B1.TabIndex = 2;
            this.plotViewS1B1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.PanWest;
            this.plotViewS1B1.ZoomRectangleCursor = System.Windows.Forms.Cursors.No;
            this.plotViewS1B1.ZoomVerticalCursor = System.Windows.Forms.Cursors.No;
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonStartStop.Location = new System.Drawing.Point(0, 1163);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(2081, 58);
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
            this.tableLayoutPanelO2SensorGraphs.ColumnCount = 1;
            this.tableLayoutPanelO2SensorGraphs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelO2SensorGraphs.Controls.Add(this.plotViewS1B1, 0, 0);
            this.tableLayoutPanelO2SensorGraphs.Controls.Add(this.plotViewS2B1, 0, 1);
            this.tableLayoutPanelO2SensorGraphs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelO2SensorGraphs.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelO2SensorGraphs.Name = "tableLayoutPanelO2SensorGraphs";
            this.tableLayoutPanelO2SensorGraphs.RowCount = 2;
            this.tableLayoutPanelO2SensorGraphs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelO2SensorGraphs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelO2SensorGraphs.Size = new System.Drawing.Size(2081, 1163);
            this.tableLayoutPanelO2SensorGraphs.TabIndex = 5;
            // 
            // plotViewS2B1
            // 
            this.plotViewS2B1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotViewS2B1.Location = new System.Drawing.Point(3, 584);
            this.plotViewS2B1.Name = "plotViewS2B1";
            this.plotViewS2B1.PanCursor = System.Windows.Forms.Cursors.PanWest;
            this.plotViewS2B1.Size = new System.Drawing.Size(2075, 576);
            this.plotViewS2B1.TabIndex = 3;
            this.plotViewS2B1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.PanWest;
            this.plotViewS2B1.ZoomRectangleCursor = System.Windows.Forms.Cursors.No;
            this.plotViewS2B1.ZoomVerticalCursor = System.Windows.Forms.Cursors.No;
            // 
            // OxygenVoltageGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2081, 1221);
            this.Controls.Add(this.tableLayoutPanelO2SensorGraphs);
            this.Controls.Add(this.buttonStartStop);
            this.Name = "OxygenVoltageGraph";
            this.Text = "OxygenVoltageGraph";
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
    }
}