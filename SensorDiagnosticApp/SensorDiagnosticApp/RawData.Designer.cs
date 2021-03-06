namespace SensorDiagnosticApp
{
    partial class RawData
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.rawDataGridView = new System.Windows.Forms.DataGridView();
            this.chartStddr = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.chartRstddr = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMaxRate = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartAverage = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.rawDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStddr)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRstddr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMaxRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAverage)).BeginInit();
            this.SuspendLayout();
            // 
            // rawDataGridView
            // 
            this.rawDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rawDataGridView.Location = new System.Drawing.Point(12, 12);
            this.rawDataGridView.Name = "rawDataGridView";
            this.rawDataGridView.Size = new System.Drawing.Size(392, 423);
            this.rawDataGridView.TabIndex = 0;
            // 
            // chartStddr
            // 
            chartArea1.Name = "ChartArea1";
            this.chartStddr.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartStddr.Legends.Add(legend1);
            this.chartStddr.Location = new System.Drawing.Point(6, 6);
            this.chartStddr.Name = "chartStddr";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartStddr.Series.Add(series1);
            this.chartStddr.Size = new System.Drawing.Size(593, 385);
            this.chartStddr.TabIndex = 1;
            this.chartStddr.Text = "chart1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(410, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(613, 423);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chartStddr);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(605, 397);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "stddr";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chartRstddr);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(605, 397);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "rstddr";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chartMaxRate);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(605, 397);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "max rate";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.chartAverage);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(605, 397);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Average";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // chartRstddr
            // 
            chartArea2.Name = "ChartArea1";
            this.chartRstddr.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartRstddr.Legends.Add(legend2);
            this.chartRstddr.Location = new System.Drawing.Point(6, 6);
            this.chartRstddr.Name = "chartRstddr";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartRstddr.Series.Add(series2);
            this.chartRstddr.Size = new System.Drawing.Size(593, 385);
            this.chartRstddr.TabIndex = 2;
            this.chartRstddr.Text = "chart";
            // 
            // chartMaxRate
            // 
            chartArea3.Name = "ChartArea1";
            this.chartMaxRate.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartMaxRate.Legends.Add(legend3);
            this.chartMaxRate.Location = new System.Drawing.Point(6, 6);
            this.chartMaxRate.Name = "chartMaxRate";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartMaxRate.Series.Add(series3);
            this.chartMaxRate.Size = new System.Drawing.Size(593, 385);
            this.chartMaxRate.TabIndex = 3;
            this.chartMaxRate.Text = "chart";
            // 
            // chartAverage
            // 
            chartArea4.Name = "ChartArea1";
            this.chartAverage.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartAverage.Legends.Add(legend4);
            this.chartAverage.Location = new System.Drawing.Point(6, 6);
            this.chartAverage.Name = "chartAverage";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartAverage.Series.Add(series4);
            this.chartAverage.Size = new System.Drawing.Size(593, 385);
            this.chartAverage.TabIndex = 3;
            this.chartAverage.Text = "chart";
            // 
            // RawData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 443);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.rawDataGridView);
            this.Name = "RawData";
            this.Text = "Raw Data";
            ((System.ComponentModel.ISupportInitialize)(this.rawDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStddr)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartRstddr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMaxRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAverage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView rawDataGridView;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStddr;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRstddr;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMaxRate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAverage;
    }
}