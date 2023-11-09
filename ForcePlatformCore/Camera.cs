using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ForcePlatformCore
{
    public partial class Camera : Form
    {
        FilterInfoCollection filter;
        VideoCaptureDevice device;
        Bitmap bitmapper;

        public Camera()
        {
            InitializeComponent();
        }

        private void Camera_Load(object sender, EventArgs e)
        {
            filter = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo device in filter)
                comboDevices.Items.Add(device.Name);
        }

        private void comboDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                device.Stop();
                device.NewFrame -= Device_NewFrame;
            }
            catch { }

            device = new VideoCaptureDevice(filter[comboDevices.SelectedIndex].MonikerString);
            device.NewFrame += Device_NewFrame;
            device.Start();
        }

        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            bitmapper = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bitmapper;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            //bitmapper.RotateFlip(RotateFlipType.Rotate90FlipY);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            //bitmapper.RotateFlip(RotateFlipType.RotateNoneFlipY);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            //bitmapper.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }
    }
}
