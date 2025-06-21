namespace Astra_Ground_Station
{
    partial class RocketAngleIndicator
    {
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.ROKET;
            pictureBox1.Location = new Point(20, 140);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(160, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // RocketAngleIndicator
            // 
            Controls.Add(pictureBox1);
            Name = "RocketAngleIndicator";
            Size = new Size(300, 300);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }
        private PictureBox pictureBox1;
    }
}