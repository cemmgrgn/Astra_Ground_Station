using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Astra_Ground_Station
{
    public partial class Astra : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private readonly PointLatLng defGPSpos = new PointLatLng(40.991456211811055, 28.83219514613196);

        public Astra()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.FormClosing += Astra_FormClosing;
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RocketMap.MapProvider = BingSatelliteMapProvider.Instance;
            RocketMap.Position = defGPSpos;
            RocketMap.MinZoom = 1;
            RocketMap.MaxZoom = 32;
            RocketMap.Zoom = 16;
            GMaps.Instance.Mode = AccessMode.CacheOnly;
            RocketMap.OnMapZoomChanged += RocketMap_OnMapZoomChanged;

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No Camera!");
                return;
            }

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += videoSource_NewFrame;
            videoSource.Start();
        }

        private void RocketMap_OnMapZoomChanged()
        {
            RocketMap.Position = defGPSpos;
        }

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke(new MethodInvoker(delegate
                {
                    SetPictureBoxImage((Bitmap)eventArgs.Frame.Clone());
                }));
            }
            else
            {
                SetPictureBoxImage((Bitmap)eventArgs.Frame.Clone());
            }
        }

        private void SetPictureBoxImage(Bitmap bitmap)
        {
            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose();

            pictureBox1.Image = bitmap;
        }

        private void Astra_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();
            Environment.Exit(0);
        }

        private void StopCamera()
        {
            if (videoSource != null)
            {
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    int waited = 0;
                    while (videoSource.IsRunning && waited < 2000)
                    {
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(50);
                        waited += 50;
                    }
                }
                videoSource.NewFrame -= videoSource_NewFrame;
                try { videoSource.Stop(); } catch { }
                try { videoSource.SignalToStop(); } catch { }
                try { videoSource.WaitForStop(); } catch { }
                try { videoSource = null; } catch { }
                try { videoDevices = null; } catch { }
                try { pictureBox1.Image = null; } catch { }
                try { GC.Collect(); } catch { }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void SideMenu_Paint(object sender, PaintEventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void button1_Click_1(object sender, EventArgs e) { }
        private void GPSalert_Click(object sender, EventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label11_Click(object sender, EventArgs e) { }
        private void label23_Click(object sender, EventArgs e) { }
        private void label13_Click(object sender, EventArgs e) { }
        private void RocketStatus_Paint(object sender, PaintEventArgs e) { }
        private void MainPanel_Paint(object sender, PaintEventArgs e) { }
        private void altgraph_Click(object sender, EventArgs e) { }
        private void preschart_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
    }
}