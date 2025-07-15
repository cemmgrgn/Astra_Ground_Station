using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Astra_Ground_Station
{
    public partial class RocketAngleIndicator : UserControl
    {
        private float _angle = 175;
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

        public float Angle
        {
            get => _angle;
            set
            {
                if (value < 0) value = 0;
                if (value > 180) value = 180;
                _angle = value;
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

            int groundY = 150;
            int pivotX = 150;
            int pivotY = groundY;

            using (Pen groundPen = new Pen(Color.Black, 1))
                e.Graphics.DrawLine(groundPen, pivotX, groundY, Width, groundY);

            float displayAngle = -_angle + 270;

            e.Graphics.TranslateTransform(pivotX, pivotY);
            e.Graphics.RotateTransform(displayAngle);

            if (_rocketImage != null)
            {
                e.Graphics.TranslateTransform(-_rocketImage.Width / 2, -_rocketImage.Height + 8);
                e.Graphics.DrawImage(_rocketImage, 0, 0, _rocketImage.Width, _rocketImage.Height);
            }
            else
            {
                Point[] arrowPoints = new Point[]
                {
                    new Point(RocketWidth / 2, 0),
                    new Point(0, RocketHeight),
                    new Point(RocketWidth, RocketHeight)
                };
                e.Graphics.TranslateTransform(-RocketWidth / 2, -RocketHeight + 8);
                e.Graphics.FillPolygon(Brushes.Gray, arrowPoints);
            }

            e.Graphics.ResetTransform();
        }

        public void SetAngle(float angle)
        {
            Angle = angle;
        }
    }
}