using AForge.Video;
using AForge.Video.DirectShow;
namespace ForcePlatformCore
{
    public partial class Camera : Form
    {
        FilterInfoCollection filter;
        VideoCaptureDevice device;
        Bitmap bitmapper;
        int width;
        int height;

        public Camera()
        {
            InitializeComponent();
        }

        private void Camera_Load(object sender, EventArgs e)
        {
            width = this.Width;
            height = this.Height;
            filter = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo device in filter)
                comboDevices.Items.Add(device.Name);
        }

        private void comboDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            closeDevice();

            device = new VideoCaptureDevice(filter[comboDevices.SelectedIndex].MonikerString);
            device.NewFrame += Device_NewFrame;
            device.Start();

            setFormSize(3000);
        }

        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            bitmapper = (Bitmap)eventArgs.Frame.Clone();

            if (checkBox3.Checked) bitmapper.RotateFlip(RotateFlipType.Rotate90FlipX);
            if (checkBox1.Checked) bitmapper.RotateFlip(RotateFlipType.RotateNoneFlipX);
            if (checkBox2.Checked) bitmapper.RotateFlip(RotateFlipType.RotateNoneFlipY);

            pictureBox1.Image = bitmapper;
            width = bitmapper.Width;
            height = bitmapper.Height;
        }

        private void Camera_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeDevice();
        }
        private void closeDevice()
        {
            try
            {
                device.SignalToStop();
                device.NewFrame -= Device_NewFrame;
            }
            catch { }
        }
        private void setFormSize(int sleep)
        {
            Thread.Sleep(sleep);
            this.Width = width + 15;
            this.Height = height + 68;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            setFormSize(500);
        }
    }
}
