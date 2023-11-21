using ForcePlatformData;
using ForcePlatformData.DbModels;
using ForcePlatformData.Helpers;
using ForcePlatformData.Models;
using System.Windows.Forms.DataVisualization.Charting;
using static ForcePlatformData.Constants;

namespace ForcePlatformSmart
{
    public partial class AnalyticsForm : Form
    {
        private Report userReport;
        private List<CsvLoadArrayModel> currData = new List<CsvLoadArrayModel>();
        private User user;
        public AnalyticsForm(User user, Report report)
        {
            this.user = user;
            this.userReport = report;

            InitializeComponent();

            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart2.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart3.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart4.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            chart1.MouseWheel += chart1_MouseWheel;
            chart3.MouseWheel += chart1_MouseWheel;
        }

        private void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;
            var xAxis = chart.ChartAreas[0].AxisX;

            try
            {
                if (e.Delta < 0)
                {
                    xAxis.ScaleView.ZoomReset();
                }
                else if (e.Delta > 0)
                {
                    var xMin = xAxis.ScaleView.ViewMinimum;
                    var xMax = xAxis.ScaleView.ViewMaximum;

                    var posXStart = xAxis.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                    var posXFinish = xAxis.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;

                    xAxis.ScaleView.Zoom(posXStart, posXFinish);
                }
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            currData.Clear();
            try
            {
                var content = CsvProcessor.Read(userReport.Path);
                foreach (var line in content)
                {
                    currData.Add(new CsvLoadArrayModel(line));
                }

                currData.RemoveAt(0);

                if (currData.Count == 0) return;
            }
            catch (Exception ex)
            {
                Program.Message("Error", ex.Message);
            }

            loadFastLine(chart1, currData, userReport.Unit);
            loadPolarChartRadar(chart2, currData);
            loadHistogram(chart3, currData, userReport.Unit);
            loadPolarChartTrack(chart4, currData);
        }

        private void loadHistogram(Chart chart, List<CsvLoadArrayModel> data, string unit)
        {
            chart.ChartAreas[0].AxisX.Title = "Time(msec)";
            chart.ChartAreas[0].AxisY.Title = unit;

            foreach (CsvLoadArrayModel da in data)
            {
                if ((da.data[1] > 0.0 && da.data[2] > 0.0) || (da.data[1] < 0.0 && da.data[2] < 0.0))
                {
                    var x = da.data[1]; // %%
                    var y = da.data[2];

                    chart.Series[0].Points.AddXY(x, y);
                }
                else continue;
            }
        }

        private void loadFastLine(Chart chart, List<CsvLoadArrayModel> data, string unit)
        {
            chart.ChartAreas[0].AxisX.Title = "Time(msec)";
            chart.ChartAreas[0].AxisY.Title = unit;

            foreach (Series s in chart.Series) s.Points.Clear();

            foreach (CsvLoadArrayModel dd in data)
            {
                var timeShift = dd.data[0];
                if (timeShift > 0)
                {
                    if (checkBox2.Checked) for (int i = 1; i < 4; i++) chart.Series[i - 1].Points.AddXY(timeShift, dd.data[i]);
                    if (checkBox3.Checked) for (int i = 4; i < 7; i++) chart.Series[i - 1].Points.AddXY(timeShift, dd.data[i]);
                    if (checkBox4.Checked) for (int i = 7; i < 10; i++) chart.Series[i - 1].Points.AddXY(timeShift, dd.data[i]);
                    if (checkBox5.Checked) for (int i = 10; i < 13; i++) chart.Series[i - 1].Points.AddXY(timeShift, dd.data[i]);
                }
            }
        }

        private void convertToPolarChartCoords(ref double x, ref double y)
        {
            double r = Math.Sqrt((x * x) + (y * y));
            double q = Math.Atan(Math.Abs(x) / Math.Abs(y)) * 180 / Math.PI;

            if (x < 0 && y > 0) q = 360 - q;
            if (x > 0 && y < 0) q = 180 - q;
            if (x < 0 && y < 0) q = 270 - (90 - q);

            x = q;
            y = r;
        }

