using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace WaterIntakeCalc.Services
{
    public class ChartService
    {
        Chart _chart;
        ChartArea _chartArea;
        Series _series;

        public ChartService()
        {
            // create the chart
            _chart = new Chart();
            _chart.Size = new Size(600, 250);

            _chartArea = new ChartArea();
            _chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            _chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            _chartArea.AxisX.LabelStyle.Font = new Font("Consolas", 8);
            _chartArea.AxisY.LabelStyle.Font = new Font("Consolas", 8);
            _chartArea.AxisX.LabelStyle.IsEndLabelVisible = false;

            _series = new Series();
            _series.Name = "Series1";
            _series.ChartType = SeriesChartType.FastLine;
            _series.XValueType = ChartValueType.DateTime;
            _chart.Series.Add(_series);
        }

        public void CreateChartOfWeek(List<DateTime> dateX, List<int> amountY)
        {
            _chartArea.AxisX.LabelStyle.Format = "dd/MMM\nddd";   
            _chart.Series["Series1"].Points.DataBindXY(dateX, amountY);
            GetImage();
        }

        public void CreateChartOfMonth(List<DateTime> dateX, List<int> amountY)
        {
            _chartArea.AxisX.LabelStyle.Format = "dd/MMM\nddd";
            _chart.Series["Series1"].Points.DataBindXY(dateX, amountY);
            GetImage();
        }

        private void GetImage()
        {
            _chart.ChartAreas.Add(_chartArea);
           
            // draw
            _chart.Invalidate();
            // write out a file
            _chart.SaveImage("D:/chart.png", ChartImageFormat.Png);
        }
    }
}