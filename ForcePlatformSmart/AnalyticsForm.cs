using ForcePlatformData.DbModels;
using ForcePlatformData.Helpers;
using ForcePlatformData.Models;
using System.Windows.Forms.DataVisualization.Charting;

namespace ForcePlatformSmart
{
    public partial class AnalyticsForm : Form
    {
        private string filePath;
        private List<CsvLoadArrayModel> currData = new List<CsvLoadArrayModel>();
        public int startMC = 0;
        private User user;
        public AnalyticsForm(User user, string filePath)
        {
            this.user = user;
            this.filePath = filePath;
            InitializeComponent();

            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart2.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart3.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart4.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            chart1.MouseWheel += chart1_MouseWheel;
            chart2.MouseWheel += chart1_MouseWheel;
            chart3.MouseWheel += chart1_MouseWheel;
            chart4.MouseWheel += chart1_MouseWheel;
        }

        private void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;
            var xAxis = chart.ChartAreas[0].AxisX;
            var yAxis = chart.ChartAreas[0].AxisY;

            try
            {
                if (e.Delta < 0) // Scrolled down.
                {
                    xAxis.ScaleView.ZoomReset();
                }
                else if (e.Delta > 0) // Scrolled up.
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
            var content = CsvProcessor.Read(filePath);

            foreach (var line in content)
            {
                currData.Add(new CsvLoadArrayModel(line));

            }

            currData.RemoveAt(0);

            if (currData.Count == 0) return;
            startMC = currData[0].data[0];

            foreach (Series s in chart1.Series) s.Points.Clear();

            foreach (CsvLoadArrayModel dd in currData)
            {
                int timeShift = dd.data[0] - startMC;
                if (timeShift > 0)
                {
                    if (checkBox2.Checked) for (int i = 1; i < 4; i++) chart1.Series[i - 1].Points.AddXY(timeShift, dd.data[i]);
                    if (checkBox3.Checked) for (int i = 4; i < 7; i++) chart1.Series[i - 1].Points.AddXY(timeShift, dd.data[i]);
                    if (checkBox4.Checked) for (int i = 7; i < 10; i++) chart1.Series[i - 1].Points.AddXY(timeShift, dd.data[i]);
                    if (checkBox5.Checked) for (int i = 10; i < 13; i++) chart1.Series[i - 1].Points.AddXY(timeShift, dd.data[i]);
                }
            }
            loadPolarChartRadar(chart2, currData);
            loadPolarChartTrack(chart4, currData);

            foreach (CsvLoadArrayModel da in currData)
            {
                if (da.data[3] > 5000)
                {
                    double x = 100 * da.data[1] / da.data[3]; // %%
                    double y = 100 * da.data[2] / da.data[3];

                    chart3.Series[0].Points.AddXY(x, y);
                }
                else continue;
            }

        }
        static void convertToPolarChartCoords(ref double x, ref double y)
        {

            double r = Math.Sqrt((x * x) + (y * y));
            double q = Math.Atan(Math.Abs(x) / Math.Abs(y)) * 180 / Math.PI;


            if (x < 0) q = 360 - q;
            if (y < 0) q = 180 - q;

            x = q;
            y = r;
        }
        //------------------------------------------------------------------------------------
        public void loadPolarChartTrack(Chart chart, List<CsvLoadArrayModel> data)  // Traektoria
        {
            chart.Series[0].Points.Clear();

            foreach (CsvLoadArrayModel da in data)
            {
                if (da.data[3] > 5000)
                {
                    double x = 100 * da.data[1] / da.data[3]; // %%
                    double y = 100 * da.data[2] / da.data[3];


                    convertToPolarChartCoords(ref x, ref y);

                    chart.Series[0].Points.AddXY(x, y);
                }
                else continue;
            }


        }
        //------------------------------------------------------------------------------------
        public void loadPolarChartRadar(Chart chart, List<CsvLoadArrayModel> data)  // Radar
        {
            chart.Series[0].Points.Clear();

            List<CoordinateModel> cr = new List<CoordinateModel>();

            foreach (CsvLoadArrayModel da in data)
            {

                if (da.data[3] > 15000)
                {
                    double x = 100 * da.data[1] / da.data[3]; // %%
                    double y = 100 * da.data[2] / da.data[3];
                    convertToPolarChartCoords(ref x, ref y);
                    cr.Add(new CoordinateModel(x, y));
                }
                else continue;
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
            while (currData.Count > 0 && (currData[0].data[3] + currData[0].data[6] + currData[0].data[9] + currData[0].data[12]) < 5000)
                currData.RemoveAt(0);
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
