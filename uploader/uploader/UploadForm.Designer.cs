namespace uploader
{
    partial class UploadForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadForm));
			this.settingsGroup = new DarkUI.Controls.DarkGroupBox();
			this.sha2Textbox = new DarkUI.Controls.DarkTextBox();
			this.darkLabel3 = new DarkUI.Controls.DarkLabel();
			this.shaTextbox = new DarkUI.Controls.DarkTextBox();
			this.darkLabel2 = new DarkUI.Controls.DarkLabel();
			this.mdTextbox = new DarkUI.Controls.DarkTextBox();
			this.darkLabel1 = new DarkUI.Controls.DarkLabel();
			this.uploadButton = new DarkUI.Controls.DarkButton();
			this.statusLabel = new DarkUI.Controls.DarkLabel();
			this.settingsGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// settingsGroup
			// 
			this.settingsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.settingsGroup.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
			this.settingsGroup.Controls.Add(this.sha2Textbox);
			this.settingsGroup.Controls.Add(this.darkLabel3);
			this.settingsGroup.Controls.Add(this.shaTextbox);
			this.settingsGroup.Controls.Add(this.darkLabel2);
			this.settingsGroup.Controls.Add(this.mdTextbox);
			this.settingsGroup.Controls.Add(this.darkLabel1);
			this.settingsGroup.Location = new System.Drawing.Point(20, 20);
			this.settingsGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.settingsGroup.Name = "settingsGroup";
			this.settingsGroup.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.settingsGroup.Size = new System.Drawing.Size(750, 169);
			this.settingsGroup.TabIndex = 0;
			this.settingsGroup.TabStop = false;
			this.settingsGroup.Text = "File information";
			// 
			// sha2Textbox
			// 
			this.sha2Textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.sha2Textbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
			this.sha2Textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.sha2Textbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.sha2Textbox.Location = new System.Drawing.Point(110, 111);
			this.sha2Textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.sha2Textbox.Name = "sha2Textbox";
			this.sha2Textbox.Size = new System.Drawing.Size(624, 26);
			this.sha2Textbox.TabIndex = 5;
			// 
			// darkLabel3
			// 
			this.darkLabel3.AutoSize = true;
			this.darkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.darkLabel3.Location = new System.Drawing.Point(9, 114);
			this.darkLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.darkLabel3.Name = "darkLabel3";
			this.darkLabel3.Size = new System.Drawing.Size(74, 20);
			this.darkLabel3.TabIndex = 4;
			this.darkLabel3.Text = "SHA256:";
			// 
			// shaTextbox
			// 
			this.shaTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.shaTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
			this.shaTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.shaTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.shaTextbox.Location = new System.Drawing.Point(110, 71);
			this.shaTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.shaTextbox.Name = "shaTextbox";
			this.shaTextbox.Size = new System.Drawing.Size(624, 26);
			this.shaTextbox.TabIndex = 3;
			// 
			// darkLabel2
			// 
			this.darkLabel2.AutoSize = true;
			this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.darkLabel2.Location = new System.Drawing.Point(9, 74);
			this.darkLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.darkLabel2.Name = "darkLabel2";
			this.darkLabel2.Size = new System.Drawing.Size(56, 20);
			this.darkLabel2.TabIndex = 2;
			this.darkLabel2.Text = "SHA1:";
			// 
			// mdTextbox
			// 
			this.mdTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mdTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
			this.mdTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mdTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.mdTextbox.Location = new System.Drawing.Point(110, 31);
			this.mdTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.mdTextbox.Name = "mdTextbox";
			this.mdTextbox.Size = new System.Drawing.Size(624, 26);
			this.mdTextbox.TabIndex = 1;
			// 
			// darkLabel1
			// 
			this.darkLabel1.AutoSize = true;
			this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.darkLabel1.Location = new System.Drawing.Point(9, 34);
			this.darkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.darkLabel1.Name = "darkLabel1";
			this.darkLabel1.Size = new System.Drawing.Size(47, 20);
			this.darkLabel1.TabIndex = 0;
			this.darkLabel1.Text = "MD5:";
			// 
			// uploadButton
			// 
			this.uploadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.uploadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.uploadButton.Location = new System.Drawing.Point(647, 199);
			this.uploadButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.uploadButton.Name = "uploadButton";
			this.uploadButton.Padding = new System.Windows.Forms.Padding(8);
			this.uploadButton.Size = new System.Drawing.Size(123, 45);
			this.uploadButton.TabIndex = 1;
			this.uploadButton.Text = "Upload";
			this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
			// 
			// statusLabel
			// 
			this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.statusLabel.Location = new System.Drawing.Point(16, 211);
			this.statusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(623, 33);
			this.statusLabel.TabIndex = 2;
			this.statusLabel.Text = "Idle.";
			this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// UploadForm
			// 
			this.AcceptButton = this.uploadButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(788, 260);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.uploadButton);
			this.Controls.Add(this.settingsGroup);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.Name = "UploadForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "VirusTotal Uploader";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UploadForm_FormClosing);
			this.Load += new System.EventHandler(this.UploadForm_Load);
			this.settingsGroup.ResumeLayout(false);
			this.settingsGroup.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkGroupBox settingsGroup;
        private DarkUI.Controls.DarkButton uploadButton;
        private DarkUI.Controls.DarkLabel statusLabel;
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkTextBox sha2Textbox;
        private DarkUI.Controls.DarkLabel darkLabel3;
        private DarkUI.Controls.DarkTextBox shaTextbox;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private DarkUI.Controls.DarkTextBox mdTextbox;
    }
}