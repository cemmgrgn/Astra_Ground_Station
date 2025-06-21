using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Astra_Ground_Station
{
    public partial class RocketAngleIndicator : UserControl
    {
        private float _angle = 0;
        private Image _rocketImage;

        private const int RocketWidth = 160;
        private const int RocketHeight = 20;

        public RocketAngleIndicator()
        {
            InitializeComponent();
            this.Size = new Size(300, 300);

            try
            {
                this.RocketImage = Properties.Resources.rocket;
            }
            catch
            {
                this.RocketImage = null;
            }

        }

        [Description("Roketin yer ile yaptığı açı"), Category("Gösterge"), DefaultValue(0)]
        public float Angle
        {
            get => _angle;
            set
            {
                if (value < -90) value = -90;
                if (value > 90) value = 90;
                _angle = value;
                Invalidate();
            }
        }

        [Description("Roket görseli"), Category("Gösterge")]
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

            int groundY = 150;

            using (Pen groundPen = new Pen(Color.Black, 1))
                e.Graphics.DrawLine(groundPen, 0, groundY, Width, groundY);

            int pivotX = 150;
            int pivotY = groundY;

            e.Graphics.TranslateTransform(pivotX, pivotY);
            e.Graphics.RotateTransform(_angle);

            if (_rocketImage != null)
            {
                e.Graphics.TranslateTransform(-_rocketImage.Width / 2, -_rocketImage.Height);
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
            Angle = angle;
        }
    }
}