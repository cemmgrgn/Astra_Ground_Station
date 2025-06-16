using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Text.Json;

namespace Astra_Ground_Station
{
    public partial class Settings : UserControl
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private readonly string settingsFile = "settings.json";

        public Settings()
        {
            InitializeComponent();
            PopulateSerialPortCombos();
            PopulateBaudRateCombos();
            PopulateCameraCombo();

            LoadSettingsFromFile();

            checkbutton.Click += checkbutton_Click;
            checkbutton2.Click += checkbutton2_Click;
            checkbutton3.Click += checkbutton3_Click;
            rocketrefreshbutton.Click += rocketrefreshbutton_Click;
            payloadrefreshbutton.Click += payloadrefreshbutton_Click;
            HYIrefreshbutton.Click += HYIrefreshbutton_Click;

            cameraCombo.SelectedIndexChanged += cameraCombo_SelectedIndexChanged;
            camerarefreshbutton.Click += camerarefreshbutton_Click;
            savebutton.Click += savebutton_Click;

            dat1baud.SelectedIndexChanged += dat1baud_SelectedIndexChanged;
            dat1com.SelectedIndexChanged += dat1com_SelectedIndexChanged;
            dat2baud.SelectedIndexChanged += dat2baud_SelectedIndexChanged;
            dat2com.SelectedIndexChanged += dat2com_SelectedIndexChanged;
            dat3baud.SelectedIndexChanged += dat3baud_SelectedIndexChanged;
            dat3com.SelectedIndexChanged += dat3com_SelectedIndexChanged;

            rocketlogcheck.CheckedChanged += rocketlogcheck_CheckedChanged;
            payloadlogcheck.CheckedChanged += payloadlogcheck_CheckedChanged;

            cameraPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            cameraPictureBox.Anchor = AnchorStyles.None;

            this.VisibleChanged += Settings_VisibleChanged;
        }

