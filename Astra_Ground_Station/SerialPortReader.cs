using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Astra_Ground_Station
{
    public class SerialPortReader : IDisposable
    {
        private SerialPort serialPort;
        private Label outputLabel;
        private System.Threading.Timer readTimer;
        private string csvFilePath;
        private Dictionary<string, string> settingsDict;

        public SerialPortReader(string csvFilePath, Label outputLabel)
        {
            this.csvFilePath = csvFilePath;
            this.outputLabel = outputLabel;
            LoadSettings();
        }

        private void LoadSettings()
        {
            settingsDict = new Dictionary<string, string>();
            if (!File.Exists(csvFilePath))
                throw new FileNotFoundException("settings.csv not found!");

            foreach (var line in File.ReadAllLines(csvFilePath))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split(',');
                if (parts.Length == 2)
                    settingsDict[parts[0].Trim()] = parts[1].Trim();
            }
        }

        public void Start(string portType = "Rocket")
        {
            string portNameKey = portType + "Com";
            string baudRateKey = portType + "Baud";

            if (!settingsDict.ContainsKey(portNameKey) || !settingsDict.ContainsKey(baudRateKey))
                throw new ArgumentException("Port settings missing in CSV for: " + portType);

            string portName = settingsDict[portNameKey];
            int baudRate = int.Parse(settingsDict[baudRateKey]);

            serialPort = new SerialPort(portName, baudRate);
            serialPort.DataReceived += SerialPort_DataReceived;

            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open serial port: " + ex.Message);
                return;
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort.ReadLine();
                if (outputLabel.InvokeRequired)
                {
                    outputLabel.Invoke(new MethodInvoker(() =>
                    {
                        outputLabel.Text = data;
                    }));
                }
                else
                {
                    outputLabel.Text = data;
                }
            }
            catch { }
        }

        public void Stop()
        {
            if (serialPort != null)
            {
                serialPort.DataReceived -= SerialPort_DataReceived;
                if (serialPort.IsOpen)
                {
                    try { serialPort.Close(); } catch { }
                }
            }
        }

        public void Dispose()
        {
            Stop();
            if (serialPort != null)
            {
                serialPort.Dispose();
                serialPort = null;
            }
        }
    }
}