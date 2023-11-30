using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using ForcePlatformData;
using ForcePlatformData.Helpers;
using ForcePlatformData.Models;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ForcePlatformCore
{
    public partial class Camera : Form
    {
        private VideoCapture videoCapture;

        VideoWriter videoWriter;
        Bitmap bitmapper;
        bool startRecording = false;
        string filePath = "";
        public bool IsOpen = false;

        public Camera()
        {
            InitializeComponent();
        }

        private void Camera_Load(object sender, EventArgs e)
        {
            IsOpen = true;
            int cameraCount = 0;
            try
            {
                while (true)
                {
                    using (var tempCapture = new VideoCapture(cameraCount, VideoCapture.API.Msmf))
                    {
                        if (!tempCapture.IsOpened)
                            break;

                        comboDevices.Items.Add($"Camera {cameraCount}");
                        cameraCount++;
                    }
                }

                if (comboDevices.Items.Count > 0)
                    comboDevices.SelectedIndex = 0;
                else
                    MessageBox.Show("No cameras found.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cameras: {ex.Message}");
            }
        }

        private void comboDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboDevices.SelectedIndex >= 0)
            {
                int selectedCameraIndex = comboDevices.SelectedIndex;
                videoCapture = new VideoCapture(selectedCameraIndex);
                videoCapture.ImageGrabbed += Device_NewFrame;
                videoCapture.Start();
                setFormSize(videoCapture.Width, videoCapture.Height);
            }
            else
            {
                MessageBox.Show("Please select a camera.");
            }
        }

        private void Device_NewFrame(object sender, EventArgs e)
        {
            try
            {
                var frame = new Mat();
                videoCapture.Retrieve(frame);

                if (checkBox3.Checked) CvInvoke.Rotate(frame, frame, RotateFlags.Rotate90Clockwise);
                if (checkBox1.Checked) CvInvoke.Flip(frame, frame, FlipType.Horizontal);
                if (checkBox2.Checked) CvInvoke.Flip(frame, frame, FlipType.Vertical);

                bitmapper = frame.ToImage<Bgr, byte>().ToBitmap();
                pictureBox1.Image = bitmapper;

                if (startRecording)
                    videoWriter.Write(frame);
            }
            catch { }
        }

        private void Camera_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsOpen = false;
            closeDevice();
        }
        private void closeDevice()
        {
            try
            {
                if (videoCapture.IsOpened)
                {
                    StopRecording(true);
                    videoCapture.Dispose();
                }
            }
            catch { }
        }
        private void setFormSize(int width, int height)
        {
            this.Width = width + 15;
            this.Height = height + 68;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked) setFormSize(videoCapture.Height, videoCapture.Width);
            else setFormSize(videoCapture.Width, videoCapture.Height);
        }

        public void StartRecording(string fileName)
        {
            filePath = Path.Join(AppConfig.CommonPath, AppConfig.Config.VideosPath, $"{fileName}.{Constants.FileTypes.mp4}");
            try
            {
                int frameWidth = Convert.ToInt32(videoCapture.Get(CapProp.FrameWidth));
                int frameHeight = Convert.ToInt32(videoCapture.Get(CapProp.FrameHeight));

                videoWriter = new VideoWriter(filePath, VideoWriter.Fourcc('m', 'p', '4', 'v'), 30, new Size(frameWidth, frameHeight), true);
                if (!videoCapture.IsOpened || !videoWriter.IsOpened)
                {
                    Program.Message("Message", "Failed to open capture or writer.");
                    return;
                }
                startRecording = true;
            }
            catch { }
        }

        public void StopRecording(bool saveIt)
        {
            try
            {
                startRecording = false;
                if (videoWriter.IsOpened) videoWriter.Dispose();
                if (!saveIt) VideoProcessor.Delete(filePath);
            }
            catch { }

        }
    }
}
