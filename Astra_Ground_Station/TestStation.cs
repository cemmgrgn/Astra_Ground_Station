using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace Astra_Ground_Station
{
    public partial class TestStation : UserControl
    {
        private SerialPort serialPort;
        private Label serialLabel;

        public TestStation()
        {
            InitializeComponent();

            // Label ekle
            serialLabel = new Label();
            serialLabel.AutoSize = true;
            serialLabel.Location = new System.Drawing.Point(20, 20);
            serialLabel.Text = "Serial veri bekleniyor...";
            this.Controls.Add(serialLabel);

            // SerialPort nesnesini oluştur (başta portu açma!)
            serialPort = new SerialPort("COM6", 9600);
            serialPort.RtsEnable = true;
            serialPort.DtrEnable = true;
            serialPort.DataReceived += SerialPort_DataReceived;

            // Form/thread güvenliği için (opsiyonel, tavsiye edilen yol her zaman Invoke/BeginInvoke kullanmaktır)
            Control.CheckForIllegalCrossThreadCalls = false;

            // Eğer TestStation bir form değil UserControl ise, FormClosing eventini parent formdan set etmelisin.
            // Eğer bir formdaysa aşağıdaki satırı açabilirsin:
            // this.FormClosing += Form1_FormClosing;
        }

        // Eğer UserControl'ün parent formunda FormClosing eventini yakalamak istersen,
        // parent formda aşağıdaki gibi çağırabilirsin:
        // form.FormClosing += (s, e) => testStation1.OnFormClosing(e);

        public void OnFormClosing(FormClosingEventArgs e)
        {
            if (serialPort != null)
            {
                if (serialPort.IsOpen)
                    serialPort.Close();
                serialPort.Dispose();
                serialPort = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Seri portu açmak için butona basılmasını bekle
            try
            {
                if (!serialPort.IsOpen)
                {
                    serialPort.Open();
                    serialLabel.Text = "Serial port açıldı, veri bekleniyor...";
                }
                else
                {
                    serialLabel.Text = "Serial port zaten açık.";
                }
            }
            catch (Exception ex)
            {
                serialLabel.Text = "Port açılamadı: " + ex.Message;
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort.ReadLine();
                // UI thread'ine güvenli şekilde yaz
                this.BeginInvoke(new Action(() =>
                {
                    serialLabel.Text = data;
                }));
            }
            catch (Exception ex)
            {
                // Hata olursa etikete yaz
                this.BeginInvoke(new Action(() =>
                {
                    serialLabel.Text = "Okuma hatası: " + ex.Message;
                }));
            }
        }
    }
}