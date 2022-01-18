namespace uploader
{
    partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.dragLabel = new DarkUI.Controls.DarkLabel();
			this.darkButton1 = new DarkUI.Controls.DarkButton();
			this.moreLabel = new DarkUI.Controls.DarkButton();
			this.SuspendLayout();
			// 
			// dragLabel
			// 
			this.dragLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.dragLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dragLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.dragLabel.Location = new System.Drawing.Point(9, 19);
			this.dragLabel.Name = "dragLabel";
			this.dragLabel.Size = new System.Drawing.Size(367, 65);
			this.dragLabel.TabIndex = 0;
			this.dragLabel.Text = "Drag file here";
			this.dragLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// darkButton1
			// 
			this.darkButton1.Location = new System.Drawing.Point(301, 337);
			this.darkButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.darkButton1.Name = "darkButton1";
			this.darkButton1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.darkButton1.Size = new System.Drawing.Size(75, 15);
			this.darkButton1.TabIndex = 2;
			this.darkButton1.Text = "Languages";
			this.darkButton1.Visible = false;
			this.darkButton1.Click += new System.EventHandler(this.DarkButton1_Click);
			// 
			// moreLabel
			// 
			this.moreLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.moreLabel.Location = new System.Drawing.Point(149, 108);
			this.moreLabel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.moreLabel.Name = "moreLabel";
			this.moreLabel.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.moreLabel.Size = new System.Drawing.Size(87, 25);
			this.moreLabel.TabIndex = 3;
			this.moreLabel.Text = "Settings";
			this.moreLabel.Click += new System.EventHandler(this.moreLabel_Click);
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 148);
			this.Controls.Add(this.moreLabel);
			this.Controls.Add(this.darkButton1);
			this.Controls.Add(this.dragLabel);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "VirusTotal Uploader";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
			this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkLabel dragLabel;
		private DarkUI.Controls.DarkButton darkButton1;
		private DarkUI.Controls.DarkButton moreLabel;
	}
}

