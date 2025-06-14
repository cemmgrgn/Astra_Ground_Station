using AForge.Video;
using AForge.Video.DirectShow;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace Astra_Ground_Station
{
    public partial class Astra : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private readonly PointLatLng defGPSpos = new PointLatLng(40.991456211811055, 28.83219514613196);

        private Settings settingsControl;
        private TestStation testStationControl;

        private SerialPort serialPortRocket;
        private SerialPort serialPortPayload;

        private const int MaxChartPoints = 30;
        private int sampleIndex = 0;
        private double[] altBuffer = new double[MaxChartPoints];
        private double[] sdpBuffer = new double[MaxChartPoints];
        private double[] accBuffer = new double[MaxChartPoints];
        private double[] altPayloadBuffer = new double[MaxChartPoints];
        private double[] sdpPayloadBuffer = new double[MaxChartPoints];
        private double[] accPayloadBuffer = new double[MaxChartPoints];

        private System.Windows.Forms.Timer chartUpdateTimer;
        private System.Windows.Forms.Timer serialReconnectTimer;
        private bool hasNewRocketData = false;
        private bool hasNewPayloadData = false;

        private double lastAlt = 0, lastSdp = 0, lastAcc = 0;
        private double lastAltPayload = 0, lastSdpPayload = 0, lastAccPayload = 0;

        private double? lastMapLat = null, lastMapLon = null;

        private double? lastPressure = null;
        private double? lastAccVal = null;

        private double? lastPayloadPressure = null;
        private double? lastPayloadAccVal = null;

        private DateTime lastAltAlertChange = DateTime.MinValue;
        private DateTime lastIMUAlertChange = DateTime.MinValue;
        private bool altChangedRecently = false;
        private bool imuChangedRecently = false;

        private DateTime lastPayloadAltAlertChange = DateTime.MinValue;
        private DateTime lastPayloadIMUAlertChange = DateTime.MinValue;
        private bool payloadAltChangedRecently = false;
        private bool payloadIMUChangedRecently = false;

        private DateTime lastGNSSAlertChange = DateTime.MinValue;
        private bool gnssChangedRecently = false;
        private double? lastGNSSLon = null;

        private DateTime lastPayloadGNSSAlertChange = DateTime.MinValue;
        private bool payloadGNSSChangedRecently = false;
        private double? lastPayloadGNSSLon = null;

        private System.Windows.Forms.Timer alertTimeoutTimer;

        private Color ALTalertBorderColor = Color.LightSkyBlue;
        private Color IMUalertBorderColor = Color.LightSkyBlue;
        private Color FSCalertBorderColor = Color.Crimson;
        private Color GNSSalertBorderColor = Color.Crimson;
        private Color FRSalertBorderColor = Color.LightSkyBlue;
        private Color SRSalertBorderColor = Color.LightSkyBlue;

        private Color ALTalertPayloadBorderColor = Color.LightSkyBlue;
        private Color IMUalertPayloadBorderColor = Color.LightSkyBlue;
        private Color FSCalertPayloadBorderColor = Color.Crimson;
        private Color GNSSalertPayloadBorderColor = Color.Crimson;

        public Astra()
        {
            InitializeComponent();
            ConnectButton.Click += ConnectButton_Click;
            DisconnectButton.Click += DisconnectButton_Click;
            ConnectPayloadButton.Click += ConnectPayloadButton_Click;
            DisconnectPayloadButton.Click += DisconnectPayloadButton_Click;
            CameraConnectButton.Click += CameraConnectButton_Click;
            CameraDisconnectButton.Click += CameraDisconnectButton_Click;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.FormClosing += Astra_FormClosing;
            this.Load += Form1_Load;

            settingsControl = new Settings();
            settingsControl.Dock = DockStyle.Fill;

            testStationControl = new TestStation();
            testStationControl.Dock = DockStyle.Fill;

            ConnectButton.Enabled = true;
            DisconnectButton.Enabled = false;
            ConnectPayloadButton.Enabled = true;
            DisconnectPayloadButton.Enabled = false;
            CameraConnectButton.Enabled = true;
            CameraDisconnectButton.Enabled = false;
            CameraConnectButton.Visible = true;
            CameraDisconnectButton.Visible = false;

            chartUpdateTimer = new System.Windows.Forms.Timer();
            chartUpdateTimer.Interval = 1000;
            chartUpdateTimer.Tick += ChartUpdateTimer_Tick;
            chartUpdateTimer.Start();

            serialReconnectTimer = new System.Windows.Forms.Timer();
            serialReconnectTimer.Interval = 2000;
            serialReconnectTimer.Tick += SerialReconnectTimer_Tick;
            serialReconnectTimer.Start();

            alertTimeoutTimer = new System.Windows.Forms.Timer();
            alertTimeoutTimer.Interval = 500;
            alertTimeoutTimer.Tick += AlertTimeoutTimer_Tick;
            alertTimeoutTimer.Start();

            Control.CheckForIllegalCrossThreadCalls = false;

            ALTalert.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, ALTalert.ClientRectangle, ALTalertBorderColor, ButtonBorderStyle.Solid);
            IMUalert.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, IMUalert.ClientRectangle, IMUalertBorderColor, ButtonBorderStyle.Solid);
            FSCalert.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, FSCalert.ClientRectangle, FSCalertBorderColor, ButtonBorderStyle.Solid);
            GNSSalert.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, GNSSalert.ClientRectangle, GNSSalertBorderColor, ButtonBorderStyle.Solid);
            FRSalert.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, FRSalert.ClientRectangle, FRSalertBorderColor, ButtonBorderStyle.Solid);
            SRSalert.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, SRSalert.ClientRectangle, SRSalertBorderColor, ButtonBorderStyle.Solid);

            ALTalert2.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, ALTalert2.ClientRectangle, ALTalertPayloadBorderColor, ButtonBorderStyle.Solid);
            IMUalert2.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, IMUalert2.ClientRectangle, IMUalertPayloadBorderColor, ButtonBorderStyle.Solid);
            FSCalert2.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, FSCalert2.ClientRectangle, FSCalertPayloadBorderColor, ButtonBorderStyle.Solid);
            GNSSalert2.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, GNSSalert.ClientRectangle, GNSSalertPayloadBorderColor, ButtonBorderStyle.Solid);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            RocketMap.MapProvider = BingSatelliteMapProvider.Instance;
            RocketMap.Position = defGPSpos;
            RocketMap.MinZoom = 1;
            RocketMap.MaxZoom = 32;
            RocketMap.Zoom = 16;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            RocketMap.OnMapZoomChanged += RocketMap_OnMapZoomChanged;

            SetupChartSeries(AltChart, "Rocket", "Payload");
            SetupChartSeries(SpdChart, "Rocket", "Payload");
            SetupChartSeries(AccChart, "Rocket", "Payload");
        }

        private void SetupChartSeries(System.Windows.Forms.DataVisualization.Charting.Chart chart, string rocketName, string payloadName)
        {
            chart.Series.Clear();
            var payloadSeries = chart.Series.Add(payloadName);
            payloadSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            payloadSeries.Color = Color.LightBlue;
            payloadSeries.BorderWidth = 2;
            payloadSeries.LegendText = "Payload";

            var rocketSeries = chart.Series.Add(rocketName);
            rocketSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            rocketSeries.Color = Color.Purple;
            rocketSeries.BorderWidth = 2;
            rocketSeries.LegendText = "Rocket";
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

        private void CameraConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                string cameraMonikerString = null;
                string settingsFile = "settings.csv";
                if (File.Exists(settingsFile))
                {
                    var lines = File.ReadAllLines(settingsFile);
                    foreach (var line in lines)
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 2 &&
                            (parts[0].Trim().Equals("CameraPort", StringComparison.OrdinalIgnoreCase) ||
                             parts[0].Trim().Equals("Camera", StringComparison.OrdinalIgnoreCase)))
                        {
                            cameraMonikerString = parts[1].Trim();
                            break;
                        }
                    }
                }

                if (string.IsNullOrEmpty(cameraMonikerString))
                {
                    messageLabel.Text = "Camera port could not be found in settings.csv!";
                    return;
                }

                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                VideoCaptureDevice selectedDevice = null;
                foreach (FilterInfo device in videoDevices)
                {
                    if (device.MonikerString == cameraMonikerString || device.Name == cameraMonikerString)
                    {
                        selectedDevice = new VideoCaptureDevice(device.MonikerString);
                        break;
                    }
                }

                if (selectedDevice == null)
                {
                    messageLabel.Text = "No device was found corresponding to the configured camera port!";
                    return;
                }

                StopCamera();

                videoSource = selectedDevice;
                videoSource.NewFrame += videoSource_NewFrame;
                videoSource.Start();

                messageLabel.Text = "Camera started successfully.";

                CameraConnectButton.Enabled = false;
                CameraConnectButton.Visible = false;
                CameraDisconnectButton.Enabled = true;
                CameraDisconnectButton.Visible = true;
            }
            catch (Exception ex)
            {
                messageLabel.Text = "Error while starting camera: " + ex.Message;
            }
        }
        private void CameraDisconnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                StopCamera();
                messageLabel.Text = "Camera connection closed.";

                CameraConnectButton.Enabled = true;
                CameraConnectButton.Visible = true;
                CameraDisconnectButton.Enabled = false;
                CameraDisconnectButton.Visible = false;
            }
            catch (Exception ex)
            {
                messageLabel.Text = "Camera could not be disconnected: " + ex.Message;
            }
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

        private void Astra_FormClosing(object sender, FormClosingEventArgs e)
        {
            chartUpdateTimer?.Stop();
            serialReconnectTimer?.Stop();
            alertTimeoutTimer?.Stop();
            StopCamera();
            CloseSerialPorts();
            ConnectButton.Enabled = false;
            DisconnectButton.Enabled = false;
            ConnectPayloadButton.Enabled = false;
            DisconnectPayloadButton.Enabled = false;
            CameraConnectButton.Enabled = false;
            CameraDisconnectButton.Enabled = false;
            Environment.Exit(0);
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

        private (string rocketPort, int rocketBaud, string payloadPort, int payloadBaud) ReadSerialSettings()
        {
            string settingsFile = "settings.csv";
            string rocketCom = "COM100";
            int rocketBaud = 9600;
            string payloadCom = "COM102";
            int payloadBaud = 9600;

            try
            {
                if (File.Exists(settingsFile))
                {
                    var lines = File.ReadAllLines(settingsFile);
                    foreach (var line in lines)
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            if (parts[0].Trim() == "RocketCom")
                                rocketCom = parts[1].Trim();
                            else if (parts[0].Trim() == "RocketBaud")
                                int.TryParse(parts[1].Trim(), out rocketBaud);
                            else if (parts[0].Trim() == "PayloadCom")
                                payloadCom = parts[1].Trim();
                            else if (parts[0].Trim() == "PayloadBaud")
                                int.TryParse(parts[1].Trim(), out payloadBaud);
                        }
                    }
                }
                else
                {
                    messageLabel.Text = "settings.csv not found. Using default port settings.";
                }
            }
            catch (Exception ex)
            {
                messageLabel.Text = "Error reading settings.csv: " + ex.Message + " Using default port settings.";
            }

            return (rocketCom, rocketBaud, payloadCom, payloadBaud);
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPortRocket == null || !serialPortRocket.IsOpen)
                {
                    var (rocketPort, rocketBaud, _, _) = ReadSerialSettings();

                    serialPortRocket = new SerialPort(rocketPort, rocketBaud, Parity.None, 8, StopBits.One);
                    serialPortRocket.RtsEnable = true;
                    serialPortRocket.DtrEnable = true;

                    serialPortRocket.DataReceived += SerialPortRocket_DataReceived;
                    serialPortRocket.Open();
                    messageLabel.Text = $"Rocket Connected ({rocketPort}, {rocketBaud} baud).";
                    ConnectButton.Enabled = false;
                    ConnectButton.Visible = false;
                    DisconnectButton.Enabled = true;
                    DisconnectButton.Visible = true;
                }
            }
            catch (Exception ex)
            {
                messageLabel.Text = "Rocket Connection Error: " + ex.Message;
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                CloseSerialPortRocket();
                messageLabel.Text = "Rocket Connection Closed.";
                ConnectButton.Enabled = true;
                ConnectButton.Visible = true;
                DisconnectButton.Enabled = false;
                DisconnectButton.Visible = false;
            }
            catch (Exception ex)
            {
                messageLabel.Text = "Rocket Error: " + ex.Message;
            }
        }

        private void ConnectPayloadButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPortPayload == null || !serialPortPayload.IsOpen)
                {
                    var (_, _, payloadPort, payloadBaud) = ReadSerialSettings();

                    serialPortPayload = new SerialPort(payloadPort, payloadBaud, Parity.None, 8, StopBits.One);
                    serialPortPayload.RtsEnable = true;
                    serialPortPayload.DtrEnable = true;

                    serialPortPayload.DataReceived += SerialPortPayload_DataReceived;
                    serialPortPayload.Open();
                    messageLabel.Text = $"Payload Connected ({payloadPort}, {payloadBaud} baud).";
                    ConnectPayloadButton.Enabled = false;
                    ConnectPayloadButton.Visible = false;
                    DisconnectPayloadButton.Enabled = true;
                    DisconnectPayloadButton.Visible = true;
                }
            }
            catch (Exception ex)
            {
                messageLabel.Text = "Payload Connection Error: " + ex.Message;
            }
        }

        private void DisconnectPayloadButton_Click(object sender, EventArgs e)
        {
            try
            {
                CloseSerialPortPayload();
                messageLabel.Text = "Payload Connection Closed.";
                ConnectPayloadButton.Enabled = true;
                ConnectPayloadButton.Visible = true;
                DisconnectPayloadButton.Enabled = false;
                DisconnectPayloadButton.Visible = false;
            }
            catch (Exception ex)
            {
                messageLabel.Text = "Payload Error: " + ex.Message;
            }
        }

        private void SerialPortRocket_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPortRocket.ReadLine()?.Trim();

                this.BeginInvoke((MethodInvoker)delegate {
                    dat1rocket.Text = data;
                });

                if (!string.IsNullOrEmpty(data) && data.StartsWith("$AR"))
                {
                    string[] parts = data.Split(',');
                    if (parts.Length >= 22)
                    {
                        this.BeginInvoke((MethodInvoker)delegate
                        {
                            dat1lat.Text = parts[1];
                            dat1lon.Text = parts[2];
                            dat1alt.Text = parts[3];
                            dat1pre.Text = parts[4];
                            dat1gspd.Text = parts[5];
                            dat1aspd.Text = parts[6];
                            dat1wspd.Text = parts[7];
                            dat1yaw.Text = parts[8];
                            dat1pitch.Text = parts[9];
                            dat1roll.Text = parts[10];
                            dat1accx.Text = parts[11];
                            dat1accy.Text = parts[12];
                            dat1accz.Text = parts[13];
                            dat1absacc.Text = parts[14];
                            dat1gyrx.Text = parts[15];
                            dat1gyry.Text = parts[16];
                            dat1gyrz.Text = parts[17];
                            dat1temp.Text = parts[18];
                            dat1calt.Text = parts[19];
                            dat1vol.Text = parts[20];
                            dat1sts.Text = parts[21];

                            if (double.TryParse(dat1calt.Text, out double caltVal)) lastAlt = caltVal;
                            if (double.TryParse(dat1gspd.Text, out double gspdVal)) lastSdp = gspdVal;
                            if (double.TryParse(dat1absacc.Text, out double absaccVal)) lastAcc = absaccVal;
                            hasNewRocketData = true;

                            if (double.TryParse(dat1lat.Text, out double rocketLat) &&
                                double.TryParse(dat1lon.Text, out double rocketLon))
                            {
                                lastMapLat = rocketLat;
                                lastMapLon = rocketLon;
                            }

                            UpdateStatusAlerts();
                            UpdateSensorAlerts();
                        });
                    }
                    else
                    {
                        this.BeginInvoke((MethodInvoker)delegate
                        {
                            messageLabel.Text = "Incomplete or invalid rocket data received!";
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    messageLabel.Text = "Rocket serial parse error: " + ex.Message;
                });
            }
        }

        private void SerialPortPayload_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPortPayload.ReadLine()?.Trim();

                this.BeginInvoke((MethodInvoker)delegate {
                    dat2payload.Text = data;
                });

                if (!string.IsNullOrEmpty(data) && data.StartsWith("$AP"))
                {
                    string[] parts = data.Split(',');
                    if (parts.Length >= 22)
                    {
                        this.BeginInvoke((MethodInvoker)delegate
                        {
                            dat2lat.Text = parts[1];
                            dat2lon.Text = parts[2];
                            dat2alt.Text = parts[3];
                            dat2pre.Text = parts[4];
                            dat2gspd.Text = parts[5];
                            dat2aspd.Text = parts[6];
                            dat2wspd.Text = parts[7];
                            dat2yaw.Text = parts[8];
                            dat2pitch.Text = parts[9];
                            dat2roll.Text = parts[10];
                            dat2accx.Text = parts[11];
                            dat2accy.Text = parts[12];
                            dat2accz.Text = parts[13];
                            dat2absacc.Text = parts[14];
                            dat2gyrx.Text = parts[15];
                            dat2gyry.Text = parts[16];
                            dat2gyrz.Text = parts[17];
                            dat2temp.Text = parts[18];
                            dat2calt.Text = parts[19];
                            dat2vol.Text = parts[20];
                            dat2sts.Text = parts[21];

                            if (double.TryParse(dat2calt.Text, out double caltVal)) lastAltPayload = caltVal;
                            if (double.TryParse(dat2gspd.Text, out double gspdVal)) lastSdpPayload = gspdVal;
                            if (double.TryParse(dat2absacc.Text, out double absaccVal)) lastAccPayload = absaccVal;
                            hasNewPayloadData = true;

                            UpdateSensorAlertsPayload();
                        });
                    }
                    else
                    {
                        this.BeginInvoke((MethodInvoker)delegate
                        {
                            messageLabel.Text = "Incomplete or invalid payload data received!";
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    messageLabel.Text = "Payload serial parse error: " + ex.Message;
                });
            }
        }

        private void ChartUpdateTimer_Tick(object sender, EventArgs e)
        {
            bool anyUpdate = hasNewRocketData || hasNewPayloadData;
            hasNewRocketData = false;
            hasNewPayloadData = false;

            if (anyUpdate)
            {
                ShiftAndAppend(altBuffer, lastAlt);
                ShiftAndAppend(sdpBuffer, lastSdp);
                ShiftAndAppend(accBuffer, lastAcc);
                ShiftAndAppend(altPayloadBuffer, lastAltPayload);
                ShiftAndAppend(sdpPayloadBuffer, lastSdpPayload);
                ShiftAndAppend(accPayloadBuffer, lastAccPayload);

                UpdateChart2Series(AltChart, altBuffer, altPayloadBuffer);
                UpdateChart2Series(SpdChart, sdpBuffer, sdpPayloadBuffer);
                UpdateChart2Series(AccChart, accBuffer, accPayloadBuffer);

                sampleIndex++;
            }

            if (lastMapLat.HasValue && lastMapLon.HasValue)
            {
                RocketMap.Position = new PointLatLng(lastMapLat.Value, lastMapLon.Value);
            }
        }

        private void ShiftAndAppend(double[] buffer, double value)
        {
            for (int i = 0; i < buffer.Length - 1; i++)
                buffer[i] = buffer[i + 1];
            buffer[buffer.Length - 1] = value;
        }

        private void UpdateChart2Series(System.Windows.Forms.DataVisualization.Charting.Chart chart, double[] buffer1, double[] buffer2)
        {
            var seriesPayload = chart.Series[0];
            var seriesRocket = chart.Series[1];
            seriesPayload.Points.Clear();
            seriesRocket.Points.Clear();
            for (int i = 0; i < MaxChartPoints; i++)
            {
                int x = sampleIndex - MaxChartPoints + 1 + i;
                if (x < 0) x = 0;
                seriesPayload.Points.AddXY(x, buffer2[i]);
                seriesRocket.Points.AddXY(x, buffer1[i]);
            }
        }

        private void CloseSerialPortRocket()
        {
            try
            {
                if (serialPortRocket != null)
                {
                    serialPortRocket.DataReceived -= SerialPortRocket_DataReceived;

                    if (serialPortRocket.IsOpen)
                    {
                        serialPortRocket.Close();
                    }
                    serialPortRocket.Dispose();
                    serialPortRocket = null;
                }
            }
            catch { }
        }

        private void CloseSerialPortPayload()
        {
            try
            {
                if (serialPortPayload != null)
                {
                    serialPortPayload.DataReceived -= SerialPortPayload_DataReceived;

                    if (serialPortPayload.IsOpen)
                    {
                        serialPortPayload.Close();
                    }
                    serialPortPayload.Dispose();
                    serialPortPayload = null;
                }
            }
            catch { }
        }

        private void CloseSerialPorts()
        {
            CloseSerialPortRocket();
            CloseSerialPortPayload();
        }

        private void SerialReconnectTimer_Tick(object sender, EventArgs e)
        {
            if ((serialPortRocket == null || !serialPortRocket.IsOpen) && !ConnectButton.Enabled)
            {
                try { ConnectButton_Click(null, null); } catch { }
            }
            if ((serialPortPayload == null || !serialPortPayload.IsOpen) && !ConnectPayloadButton.Enabled)
            {
                try { ConnectPayloadButton_Click(null, null); } catch { }
            }
        }

        private void SetAlertGreen(Control alert)
        {
            alert.ForeColor = Color.Green;
            SetAlertBorderColor(alert, Color.Green);
        }

        private void SetAlertCyan(Control alert)
        {
            alert.ForeColor = Color.LightSkyBlue;
            SetAlertBorderColor(alert, Color.LightSkyBlue);
        }

        private void SetAlertRed(Control alert)
        {
            alert.ForeColor = Color.Crimson;
            SetAlertBorderColor(alert, Color.Crimson);
        }

        private void SetAlertBorderColor(Control alert, Color color)
        {
            if (alert == ALTalert) ALTalertBorderColor = color;
            else if (alert == IMUalert) IMUalertBorderColor = color;
            else if (alert == FSCalert) FSCalertBorderColor = color;
            else if (alert == GNSSalert) GNSSalertBorderColor = color;
            else if (alert == FRSalert) FRSalertBorderColor = color;
            else if (alert == SRSalert) SRSalertBorderColor = color;
            else if (alert == ALTalert2) ALTalertPayloadBorderColor = color;
            else if (alert == IMUalert2) IMUalertPayloadBorderColor = color;
            else if (alert == FSCalert2) FSCalertPayloadBorderColor = color;
            else if (alert == GNSSalert2) GNSSalertPayloadBorderColor = color;
            alert.Invalidate();
        }

        private void UpdateFSCalert()
        {
            if (!altChangedRecently && !imuChangedRecently)
            {
                SetAlertRed(FSCalert);
            }
            else if (altChangedRecently && imuChangedRecently)
            {
                SetAlertGreen(FSCalert);
            }
            else
            {
                SetAlertCyan(FSCalert);
            }
        }

        private void UpdateFSCalertPayload()
        {
            if (!payloadAltChangedRecently && !payloadIMUChangedRecently)
            {
                SetAlertRed(FSCalert2);
            }
            else if (payloadAltChangedRecently && payloadIMUChangedRecently)
            {
                SetAlertGreen(FSCalert2);
            }
            else
            {
                SetAlertCyan(FSCalert2);
            }
        }

        private void UpdateStatusAlerts()
        {
            int.TryParse(dat1sts.Text, out int status);

            if (status == 2)
            {
                SetAlertGreen(FRSalert);
                SetAlertCyan(SRSalert);
            }
            else if (status == 4)
            {
                SetAlertGreen(FRSalert);
                SetAlertGreen(SRSalert);
            }
            else
            {
                SetAlertCyan(FRSalert);
                SetAlertCyan(SRSalert);
            }
        }

        private void UpdateSensorAlerts()
        {
            if (double.TryParse(dat1pre.Text, out double pressure))
            {
                if (!lastPressure.HasValue || lastPressure.Value != pressure)
                {
                    SetAlertGreen(ALTalert);
                    lastAltAlertChange = DateTime.Now;
                    altChangedRecently = true;
                }
                lastPressure = pressure;
            }

            if (double.TryParse(dat1absacc.Text, out double accVal))
            {
                if (!lastAccVal.HasValue || lastAccVal.Value != accVal)
                {
                    SetAlertGreen(IMUalert);
                    lastIMUAlertChange = DateTime.Now;
                    imuChangedRecently = true;
                }
                lastAccVal = accVal;
            }

            if (double.TryParse(dat1lon.Text, out double lonVal))
            {
                if (!lastGNSSLon.HasValue || lastGNSSLon.Value != lonVal)
                {
                    SetAlertGreen(GNSSalert);
                    lastGNSSAlertChange = DateTime.Now;
                    gnssChangedRecently = true;
                }
                lastGNSSLon = lonVal;

                if (lonVal != 0)
                {
                }
                else
                {
                    SetAlertRed(GNSSalert);
                }
            }
            else
            {
                SetAlertRed(GNSSalert);
            }

            UpdateFSCalert();
        }

        private void UpdateSensorAlertsPayload()
        {
            if (double.TryParse(dat2pre.Text, out double pressure))
            {
                if (!lastPayloadPressure.HasValue || lastPayloadPressure.Value != pressure)
                {
                    SetAlertGreen(ALTalert2);
                    lastPayloadAltAlertChange = DateTime.Now;
                    payloadAltChangedRecently = true;
                }
                lastPayloadPressure = pressure;
            }

            if (double.TryParse(dat2absacc.Text, out double accVal))
            {
                if (!lastPayloadAccVal.HasValue || lastPayloadAccVal.Value != accVal)
                {
                    SetAlertGreen(IMUalert2);
                    lastPayloadIMUAlertChange = DateTime.Now;
                    payloadIMUChangedRecently = true;
                }
                lastPayloadAccVal = accVal;
            }

            if (double.TryParse(dat2lon.Text, out double lonVal))
            {
                if (!lastPayloadGNSSLon.HasValue || lastPayloadGNSSLon.Value != lonVal)
                {
                    SetAlertGreen(GNSSalert2);
                    lastPayloadGNSSAlertChange = DateTime.Now;
                    payloadGNSSChangedRecently = true;
                }
                lastPayloadGNSSLon = lonVal;

                if (lonVal != 0)
                {
                }
                else
                {
                    SetAlertRed(GNSSalert2);
                }
            }
            else
            {
                SetAlertRed(GNSSalert2);
            }

            UpdateFSCalertPayload();
        }

        private void AlertTimeoutTimer_Tick(object sender, EventArgs e)
        {
            bool altWasRecently = altChangedRecently;
            bool imuWasRecently = imuChangedRecently;
            bool payloadAltWasRecently = payloadAltChangedRecently;
            bool payloadIMUWasRecently = payloadIMUChangedRecently;

            if ((DateTime.Now - lastAltAlertChange).TotalSeconds > 3)
            {
                SetAlertRed(ALTalert);
                altChangedRecently = false;
            }

            if ((DateTime.Now - lastIMUAlertChange).TotalSeconds > 3)
            {
                SetAlertRed(IMUalert);
                imuChangedRecently = false;
            }

            if ((DateTime.Now - lastGNSSAlertChange).TotalSeconds > 3)
            {
                SetAlertRed(GNSSalert);
                gnssChangedRecently = false;
            }

            if ((DateTime.Now - lastPayloadAltAlertChange).TotalSeconds > 3)
            {
                SetAlertRed(ALTalert2);
                payloadAltChangedRecently = false;
            }

            if ((DateTime.Now - lastPayloadIMUAlertChange).TotalSeconds > 3)
            {
                SetAlertRed(IMUalert2);
                payloadIMUChangedRecently = false;
            }

            if ((DateTime.Now - lastPayloadGNSSAlertChange).TotalSeconds > 3)
            {
                SetAlertRed(GNSSalert2);
                payloadGNSSChangedRecently = false;
            }

            if (altWasRecently != altChangedRecently || imuWasRecently != imuChangedRecently)
            {
                UpdateFSCalert();
            }

            if (payloadAltWasRecently != payloadAltChangedRecently || payloadIMUWasRecently != payloadIMUChangedRecently)
            {
                UpdateFSCalertPayload();
            }
        }
    }
}