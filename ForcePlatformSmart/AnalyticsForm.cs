using ForcePlatformData;
using ForcePlatformData.DbModels;
using ForcePlatformData.Helpers;
using ForcePlatformData.Models;
using Newtonsoft.Json.Linq;
using ScottPlot;
using ScottPlot.Plottable;
using System.Windows.Forms.DataVisualization.Charting;
using static ForcePlatformData.Constants;
using static ScottPlot.Plottable.PopulationPlot;

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

            drawCharts(currData);

        }
        private void drawCharts(List<CsvLoadArrayModel> csvata)
        {
            loadFastLine(formsPlot1, csvata, userReport.Unit);
            loadPolarChartRadar(chart1, csvata);
            loadPolarChartTrack(chart2, csvata);
        }
        private void loadFastLine(FormsPlot plot, List<CsvLoadArrayModel> data, string unit)
        {
            var plotDataTime = new double[data.Count];
            var plotDataTimeStr = new string[data.Count];
            var plotDataX = new Dictionary<int, double[]>();
            var plotDataY = new Dictionary<int, double[]>();
            var plotDataZ = new Dictionary<int, double[]>();

            var plates = new bool[] {
                checkBox1.Checked,
                checkBox2.Checked,
                checkBox3.Checked,
                checkBox4.Checked
            };

            plot.Plot.Clear();

            plotDataTime = data.Select(c => c.data[0]).ToArray();
            plotDataTimeStr = data.Select(c => c.data[0].ToString()).ToArray();

            for (var plate = 0; plate < 4; plate++)
            {
                if (!plates[plate]) continue;

                var valsX = data.Select(c => c.data[1 + (plate * 3)] * c.data[3 + (plate * 3)] / 100).ToArray();
                plot.Plot.AddSignal(valsX, 1, null, $"p{plate + 1}X").LineWidth = 2;

                var valsY = data.Select(c => c.data[2 + (plate * 3)] * c.data[3 + (plate * 3)] / 100).ToArray();
                plot.Plot.AddSignal(valsY, 1, null, $"p{plate + 1}Y").LineWidth = 2;

                var valsZ = data.Select(c => c.data[3 + (plate * 3)]).ToArray();
                plot.Plot.AddSignal(valsZ, 1, null, $"p{plate + 1}Z").LineWidth = 2;
            }

            plot.Plot.XAxis.ManualTickPositions(plotDataTime, plotDataTimeStr);
            plot.Plot.XAxis.TickLabelStyle(rotation: 90);

            formsPlot1.Plot.Legend(checkBox5.Checked, location: Alignment.UpperLeft);

            plot.Plot.XLabel("Time (msec)");
            plot.Plot.YLabel(unit);
            plot.Configuration.LockVerticalAxis = true;

            plot.Refresh();
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

        private void loadPolarChartRadar(Chart chart, List<CsvLoadArrayModel> data)
        {
            for (int plate = 0; plate < 4; plate++)
            {
                chart.Series[plate].Points.Clear();
            }

            var plates = new bool[] {
                checkBox6.Checked,
                checkBox7.Checked,
                checkBox8.Checked,
                checkBox9.Checked
            };

            var cr = new Dictionary<int, List<CoordinateModel>>
            {
                { 0, new List<CoordinateModel>()},
                { 1, new List<CoordinateModel>()},
                { 2, new List<CoordinateModel>()},
                { 3, new List<CoordinateModel>()}
            };

            foreach (CsvLoadArrayModel da in data)
            {

                for (int plate = 0; plate < 4; plate++)
                {
                    if (!plates[plate]) continue;

                    var x = da.data[1 + (plate * 3)];
                    var y = da.data[2 + (plate * 3)];

                    convertToPolarChartCoords(ref x, ref y);
                    cr[plate].Add(new CoordinateModel(x, y));
                }
            }

            for (int plate = 0; plate < 4; plate++)
            {
                chart.Series[plate].LegendText = $"Plate {plate + 1}";
                chart.Series[plate].IsVisibleInLegend = checkBox10.Checked & plates[plate];

                if (!plates[plate]) continue;

                cr[plate].Sort();

                for (int i = 0; i < 361; i++)
                {
                    var y = 0.0;
                    var cnt = 0;
                    foreach (CoordinateModel da in cr[plate]) if (da.X >= i && da.X < (i + 1)) { y += da.Y; cnt++; }

                    if (cnt > 0) y /= cnt;

                    chart.Series[plate].Points.AddXY(i, y);
                }
            }
        }

        public void loadHeatmap(Chart chart, List<CsvLoadArrayModel> data)
        {
            for (int plate = 0; plate < 4; plate++)
            {
                chart.Series[plate].Points.Clear();
            }

            var plates = new bool[] {
                checkBox16.Checked,
                checkBox17.Checked,
                checkBox18.Checked,
                checkBox19.Checked
            };

            foreach (CsvLoadArrayModel da in data)
            {
                for (int plate = 0; plate < 4; plate++)
                {
                    chart.Series[plate].LegendText = $"Plate {plate + 1}";
                    chart.Series[plate].IsVisibleInLegend = checkBox20.Checked & plates[plate];

                    if (!plates[plate]) continue;

                    var x = da.data[1 + (plate * 3)];
                    var y = da.data[2 + (plate * 3)];

                    convertToPolarChartCoords(ref x, ref y);

                    chart.Series[plate].Points.AddXY(x, y);
                }
            }
        }
        public void loadPolarChartTrack(Chart chart, List<CsvLoadArrayModel> data)
        {
            for (int plate = 0; plate < 4; plate++)
            {
                chart.Series[plate].Points.Clear();
            }

            var plates = new bool[] {
                checkBox16.Checked,
                checkBox17.Checked,
                checkBox18.Checked,
                checkBox19.Checked
            };

            foreach (CsvLoadArrayModel da in data)
            {
                for (int plate = 0; plate < 4; plate++)
                {
                    chart.Series[plate].LegendText = $"Plate {plate + 1}";
                    chart.Series[plate].IsVisibleInLegend = checkBox20.Checked & plates[plate];

                    if (!plates[plate]) continue;

                    var x = da.data[1 + (plate * 3)];
                    var y = da.data[2 + (plate * 3)];

                    convertToPolarChartCoords(ref x, ref y);

                    chart.Series[plate].Points.AddXY(x, y);
                }
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            var unitValue = 2.8;
            if (userReport.Unit == Units.N.ToString()) unitValue = unitValue * AppConfig.Config.FreeFallAcc;

            while (currData.Count > 0 && (currData[0].data[3] + currData[0].data[6] + currData[0].data[9] + currData[0].data[12]) < unitValue)
                currData.RemoveAt(0);

            drawCharts(currData);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            formsPlot1.Visible = false;
            var chart1Size = formsPlot1.Size;
            formsPlot1.Size = new Size(1500, 900);
            formsPlot1.Plot.SaveFig("assets/images/chart1.png");
            formsPlot1.Size = chart1Size;
            formsPlot1.Visible = true;

            chart1.Visible = false;
            var chart2Size = chart1.Size;
            chart1.Size = new Size(1500, 900);
            chart1.SaveImage("assets/images/chart2.png", ChartImageFormat.Png);
            chart1.Size = chart2Size;
            chart1.Visible = true;

            //var chart3Size = chart3.Size;
            //chart3.Size = new Size(1500, 900);
            //chart3.SaveImage("assets/images/chart3.png", ChartImageFormat.Png);
            //chart3.Size = chart3Size;

            chart2.Visible = false;
            var chart4Size = chart2.Size;
            chart2.Size = new Size(1500, 900);
            chart2.SaveImage("assets/images/chart4.png", ChartImageFormat.Png);
            chart2.Size = chart4Size;
            chart2.Visible = true;


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

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            drawCharts(currData);
        }
    }


}
