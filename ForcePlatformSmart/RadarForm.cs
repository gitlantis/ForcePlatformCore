using ForcePlatformData.DbModels;
using ScottPlot;

namespace ForcePlatformSmart
{
    public partial class RadarForm : Form
    {
        private bool pausePlot = false;
        private Plot plt;
        private double[] maxValues = new double[72];
        private double[,] plotValues;

        private int stopTime = 0;
        private bool isStopped = false;
        private User user = new User();

        public double[] convertToPolar(double X, double Y)
        {
            double[] res = new double[2] { 0, 0 };

            double vectorVal = Math.Sqrt(X * X + Y * Y);

            double angle = 0;

            res[0] = vectorVal;
            if (vectorVal != 0)
            {
                var _temp = Math.Abs(X) / vectorVal;

                angle = Math.Acos(_temp) / (Math.PI * 2) * 360;
                if (Y < 0) angle = 180 - angle;
                if (X < 0) angle = 360 - angle;
                res[1] = angle;
            }
            return res;
        }

        private void initalizePlot()
        {
            plt = new Plot(1000, 1000);
            for (int i = 0; i < 72; i++) maxValues[i++] = 100;
            plotValues = new double[1, 72];
            formsPlot1.Plot.Clear();
            timer1.Enabled = true;
        }

        public RadarForm(User selectedUser)
        {
            user = selectedUser;

            InitializeComponent();

            initalizePlot();
            drawRadarChart();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (stopTime >= 50)
            {
                isStopped = false;
                stopTime = 0;
            }

            if (isStopped) stopTime++;

            if (!pausePlot && !isStopped)
            {
                drawRadarChart();
            }
        }

        public void Pause(bool isPaused)
        {
            pausePlot = isPaused;
        }

        private void formsPlot1_MouseDown(object sender, MouseEventArgs e)
        {
            isStopped = true;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    SharedStaticModel.Weight = AdcBuffer.BufferItems[plateNumber].LastOrDefault().DiffZ / AppConfig.Config.CalibrateZ;
            //    SharedStaticModel.DiffX = AdcBuffer.BufferItems[plateNumber].LastOrDefault().DiffX;
            //    SharedStaticModel.DiffY = AdcBuffer.BufferItems[plateNumber].LastOrDefault().DiffY;
            //    SharedStaticModel.DiffZ = AdcBuffer.BufferItems[plateNumber].LastOrDefault().DiffZ;
            //    AdcBuffer.BufferItems[0].Clear();

            //    label1.Text = $"Weight: {SharedStaticModel.Weight.ToString("0.000")}kg";
            //    initalizePlot();
            //}
            //catch { }
        }

        private void drawRadarChart()
        {
           
                double[] cc;

                var tmp = new double[72];

                //for (int i = 0; i < 72; i++)
                {
                    //foreach (var point in points)
                    //{
                    //    //cc = convertToPolar((2 * (point.DiffX- SharedStaticModel.DiffX)) / (SharedStaticModel.Weight * 100), (2 * (point.DiffY- SharedStaticModel.DiffX)) / (SharedStaticModel.Weight * 100)); 
                    //    var percentX = Math.Round((double)point.DiffX / point.DiffZ * 100);
                    //    var percentY = Math.Round((double)point.DiffY / point.DiffZ * 100);
                    //    var weight = Math.Round((double)point.DiffZ / 11600);

                    //    cc = convertToPolar(percentX, percentY);
                    //    double angle = cc[1];
                    //    int section = (int)(angle / 360 * 72) % 72;
                    //    plotValues[0, section] = cc[0];
                    //    richTextBox1.AppendText($"{percentX} {percentY} {weight} \r\n");
                    //    richTextBox1.ScrollToCaret();
                    //}
                }
                formsPlot1.Plot.Clear();
                var radar = formsPlot1.Plot.AddRadar(plotValues, independentAxes: false, maxValues: maxValues, false);
                formsPlot1.Refresh();
        }
    }
}
