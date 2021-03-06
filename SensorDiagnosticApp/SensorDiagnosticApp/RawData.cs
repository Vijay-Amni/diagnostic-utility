using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SensorDiagnosticApp
{
    public partial class RawData : Form
    {
        public RawData(DataTable table)
        {
            InitializeComponent();
            DataTable rawDataTable = table;
            FillTable(table);
            try
            {
                DrawStddrGraph(table);
                DrawRstddrGraph(table);
                DrawMaxRateGraph(table);
                DrawAverageGraph(table);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void FillTable (DataTable data)
        {
            try
            {
                rawDataGridView.DataSource = data;
                rawDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                rawDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                rawDataGridView.Columns[0].HeaderText = "Response";
                rawDataGridView.Columns[1].HeaderText = "Average";
                rawDataGridView.Columns[2].HeaderText = "stddr";
                rawDataGridView.Columns[3].HeaderText = "rstddr";
                rawDataGridView.Columns[4].HeaderText = "max rate";
                rawDataGridView.Columns[5].HeaderText = "Temperature";
            }
            catch (ArgumentOutOfRangeException aex)
            {
                MessageBox.Show("There was an error displaying the Raw Data. Please try again.", "Alert");
            }
        }

        public void DrawStddrGraph(DataTable data)
        {
            //Remove the Default Series.
            if (chartStddr.Series.Count() == 1)
            {
                chartStddr.Series.Remove(chartStddr.Series[0]);
            }

            // Create new series for stddr values
            chartStddr.DataSource = data;
            
            // Chart Configuration
            int totalRows = data.Rows.Count;
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.Color = Color.Red;
            series.BorderWidth = 4;
            series.BorderColor = Color.Black;
            series.IsValueShownAsLabel = true;
            series.LabelBorderWidth = 1;
            series.LabelBackColor = Color.White;
            series.LabelBorderColor = Color.Black;
            series.Name = "stddr";
            double max = double.MinValue;
            double min = double.MaxValue;

            // Load the chart
            for (int i = 1; i < totalRows; i++)
            {
                double y = Convert.ToDouble(data.Rows[i - 1][2].ToString());
                if (y > max) { max = y; }
                if (y < min) { min = y; }
                series.Points.AddXY(i, y);
            }
            chartStddr.Series.Add(series);

            // Resize the Y Axis according to the max and min values 
            chartStddr.ChartAreas[0].AxisY.Minimum = Math.Floor(min);
            chartStddr.ChartAreas[0].AxisY.Maximum = Math.Ceiling(max);
        }

        public void DrawRstddrGraph(DataTable data)
        {
            //Remove the Default Series.
            if (chartRstddr.Series.Count() == 1)
            {
                chartRstddr.Series.Remove(chartRstddr.Series[0]);
            }

            // Create new series for rstddr values
            chartRstddr.DataSource = data;

            // Chart Configuration
            int totalRows = data.Rows.Count;
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.Color = Color.Blue;
            series.BorderWidth = 4;
            series.BorderColor = Color.Black;
            series.IsValueShownAsLabel = true;
            series.LabelBorderWidth = 1;
            series.LabelBackColor = Color.White;
            series.LabelBorderColor = Color.Black;
            series.Name = "rstddr";
            double max = double.MinValue;
            double min = double.MaxValue;

            // Load the chart
            for (int i = 1; i < totalRows; i++)
            {
                double y = Convert.ToDouble(data.Rows[i - 1][3].ToString());
                if (y > max) { max = y; }
                if (y < min) { min = y; }
                series.Points.AddXY(i, y);
            }
            chartRstddr.Series.Add(series);

            // Resize the Y Axis according to the max and min values 
            chartRstddr.ChartAreas[0].AxisY.Minimum = Math.Floor(min);
            chartRstddr.ChartAreas[0].AxisY.Maximum = Math.Ceiling(max);
        }

        public void DrawMaxRateGraph(DataTable data)
        {
            //Remove the Default Series.
            if (chartMaxRate.Series.Count() == 1)
            {
                chartMaxRate.Series.Remove(chartMaxRate.Series[0]);
            }

            // Create new series for max rate values
            chartMaxRate.DataSource = data;

            // Chart Configuration
            int totalRows = data.Rows.Count;
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.Color = Color.Green;
            series.BorderWidth = 4;
            series.BorderColor = Color.Black;
            series.IsValueShownAsLabel = true;
            series.LabelBorderWidth = 1;
            series.LabelBackColor = Color.White;
            series.LabelBorderColor = Color.Black;
            series.Name = "max rate";
            double max = double.MinValue;
            double min = double.MaxValue;

            // Load the chart
            for (int i = 1; i < totalRows; i++)
            {
                double y = Convert.ToDouble(data.Rows[i - 1][4].ToString());
                if (y > max) { max = y; }
                if (y < min) { min = y; }
                series.Points.AddXY(i, y);
            }
            chartMaxRate.Series.Add(series);

            // Resize the Y Axis according to the max and min values 
            chartMaxRate.ChartAreas[0].AxisY.Minimum = Math.Floor(min);
            chartMaxRate.ChartAreas[0].AxisY.Maximum = Math.Ceiling(max);
        }

        public void DrawAverageGraph(DataTable data)
        {
            //Remove the Default Series.
            if (chartAverage.Series.Count() == 1)
            {
                chartAverage.Series.Remove(chartAverage.Series[0]);
            }

            // Create new series for average values
            chartAverage.DataSource = data;

            // Chart Configuration
            int totalRows = data.Rows.Count;
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.Color = Color.Purple;
            series.BorderWidth = 4;
            series.BorderColor = Color.Black;
            series.IsValueShownAsLabel = true;
            series.LabelBorderWidth = 1;
            series.LabelBackColor = Color.White;
            series.LabelBorderColor = Color.Black;
            series.Name = "Average";
            double max = double.MinValue;
            double min = double.MaxValue;

            // Load the chart
            for (int i = 1; i < totalRows; i++)
            {
                double y = Convert.ToDouble(data.Rows[i - 1][1].ToString());
                if (y > max) { max = y; }
                if (y < min) { min = y; }
                series.Points.AddXY(i, y);
            }
            chartAverage.Series.Add(series);

            // Resize the Y Axis according to the max and min values 
            chartAverage.ChartAreas[0].AxisY.Minimum = Math.Floor(min);
            chartAverage.ChartAreas[0].AxisY.Maximum = Math.Ceiling(max);
        }
    }
}
