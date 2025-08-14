using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ArtificialHorizon
{
    public class ArtificialHorizonControl : UserControl
    {
        private float pitch = 0f;
        private float roll = 0f;

        [Description("Pitch in degrees (+up, -down)"), Category("Attitude")]
        public float Pitch
        {
            get => pitch;
            set { pitch = Math.Max(-90, Math.Min(90, value)); Invalidate(); }
        }

        [Description("Roll in degrees (+right, -left)"), Category("Attitude")]
        public float Roll
        {
            get => roll;
            set { roll = (value + 180) % 360 - 180; Invalidate(); }
        }

        public ArtificialHorizonControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            MinimumSize = new Size(80, 120);
            Size = new Size(160, 240);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int radius = Math.Min(ClientSize.Width, ClientSize.Height) / 10;
            Rectangle rect = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);
            using (GraphicsPath path = RoundedRect(rect, radius))
            {
                e.Graphics.SetClip(path);

                using (LinearGradientBrush bgBrush = new LinearGradientBrush(
                    rect, Color.FromArgb(0, 144, 255), Color.FromArgb(255, 140, 0), LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(bgBrush, rect);
                }

                DrawHorizon(e.Graphics, rect);

                DrawPitchLines(e.Graphics, rect);

                DrawRollMarkersRocket(e.Graphics, rect);

                DrawRocketCursor(e.Graphics, rect);

                e.Graphics.ResetClip();

                using (Pen borderPen = new Pen(Color.White, 0.8f))
                    e.Graphics.DrawPath(borderPen, path);
            }
        }

        private GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            int d = radius * 2;
            GraphicsPath p = new GraphicsPath();
            p.AddArc(r.Left, r.Top, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Top, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.Left, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }

        private void DrawHorizon(Graphics g, Rectangle rect)
        {
            float cx = rect.Width / 2f;
            float cy = rect.Height / 2f;
            float pxPerDeg = rect.Height / 180f;
            float yOffset = pxPerDeg * pitch;
            float horizonRoll = roll;

            g.TranslateTransform(cx, cy);
            g.RotateTransform(-horizonRoll);

            using (SolidBrush skyBrush = new SolidBrush(Color.FromArgb(0, 144, 255)))
            {
                g.FillRectangle(skyBrush, -rect.Width, -rect.Height * 1.5f + yOffset, rect.Width * 2, rect.Height * 2 + yOffset);
            }

            using (SolidBrush groundBrush = new SolidBrush(Color.FromArgb(255, 140, 0)))
            {
                g.FillRectangle(groundBrush, -rect.Width, yOffset, rect.Width * 2, rect.Height * 2);
            }

            using (Pen p = new Pen(Color.White, 0.8f))
            {
                g.DrawLine(p, -rect.Width, yOffset, rect.Width, yOffset);
            }

            g.ResetTransform();
        }

        private void DrawPitchLines(Graphics g, Rectangle rect)
        {
            float cx = rect.Width / 2f;
            float cy = rect.Height / 2f;
            float pxPerDeg = rect.Height / 180f;
            int step = 10;
            int maxDeg = 90;

            g.TranslateTransform(cx, cy);
            g.RotateTransform(-roll);

            using (Pen thickPen = new Pen(Color.White, 0.8f))
            using (Pen thinPen = new Pen(Color.White, 0.5f))
            using (Font f = new Font("Segoe UI", 7, FontStyle.Regular))
            using (StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                for (int deg = -maxDeg; deg <= maxDeg; deg += step)
                {
                    if (deg == 0) continue;
                    float y = pxPerDeg * (pitch - deg);

                    int len;
                    if (deg % 30 == 0)
                        len = rect.Width / 8;
                    else if (deg % 20 == 0)
                        len = rect.Width / 14;
                    else
                        len = rect.Width / 20;

                    Pen pen = (deg % 30 == 0) ? thickPen : thinPen;
                    g.DrawLine(pen, -len, y, len, y);

                    if (deg % 30 == 0)
                    {
                        string s = Math.Abs(deg).ToString();
                        g.DrawString(s, f, Brushes.White, -(len + 8), y, sf);
                        g.DrawString(s, f, Brushes.White, (len + 8), y, sf);
                    }
                }
            }
            g.ResetTransform();
        }

        private void DrawRollMarkersRocket(Graphics g, Rectangle rect)
        {
            float cx = rect.Width / 2f;
            float cy = rect.Height / 2f;
            float r = rect.Width / 2f - 8;

            using (Pen p = new Pen(Color.White, 1.0f))
            using (Font f = new Font("Segoe UI", 8, FontStyle.Bold))
            using (StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                float angleTop = (float)((0 - roll - 90) * Math.PI / 180.0);
                float x1t = cx + (float)Math.Cos(angleTop) * (r - 10);
                float y1t = cy + (float)Math.Sin(angleTop) * (r - 10);
                float x2t = cx + (float)Math.Cos(angleTop) * r;
                float y2t = cy + (float)Math.Sin(angleTop) * r;
                g.DrawLine(p, x1t, y1t, x2t, y2t);
                g.DrawString("0", f, Brushes.White, cx, cy - r + 8, sf);

                float angleBot = (float)((180 - roll - 90) * Math.PI / 180.0);
                float x1b = cx + (float)Math.Cos(angleBot) * (r - 10);
                float y1b = cy + (float)Math.Sin(angleBot) * (r - 10);
                float x2b = cx + (float)Math.Cos(angleBot) * r;
                float y2b = cy + (float)Math.Sin(angleBot) * r;
                g.DrawLine(p, x1b, y1b, x2b, y2b);
                g.DrawString("180", f, Brushes.White, cx, cy + r - 8, sf);
            }
        }

        private void DrawRocketCursor(Graphics g, Rectangle rect)
        {
            float cx = rect.Width / 2f;
            float cy = rect.Height / 2f;
            float scale = 1.5f;

            using (Pen p = new Pen(Color.White, 1.3f))
            {
                g.DrawLine(p, cx, cy - 12 * scale, cx, cy + 12 * scale);

                using (GraphicsPath uPath = new GraphicsPath())
                {
                    uPath.AddArc(cx - 7 * scale, cy + 6 * scale, 14 * scale, 10 * scale, 0, 180);
                    g.DrawPath(p, uPath);
                }

                g.DrawLine(p, cx - 12 * scale, cy + 10 * scale, cx - 4 * scale, cy + 6 * scale);
                g.DrawLine(p, cx + 12 * scale, cy + 10 * scale, cx + 4 * scale, cy + 6 * scale);

                g.DrawLine(p, cx - 10 * scale, cy, cx + 10 * scale, cy);
            }
        }
    }
}