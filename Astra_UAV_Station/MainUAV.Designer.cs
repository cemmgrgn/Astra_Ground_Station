namespace Astra_Ground_Station
{
    partial class Astra
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Astra));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            SideMenu = new Panel();
            messageLabel = new Label();
            ConnectButton = new Button();
            DisconnectButton = new Button();
            AltLogo = new PictureBox();
            AstraText = new Label();
            AstraLogo = new PictureBox();
            SettingsButton = new Button();
            TestStationButton = new Button();
            GroundStationButton = new Button();
            dat1rocket = new Label();
            MainPanel = new Panel();
            PosText = new Label();
            panel1 = new Panel();
            graphtext = new Label();
            CamText = new Label();
            RocketText = new Label();
            CamPanel = new Panel();
            capvid = new Button();
            stpcapvid = new Button();
            capimg = new Button();
            CameraConnectButton = new Button();
            CameraDisconnectButton = new Button();
            pictureBox1 = new PictureBox();
            GraphPanel = new Panel();
            AccChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            SpdChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            AltChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            RocketMap = new GMap.NET.WindowsForms.GMapControl();
            RocketPanel = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            gyroxtext = new Label();
            statustext = new Label();
            voltagetext = new Label();
            gyroytext = new Label();
            temptext = new Label();
            gyroztext = new Label();
            calcalttext = new Label();
            dat1sts = new Label();
            dat1absacc = new Label();
            absacctext = new Label();
            dat1ang = new Label();
            angeltext = new Label();
            dat1accz = new Label();
            accztext = new Label();
            dat1aspd = new Label();
            aveltext = new Label();
            dat1calt = new Label();
            dat1accy = new Label();
            accytext = new Label();
            dat1gspd = new Label();
            gveltext = new Label();
            dat1temp = new Label();
            dat1accx = new Label();
            accxtext = new Label();
            dat1pre = new Label();
            pressuretext = new Label();
            dat1gyrz = new Label();
            dat1roll = new Label();
            roltext = new Label();
            dat1alt = new Label();
            gpsalttext = new Label();
            dat1gyry = new Label();
            dat1pitch = new Label();
            pitchtext = new Label();
            dat1lon = new Label();
            longitudetext = new Label();
            dat1gyrx = new Label();
            dat1yaw = new Label();
            yawtext = new Label();
            dat1lat = new Label();
            latitudetext = new Label();
            dat1vol = new Label();
            RocketAlert = new Panel();
            SRSalert = new Button();
            FRSalert = new Button();
            TSCalert = new Button();
            IMUalert = new Button();
            SSCalert = new Button();
            FSCalert = new Button();
            ALTalert = new Button();
            GNSSalert = new Button();
            SettingsPanel = new Panel();
            TestStationPanel = new Panel();
            SideMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AltLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AstraLogo).BeginInit();
            MainPanel.SuspendLayout();
            CamPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            GraphPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AccChart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SpdChart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AltChart).BeginInit();
            RocketPanel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            RocketAlert.SuspendLayout();
            SuspendLayout();
            // 
            // SideMenu
            // 
            SideMenu.BackColor = Color.FromArgb(40, 40, 40);
            SideMenu.Controls.Add(messageLabel);
            SideMenu.Controls.Add(ConnectButton);
            SideMenu.Controls.Add(DisconnectButton);
            SideMenu.Controls.Add(AltLogo);
            SideMenu.Controls.Add(AstraText);
            SideMenu.Controls.Add(AstraLogo);
            SideMenu.Controls.Add(SettingsButton);
            SideMenu.Controls.Add(TestStationButton);
            SideMenu.Controls.Add(GroundStationButton);
            SideMenu.Dock = DockStyle.Left;
            SideMenu.Location = new Point(0, 0);
            SideMenu.Name = "SideMenu";
            SideMenu.Size = new Size(300, 1001);
            SideMenu.TabIndex = 1;
            // 
            // messageLabel
            // 
            messageLabel.ForeColor = SystemColors.Control;
            messageLabel.Location = new Point(3, 896);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(294, 51);
            messageLabel.TabIndex = 12;
            // 
            // ConnectButton
            // 
            ConnectButton.BackColor = Color.White;
            ConnectButton.FlatAppearance.BorderColor = Color.FromArgb(255, 224, 192);
            ConnectButton.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ConnectButton.ForeColor = Color.DarkGreen;
            ConnectButton.Location = new Point(25, 628);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(250, 50);
            ConnectButton.TabIndex = 10;
            ConnectButton.Text = "Connect Rocket";
            ConnectButton.UseVisualStyleBackColor = false;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // DisconnectButton
            // 
            DisconnectButton.BackColor = Color.White;
            DisconnectButton.FlatAppearance.BorderColor = Color.FromArgb(255, 224, 192);
            DisconnectButton.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DisconnectButton.ForeColor = Color.Crimson;
            DisconnectButton.Location = new Point(25, 628);
            DisconnectButton.Name = "DisconnectButton";
            DisconnectButton.Size = new Size(250, 50);
            DisconnectButton.TabIndex = 11;
            DisconnectButton.Text = "Disconnect Rocket";
            DisconnectButton.UseVisualStyleBackColor = false;
            DisconnectButton.Visible = false;
            // 
            // AltLogo
            // 
            AltLogo.BackColor = Color.Transparent;
            AltLogo.Image = Astra_UAV_Station.Properties.Resources.KulturLogo;
            AltLogo.Location = new Point(-1, 950);
            AltLogo.Name = "AltLogo";
            AltLogo.Size = new Size(300, 50);
            AltLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            AltLogo.TabIndex = 9;
            AltLogo.TabStop = false;
            // 
            // AstraText
            // 
            AstraText.BackColor = Color.Transparent;
            AstraText.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AstraText.ForeColor = SystemColors.Control;
            AstraText.Location = new Point(0, 225);
            AstraText.Name = "AstraText";
            AstraText.Size = new Size(300, 30);
            AstraText.TabIndex = 8;
            AstraText.Text = "Astra Ground Station";
            AstraText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AstraLogo
            // 
            AstraLogo.BackColor = Color.Transparent;
            AstraLogo.Image = (Image)resources.GetObject("AstraLogo.Image");
            AstraLogo.Location = new Point(50, 25);
            AstraLogo.Name = "AstraLogo";
            AstraLogo.Size = new Size(200, 200);
            AstraLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            AstraLogo.TabIndex = 7;
            AstraLogo.TabStop = false;
            // 
            // SettingsButton
            // 
            SettingsButton.Font = new Font("Verdana", 9.75F, FontStyle.Bold);
            SettingsButton.Location = new Point(25, 450);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(250, 50);
            SettingsButton.TabIndex = 5;
            SettingsButton.Text = "Settings";
            SettingsButton.UseVisualStyleBackColor = true;
            SettingsButton.Click += SettingsButton_Click;
            // 
            // TestStationButton
            // 
            TestStationButton.Font = new Font("Verdana", 9.75F, FontStyle.Bold);
            TestStationButton.Location = new Point(25, 375);
            TestStationButton.Name = "TestStationButton";
            TestStationButton.Size = new Size(250, 50);
            TestStationButton.TabIndex = 4;
            TestStationButton.Text = "Test Station";
            TestStationButton.UseVisualStyleBackColor = true;
            TestStationButton.Click += TestStation_Click;
            // 
            // GroundStationButton
            // 
            GroundStationButton.Font = new Font("Verdana", 9.75F, FontStyle.Bold);
            GroundStationButton.Location = new Point(25, 300);
            GroundStationButton.Name = "GroundStationButton";
            GroundStationButton.Size = new Size(250, 50);
            GroundStationButton.TabIndex = 0;
            GroundStationButton.Text = "Ground Station";
            GroundStationButton.UseVisualStyleBackColor = true;
            GroundStationButton.Click += button1_Click;
            // 
            // dat1rocket
            // 
            dat1rocket.BackColor = Color.Transparent;
            dat1rocket.Font = new Font("Segoe UI", 7F);
            dat1rocket.ForeColor = SystemColors.Control;
            dat1rocket.Location = new Point(15, 236);
            dat1rocket.Name = "dat1rocket";
            dat1rocket.Size = new Size(563, 18);
            dat1rocket.TabIndex = 0;
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(PosText);
            MainPanel.Controls.Add(panel1);
            MainPanel.Controls.Add(graphtext);
            MainPanel.Controls.Add(CamText);
            MainPanel.Controls.Add(RocketText);
            MainPanel.Controls.Add(CamPanel);
            MainPanel.Controls.Add(GraphPanel);
            MainPanel.Controls.Add(RocketPanel);
            MainPanel.Controls.Add(SettingsPanel);
            MainPanel.Dock = DockStyle.Top;
            MainPanel.Location = new Point(300, 0);
            MainPanel.Margin = new Padding(30);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1604, 1000);
            MainPanel.TabIndex = 2;
            // 
            // PosText
            // 
            PosText.AutoSize = true;
            PosText.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PosText.ForeColor = SystemColors.ButtonFace;
            PosText.Location = new Point(662, 13);
            PosText.Name = "PosText";
            PosText.Size = new Size(173, 18);
            PosText.TabIndex = 9;
            PosText.Text = "Rocket Orientation";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(625, 21);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 300);
            panel1.TabIndex = 13;
            // 
            // graphtext
            // 
            graphtext.AutoSize = true;
            graphtext.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            graphtext.ForeColor = SystemColors.ButtonFace;
            graphtext.Location = new Point(76, 339);
            graphtext.Name = "graphtext";
            graphtext.Size = new Size(117, 18);
            graphtext.TabIndex = 11;
            graphtext.Text = "Graph - Map";
            // 
            // CamText
            // 
            CamText.AutoSize = true;
            CamText.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CamText.ForeColor = SystemColors.ButtonFace;
            CamText.Location = new Point(838, 340);
            CamText.Name = "CamText";
            CamText.Size = new Size(77, 18);
            CamText.TabIndex = 10;
            CamText.Text = "Camera";
            // 
            // RocketText
            // 
            RocketText.AutoSize = true;
            RocketText.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RocketText.ForeColor = SystemColors.ButtonFace;
            RocketText.Location = new Point(76, 12);
            RocketText.Name = "RocketText";
            RocketText.Size = new Size(69, 18);
            RocketText.TabIndex = 8;
            RocketText.Text = "Rocket";
            // 
            // CamPanel
            // 
            CamPanel.BorderStyle = BorderStyle.FixedSingle;
            CamPanel.Controls.Add(capvid);
            CamPanel.Controls.Add(stpcapvid);
            CamPanel.Controls.Add(capimg);
            CamPanel.Controls.Add(CameraConnectButton);
            CamPanel.Controls.Add(CameraDisconnectButton);
            CamPanel.Controls.Add(pictureBox1);
            CamPanel.Location = new Point(800, 350);
            CamPanel.Name = "CamPanel";
            CamPanel.Size = new Size(770, 625);
            CamPanel.TabIndex = 4;
            // 
            // capvid
            // 
            capvid.BackColor = Color.White;
            capvid.FlatAppearance.BorderColor = Color.FromArgb(255, 224, 192);
            capvid.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            capvid.ForeColor = Color.DimGray;
            capvid.Location = new Point(422, 554);
            capvid.Name = "capvid";
            capvid.Size = new Size(250, 50);
            capvid.TabIndex = 14;
            capvid.Text = "Record";
            capvid.UseVisualStyleBackColor = false;
            capvid.Click += capvid_Click;
            // 
            // stpcapvid
            // 
            stpcapvid.BackColor = Color.White;
            stpcapvid.FlatAppearance.BorderColor = Color.FromArgb(255, 224, 192);
            stpcapvid.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            stpcapvid.ForeColor = Color.DimGray;
            stpcapvid.Location = new Point(422, 554);
            stpcapvid.Name = "stpcapvid";
            stpcapvid.Size = new Size(250, 50);
            stpcapvid.TabIndex = 15;
            stpcapvid.Text = "Stop Record";
            stpcapvid.UseVisualStyleBackColor = false;
            stpcapvid.Click += stpcapvid_Click;
            // 
            // capimg
            // 
            capimg.BackColor = Color.White;
            capimg.FlatAppearance.BorderColor = Color.FromArgb(255, 224, 192);
            capimg.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            capimg.ForeColor = Color.DimGray;
            capimg.Location = new Point(96, 554);
            capimg.Name = "capimg";
            capimg.Size = new Size(250, 50);
            capimg.TabIndex = 13;
            capimg.Text = "Capture Image";
            capimg.UseVisualStyleBackColor = false;
            capimg.Click += capimg_Click;
            // 
            // CameraConnectButton
            // 
            CameraConnectButton.BackColor = Color.White;
            CameraConnectButton.FlatAppearance.BorderColor = Color.FromArgb(255, 224, 192);
            CameraConnectButton.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CameraConnectButton.ForeColor = Color.DarkGreen;
            CameraConnectButton.Location = new Point(16, 14);
            CameraConnectButton.Name = "CameraConnectButton";
            CameraConnectButton.Size = new Size(250, 50);
            CameraConnectButton.TabIndex = 11;
            CameraConnectButton.Text = "Connect Camera";
            CameraConnectButton.UseVisualStyleBackColor = false;
            // 
            // CameraDisconnectButton
            // 
            CameraDisconnectButton.BackColor = Color.White;
            CameraDisconnectButton.FlatAppearance.BorderColor = Color.FromArgb(255, 224, 192);
            CameraDisconnectButton.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CameraDisconnectButton.ForeColor = Color.Crimson;
            CameraDisconnectButton.Location = new Point(16, 14);
            CameraDisconnectButton.Name = "CameraDisconnectButton";
            CameraDisconnectButton.Size = new Size(250, 50);
            CameraDisconnectButton.TabIndex = 12;
            CameraDisconnectButton.Text = "Disconnect Camera";
            CameraDisconnectButton.UseVisualStyleBackColor = false;
            CameraDisconnectButton.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(16, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(730, 590);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // GraphPanel
            // 
            GraphPanel.BorderStyle = BorderStyle.FixedSingle;
            GraphPanel.Controls.Add(AccChart);
            GraphPanel.Controls.Add(SpdChart);
            GraphPanel.Controls.Add(AltChart);
            GraphPanel.Controls.Add(RocketMap);
            GraphPanel.Location = new Point(30, 350);
            GraphPanel.Name = "GraphPanel";
            GraphPanel.Size = new Size(750, 625);
            GraphPanel.TabIndex = 2;
            // 
            // AccChart
            // 
            chartArea1.AxisX.Title = "Time(s)";
            chartArea1.AxisY.Title = "Absolute Accleration(m/s²)";
            chartArea1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Bottom;
            chartArea1.Name = "ChartArea1";
            AccChart.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            AccChart.Legends.Add(legend1);
            AccChart.Location = new Point(22, 319);
            AccChart.Name = "AccChart";
            AccChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Abs Acc(m/s²)";
            AccChart.Series.Add(series1);
            AccChart.Size = new Size(340, 290);
            AccChart.TabIndex = 3;
            AccChart.Text = "chart3";
            // 
            // SpdChart
            // 
            chartArea2.AxisX.Title = "Time(s)";
            chartArea2.AxisY.Title = "Ground Speed(m/s)";
            chartArea2.Name = "ChartArea1";
            SpdChart.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            SpdChart.Legends.Add(legend2);
            SpdChart.Location = new Point(384, 14);
            SpdChart.Name = "SpdChart";
            SpdChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Ground Speed(m/s)";
            SpdChart.Series.Add(series2);
            SpdChart.Size = new Size(340, 290);
            SpdChart.TabIndex = 2;
            SpdChart.Text = "chart2";
            // 
            // AltChart
            // 
            chartArea3.AxisX.Title = "Time(s)";
            chartArea3.AxisY.Title = "Altitute(m)";
            chartArea3.Name = "ChartArea1";
            AltChart.ChartAreas.Add(chartArea3);
            legend3.BorderWidth = 2;
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            AltChart.Legends.Add(legend3);
            AltChart.Location = new Point(22, 14);
            AltChart.Name = "AltChart";
            AltChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Altitute(m)";
            AltChart.Series.Add(series3);
            AltChart.Size = new Size(340, 290);
            AltChart.TabIndex = 1;
            AltChart.Text = "chart1";
            // 
            // RocketMap
            // 
            RocketMap.Bearing = 0F;
            RocketMap.CanDragMap = true;
            RocketMap.EmptyTileColor = Color.Navy;
            RocketMap.GrayScaleMode = false;
            RocketMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            RocketMap.LevelsKeepInMemory = 5;
            RocketMap.Location = new Point(384, 319);
            RocketMap.MarkersEnabled = true;
            RocketMap.MaxZoom = 2;
            RocketMap.MinZoom = 2;
            RocketMap.MouseWheelZoomEnabled = true;
            RocketMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            RocketMap.Name = "RocketMap";
            RocketMap.NegativeMode = false;
            RocketMap.PolygonsEnabled = true;
            RocketMap.RetryLoadTile = 0;
            RocketMap.RoutesEnabled = true;
            RocketMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            RocketMap.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
            RocketMap.ShowTileGridLines = false;
            RocketMap.Size = new Size(340, 290);
            RocketMap.TabIndex = 0;
            RocketMap.Zoom = 0D;
            // 
            // RocketPanel
            // 
            RocketPanel.BackgroundImageLayout = ImageLayout.None;
            RocketPanel.BorderStyle = BorderStyle.FixedSingle;
            RocketPanel.Controls.Add(tableLayoutPanel1);
            RocketPanel.Controls.Add(RocketAlert);
            RocketPanel.Controls.Add(dat1rocket);
            RocketPanel.ForeColor = Color.AliceBlue;
            RocketPanel.Location = new Point(30, 21);
            RocketPanel.Name = "RocketPanel";
            RocketPanel.RightToLeft = RightToLeft.No;
            RocketPanel.Size = new Size(580, 309);
            RocketPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.Controls.Add(gyroxtext, 4, 0);
            tableLayoutPanel1.Controls.Add(statustext, 4, 6);
            tableLayoutPanel1.Controls.Add(voltagetext, 4, 5);
            tableLayoutPanel1.Controls.Add(gyroytext, 4, 1);
            tableLayoutPanel1.Controls.Add(temptext, 4, 3);
            tableLayoutPanel1.Controls.Add(gyroztext, 4, 2);
            tableLayoutPanel1.Controls.Add(calcalttext, 4, 4);
            tableLayoutPanel1.Controls.Add(dat1sts, 5, 6);
            tableLayoutPanel1.Controls.Add(dat1absacc, 3, 6);
            tableLayoutPanel1.Controls.Add(absacctext, 2, 6);
            tableLayoutPanel1.Controls.Add(dat1ang, 1, 6);
            tableLayoutPanel1.Controls.Add(angeltext, 0, 6);
            tableLayoutPanel1.Controls.Add(dat1accz, 3, 5);
            tableLayoutPanel1.Controls.Add(accztext, 2, 5);
            tableLayoutPanel1.Controls.Add(dat1aspd, 1, 5);
            tableLayoutPanel1.Controls.Add(aveltext, 0, 5);
            tableLayoutPanel1.Controls.Add(dat1calt, 5, 4);
            tableLayoutPanel1.Controls.Add(dat1accy, 3, 4);
            tableLayoutPanel1.Controls.Add(accytext, 2, 4);
            tableLayoutPanel1.Controls.Add(dat1gspd, 1, 4);
            tableLayoutPanel1.Controls.Add(gveltext, 0, 4);
            tableLayoutPanel1.Controls.Add(dat1temp, 5, 3);
            tableLayoutPanel1.Controls.Add(dat1accx, 3, 3);
            tableLayoutPanel1.Controls.Add(accxtext, 2, 3);
            tableLayoutPanel1.Controls.Add(dat1pre, 1, 3);
            tableLayoutPanel1.Controls.Add(pressuretext, 0, 3);
            tableLayoutPanel1.Controls.Add(dat1gyrz, 5, 2);
            tableLayoutPanel1.Controls.Add(dat1roll, 3, 2);
            tableLayoutPanel1.Controls.Add(roltext, 2, 2);
            tableLayoutPanel1.Controls.Add(dat1alt, 1, 2);
            tableLayoutPanel1.Controls.Add(gpsalttext, 0, 2);
            tableLayoutPanel1.Controls.Add(dat1gyry, 5, 1);
            tableLayoutPanel1.Controls.Add(dat1pitch, 3, 1);
            tableLayoutPanel1.Controls.Add(pitchtext, 2, 1);
            tableLayoutPanel1.Controls.Add(dat1lon, 1, 1);
            tableLayoutPanel1.Controls.Add(longitudetext, 0, 1);
            tableLayoutPanel1.Controls.Add(dat1gyrx, 5, 0);
            tableLayoutPanel1.Controls.Add(dat1yaw, 3, 0);
            tableLayoutPanel1.Controls.Add(yawtext, 2, 0);
            tableLayoutPanel1.Controls.Add(dat1lat, 1, 0);
            tableLayoutPanel1.Controls.Add(latitudetext, 0, 0);
            tableLayoutPanel1.Controls.Add(dat1vol, 5, 5);
            tableLayoutPanel1.Location = new Point(15, 15);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(545, 220);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // gyroxtext
            // 
            gyroxtext.Location = new Point(368, 1);
            gyroxtext.Name = "gyroxtext";
            gyroxtext.Size = new Size(94, 30);
            gyroxtext.TabIndex = 44;
            gyroxtext.Text = "Gyro X[°]:";
            gyroxtext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // statustext
            // 
            statustext.Location = new Point(368, 187);
            statustext.Name = "statustext";
            statustext.Size = new Size(94, 30);
            statustext.TabIndex = 16;
            statustext.Text = "Status:";
            statustext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // voltagetext
            // 
            voltagetext.Location = new Point(368, 156);
            voltagetext.Name = "voltagetext";
            voltagetext.Size = new Size(94, 30);
            voltagetext.TabIndex = 22;
            voltagetext.Text = "Voltage(V):";
            voltagetext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // gyroytext
            // 
            gyroytext.Location = new Point(368, 32);
            gyroytext.Name = "gyroytext";
            gyroytext.Size = new Size(94, 30);
            gyroytext.TabIndex = 43;
            gyroytext.Text = "Gyro Y[°]:";
            gyroytext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // temptext
            // 
            temptext.Location = new Point(368, 94);
            temptext.Name = "temptext";
            temptext.Size = new Size(94, 30);
            temptext.TabIndex = 4;
            temptext.Text = "Temprature[C°]:";
            temptext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // gyroztext
            // 
            gyroztext.Location = new Point(368, 63);
            gyroztext.Name = "gyroztext";
            gyroztext.Size = new Size(94, 30);
            gyroztext.TabIndex = 42;
            gyroztext.Text = "Gyro Z[°]:";
            gyroztext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // calcalttext
            // 
            calcalttext.Location = new Point(368, 125);
            calcalttext.Name = "calcalttext";
            calcalttext.Size = new Size(94, 30);
            calcalttext.TabIndex = 10;
            calcalttext.Text = "Calc Altitute[m]:";
            calcalttext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dat1sts
            // 
            dat1sts.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dat1sts.Location = new Point(469, 187);
            dat1sts.Name = "dat1sts";
            dat1sts.Size = new Size(74, 30);
            dat1sts.TabIndex = 41;
            dat1sts.Text = "--";
            dat1sts.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dat1absacc
            // 
            dat1absacc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dat1absacc.Location = new Point(287, 187);
            dat1absacc.Name = "dat1absacc";
            dat1absacc.Size = new Size(74, 30);
            dat1absacc.TabIndex = 39;
            dat1absacc.Text = "--";
            dat1absacc.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // absacctext
            // 
            absacctext.Location = new Point(186, 187);
            absacctext.Name = "absacctext";
            absacctext.Size = new Size(94, 30);
            absacctext.TabIndex = 38;
            absacctext.Text = "Absolute Acc [m/s²]:";
            absacctext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dat1ang
            // 
            dat1ang.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dat1ang.Location = new Point(105, 187);
            dat1ang.Name = "dat1ang";
            dat1ang.Size = new Size(74, 30);
            dat1ang.TabIndex = 37;
            dat1ang.Text = "--";
            dat1ang.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // angeltext
            // 
            angeltext.Location = new Point(4, 187);
            angeltext.Name = "angeltext";
            angeltext.Size = new Size(94, 30);
            angeltext.TabIndex = 36;
            angeltext.Text = "Angle[°]:";
            angeltext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dat1accz
            // 
            dat1accz.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dat1accz.Location = new Point(287, 156);
            dat1accz.Name = "dat1accz";
            dat1accz.Size = new Size(74, 30);
            dat1accz.TabIndex = 33;
            dat1accz.Text = "--";
            dat1accz.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // accztext
            // 
            accztext.Location = new Point(186, 156);
            accztext.Name = "accztext";
            accztext.Size = new Size(94, 30);
            accztext.TabIndex = 32;
            accztext.Text = "Acceleration Z [m/s²]:";
            accztext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dat1aspd
            // 
            dat1aspd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dat1aspd.Location = new Point(105, 156);
            dat1aspd.Name = "dat1aspd";
            dat1aspd.Size = new Size(74, 30);
            dat1aspd.TabIndex = 31;
            dat1aspd.Text = "--";
            dat1aspd.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // aveltext
            // 
            aveltext.Location = new Point(4, 156);
            aveltext.Name = "aveltext";
            aveltext.Size = new Size(94, 30);
            aveltext.TabIndex = 30;
            aveltext.Text = "Air Speed[m/s]:";
            aveltext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dat1calt
            // 
            dat1calt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dat1calt.Location = new Point(469, 125);
            dat1calt.Name = "dat1calt";
            dat1calt.Size = new Size(74, 30);
            dat1calt.TabIndex = 29;
            dat1calt.Text = "--";
            dat1calt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dat1accy
            // 
            dat1accy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dat1accy.Location = new Point(287, 125);
            dat1accy.Name = "dat1accy";
            dat1accy.Size = new Size(74, 30);
            dat1accy.TabIndex = 27;
            dat1accy.Text = "--";
            dat1accy.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // accytext
            // 
            accytext.Location = new Point(186, 125);
            accytext.Name = "accytext";
            accytext.Size = new Size(94, 30);
            accytext.TabIndex = 26;
            accytext.Text = "Acceleration Y [m/s²]:";
            accytext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dat1gspd
            // 
            dat1gspd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dat1gspd.Location = new Point(105, 125);
            dat1gspd.Name = "dat1gspd";
            dat1gspd.Size = new Size(74, 30);
            dat1gspd.TabIndex = 25;
            dat1gspd.Text = "--";
            dat1gspd.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gveltext
            // 
            gveltext.Location = new Point(4, 125);
            gveltext.Name = "gveltext";
            gveltext.Size = new Size(94, 30);
            gveltext.TabIndex = 24;
            gveltext.Text = "Ground Speed[m/s]:";
            gveltext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dat1temp
            // 
            dat1temp.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dat1temp.Location = new Point(469, 94);
            dat1temp.Name = "dat1temp";
            dat1temp.Size = new Size(74, 30);
            dat1temp.TabIndex = 23;
            dat1temp.Text = "--";
            dat1temp.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dat1accx
            // 
            dat1accx.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dat1accx.Location = new Point(287, 94);
            dat1accx.Name = "dat1accx";
            dat1accx.Size = new Size(74, 30);
            dat1accx.TabIndex = 21;
            dat1accx.Text = "--";
            dat1accx.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // accxtext
            // 
            accxtext.Location = new Point(186, 94);
            accxtext.Name = "accxtext";
            accxtext.Size = new Size(94, 30);
            accxtext.TabIndex = 20;
            accxtext.Text = "Acceleration X [m/s²]:";
            accxtext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dat1pre
            // 
            dat1pre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dat1pre.Location = new Point(105, 94);
            dat1pre.Name = "dat1pre";
            dat1pre.Size = new Size(74, 30);
            dat1pre.TabIndex = 19;
            dat1pre.Text = "--";
            dat1pre.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pressuretext
            // 
            pressuretext.Location = new Point(4, 94);
            pressuretext.Name = "pressuretext";
            pressuretext.Size = new Size(94, 30);
            pressuretext.TabIndex = 18;
            pressuretext.Text = "Pressure[hPa]:";
            pressuretext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dat1gyrz
            // 
            dat1gyrz.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dat1gyrz.Location = new Point(469, 63);
            dat1gyrz.Name = "dat1gyrz";
            dat1gyrz.Size = new Size(74, 30);
            dat1gyrz.TabIndex = 17;
            dat1gyrz.Text = "--";
            dat1gyrz.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dat1roll
            // 
            dat1roll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dat1roll.Location = new Point(287, 63);
            dat1roll.Name = "dat1roll";
            dat1roll.Size = new Size(74, 30);
            dat1roll.TabIndex = 15;
            dat1roll.Text = "--";
            dat1roll.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // roltext
            // 
            roltext.Location = new Point(186, 63);
            roltext.Name = "roltext";
            roltext.Size = new Size(94, 30);
            roltext.TabIndex = 14;
            roltext.Text = "Rol[°]:";
            roltext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dat1alt
            // 
            dat1alt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dat1alt.Location = new Point(105, 63);
            dat1alt.Name = "dat1alt";
            dat1alt.Size = new Size(74, 30);
            dat1alt.TabIndex = 13;
            dat1alt.Text = "--";
            dat1alt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gpsalttext
            // 
            gpsalttext.Location = new Point(4, 63);
            gpsalttext.Name = "gpsalttext";
            gpsalttext.Size = new Size(94, 30);
            gpsalttext.TabIndex = 12;
            gpsalttext.Text = "Altitute[m]:";
            gpsalttext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dat1gyry
            // 
            dat1gyry.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dat1gyry.Location = new Point(469, 32);
            dat1gyry.Name = "dat1gyry";
            dat1gyry.Size = new Size(74, 30);
            dat1gyry.TabIndex = 11;
            dat1gyry.Text = "--";
            dat1gyry.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dat1pitch
            // 
            dat1pitch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dat1pitch.Location = new Point(287, 32);
            dat1pitch.Name = "dat1pitch";
            dat1pitch.Size = new Size(74, 30);
            dat1pitch.TabIndex = 9;
            dat1pitch.Text = "--";
            dat1pitch.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pitchtext
            // 
            pitchtext.Location = new Point(186, 32);
            pitchtext.Name = "pitchtext";
            pitchtext.Size = new Size(94, 30);
            pitchtext.TabIndex = 8;
            pitchtext.Text = "Pitch[°]:";
            pitchtext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dat1lon
            // 
            dat1lon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dat1lon.Location = new Point(105, 32);
            dat1lon.Name = "dat1lon";
            dat1lon.Size = new Size(74, 30);
            dat1lon.TabIndex = 7;
            dat1lon.Text = "--";
            dat1lon.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // longitudetext
            // 
            longitudetext.Location = new Point(4, 32);
            longitudetext.Name = "longitudetext";
            longitudetext.Size = new Size(94, 30);
            longitudetext.TabIndex = 6;
            longitudetext.Text = "Longitude[Deg]:";
            longitudetext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dat1gyrx
            // 
            dat1gyrx.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dat1gyrx.Location = new Point(469, 1);
            dat1gyrx.Name = "dat1gyrx";
            dat1gyrx.Size = new Size(74, 30);
            dat1gyrx.TabIndex = 5;
            dat1gyrx.Text = "--";
            dat1gyrx.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dat1yaw
            // 
            dat1yaw.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dat1yaw.Location = new Point(287, 1);
            dat1yaw.Name = "dat1yaw";
            dat1yaw.Size = new Size(74, 30);
            dat1yaw.TabIndex = 3;
            dat1yaw.Text = "--";
            dat1yaw.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // yawtext
            // 
            yawtext.Location = new Point(186, 1);
            yawtext.Name = "yawtext";
            yawtext.Size = new Size(94, 30);
            yawtext.TabIndex = 2;
            yawtext.Text = "Yaw[°]:";
            yawtext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dat1lat
            // 
            dat1lat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dat1lat.Location = new Point(105, 1);
            dat1lat.Name = "dat1lat";
            dat1lat.Size = new Size(74, 30);
            dat1lat.TabIndex = 1;
            dat1lat.Text = "--";
            dat1lat.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // latitudetext
            // 
            latitudetext.Location = new Point(4, 1);
            latitudetext.Name = "latitudetext";
            latitudetext.Size = new Size(94, 30);
            latitudetext.TabIndex = 0;
            latitudetext.Text = "Latitude[Deg]:";
            latitudetext.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dat1vol
            // 
            dat1vol.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dat1vol.Location = new Point(469, 156);
            dat1vol.Name = "dat1vol";
            dat1vol.Size = new Size(74, 30);
            dat1vol.TabIndex = 35;
            dat1vol.Text = "--";
            dat1vol.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RocketAlert
            // 
            RocketAlert.BorderStyle = BorderStyle.FixedSingle;
            RocketAlert.Controls.Add(SRSalert);
            RocketAlert.Controls.Add(FRSalert);
            RocketAlert.Controls.Add(TSCalert);
            RocketAlert.Controls.Add(IMUalert);
            RocketAlert.Controls.Add(SSCalert);
            RocketAlert.Controls.Add(FSCalert);
            RocketAlert.Controls.Add(ALTalert);
            RocketAlert.Controls.Add(GNSSalert);
            RocketAlert.Dock = DockStyle.Bottom;
            RocketAlert.Location = new Point(0, 257);
            RocketAlert.Name = "RocketAlert";
            RocketAlert.Size = new Size(578, 50);
            RocketAlert.TabIndex = 0;
            // 
            // SRSalert
            // 
            SRSalert.BackColor = Color.FromArgb(28, 28, 28);
            SRSalert.FlatAppearance.BorderColor = Color.LightSkyBlue;
            SRSalert.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28);
            SRSalert.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 28, 28);
            SRSalert.FlatStyle = FlatStyle.Flat;
            SRSalert.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SRSalert.ForeColor = Color.LightSkyBlue;
            SRSalert.Location = new Point(500, 8);
            SRSalert.Name = "SRSalert";
            SRSalert.Size = new Size(60, 34);
            SRSalert.TabIndex = 7;
            SRSalert.Text = "SRS";
            SRSalert.UseVisualStyleBackColor = false;
            // 
            // FRSalert
            // 
            FRSalert.BackColor = Color.FromArgb(28, 28, 28);
            FRSalert.FlatAppearance.BorderColor = Color.LightSkyBlue;
            FRSalert.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28);
            FRSalert.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 28, 28);
            FRSalert.FlatStyle = FlatStyle.Flat;
            FRSalert.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FRSalert.ForeColor = Color.LightSkyBlue;
            FRSalert.Location = new Point(430, 8);
            FRSalert.Name = "FRSalert";
            FRSalert.Size = new Size(60, 34);
            FRSalert.TabIndex = 6;
            FRSalert.Text = "FRS";
            FRSalert.UseVisualStyleBackColor = false;
            // 
            // TSCalert
            // 
            TSCalert.BackColor = Color.FromArgb(28, 28, 28);
            TSCalert.FlatAppearance.BorderColor = Color.Crimson;
            TSCalert.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28);
            TSCalert.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 28, 28);
            TSCalert.FlatStyle = FlatStyle.Flat;
            TSCalert.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TSCalert.ForeColor = Color.Crimson;
            TSCalert.Location = new Point(360, 8);
            TSCalert.Name = "TSCalert";
            TSCalert.Size = new Size(60, 34);
            TSCalert.TabIndex = 5;
            TSCalert.Text = "TSC";
            TSCalert.UseVisualStyleBackColor = false;
            // 
            // IMUalert
            // 
            IMUalert.BackColor = Color.FromArgb(28, 28, 28);
            IMUalert.FlatAppearance.BorderColor = Color.Crimson;
            IMUalert.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28);
            IMUalert.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 28, 28);
            IMUalert.FlatStyle = FlatStyle.Flat;
            IMUalert.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IMUalert.ForeColor = Color.Crimson;
            IMUalert.Location = new Point(150, 8);
            IMUalert.Name = "IMUalert";
            IMUalert.Size = new Size(60, 34);
            IMUalert.TabIndex = 2;
            IMUalert.Text = "IMU";
            IMUalert.UseVisualStyleBackColor = false;
            // 
            // SSCalert
            // 
            SSCalert.BackColor = Color.FromArgb(28, 28, 28);
            SSCalert.FlatAppearance.BorderColor = Color.Crimson;
            SSCalert.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28);
            SSCalert.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 28, 28);
            SSCalert.FlatStyle = FlatStyle.Flat;
            SSCalert.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SSCalert.ForeColor = Color.Crimson;
            SSCalert.Location = new Point(290, 8);
            SSCalert.Name = "SSCalert";
            SSCalert.Size = new Size(60, 34);
            SSCalert.TabIndex = 4;
            SSCalert.Text = "SSC";
            SSCalert.UseVisualStyleBackColor = false;
            // 
            // FSCalert
            // 
            FSCalert.BackColor = Color.FromArgb(28, 28, 28);
            FSCalert.FlatAppearance.BorderColor = Color.Crimson;
            FSCalert.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28);
            FSCalert.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 28, 28);
            FSCalert.FlatStyle = FlatStyle.Flat;
            FSCalert.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FSCalert.ForeColor = Color.Crimson;
            FSCalert.Location = new Point(220, 8);
            FSCalert.Name = "FSCalert";
            FSCalert.Size = new Size(60, 34);
            FSCalert.TabIndex = 1;
            FSCalert.Text = "FSC";
            FSCalert.UseVisualStyleBackColor = false;
            // 
            // ALTalert
            // 
            ALTalert.BackColor = Color.FromArgb(28, 28, 28);
            ALTalert.FlatAppearance.BorderColor = Color.Crimson;
            ALTalert.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28);
            ALTalert.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 28, 28);
            ALTalert.FlatStyle = FlatStyle.Flat;
            ALTalert.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ALTalert.ForeColor = Color.Crimson;
            ALTalert.Location = new Point(80, 8);
            ALTalert.Name = "ALTalert";
            ALTalert.Size = new Size(60, 34);
            ALTalert.TabIndex = 3;
            ALTalert.Text = "ALT";
            ALTalert.UseVisualStyleBackColor = false;
            // 
            // GNSSalert
            // 
            GNSSalert.BackColor = Color.FromArgb(28, 28, 28);
            GNSSalert.FlatAppearance.BorderColor = Color.Crimson;
            GNSSalert.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28);
            GNSSalert.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 28, 28);
            GNSSalert.FlatStyle = FlatStyle.Flat;
            GNSSalert.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GNSSalert.ForeColor = Color.Crimson;
            GNSSalert.Location = new Point(10, 8);
            GNSSalert.Margin = new Padding(0);
            GNSSalert.Name = "GNSSalert";
            GNSSalert.Size = new Size(60, 34);
            GNSSalert.TabIndex = 0;
            GNSSalert.Text = "GNS";
            GNSSalert.UseVisualStyleBackColor = false;
            // 
            // SettingsPanel
            // 
            SettingsPanel.BackColor = Color.Transparent;
            SettingsPanel.Location = new Point(0, 0);
            SettingsPanel.Name = "SettingsPanel";
            SettingsPanel.Size = new Size(1600, 1000);
            SettingsPanel.TabIndex = 12;
            SettingsPanel.Visible = false;
            // 
            // TestStationPanel
            // 
            TestStationPanel.BackColor = Color.FromArgb(28, 28, 28);
            TestStationPanel.Location = new Point(300, 0);
            TestStationPanel.Name = "TestStationPanel";
            TestStationPanel.Size = new Size(2600, 1000);
            TestStationPanel.TabIndex = 3;
            TestStationPanel.Visible = false;
            // 
            // Astra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 28);
            ClientSize = new Size(1904, 1001);
            Controls.Add(MainPanel);
            Controls.Add(SideMenu);
            Controls.Add(TestStationPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Astra";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Astra Ground Station";
            SideMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AltLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)AstraLogo).EndInit();
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            CamPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            GraphPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AccChart).EndInit();
            ((System.ComponentModel.ISupportInitialize)SpdChart).EndInit();
            ((System.ComponentModel.ISupportInitialize)AltChart).EndInit();
            RocketPanel.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            RocketAlert.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private Panel SideMenu;
        private Button GroundStationButton;
        private Label latitudetext;
        private Button GeneralSettings;
        private Button SettingsButton;
        private Button TestStationButton;
        private PictureBox AstraLogo;
        private Label AstraText;
        private PictureBox AltLogo;
        private Panel MainPanel;
        private Panel RocketPanel;
        private Panel RocketAlert;
        private Panel leftmargin;
        private Button GNSSalert;
        private Button IMUalert;
        private Button FSCalert;
        private Button SRSalert;
        private Button FRSalert;
        private Button TSCalert;
        private Button SSCalert;
        private Button ALTalert;
        private TableLayoutPanel tableLayoutPanel1;
        private Label dat1vol;
        private Label dat1accz;
        private Label dat1aspd;
        private Label aveltext;
        private Label dat1calt;
        private Label dat1accy;
        private Label accytext;
        private Label dat1gspd;
        private Label gveltext;
        private Label dat1temp;
        private Label dat1accx;
        private Label accxtext;
        private Label dat1pre;
        private Label pressuretext;
        private Label dat1gyrz;
        private Label statustext;
        private Label dat1roll;
        private Label roltext;
        private Label dat1alt;
        private Label gpsalttext;
        private Label dat1gyry;
        private Label dat1pitch;
        private Label pitchtext;
        private Label dat1lon;
        private Label longitudetext;
        private Label dat1gyrx;
        private Label dat1yaw;
        private Label yawtext;
        private Label dat1lat;
        private Label dat1sts;
        private Label dat1absacc;
        private Label absacctext;
        private Label dat1ang;
        private Label angeltext;
        private Label accztext;
        private Label gyroxtext;
        private Label voltagetext;
        private Label gyroytext;
        private Label temptext;
        private Label gyroztext;
        private Label calcalttext;
        private Panel GraphPanel;
        private Panel CamPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart AltChart;
        private GMap.NET.WindowsForms.GMapControl RocketMap;
        private System.Windows.Forms.DataVisualization.Charting.Chart AccChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart SpdChart;
        private Label PosText;
        private Label RocketText;
        private Label graphtext;
        private Label CamText;
        private PictureBox pictureBox1;
        private Panel SettingsPanel;
        private Settings settings1;
        private Panel TestStationPanel;
        private Button ConnectButton;
        private Label dat1rocket;
        private Button DisconnectButton;
        private Label messageLabel;
        private Button capvid;
        private Button capimg;
        private Button CameraConnectButton;
        private Button CameraDisconnectButton;
        private Button stpcapvid;
        private Panel panel1;
        private RocketAngleIndicator rocketAngleIndicator1;
    }
}