        private void Settings_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                PopulateSerialPortCombos();
            }
        }

        public void PopulateSerialPortCombos()
        {
            string[] ports = SerialPort.GetPortNames();
            dat1com.Items.Clear();
            dat2com.Items.Clear();
            dat3com.Items.Clear();

            dat1com.Items.AddRange(ports);
            dat2com.Items.AddRange(ports);
            dat3com.Items.AddRange(ports);
        }

        private void PopulateBaudRateCombos()
        {
            string[] baudRates = { "9600", "19200", "38400", "57600", "115200" };
            dat1baud.Items.Clear();
            dat2baud.Items.Clear();
            dat3baud.Items.Clear();

            dat1baud.Items.AddRange(baudRates);
            dat2baud.Items.AddRange(baudRates);
            dat3baud.Items.AddRange(baudRates);
        }

        private void RefreshCameraDevices()
        {
            int oldIndex = cameraCombo.SelectedIndex;
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            cameraCombo.Items.Clear();
            foreach (FilterInfo device in videoDevices)
                cameraCombo.Items.Add(device.Name);

            if (cameraCombo.Items.Count > 0)
                cameraCombo.SelectedIndex = Math.Min(oldIndex, cameraCombo.Items.Count - 1);
        }

        private void PopulateCameraCombo()
        {
            RefreshCameraDevices();
        }

        private void camerarefreshbutton_Click(object sender, EventArgs e)
        {
            RefreshCameraDevices();
        }

        private void cameraCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CloseCameraSafely();

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (cameraCombo.SelectedIndex >= 0 && videoDevices.Count > cameraCombo.SelectedIndex)
            {
                string monikerString = videoDevices[cameraCombo.SelectedIndex].MonikerString;
                videoSource = new VideoCaptureDevice(monikerString);
                videoSource.NewFrame += videoSource_NewFrame;
                videoSource.Start();
            }
        }

        private void checkbutton_Click(object sender, EventArgs e)
        {
            checktext.Text = "";
            checktext.ForeColor = SystemColors.ControlText;
            CheckPort(dat1com, dat1baud, checktext);
        }

        private void checkbutton2_Click(object sender, EventArgs e)
        {
            checktext2.Text = "";
            checktext2.ForeColor = SystemColors.ControlText;
            CheckPort(dat2com, dat2baud, checktext2);
        }

        private void checkbutton3_Click(object sender, EventArgs e)
        {
            checktext3.Text = "";
            checktext3.ForeColor = SystemColors.ControlText;
            CheckPort(dat3com, dat3baud, checktext3);
        }

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            if (cameraPictureBox.InvokeRequired)
            {
                cameraPictureBox.BeginInvoke(new MethodInvoker(delegate
                {
                    SetCameraPictureBoxImage(bmp);
                }));
            }
            else
            {
                SetCameraPictureBoxImage(bmp);
            }
            CloseCameraSafely();
        }

        private void SetCameraPictureBoxImage(Bitmap bitmap)
        {
            if (cameraPictureBox.Image != null)
                cameraPictureBox.Image.Dispose();

            cameraPictureBox.Image = bitmap;
            cameraPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            cameraPictureBox.Anchor = AnchorStyles.None;
        }

        private void CloseCameraSafely()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                var vs = videoSource;
                videoSource = null;
                System.Threading.ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        vs.SignalToStop();
                        vs.WaitForStop();
                    }
                    catch { }
                    finally
                    {
                        vs.NewFrame -= videoSource_NewFrame;
                    }
                });
            }
        }

        private void CheckPort(ComboBox portCombo, ComboBox baudCombo, Label statusLabel)
        {
            if (portCombo.SelectedItem == null || baudCombo.SelectedItem == null)
            {
                statusLabel.Text = "Not available: Select Port and Baud Rate.";
                statusLabel.ForeColor = Color.Red;
                return;
            }

            string portName = portCombo.SelectedItem.ToString();
            int baudRate = int.Parse(baudCombo.SelectedItem.ToString());

            using (SerialPort port = new SerialPort(portName, baudRate))
            {
                try
                {
                    port.Open();
                    if (port.IsOpen)
                    {
                        statusLabel.Text = "Available: Port is open.";
                        statusLabel.ForeColor = Color.Green;
                        port.Close();
                    }
                    else
                    {
                        statusLabel.Text = "Not available: Port is closed.";
                        statusLabel.ForeColor = Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    statusLabel.Text = $"Not available: Error - {ex.Message}";
                    statusLabel.ForeColor = Color.Red;
                }
            }
        }

        private void rocketrefreshbutton_Click(object sender, EventArgs e)
        {
            PopulateSerialPortCombos();
        }

        private void payloadrefreshbutton_Click(object sender, EventArgs e)
        {
            PopulateSerialPortCombos();
        }

        private void HYIrefreshbutton_Click(object sender, EventArgs e)
        {
            PopulateSerialPortCombos();
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            SaveSettingsToFile();
            SetLabelTextWithTimeout(savetext, "Configuration saved.");
        }

        private void SetLabelTextWithTimeout(Label label, string text, int timeoutMs = 5000)
        {
            label.Text = text;
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = timeoutMs;
            timer.Tick += (s, e) =>
            {
                label.Text = "";
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void SaveSettingsToFile()
        {
            var settings = new AppSettings
            {
                RocketCom = dat1com.Text,
                RocketBaud = int.TryParse(dat1baud.Text, out int rb) ? rb : 9600,
                PayloadCom = dat2com.Text,
                PayloadBaud = int.TryParse(dat2baud.Text, out int pb) ? pb : 9600,
                HYICom = dat3com.Text,
                HYIBaud = int.TryParse(dat3baud.Text, out int hb) ? hb : 19200,
                HYIHertz = int.TryParse(HYIhertz.Text, out int hh) ? hh : 5,
                Camera = cameraCombo.Text,
                TeamID = byte.TryParse(teadidinput.Text, out byte tid) ? tid : (byte)0,
                RocketLogEnabled = rocketlogcheck.Checked,
                PayloadLogEnabled = payloadlogcheck.Checked
            };
            File.WriteAllText(settingsFile, JsonSerializer.Serialize(settings));
        }

        private void LoadSettingsFromFile()
        {
            if (!File.Exists(settingsFile))
                return;

            try
            {
                var settings = JsonSerializer.Deserialize<AppSettings>(File.ReadAllText(settingsFile));
                SelectComboBoxItem(dat1com, settings.RocketCom);
                SelectComboBoxItem(dat1baud, settings.RocketBaud.ToString());
                SelectComboBoxItem(dat2com, settings.PayloadCom);
                SelectComboBoxItem(dat2baud, settings.PayloadBaud.ToString());
                SelectComboBoxItem(dat3com, settings.HYICom);
                SelectComboBoxItem(dat3baud, settings.HYIBaud.ToString());
                HYIhertz.Text = settings.HYIHertz.ToString();
                SelectComboBoxItem(cameraCombo, settings.Camera);
                teadidinput.Text = settings.TeamID.ToString();
                rocketlogcheck.Checked = settings.RocketLogEnabled;
                payloadlogcheck.Checked = settings.PayloadLogEnabled;
            }
            catch { }
        }

        private void SelectComboBoxItem(ComboBox combo, string value)
        {
            int idx = combo.Items.IndexOf(value);
            if (idx >= 0)
                combo.SelectedIndex = idx;
            else
            {
                combo.Items.Add(value);
                combo.SelectedIndex = combo.Items.Count - 1;
            }
        }

        private void rocketlogcheck_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void payloadlogcheck_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void dat1baud_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dat1com_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dat2baud_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dat2com_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dat3baud_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dat3com_SelectedIndexChanged(object sender, EventArgs e) { }
    }

}