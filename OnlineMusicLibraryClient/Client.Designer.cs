namespace OnlineMusicLibraryClient
{
    partial class Client
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
            this.songLabel = new System.Windows.Forms.Label();
            this.searchBtn = new System.Windows.Forms.Button();
            this.connectBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.server1Download = new System.Windows.Forms.Button();
            this.server2Download = new System.Windows.Forms.Button();
            this.songList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // songLabel
            // 
            this.songLabel.AutoSize = true;
            this.songLabel.Location = new System.Drawing.Point(85, 193);
            this.songLabel.Name = "songLabel";
            this.songLabel.Size = new System.Drawing.Size(69, 15);
            this.songLabel.TabIndex = 0;
            this.songLabel.Text = "Song Name";
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(85, 256);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(250, 52);
            this.searchBtn.TabIndex = 1;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(85, 38);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(111, 61);
            this.connectBtn.TabIndex = 2;
            this.connectBtn.Text = "Connect to Server";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(224, 38);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(111, 61);
            this.stopBtn.TabIndex = 3;
            this.stopBtn.Text = "Stop Connection";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // searchBar
            // 
            this.searchBar.Location = new System.Drawing.Point(160, 190);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(175, 23);
            this.searchBar.TabIndex = 4;
            // 
            // server1Download
            // 
            this.server1Download.Location = new System.Drawing.Point(85, 355);
            this.server1Download.Name = "server1Download";
            this.server1Download.Size = new System.Drawing.Size(121, 65);
            this.server1Download.TabIndex = 5;
            this.server1Download.Text = "Server1 Download";
            this.server1Download.UseVisualStyleBackColor = true;
            this.server1Download.Click += new System.EventHandler(this.server1Download_Click);
            // 
            // server2Download
            // 
            this.server2Download.Location = new System.Drawing.Point(212, 355);
            this.server2Download.Name = "server2Download";
            this.server2Download.Size = new System.Drawing.Size(123, 65);
            this.server2Download.TabIndex = 6;
            this.server2Download.Text = "Server2 Download";
            this.server2Download.UseVisualStyleBackColor = true;
            // 
            // songList
            // 
            this.songList.FormattingEnabled = true;
            this.songList.ItemHeight = 15;
            this.songList.Location = new System.Drawing.Point(364, 71);
            this.songList.Name = "songList";
            this.songList.Size = new System.Drawing.Size(272, 349);
            this.songList.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(421, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Available Songs List";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 459);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.songList);
            this.Controls.Add(this.server2Download);
            this.Controls.Add(this.server1Download);
            this.Controls.Add(this.searchBar);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.songLabel);
            this.Name = "Client";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label songLabel;
        private Button searchBtn;
        private Button connectBtn;
        private Button stopBtn;
        private TextBox searchBar;
        private Button server1Download;
        private Button server2Download;
        private ListBox songList;
        private Label label1;
    }
}