using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace Astra_Ground_Station
{
    public partial class TestStation : UserControl
    {
        private SerialPort rocketSerialPort;

        public TestStation()
        {
            InitializeComponent();
            btnConnect.Click += btnConnect_Click;
            btnDisconnect.Click += btnDisconnect_Click;

            btnConnect.Visible = true;
            btnDisconnect.Visible = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string settingsPath = "settings.csv";
            string rocketPort = "COM101";
            int rocketBaud = 9600;

            if (File.Exists(settingsPath))
            {
                var lines = File.ReadAllLines(settingsPath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        if (parts[0] == "RocketCom")
                            rocketPort = parts[1];
                        else if (parts[0] == "RocketBaud")
                            int.TryParse(parts[1], out rocketBaud);
                    }
                }
            }
            else
            {
                SetErrorMsg("settings.csv file not found.");
                return;
            }

            if (!string.IsNullOrEmpty(rocketPort))
            {
                try
                {
                    if (rocketSerialPort == null || !rocketSerialPort.IsOpen)
                    {
                        rocketSerialPort = new SerialPort(rocketPort, rocketBaud);
                        rocketSerialPort.DataReceived += RocketSerialPort_DataReceived;
                        rocketSerialPort.ErrorReceived += RocketSerialPort_ErrorReceived;
                        rocketSerialPort.PinChanged += RocketSerialPort_PinChanged;
                        rocketSerialPort.Open();
                        SetErrorMsg($"Connected: {rocketPort} @ {rocketBaud}");

                        btnConnect.Visible = false;
                        btnDisconnect.Visible = true;
                    }
                    else
                    {
                        SetErrorMsg("Port already open.");
                    }
                }
                catch (Exception ex)
                {
                    SetErrorMsg("Serial port could not be opened: " + ex.Message);
                }
            }
            else
            {
                SetErrorMsg("RocketCom information not found.");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            DisconnectSerialPort("Serial port disconnected.");
        }

        private void RocketSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = rocketSerialPort.ReadLine();
                this.BeginInvoke(new Action(() => ProcessRocketData(data)));
            }
            catch
            {
                this.BeginInvoke(new Action(() =>
                {
                    DisconnectSerialPort("");
                }));
            }
        }

        private void RocketSerialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                DisconnectSerialPort("");
            }));
        }

        private void RocketSerialPort_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            if (e.EventType == SerialPinChange.CDChanged ||
                e.EventType == SerialPinChange.DsrChanged ||
                e.EventType == SerialPinChange.Break)
            {
                if (rocketSerialPort != null && !rocketSerialPort.IsOpen)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        DisconnectSerialPort("");
                    }));
                }
            }
        }

        private void ProcessRocketData(string data)
        {
            if (string.IsNullOrEmpty(data)) return;

            var datmsgLabel = this.Controls.Find("datmsg", true);
            if (datmsgLabel.Length > 0 && datmsgLabel[0] is Label)
                ((Label)datmsgLabel[0]).Text = data;

            if (data.StartsWith("$RA"))
            {
                var dat1msgLabel = this.Controls.Find("dat1msg", true);
                if (dat1msgLabel.Length > 0 && dat1msgLabel[0] is Label)
                    ((Label)dat1msgLabel[0]).Text = data;
            }
            else if (data.StartsWith("$RB"))
            {
                var dat2msgLabel = this.Controls.Find("dat2msg", true);
                if (dat2msgLabel.Length > 0 && dat2msgLabel[0] is Label)
                    ((Label)dat2msgLabel[0]).Text = data;
            }
            else if (data.StartsWith("$RC"))
            {
                var dat3msgLabel = this.Controls.Find("dat3msg", true);
                if (dat3msgLabel.Length > 0 && dat3msgLabel[0] is Label)
                    ((Label)dat3msgLabel[0]).Text = data;
            }
            else if (data.StartsWith("$AR"))
            {
                var sentmgLabel = this.Controls.Find("sentmsg", true);
                if (sentmgLabel.Length > 0 && sentmgLabel[0] is Label)
                    ((Label)sentmgLabel[0]).Text = data;
            }

            if (data.StartsWith("$RA") || data.StartsWith("$RB") || data.StartsWith("$RC"))
            {
                string[] parts = data.Split(',');
                if (parts.Length >= 22)
                {
                    string prefix =
                        data.StartsWith("$RA") ? "dat1" :
                        data.StartsWith("$RB") ? "dat2" :
                        data.StartsWith("$RC") ? "dat3" : "";

                    SetTelemetryText(prefix, parts);
                }
            }
        }

        private void SetTelemetryText(string prefix, string[] parts)
        {
            try
            {
                string[] fields = { "rocket", "lat", "lon", "alt", "pre", "gspd", "aspd", "ang", "yaw", "pitch", "roll", "accx", "accy", "accz", "absacc", "gyrx", "gyry", "gyrz", "temp", "calt", "vol", "sts" };
                for (int i = 0; i < fields.Length; i++)
                {
                    var controls = this.Controls.Find(prefix + fields[i], true);
                    if (controls.Length > 0 && controls[0] is Label label)
                    {
                        label.Text = parts.Length > i ? parts[i] : "";
                    }
                }
            }
            catch
            {
            }
        }

        private void SetErrorMsg(string msg)
        {
            var errmsgLabel = this.Controls.Find("errmsg", true);
            if (errmsgLabel.Length > 0 && errmsgLabel[0] is Label label)
            {
                label.Text = msg;
            }
        }

        private void DisconnectSerialPort(string msg)
        {
            try
            {
                if (rocketSerialPort != null)
                {
                    if (rocketSerialPort.IsOpen)
                        rocketSerialPort.Close();

                    rocketSerialPort.DataReceived -= RocketSerialPort_DataReceived;
                    rocketSerialPort.ErrorReceived -= RocketSerialPort_ErrorReceived;
                    rocketSerialPort.PinChanged -= RocketSerialPort_PinChanged;
                    rocketSerialPort.Dispose();
                    rocketSerialPort = null;
                }
            }
            catch { }
            SetErrorMsg(msg);

            btnConnect.Visible = true;
            btnDisconnect.Visible = false;
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}