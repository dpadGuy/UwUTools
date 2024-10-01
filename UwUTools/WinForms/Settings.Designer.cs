namespace UwUTools_Prototype.WinForms
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.welcomeSection = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.emulartorsSection = new Guna.UI2.WinForms.Guna2ImageButton();
            this.settingsSection = new Guna.UI2.WinForms.Guna2ImageButton();
            this.unknownSection = new Guna.UI2.WinForms.Guna2ImageButton();
            this.appsSection = new Guna.UI2.WinForms.Guna2ImageButton();
            this.gamesSection = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.guna2ProgressBar1 = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.minimizeButton = new Guna.UI2.WinForms.Guna2ImageButton();
            this.closeButton = new Guna.UI2.WinForms.Guna2ImageButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notificationSwitch = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl3 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.windarkmodeSwitch = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.specscopyButton = new Guna.UI2.WinForms.Guna2Button();
            this.dxdiagButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.welcomeSection)).BeginInit();
            this.guna2ShadowPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.welcomeSection);
            this.guna2ShadowPanel1.Controls.Add(this.emulartorsSection);
            this.guna2ShadowPanel1.Controls.Add(this.settingsSection);
            this.guna2ShadowPanel1.Controls.Add(this.unknownSection);
            this.guna2ShadowPanel1.Controls.Add(this.appsSection);
            this.guna2ShadowPanel1.Controls.Add(this.gamesSection);
            this.guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.ShadowDepth = 200;
            this.guna2ShadowPanel1.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(61, 667);
            this.guna2ShadowPanel1.TabIndex = 5;
            // 
            // welcomeSection
            // 
            this.welcomeSection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.welcomeSection.Image = global::UwUTools.Properties.Resources.IMG_4833_cropped;
            this.welcomeSection.ImageRotate = 0F;
            this.welcomeSection.Location = new System.Drawing.Point(5, 6);
            this.welcomeSection.Name = "welcomeSection";
            this.welcomeSection.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.welcomeSection.Size = new System.Drawing.Size(51, 49);
            this.welcomeSection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.welcomeSection.TabIndex = 44;
            this.welcomeSection.TabStop = false;
            this.welcomeSection.Click += new System.EventHandler(this.welcomeSection_Click);
            // 
            // emulartorsSection
            // 
            this.emulartorsSection.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.emulartorsSection.HoverState.ImageSize = new System.Drawing.Size(35, 35);
            this.emulartorsSection.Image = global::UwUTools.Properties.Resources.icons8_nintendo_wii_u_48;
            this.emulartorsSection.ImageOffset = new System.Drawing.Point(0, 0);
            this.emulartorsSection.ImageRotate = 0F;
            this.emulartorsSection.ImageSize = new System.Drawing.Size(35, 35);
            this.emulartorsSection.Location = new System.Drawing.Point(-1, 267);
            this.emulartorsSection.Name = "emulartorsSection";
            this.emulartorsSection.PressedState.ImageSize = new System.Drawing.Size(35, 35);
            this.emulartorsSection.Size = new System.Drawing.Size(61, 55);
            this.emulartorsSection.TabIndex = 24;
            this.emulartorsSection.Click += new System.EventHandler(this.emulartorsSection_Click);
            // 
            // settingsSection
            // 
            this.settingsSection.BackColor = System.Drawing.Color.Transparent;
            this.settingsSection.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.settingsSection.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.settingsSection.Image = global::UwUTools.Properties.Resources.icons8_setting_512__1_;
            this.settingsSection.ImageOffset = new System.Drawing.Point(0, 0);
            this.settingsSection.ImageRotate = 0F;
            this.settingsSection.ImageSize = new System.Drawing.Size(30, 30);
            this.settingsSection.Location = new System.Drawing.Point(1, 602);
            this.settingsSection.Name = "settingsSection";
            this.settingsSection.PressedState.ImageSize = new System.Drawing.Size(30, 30);
            this.settingsSection.Size = new System.Drawing.Size(57, 51);
            this.settingsSection.TabIndex = 25;
            // 
            // unknownSection
            // 
            this.unknownSection.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.unknownSection.HoverState.ImageSize = new System.Drawing.Size(35, 35);
            this.unknownSection.Image = global::UwUTools.Properties.Resources.icons8_missile_32;
            this.unknownSection.ImageOffset = new System.Drawing.Point(0, 0);
            this.unknownSection.ImageRotate = 0F;
            this.unknownSection.ImageSize = new System.Drawing.Size(35, 35);
            this.unknownSection.Location = new System.Drawing.Point(0, 389);
            this.unknownSection.Name = "unknownSection";
            this.unknownSection.PressedState.ImageSize = new System.Drawing.Size(35, 35);
            this.unknownSection.Size = new System.Drawing.Size(61, 55);
            this.unknownSection.TabIndex = 10;
            this.unknownSection.Click += new System.EventHandler(this.unknownSection_Click);
            // 
            // appsSection
            // 
            this.appsSection.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.appsSection.HoverState.ImageSize = new System.Drawing.Size(35, 35);
            this.appsSection.Image = ((System.Drawing.Image)(resources.GetObject("appsSection.Image")));
            this.appsSection.ImageOffset = new System.Drawing.Point(0, 0);
            this.appsSection.ImageRotate = 0F;
            this.appsSection.ImageSize = new System.Drawing.Size(35, 35);
            this.appsSection.Location = new System.Drawing.Point(-1, 206);
            this.appsSection.Name = "appsSection";
            this.appsSection.PressedState.ImageSize = new System.Drawing.Size(35, 35);
            this.appsSection.Size = new System.Drawing.Size(61, 55);
            this.appsSection.TabIndex = 8;
            this.appsSection.Click += new System.EventHandler(this.appsSection_Click);
            // 
            // gamesSection
            // 
            this.gamesSection.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gamesSection.HoverState.ImageSize = new System.Drawing.Size(35, 35);
            this.gamesSection.Image = ((System.Drawing.Image)(resources.GetObject("gamesSection.Image")));
            this.gamesSection.ImageOffset = new System.Drawing.Point(0, 0);
            this.gamesSection.ImageRotate = 0F;
            this.gamesSection.ImageSize = new System.Drawing.Size(35, 35);
            this.gamesSection.Location = new System.Drawing.Point(0, 328);
            this.gamesSection.Name = "gamesSection";
            this.gamesSection.PressedState.ImageSize = new System.Drawing.Size(35, 35);
            this.gamesSection.Size = new System.Drawing.Size(61, 55);
            this.gamesSection.TabIndex = 9;
            this.gamesSection.Click += new System.EventHandler(this.gamesSection_Click);
            // 
            // guna2ShadowPanel2
            // 
            this.guna2ShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel2.Controls.Add(this.guna2ProgressBar1);
            this.guna2ShadowPanel2.Controls.Add(this.label3);
            this.guna2ShadowPanel2.Controls.Add(this.minimizeButton);
            this.guna2ShadowPanel2.Controls.Add(this.closeButton);
            this.guna2ShadowPanel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.guna2ShadowPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2ShadowPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.guna2ShadowPanel2.Location = new System.Drawing.Point(61, 0);
            this.guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            this.guna2ShadowPanel2.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel2.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped;
            this.guna2ShadowPanel2.Size = new System.Drawing.Size(1225, 63);
            this.guna2ShadowPanel2.TabIndex = 6;
            // 
            // guna2ProgressBar1
            // 
            this.guna2ProgressBar1.AutoRoundedCorners = true;
            this.guna2ProgressBar1.BorderColor = System.Drawing.Color.Azure;
            this.guna2ProgressBar1.BorderRadius = 4;
            this.guna2ProgressBar1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.guna2ProgressBar1.Location = new System.Drawing.Point(441, 40);
            this.guna2ProgressBar1.Name = "guna2ProgressBar1";
            this.guna2ProgressBar1.ProgressColor = System.Drawing.Color.White;
            this.guna2ProgressBar1.ProgressColor2 = System.Drawing.Color.White;
            this.guna2ProgressBar1.Size = new System.Drawing.Size(327, 10);
            this.guna2ProgressBar1.TabIndex = 21;
            this.guna2ProgressBar1.Text = "guna2ProgressBar1";
            this.guna2ProgressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Symbol", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(550, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 37);
            this.label3.TabIndex = 5;
            this.label3.Text = "Settings";
            // 
            // minimizeButton
            // 
            this.minimizeButton.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.minimizeButton.HoverState.ImageSize = new System.Drawing.Size(15, 15);
            this.minimizeButton.Image = ((System.Drawing.Image)(resources.GetObject("minimizeButton.Image")));
            this.minimizeButton.ImageOffset = new System.Drawing.Point(0, 0);
            this.minimizeButton.ImageRotate = 0F;
            this.minimizeButton.ImageSize = new System.Drawing.Size(15, 15);
            this.minimizeButton.Location = new System.Drawing.Point(1129, 6);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.PressedState.ImageSize = new System.Drawing.Size(15, 15);
            this.minimizeButton.Size = new System.Drawing.Size(42, 46);
            this.minimizeButton.TabIndex = 10;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.closeButton.HoverState.ImageSize = new System.Drawing.Size(15, 15);
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.ImageOffset = new System.Drawing.Point(0, 0);
            this.closeButton.ImageRotate = 0F;
            this.closeButton.ImageSize = new System.Drawing.Size(15, 15);
            this.closeButton.Location = new System.Drawing.Point(1174, 6);
            this.closeButton.Name = "closeButton";
            this.closeButton.PressedState.ImageSize = new System.Drawing.Size(15, 15);
            this.closeButton.Size = new System.Drawing.Size(42, 46);
            this.closeButton.TabIndex = 10;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(78, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 30);
            this.label1.TabIndex = 21;
            this.label1.Text = "Notifications";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(78, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(557, 60);
            this.label2.TabIndex = 22;
            this.label2.Text = "Notifications can appear when you successfully \r\ninstalled an application, you ca" +
    "n either enable or disable it.";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 30;
            this.guna2Elipse1.TargetControl = this;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notificationSwitch
            // 
            this.notificationSwitch.Animated = true;
            this.notificationSwitch.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.notificationSwitch.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.notificationSwitch.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.notificationSwitch.CheckedState.InnerColor = System.Drawing.Color.White;
            this.notificationSwitch.Location = new System.Drawing.Point(209, 90);
            this.notificationSwitch.Name = "notificationSwitch";
            this.notificationSwitch.Size = new System.Drawing.Size(40, 20);
            this.notificationSwitch.TabIndex = 23;
            this.notificationSwitch.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.notificationSwitch.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.notificationSwitch.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.notificationSwitch.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.notificationSwitch.CheckedChanged += new System.EventHandler(this.notificationSwitch_CheckedChanged);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.DragStartTransparencyValue = 1D;
            this.guna2DragControl1.TargetControl = this.guna2ShadowPanel1;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2DragControl2
            // 
            this.guna2DragControl2.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl2.DragStartTransparencyValue = 1D;
            this.guna2DragControl2.TargetControl = this.guna2ShadowPanel2;
            this.guna2DragControl2.UseTransparentDrag = true;
            // 
            // guna2DragControl3
            // 
            this.guna2DragControl3.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl3.DragStartTransparencyValue = 1D;
            this.guna2DragControl3.TargetControl = this.label3;
            this.guna2DragControl3.UseTransparentDrag = true;
            // 
            // windarkmodeSwitch
            // 
            this.windarkmodeSwitch.Animated = true;
            this.windarkmodeSwitch.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.windarkmodeSwitch.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.windarkmodeSwitch.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.windarkmodeSwitch.CheckedState.InnerColor = System.Drawing.Color.White;
            this.windarkmodeSwitch.Location = new System.Drawing.Point(286, 200);
            this.windarkmodeSwitch.Name = "windarkmodeSwitch";
            this.windarkmodeSwitch.Size = new System.Drawing.Size(40, 20);
            this.windarkmodeSwitch.TabIndex = 27;
            this.windarkmodeSwitch.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.windarkmodeSwitch.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.windarkmodeSwitch.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.windarkmodeSwitch.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.windarkmodeSwitch.CheckedChanged += new System.EventHandler(this.windarkmodeSwitch_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(78, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(615, 60);
            this.label4.TabIndex = 26;
            this.label4.Text = "This option will give you the ability of having dark mode \r\non Windows 10 and upw" +
    "ards, disable it to go back to light mode.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(78, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(207, 30);
            this.label5.TabIndex = 25;
            this.label5.Text = "Windows Dark Mode";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(79, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 21);
            this.label6.TabIndex = 28;
            this.label6.Text = "Waiting for specs...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(83, 297);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 1);
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // specscopyButton
            // 
            this.specscopyButton.Animated = true;
            this.specscopyButton.AutoRoundedCorners = true;
            this.specscopyButton.BorderRadius = 15;
            this.specscopyButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.specscopyButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.specscopyButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.specscopyButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.specscopyButton.FillColor = System.Drawing.Color.Black;
            this.specscopyButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.specscopyButton.ForeColor = System.Drawing.Color.White;
            this.specscopyButton.Location = new System.Drawing.Point(628, 309);
            this.specscopyButton.Name = "specscopyButton";
            this.specscopyButton.Size = new System.Drawing.Size(95, 32);
            this.specscopyButton.TabIndex = 34;
            this.specscopyButton.Text = "Copy specs";
            this.specscopyButton.Click += new System.EventHandler(this.specscopyButton_Click);
            // 
            // dxdiagButton
            // 
            this.dxdiagButton.Animated = true;
            this.dxdiagButton.AutoRoundedCorners = true;
            this.dxdiagButton.BorderRadius = 15;
            this.dxdiagButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.dxdiagButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.dxdiagButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.dxdiagButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dxdiagButton.FillColor = System.Drawing.Color.Black;
            this.dxdiagButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dxdiagButton.ForeColor = System.Drawing.Color.White;
            this.dxdiagButton.Location = new System.Drawing.Point(628, 351);
            this.dxdiagButton.Name = "dxdiagButton";
            this.dxdiagButton.Size = new System.Drawing.Size(95, 32);
            this.dxdiagButton.TabIndex = 35;
            this.dxdiagButton.Text = "Dxdiag";
            this.dxdiagButton.Click += new System.EventHandler(this.dxdiagButton_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(1286, 667);
            this.Controls.Add(this.dxdiagButton);
            this.Controls.Add(this.specscopyButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.windarkmodeSwitch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.notificationSwitch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2ShadowPanel2);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.guna2ShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.welcomeSection)).EndInit();
            this.guna2ShadowPanel2.ResumeLayout(false);
            this.guna2ShadowPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2ImageButton emulartorsSection;
        private Guna.UI2.WinForms.Guna2ImageButton settingsSection;
        private Guna.UI2.WinForms.Guna2ImageButton unknownSection;
        private Guna.UI2.WinForms.Guna2ImageButton appsSection;
        private Guna.UI2.WinForms.Guna2ImageButton gamesSection;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ImageButton minimizeButton;
        private Guna.UI2.WinForms.Guna2ImageButton closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2ToggleSwitch notificationSwitch;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl2;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl3;
        private Guna.UI2.WinForms.Guna2ProgressBar guna2ProgressBar1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox welcomeSection;
        private Guna.UI2.WinForms.Guna2ToggleSwitch windarkmodeSwitch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button specscopyButton;
        private Guna.UI2.WinForms.Guna2Button dxdiagButton;
    }
}