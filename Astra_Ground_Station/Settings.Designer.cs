namespace Astra_Ground_Station
{
    partial class Settings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dat1com = new ComboBox();
            dat1baud = new ComboBox();
            RocketComText = new Label();
            RocketBaudText = new Label();
            checkbutton = new Button();
            RocketPort = new Panel();
            rocketrefreshbutton = new Button();
            checktext = new Label();
            Payloadtext = new Label();
            PayloadPort = new Panel();
            payloadrefreshbutton = new Button();
            checktext2 = new Label();
            dat2com = new ComboBox();
            checkbutton2 = new Button();
            dat2baud = new ComboBox();
            PayloadBaudText = new Label();
            PayloadComText = new Label();
            HYItext = new Label();
            HYIport = new Panel();
            HYIhertz = new TextBox();
            HYIhertztext = new Label();
            HYIrefreshbutton = new Button();
            checktext3 = new Label();
            dat3com = new ComboBox();
            checkbutton3 = new Button();
            dat3baud = new ComboBox();
            HYIbaudtext = new Label();
            HYIcomtext = new Label();
            label2 = new Label();
            panel1 = new Panel();
            cameraPictureBox = new PictureBox();
            camerarefreshbutton = new Button();
            cameraCombo = new ComboBox();
            cameracheckbutton = new Button();
            label5 = new Label();
            panel3 = new Panel();
            savetext = new Label();
            savebutton = new Button();
            teadidinput = new TextBox();
            teamidtext = new Label();
            label7 = new Label();
            label1 = new Label();
            RocketPort.SuspendLayout();
            PayloadPort.SuspendLayout();
            HYIport.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cameraPictureBox).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // dat1com
            // 
            dat1com.FormattingEnabled = true;
            dat1com.Location = new Point(34, 67);
            dat1com.Name = "dat1com";
            dat1com.Size = new Size(121, 23);
            dat1com.TabIndex = 8;
            // 
            // dat1baud
            // 
            dat1baud.FormattingEnabled = true;
            dat1baud.Location = new Point(214, 67);
            dat1baud.Name = "dat1baud";
            dat1baud.Size = new Size(121, 23);
            dat1baud.TabIndex = 9;
            // 
            // RocketComText
            // 
            RocketComText.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RocketComText.ForeColor = SystemColors.ButtonFace;
            RocketComText.Location = new Point(34, 41);
            RocketComText.Name = "RocketComText";
            RocketComText.Size = new Size(100, 23);
            RocketComText.TabIndex = 3;
            RocketComText.Text = "COM Port:";
            RocketComText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RocketBaudText
            // 
            RocketBaudText.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RocketBaudText.ForeColor = SystemColors.ButtonFace;
            RocketBaudText.Location = new Point(214, 41);
            RocketBaudText.Name = "RocketBaudText";
            RocketBaudText.Size = new Size(100, 23);
            RocketBaudText.TabIndex = 4;
            RocketBaudText.Text = "Baud Rate:";
            RocketBaudText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // checkbutton
            // 
            checkbutton.Location = new Point(251, 127);
            checkbutton.Name = "checkbutton";
            checkbutton.Size = new Size(84, 31);
            checkbutton.TabIndex = 5;
            checkbutton.Text = "Check";
            checkbutton.UseVisualStyleBackColor = true;
            // 
            // RocketPort
            // 
            RocketPort.BorderStyle = BorderStyle.FixedSingle;
            RocketPort.Controls.Add(rocketrefreshbutton);
            RocketPort.Controls.Add(checktext);
            RocketPort.Controls.Add(dat1com);
            RocketPort.Controls.Add(checkbutton);
            RocketPort.Controls.Add(dat1baud);
            RocketPort.Controls.Add(RocketBaudText);
            RocketPort.Controls.Add(RocketComText);
            RocketPort.Location = new Point(27, 26);
            RocketPort.Name = "RocketPort";
            RocketPort.Size = new Size(368, 201);
            RocketPort.TabIndex = 6;
            // 
            // rocketrefreshbutton
            // 
            rocketrefreshbutton.BackgroundImage = Properties.Resources.refreshicon;
            rocketrefreshbutton.BackgroundImageLayout = ImageLayout.Stretch;
            rocketrefreshbutton.Location = new Point(312, 19);
            rocketrefreshbutton.Name = "rocketrefreshbutton";
            rocketrefreshbutton.Size = new Size(23, 23);
            rocketrefreshbutton.TabIndex = 7;
            rocketrefreshbutton.UseVisualStyleBackColor = true;
            // 
            // checktext
            // 
            checktext.ForeColor = SystemColors.ButtonFace;
            checktext.Location = new Point(13, 161);
            checktext.Name = "checktext";
            checktext.Size = new Size(322, 38);
            checktext.TabIndex = 6;
            checktext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Payloadtext
            // 
            Payloadtext.AutoSize = true;
            Payloadtext.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Payloadtext.ForeColor = SystemColors.ButtonFace;
            Payloadtext.Location = new Point(434, 16);
            Payloadtext.Name = "Payloadtext";
            Payloadtext.Size = new Size(197, 18);
            Payloadtext.TabIndex = 9;
            Payloadtext.Text = "Payload Port Settings";
            // 
            // PayloadPort
            // 
            PayloadPort.BorderStyle = BorderStyle.FixedSingle;
            PayloadPort.Controls.Add(payloadrefreshbutton);
            PayloadPort.Controls.Add(checktext2);
            PayloadPort.Controls.Add(dat2com);
            PayloadPort.Controls.Add(checkbutton2);
            PayloadPort.Controls.Add(dat2baud);
            PayloadPort.Controls.Add(PayloadBaudText);
            PayloadPort.Controls.Add(PayloadComText);
            PayloadPort.Location = new Point(420, 26);
            PayloadPort.Name = "PayloadPort";
            PayloadPort.Size = new Size(368, 201);
            PayloadPort.TabIndex = 8;
            // 
            // payloadrefreshbutton
            // 
            payloadrefreshbutton.BackgroundImage = Properties.Resources.refreshicon;
            payloadrefreshbutton.BackgroundImageLayout = ImageLayout.Stretch;
            payloadrefreshbutton.Location = new Point(312, 19);
            payloadrefreshbutton.Name = "payloadrefreshbutton";
            payloadrefreshbutton.Size = new Size(23, 23);
            payloadrefreshbutton.TabIndex = 7;
            payloadrefreshbutton.UseVisualStyleBackColor = true;
            // 
            // checktext2
            // 
            checktext2.ForeColor = SystemColors.ButtonFace;
            checktext2.Location = new Point(13, 161);
            checktext2.Name = "checktext2";
            checktext2.Size = new Size(322, 38);
            checktext2.TabIndex = 6;
            checktext2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dat2com
            // 
            dat2com.FormattingEnabled = true;
            dat2com.Location = new Point(34, 67);
            dat2com.Name = "dat2com";
            dat2com.Size = new Size(121, 23);
            dat2com.TabIndex = 8;
            // 
            // checkbutton2
            // 
            checkbutton2.Location = new Point(251, 127);
            checkbutton2.Name = "checkbutton2";
            checkbutton2.Size = new Size(84, 31);
            checkbutton2.TabIndex = 5;
            checkbutton2.Text = "Check";
            checkbutton2.UseVisualStyleBackColor = true;
            // 
            // dat2baud
            // 
            dat2baud.FormattingEnabled = true;
            dat2baud.Location = new Point(214, 67);
            dat2baud.Name = "dat2baud";
            dat2baud.Size = new Size(121, 23);
            dat2baud.TabIndex = 1;
            // 
            // PayloadBaudText
            // 
            PayloadBaudText.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PayloadBaudText.ForeColor = SystemColors.ButtonFace;
            PayloadBaudText.Location = new Point(214, 41);
            PayloadBaudText.Name = "PayloadBaudText";
            PayloadBaudText.Size = new Size(100, 23);
            PayloadBaudText.TabIndex = 4;
            PayloadBaudText.Text = "Baud Rate:";
            PayloadBaudText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PayloadComText
            // 
            PayloadComText.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PayloadComText.ForeColor = SystemColors.ButtonFace;
            PayloadComText.Location = new Point(34, 41);
            PayloadComText.Name = "PayloadComText";
            PayloadComText.Size = new Size(100, 23);
            PayloadComText.TabIndex = 3;
            PayloadComText.Text = "COM Port:";
            PayloadComText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // HYItext
            // 
            HYItext.AutoSize = true;
            HYItext.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HYItext.ForeColor = SystemColors.ButtonFace;
            HYItext.Location = new Point(833, 16);
            HYItext.Name = "HYItext";
            HYItext.Size = new Size(160, 18);
            HYItext.TabIndex = 11;
            HYItext.Text = "HYI Port Settings";
            // 
            // HYIport
            // 
            HYIport.BorderStyle = BorderStyle.FixedSingle;
            HYIport.Controls.Add(HYIhertz);
            HYIport.Controls.Add(HYIhertztext);
            HYIport.Controls.Add(HYIrefreshbutton);
            HYIport.Controls.Add(checktext3);
            HYIport.Controls.Add(dat3com);
            HYIport.Controls.Add(checkbutton3);
            HYIport.Controls.Add(dat3baud);
            HYIport.Controls.Add(HYIbaudtext);
            HYIport.Controls.Add(HYIcomtext);
            HYIport.Location = new Point(819, 26);
            HYIport.Name = "HYIport";
            HYIport.Size = new Size(368, 201);
            HYIport.TabIndex = 10;
            // 
            // HYIhertz
            // 
            HYIhertz.Location = new Point(34, 135);
            HYIhertz.Name = "HYIhertz";
            HYIhertz.Size = new Size(121, 23);
            HYIhertz.TabIndex = 11;
            // 
            // HYIhertztext
            // 
            HYIhertztext.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HYIhertztext.ForeColor = SystemColors.ButtonFace;
            HYIhertztext.Location = new Point(34, 107);
            HYIhertztext.Name = "HYIhertztext";
            HYIhertztext.Size = new Size(121, 23);
            HYIhertztext.TabIndex = 9;
            HYIhertztext.Text = "Sending Hertz:";
            HYIhertztext.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // HYIrefreshbutton
            // 
            HYIrefreshbutton.BackgroundImage = Properties.Resources.refreshicon;
            HYIrefreshbutton.BackgroundImageLayout = ImageLayout.Stretch;
            HYIrefreshbutton.Location = new Point(312, 19);
            HYIrefreshbutton.Name = "HYIrefreshbutton";
            HYIrefreshbutton.Size = new Size(23, 23);
            HYIrefreshbutton.TabIndex = 7;
            HYIrefreshbutton.UseVisualStyleBackColor = true;
            // 
            // checktext3
            // 
            checktext3.ForeColor = SystemColors.ButtonFace;
            checktext3.Location = new Point(13, 161);
            checktext3.Name = "checktext3";
            checktext3.Size = new Size(322, 38);
            checktext3.TabIndex = 6;
            checktext3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dat3com
            // 
            dat3com.FormattingEnabled = true;
            dat3com.Location = new Point(34, 67);
            dat3com.Name = "dat3com";
            dat3com.Size = new Size(121, 23);
            dat3com.TabIndex = 8;
            // 
            // checkbutton3
            // 
            checkbutton3.Location = new Point(251, 127);
            checkbutton3.Name = "checkbutton3";
            checkbutton3.Size = new Size(84, 31);
            checkbutton3.TabIndex = 5;
            checkbutton3.Text = "Check";
            checkbutton3.UseVisualStyleBackColor = true;
            // 
            // dat3baud
            // 
            dat3baud.FormattingEnabled = true;
            dat3baud.Location = new Point(214, 67);
            dat3baud.Name = "dat3baud";
            dat3baud.Size = new Size(121, 23);
            dat3baud.TabIndex = 1;
            // 
            // HYIbaudtext
            // 
            HYIbaudtext.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HYIbaudtext.ForeColor = SystemColors.ButtonFace;
            HYIbaudtext.Location = new Point(214, 41);
            HYIbaudtext.Name = "HYIbaudtext";
            HYIbaudtext.Size = new Size(100, 23);
            HYIbaudtext.TabIndex = 4;
            HYIbaudtext.Text = "Baud Rate:";
            HYIbaudtext.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // HYIcomtext
            // 
            HYIcomtext.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HYIcomtext.ForeColor = SystemColors.ButtonFace;
            HYIcomtext.Location = new Point(34, 41);
            HYIcomtext.Name = "HYIcomtext";
            HYIcomtext.Size = new Size(100, 23);
            HYIcomtext.TabIndex = 3;
            HYIcomtext.Text = "COM Port:";
            HYIcomtext.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(1231, 16);
            label2.Name = "label2";
            label2.Size = new Size(153, 18);
            label2.TabIndex = 13;
            label2.Text = "Camera Settings";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(cameraPictureBox);
            panel1.Controls.Add(camerarefreshbutton);
            panel1.Controls.Add(cameraCombo);
            panel1.Controls.Add(cameracheckbutton);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(1219, 26);
            panel1.Name = "panel1";
            panel1.Size = new Size(368, 201);
            panel1.TabIndex = 12;
            // 
            // cameraPictureBox
            // 
            cameraPictureBox.Location = new Point(172, 41);
            cameraPictureBox.Name = "cameraPictureBox";
            cameraPictureBox.Size = new Size(163, 117);
            cameraPictureBox.TabIndex = 8;
            cameraPictureBox.TabStop = false;
            // 
            // camerarefreshbutton
            // 
            camerarefreshbutton.BackgroundImage = Properties.Resources.refreshicon;
            camerarefreshbutton.BackgroundImageLayout = ImageLayout.Stretch;
            camerarefreshbutton.Location = new Point(312, 19);
            camerarefreshbutton.Name = "camerarefreshbutton";
            camerarefreshbutton.Size = new Size(23, 23);
            camerarefreshbutton.TabIndex = 7;
            camerarefreshbutton.UseVisualStyleBackColor = true;
            // 
            // cameraCombo
            // 
            cameraCombo.FormattingEnabled = true;
            cameraCombo.Location = new Point(34, 67);
            cameraCombo.Name = "cameraCombo";
            cameraCombo.Size = new Size(121, 23);
            cameraCombo.TabIndex = 9;
            // 
            // cameracheckbutton
            // 
            cameracheckbutton.Location = new Point(71, 127);
            cameracheckbutton.Name = "cameracheckbutton";
            cameracheckbutton.Size = new Size(84, 31);
            cameracheckbutton.TabIndex = 5;
            cameracheckbutton.Text = "Check";
            cameracheckbutton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(34, 41);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 3;
            label5.Text = "Camera:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(savetext);
            panel3.Controls.Add(savebutton);
            panel3.Controls.Add(teadidinput);
            panel3.Controls.Add(teamidtext);
            panel3.Location = new Point(27, 253);
            panel3.Name = "panel3";
            panel3.Size = new Size(1560, 301);
            panel3.TabIndex = 14;
            // 
            // savetext
            // 
            savetext.ForeColor = SystemColors.ButtonFace;
            savetext.Location = new Point(1205, 261);
            savetext.Name = "savetext";
            savetext.Size = new Size(322, 38);
            savetext.TabIndex = 12;
            savetext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // savebutton
            // 
            savebutton.Location = new Point(1443, 227);
            savebutton.Name = "savebutton";
            savebutton.Size = new Size(84, 31);
            savebutton.TabIndex = 14;
            savebutton.Text = "Save";
            savebutton.UseVisualStyleBackColor = true;
            // 
            // teadidinput
            // 
            teadidinput.Location = new Point(34, 60);
            teadidinput.Name = "teadidinput";
            teadidinput.Size = new Size(121, 23);
            teadidinput.TabIndex = 13;
            // 
            // teamidtext
            // 
            teamidtext.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            teamidtext.ForeColor = SystemColors.ButtonFace;
            teamidtext.Location = new Point(34, 32);
            teamidtext.Name = "teamidtext";
            teamidtext.Size = new Size(121, 23);
            teamidtext.TabIndex = 12;
            teamidtext.Text = "Team ID:";
            teamidtext.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ButtonFace;
            label7.Location = new Point(41, 244);
            label7.Name = "label7";
            label7.Size = new Size(135, 18);
            label7.TabIndex = 15;
            label7.Text = "Other Settings";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(41, 16);
            label1.Name = "label1";
            label1.Size = new Size(188, 18);
            label1.TabIndex = 7;
            label1.Text = "Rocket Port Settings";
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(label7);
            Controls.Add(panel3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(HYItext);
            Controls.Add(HYIport);
            Controls.Add(Payloadtext);
            Controls.Add(PayloadPort);
            Controls.Add(label1);
            Controls.Add(RocketPort);
            Name = "Settings";
            Size = new Size(1600, 1000);
            RocketPort.ResumeLayout(false);
            PayloadPort.ResumeLayout(false);
            HYIport.ResumeLayout(false);
            HYIport.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cameraPictureBox).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox dat1com;
        private ComboBox dat1baud;
        private Label RocketComText;
        private Label RocketBaudText;
        private Button checkbutton;
        private Panel RocketPort;
        private Label checktext;
        private Button rocketrefreshbutton;
        private Label Payloadtext;
        private Panel PayloadPort;
        private Button payloadrefreshbutton;
        private Label checktext2;
        private ComboBox dat2com;
        private Button checkbutton2;
        private ComboBox dat2baud;
        private Label PayloadBaudText;
        private Label PayloadComText;
        private Label HYItext;
        private Panel HYIport;
        private Button HYIrefreshbutton;
        private Label checktext3;
        private ComboBox dat3com;
        private Button checkbutton3;
        private Label HYIcomtext;
        private Label label2;
        private Panel panel1;
        private Button camerarefreshbutton;
        private ComboBox cameraCombo;
        private Button cameracheckbutton;
        private Label label5;
        private PictureBox cameraPictureBox;
        private ComboBox dat3baud;
        private Label HYIbaudtext;
        private Label HYIhertztext;
        private Panel panel3;
        private Label label7;
        private TextBox HYIhertz;
        private Button savebutton;
        private TextBox teadidinput;
        private Label teamidtext;
        private Label label1;
        private Label savetext;
    }
}