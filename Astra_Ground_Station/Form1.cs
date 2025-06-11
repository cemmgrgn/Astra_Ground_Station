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
        private SerialPortReader serialPortReader;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private readonly PointLatLng defGPSpos = new PointLatLng(40.991456211811055, 28.83219514613196);

        private Settings settingsControl;
        private TestStation testStationControl;

        public Astra()
        {
            InitializeComponent();
            ConnectionButton.Click += ConnectionButton_Click;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.FormClosing += Astra_FormClosing;
            this.Load += Form1_Load;

            settingsControl = new Settings();
            settingsControl.Dock = DockStyle.Fill;

            testStationControl = new TestStation();
            testStationControl.Dock = DockStyle.Fill;
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
            /*
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No Camera!");
                return;
            }

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += videoSource_NewFrame;
            videoSource.Start();*/
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
            serialPortReader.Dispose();
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

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            if (!SettingsPanel.Controls.Contains(settingsControl))
            {
                SettingsPanel.Controls.Clear();
                SettingsPanel.Controls.Add(settingsControl);
                SettingsPanel.Visible = true;
                SettingsPanel.BringToFront();
                TestStationPanel.Controls.Remove(testStationControl);
                TestStationPanel.Visible = false;
            }
            else
            {
                SettingsPanel.Controls.Remove(settingsControl);
                SettingsPanel.Visible = false;
            }
        }

        private void TestStation_Click(object sender, EventArgs e)
        {
            if (!TestStationPanel.Controls.Contains(testStationControl))
            {
                TestStationPanel.Controls.Clear();
                TestStationPanel.Controls.Add(testStationControl);
                TestStationPanel.Visible = true;
                TestStationPanel.BringToFront();
                SettingsPanel.Controls.Remove(settingsControl);
                SettingsPanel.Visible = false;
            }
            else
            {
                TestStationPanel.Controls.Remove(testStationControl);
                TestStationPanel.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void SideMenu_Paint(object sender, PaintEventArgs e) { }
        private void button1_Click(object sender, EventArgs e)
        {
            SettingsPanel.Visible = false;
            SettingsPanel.BringToFront();
            TestStationPanel.Visible = false;
            TestStationPanel.BringToFront();
        }



        private void ConnectionButton_Click(object sender, EventArgs e)
        {
            if (serialPortReader == null)
            {
                try
                {
                    serialPortReader = new SerialPortReader("settings.csv", label1);
                    serialPortReader.Start("Rocket");
                    label1.Text = "Disconnect";
                    label1.ForeColor = Color.Red;
                }
                catch (Exception ex)
                {
                    label1.Text = "Bağlantı Hatası: " + ex.Message;
                    label1.ForeColor = Color.DarkGreen;
                }
            }
            else
            {
                serialPortReader.Dispose();
                serialPortReader = null;
                label1.Text = "Connect";
                label1.ForeColor = Color.DarkGreen;
            }
        }
    }
    
}