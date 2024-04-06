namespace OnlineMusicLibraryServer
{
    partial class Server1
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
            this.connectButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(40, 157);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(149, 45);
            this.connectButton.TabIndex = 5;
            this.connectButton.Text = "Connect to Client";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(240, 157);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(149, 45);
            this.stopButton.TabIndex = 6;
            this.stopButton.Text = "Stop Connection";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // Server1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 335);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.connectButton);
            this.Name = "Server1";
            this.Text = "Server1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button connectButton;
        private Button stopButton;
    }
}