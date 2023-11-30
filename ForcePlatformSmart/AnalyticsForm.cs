using ForcePlatformData;
using ForcePlatformData.DbModels;
using ForcePlatformData.Helpers;
using ForcePlatformData.Models;
using Newtonsoft.Json.Linq;
using ScottPlot;
using ScottPlot.Plottable;
using System.Security.Cryptography;
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
        private string heatmapTitle = "";
        private List<double> fastLineXLabels = new List<double>();
        private int oldDivider = 0;

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
                textBox1.Text = userReport.Comment;
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
                Close(); 
                return;
            }

            drawCharts();
            formsPlot1.MouseWheel += fastLine_MouseWheel;
        }

        private void fastLine_MouseWheel(object? sender, MouseEventArgs e)
        {
            var limits = formsPlot1.Plot.GetAxisLimits();
            double visibleWidth = limits.XMax - limits.XMin;

            var estimatedPoints = (int)Math.Round(visibleWidth / formsPlot1.Plot.GetSettings(false).Axes.Count);
            var points = estimatedPoints / 0.2;
            var divider = (int)(points / 500);

            if (divider != oldDivider)
            {
                updateFastLineTicks(formsPlot1, divider);
                oldDivider = divider;
            }
        }
        private void updateFastLineTicks(FormsPlot plot, int divider)
        {
            var plotDataTimeStr = fastLineXLabels.Select((c, index) => (index % (divider > 0 ? divider : 1) != 0) ? "" : c.ToString()).ToArray();
            plot.Plot.XAxis.ManualTickPositions(fastLineXLabels.ToArray(), plotDataTimeStr);
            plot.Render();
        }

        private void drawCharts()
        {
            loadFastLine(formsPlot1, currData, userReport.Unit);
            loadHeatmap(formsPlot2, currData);
            loadPolarChartRadar(chart1, currData);
            loadPolarChartTrack(chart2, currData);
        }

        private void loadFastLine(FormsPlot plot, List<CsvLoadArrayModel> data, string unit)
        {
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

            fastLineXLabels = data.Select(c => c.data[0]).ToList();

            var divider = (int)(data.Count() / 550);

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

            updateFastLineTicks(plot, divider);
            plot.Plot.XAxis.TickLabelStyle(rotation: 90);

            formsPlot1.Plot.Legend(checkBox5.Checked, location: Alignment.UpperLeft);

            plot.Plot.XLabel("Time (msec)");
            plot.Plot.YLabel(unit);
            plot.Configuration.LockVerticalAxis = true;

            plot.Refresh();
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

        public void loadHeatmap(FormsPlot plot, List<CsvLoadArrayModel> data)
        {
            var plates = new bool[] {
                checkBox11.Checked,
                checkBox12.Checked,
                checkBox13.Checked,
                checkBox14.Checked
            };

            var cells = 50;
            var result = calculateHeatmap(data, cells);

            var labels = new double[cells + 1];
            var labelsStr = new string[cells + 1];

            for (int i = -1 * (cells / 2), j = 0; i <= cells / 2; i++, j++)
            {
                labels[j] = j;
                labelsStr[j] = (i * 4).ToString();
            }

            plot.Plot.Clear();
            heatmapTitle = "Plates: ";
            for (int plate = 0; plate < 4; plate++)
            {
                if (!plates[plate]) continue;
                heatmapTitle += $"{plate + 1},";
                plot.Plot.AddHeatmap(result[plate], lockScales: false);
            }
            heatmapTitle = heatmapTitle.Substring(0, heatmapTitle.Length - 1);
            plot.Plot.Grid(enable: true, color: Color.Black, lineStyle: LineStyle.Solid, onTop: true);
            plot.Plot.Margins(0, 0);
            plot.Configuration.LockHorizontalAxis = true;
            plot.Configuration.LockVerticalAxis = true;

            plot.Plot.XLabel("x %");
            plot.Plot.YLabel("y %");

            plot.Plot.XAxis.ManualTickPositions(labels, labelsStr);
            plot.Plot.YAxis.ManualTickPositions(labels, labelsStr);

            plot.Refresh();
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

        private Dictionary<int, double?[,]> calculateHeatmap(List<CsvLoadArrayModel> data, int cells)
        {
            var raw = cells;
            var col = cells;

            var arr = new double?[raw, col];

            for (int i = 0; i < raw; i++)
                for (int j = 0; j < col; j++)
                    arr[i, j] = null;

            var result = new Dictionary<int, double?[,]> {
                { 0, new double?[raw,col] },
                { 1, new double?[raw,col] },
                { 2, new double?[raw,col] },
                { 3, new double?[raw,col] }
            };

            foreach (var line in data)
            {
                for (var plate = 0; plate < 4; plate++)
                {
                    var x = line.data[1 + (plate * 3)];
                    var y = line.data[2 + (plate * 3)];

                    var heatCol = (int)((100 + x) * col / 200);
                    var heatRaw = (int)((100 + y*(-1)) * raw / 200);

                    if ((heatRaw >= 0 && heatRaw < raw) && (heatCol >= 0 && heatCol < col))
                    {
                        if ((result[plate][heatRaw, heatCol] == null) || (heatRaw == raw / 2 && heatCol == col / 2))
                        {
                            result[plate][heatRaw, heatCol] = -1;
                        }

                        result[plate][heatRaw, heatCol]--;
                    }
                }
            }
            return result;
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

        private void iconButton1_Click(object sender, EventArgs e)
        {
            var printSize = new Size(1000, 650);
            formsPlot1.Visible = false;
            var chart1Size = formsPlot1.Size;
            formsPlot1.Size = printSize;
            formsPlot1.Plot.SaveFig("assets/images/chart1.png");
            formsPlot1.Size = chart1Size;
            formsPlot1.Visible = true;

            chart1.Visible = false;
            var chart2Size = chart1.Size;
            chart1.Size = printSize;
            chart1.SaveImage("assets/images/chart2.png", ChartImageFormat.Png);
            chart1.Size = chart2Size;
            chart1.Visible = true;

            formsPlot2.Visible = false;
            var chart3Size = formsPlot2.Size;
            formsPlot2.Plot.Title(heatmapTitle);
            formsPlot2.Size = printSize;
            formsPlot2.Plot.SaveFig("assets/images/chart3.png");
            formsPlot2.Size = chart3Size;
            formsPlot2.Plot.Title("");
            formsPlot2.Visible = true;
            formsPlot2.Render();

            chart2.Visible = false;
            var chart4Size = chart2.Size;
            chart2.Size = printSize;
            chart2.SaveImage("assets/images/chart4.png", ChartImageFormat.Png);
            chart2.Size = chart4Size;
            chart2.Visible = true;

            try
            {
                var result = PdfProcessor.GeneratePdf(user, userReport);
            }
            catch (Exception ex)
            {
                Program.Message("Error", ex.Message);
            }
        }

        private void checkBoxFastLine_CheckedChanged(object sender, EventArgs e)
        {
            loadFastLine(formsPlot1, currData, userReport.Unit);
        }

        private void checkBoxRadar_CheckedChanged(object sender, EventArgs e)
        {
            loadPolarChartRadar(chart1, currData);
        }

        private void checkBoxHeatmap_CheckedChanged(object sender, EventArgs e)
        {
            loadHeatmap(formsPlot2, currData);
        }

        private void checkBoxTrack_CheckedChanged(object sender, EventArgs e)
        {
            loadPolarChartTrack(chart2, currData);
        }
    }
}
