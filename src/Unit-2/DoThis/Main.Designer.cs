namespace ChartApp
{
    partial class Main
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
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
      this.sysChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.diskBtn = new System.Windows.Forms.Button();
      this.memoryBtn = new System.Windows.Forms.Button();
      this.cpuBtn = new System.Windows.Forms.Button();
      this.pauseBtn = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.sysChart)).BeginInit();
      this.SuspendLayout();
      // 
      // sysChart
      // 
      chartArea1.Name = "ChartArea1";
      this.sysChart.ChartAreas.Add(chartArea1);
      this.sysChart.Dock = System.Windows.Forms.DockStyle.Fill;
      legend1.Name = "Legend1";
      this.sysChart.Legends.Add(legend1);
      this.sysChart.Location = new System.Drawing.Point(0, 0);
      this.sysChart.Name = "sysChart";
      series1.ChartArea = "ChartArea1";
      series1.Legend = "Legend1";
      series1.Name = "Series1";
      this.sysChart.Series.Add(series1);
      this.sysChart.Size = new System.Drawing.Size(684, 446);
      this.sysChart.TabIndex = 0;
      this.sysChart.Text = "sysChart";
      // 
      // diskBtn
      // 
      this.diskBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.diskBtn.Location = new System.Drawing.Point(556, 366);
      this.diskBtn.Name = "diskBtn";
      this.diskBtn.Size = new System.Drawing.Size(116, 39);
      this.diskBtn.TabIndex = 1;
      this.diskBtn.Text = "DISK (OFF)";
      this.diskBtn.UseVisualStyleBackColor = true;
      this.diskBtn.Click += new System.EventHandler(this.diskBtn_Click);
      // 
      // memoryBtn
      // 
      this.memoryBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.memoryBtn.Location = new System.Drawing.Point(556, 321);
      this.memoryBtn.Name = "memoryBtn";
      this.memoryBtn.Size = new System.Drawing.Size(116, 39);
      this.memoryBtn.TabIndex = 2;
      this.memoryBtn.Text = "MEMORY (OFF)";
      this.memoryBtn.UseVisualStyleBackColor = true;
      this.memoryBtn.Click += new System.EventHandler(this.memoryBtn_Click);
      // 
      // cpuBtn
      // 
      this.cpuBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cpuBtn.Location = new System.Drawing.Point(556, 276);
      this.cpuBtn.Name = "cpuBtn";
      this.cpuBtn.Size = new System.Drawing.Size(116, 39);
      this.cpuBtn.TabIndex = 3;
      this.cpuBtn.Text = "CPU (ON)";
      this.cpuBtn.UseVisualStyleBackColor = true;
      this.cpuBtn.Click += new System.EventHandler(this.cpuBtn_Click);
      // 
      // pauseBtn
      // 
      this.pauseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.pauseBtn.Location = new System.Drawing.Point(556, 209);
      this.pauseBtn.Name = "pauseBtn";
      this.pauseBtn.Size = new System.Drawing.Size(116, 37);
      this.pauseBtn.TabIndex = 4;
      this.pauseBtn.Text = "Pause ll";
      this.pauseBtn.UseVisualStyleBackColor = true;
      this.pauseBtn.Click += new System.EventHandler(this.pauseBtn_Click);
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(684, 446);
      this.Controls.Add(this.pauseBtn);
      this.Controls.Add(this.cpuBtn);
      this.Controls.Add(this.memoryBtn);
      this.Controls.Add(this.diskBtn);
      this.Controls.Add(this.sysChart);
      this.Name = "Main";
      this.Text = "System Metrics";
      this.Load += new System.EventHandler(this.Main_Load);
      ((System.ComponentModel.ISupportInitialize)(this.sysChart)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart sysChart;
        private System.Windows.Forms.Button diskBtn;
        private System.Windows.Forms.Button memoryBtn;
        private System.Windows.Forms.Button cpuBtn;
        private System.Windows.Forms.Button pauseBtn;
    }
}

