namespace UwUTools_Prototype.WinForms
{
    partial class SuccessNotification
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblMsg = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.closeButton = new Guna.UI2.WinForms.Guna2ImageButton();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblMsg.Location = new System.Drawing.Point(10, 22);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(303, 25);
            this.lblMsg.TabIndex = 6;
            this.lblMsg.Text = "The app got installed successfully !";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // closeButton
            // 
            this.closeButton.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.closeButton.HoverState.ImageSize = new System.Drawing.Size(50, 50);
            this.closeButton.Image = global::UwUTools_Prototype.Properties.Resources.icons8_close_window_50;
            this.closeButton.ImageOffset = new System.Drawing.Point(0, 0);
            this.closeButton.ImageRotate = 0F;
            this.closeButton.ImageSize = new System.Drawing.Size(50, 50);
            this.closeButton.Location = new System.Drawing.Point(314, 10);
            this.closeButton.Name = "closeButton";
            this.closeButton.PressedState.ImageSize = new System.Drawing.Size(50, 50);
            this.closeButton.Size = new System.Drawing.Size(50, 48);
            this.closeButton.TabIndex = 25;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // SuccessNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(372, 72);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.lblMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SuccessNotification";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SuccessNotification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblMsg;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ImageButton closeButton;
    }
}