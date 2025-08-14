using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Astra_Ground_Station
{
    public partial class RocketAngleIndicator : UserControl
    {
        private float _angle = -95;
        private Image _rocketImage;
        private Image _backgroundImage;

        private const int RocketWidth = 160;
        private const int RocketHeight = 20;

        public RocketAngleIndicator()
        {
            InitializeComponent();
            this.Size = new Size(300, 300);

            try
            {
                this.RocketImage = Properties.Resources.ozgunroket;
                if (this.RocketImage != null)
                {
                    this.RocketImage = new Bitmap(this.RocketImage, new Size(RocketWidth, RocketHeight));
                }
            }
            catch
            {
                this.RocketImage = null;
            }

            try
            {
                this.BackgroundImageCustom = Properties.Resources.jıbapsal;
                if (this.BackgroundImageCustom != null)
                {
                    this.BackgroundImageCustom = new Bitmap(this.BackgroundImageCustom, this.Size);
                }
            }
            catch
            {
                this.BackgroundImageCustom = null;
            }
        }

        [Browsable(false)]
        public Image BackgroundImageCustom
        {
            get => _backgroundImage;
            set
            {
                _backgroundImage = value;
                Invalidate();
            }
        }

        public float Angle
        {
            get => _angle;
            set
            {
                if (value < -90) value = 90;
                if (value > 90) value = -90;
                _angle = value-90;
                Invalidate();
            }
        }

        public Image RocketImage
        {
            get => _rocketImage;
            set
            {
                _rocketImage = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_backgroundImage != null)
            {
                e.Graphics.DrawImage(_backgroundImage, 0, 0, this.Width, this.Height);
            }
            else
            {
                e.Graphics.Clear(Color.White);
            }
            
            int groundY = 150;

            //using (Pen groundPen = new Pen(Color.Black, 0)) e.Graphics.DrawLine(groundPen, 0, groundY, Width, groundY);

            int pivotX = 150;
            int pivotY = groundY;

            e.Graphics.TranslateTransform(pivotX, pivotY);
            e.Graphics.RotateTransform(_angle);

            if (_rocketImage != null)
            {
                e.Graphics.TranslateTransform(-_rocketImage.Width / 2-5, -_rocketImage.Height);
                e.Graphics.DrawImage(_rocketImage, 0, 0, _rocketImage.Width, _rocketImage.Height);
            }
            else
            {
                e.Graphics.TranslateTransform(-RocketWidth / 2, -RocketHeight);
                e.Graphics.FillRectangle(Brushes.Gray, 0, 0, RocketWidth, RocketHeight);
            }

            e.Graphics.ResetTransform();
        }

        public void SetAngle(float angle)
        {
            if (this.IsDisposed || !this.IsHandleCreated)
                return;

            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke((MethodInvoker)(() => SetAngle(angle)));
                }
                catch (ObjectDisposedException)
                {
                }
            }
            else
            {
                Angle = angle;
            }
        }
    }
}