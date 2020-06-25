namespace uploader
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.generalGroupBox = new DarkUI.Controls.DarkGroupBox();
            this.languageCombo = new DarkUI.Controls.DarkComboBox();
            this.languageLabel = new DarkUI.Controls.DarkLabel();
            this.getApiButton = new DarkUI.Controls.DarkButton();
            this.apiTextbox = new DarkUI.Controls.DarkTextBox();
            this.apiLabel = new DarkUI.Controls.DarkLabel();
            this.saveButton = new DarkUI.Controls.DarkButton();
            this.openButton = new DarkUI.Controls.DarkButton();
            this.statusLabel = new DarkUI.Controls.DarkLabel();
            this.generalGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // generalGroupBox
            // 
            this.generalGroupBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.generalGroupBox.Controls.Add(this.languageCombo);
            this.generalGroupBox.Controls.Add(this.languageLabel);
            this.generalGroupBox.Controls.Add(this.getApiButton);
            this.generalGroupBox.Controls.Add(this.apiTextbox);
            this.generalGroupBox.Controls.Add(this.apiLabel);
            this.generalGroupBox.Location = new System.Drawing.Point(13, 13);
            this.generalGroupBox.Name = "generalGroupBox";
            this.generalGroupBox.Size = new System.Drawing.Size(403, 126);
            this.generalGroupBox.TabIndex = 0;
            this.generalGroupBox.TabStop = false;
            this.generalGroupBox.Text = "General settings";
            // 
            // languageCombo
            // 
            this.languageCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.languageCombo.FormattingEnabled = true;
            this.languageCombo.Location = new System.Drawing.Point(74, 85);
            this.languageCombo.Name = "languageCombo";
            this.languageCombo.Size = new System.Drawing.Size(323, 21);
            this.languageCombo.TabIndex = 4;
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.languageLabel.Location = new System.Drawing.Point(10, 88);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(58, 13);
            this.languageLabel.TabIndex = 3;
            this.languageLabel.Text = "Language:";
            // 
            // getApiButton
            // 
            this.getApiButton.Location = new System.Drawing.Point(10, 45);
            this.getApiButton.Name = "getApiButton";
            this.getApiButton.Padding = new System.Windows.Forms.Padding(5);
            this.getApiButton.Size = new System.Drawing.Size(161, 23);
            this.getApiButton.TabIndex = 2;
            this.getApiButton.Text = "Get API key";
            this.getApiButton.Click += new System.EventHandler(this.getApiButton_Click);
            // 
            // apiTextbox
            // 
            this.apiTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.apiTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.apiTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.apiTextbox.Location = new System.Drawing.Point(60, 19);
            this.apiTextbox.Name = "apiTextbox";
            this.apiTextbox.Size = new System.Drawing.Size(337, 20);
            this.apiTextbox.TabIndex = 1;
            // 
            // apiLabel
            // 
            this.apiLabel.AutoSize = true;
            this.apiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.apiLabel.Location = new System.Drawing.Point(7, 21);
            this.apiLabel.Name = "apiLabel";
            this.apiLabel.Size = new System.Drawing.Size(47, 13);
            this.apiLabel.TabIndex = 0;
            this.apiLabel.Text = "API key:";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(13, 145);
            this.saveButton.Name = "saveButton";
            this.saveButton.Padding = new System.Windows.Forms.Padding(5);
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(94, 145);
            this.openButton.Name = "openButton";
            this.openButton.Padding = new System.Windows.Forms.Padding(5);
            this.openButton.Size = new System.Drawing.Size(153, 23);
            this.openButton.TabIndex = 3;
            this.openButton.Text = "Open settings file";
            this.openButton.Click += new System.EventHandler(this.darkButton1_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.statusLabel.Location = new System.Drawing.Point(253, 145);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(163, 23);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 180);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.generalGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.generalGroupBox.ResumeLayout(false);
            this.generalGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkGroupBox generalGroupBox;
        private DarkUI.Controls.DarkTextBox apiTextbox;
        private DarkUI.Controls.DarkLabel apiLabel;
        private DarkUI.Controls.DarkButton getApiButton;
        private DarkUI.Controls.DarkLabel languageLabel;
        private DarkUI.Controls.DarkComboBox languageCombo;
        private DarkUI.Controls.DarkButton saveButton;
        private DarkUI.Controls.DarkButton openButton;
        private DarkUI.Controls.DarkLabel statusLabel;
    }
}