        public void loadPolarChartTrack(Chart chart, List<CsvLoadArrayModel> data)  // Traektoria
        {
            chart.Series[0].Points.Clear();

            foreach (CsvLoadArrayModel da in data)
            {
                //if (da.data[3] > 5000)
                {
                    double x = da.data[1]; // %%
                    double y = da.data[2];


                    convertToPolarChartCoords(ref x, ref y);

                    chart.Series[0].Points.AddXY(x, y);
                }
                //else continue;
            }
        }

        private void loadPolarChartRadar(Chart chart, List<CsvLoadArrayModel> data)  // Radar
        {
            chart.Series[0].Points.Clear();

            List<CoordinateModel> cr = new List<CoordinateModel>();

            foreach (CsvLoadArrayModel da in data)
            {

                //if (da.data[3] > 15000)
                {
                    double x = da.data[1]; // %%
                    double y = da.data[2];
                    convertToPolarChartCoords(ref x, ref y);
                    cr.Add(new CoordinateModel(x, y));
                }
                //else continue;
            }
            cr.Sort();

            for (int i = 0; i < 361; i++)
            {
                double y = 0;
                int cnt = 0;
                foreach (CoordinateModel da in cr) if (da.X >= i && da.X < (i + 1)) { y += da.Y; cnt++; }

                if (cnt > 0) y /= cnt;

                chart.Series[0].Points.AddXY(i, y);
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {

            chart1.Series[0].Enabled = checkBox2.Checked;
            chart1.Series[1].Enabled = checkBox2.Checked;
            chart1.Series[2].Enabled = checkBox2.Checked;

            chart1.Series[3].Enabled = checkBox3.Checked;
            chart1.Series[4].Enabled = checkBox3.Checked;
            chart1.Series[5].Enabled = checkBox3.Checked;

            chart1.Series[6].Enabled = checkBox4.Checked;
            chart1.Series[7].Enabled = checkBox4.Checked;
            chart1.Series[8].Enabled = checkBox4.Checked;

            chart1.Series[9].Enabled = checkBox5.Checked;
            chart1.Series[10].Enabled = checkBox5.Checked;
            chart1.Series[11].Enabled = checkBox5.Checked;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            var unitValue = 2.8;
            if (userReport.Unit == Units.N.ToString()) unitValue = unitValue * AppConfig.Config.FreeFallAcc;

            while (currData.Count > 0 && (currData[0].data[3] + currData[0].data[6] + currData[0].data[9] + currData[0].data[12]) < unitValue)
                currData.RemoveAt(0);

            loadFastLine(chart1, currData, userReport.Unit);
            loadPolarChartRadar(chart2, currData);
            loadHistogram(chart3, currData, userReport.Unit);
            loadPolarChartTrack(chart4, currData);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            var chart1Size = chart1.Size;
            chart1.Size = new Size(1500, 900);
            chart1.SaveImage("assets/images/chart1.png", ChartImageFormat.Png);
            chart1.Size = chart1Size;

            var chart2Size = chart2.Size;
            chart2.Size = new Size(1500, 900);
            chart2.SaveImage("assets/images/chart2.png", ChartImageFormat.Png);
            chart2.Size = chart2Size;

            var chart3Size = chart3.Size;
            chart3.Size = new Size(1500, 900);
            chart3.SaveImage("assets/images/chart3.png", ChartImageFormat.Png);
            chart3.Size = chart3Size;

            var chart4Size = chart4.Size;
            chart4.Size = new Size(1500, 900);
            chart4.SaveImage("assets/images/chart4.png", ChartImageFormat.Png);
            chart4.Size = chart4Size;

            try
            {
                var result = PdfProcessor.GeneratePdf(user);
                //Program.Message("Success", $"File successfully saved to {result}");
            }
            catch (Exception ex)
            {
                Program.Message("Error", ex.Message);
            }
        }
    }


}
