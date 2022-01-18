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
			this.directCheckbox = new DarkUI.Controls.DarkCheckBox();
			this.languageCombo = new DarkUI.Controls.DarkComboBox();
			this.languageLabel = new DarkUI.Controls.DarkLabel();
			this.getApiButton = new DarkUI.Controls.DarkButton();
			this.apiTextbox = new DarkUI.Controls.DarkTextBox();
			this.apiLabel = new DarkUI.Controls.DarkLabel();
			this.saveButton = new DarkUI.Controls.DarkButton();
			this.resetBtn = new DarkUI.Controls.DarkButton();
			this.contextChk = new DarkUI.Controls.DarkCheckBox();
			this.generalGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// generalGroupBox
			// 
			this.generalGroupBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
			this.generalGroupBox.Controls.Add(this.contextChk);
			this.generalGroupBox.Controls.Add(this.directCheckbox);
			this.generalGroupBox.Controls.Add(this.languageCombo);
			this.generalGroupBox.Controls.Add(this.languageLabel);
			this.generalGroupBox.Controls.Add(this.getApiButton);
			this.generalGroupBox.Controls.Add(this.apiTextbox);
			this.generalGroupBox.Controls.Add(this.apiLabel);
			this.generalGroupBox.Location = new System.Drawing.Point(20, 20);
			this.generalGroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.generalGroupBox.Name = "generalGroupBox";
			this.generalGroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.generalGroupBox.Size = new System.Drawing.Size(669, 237);
			this.generalGroupBox.TabIndex = 0;
			this.generalGroupBox.TabStop = false;
			this.generalGroupBox.Text = "General settings";
			// 
			// directCheckbox
			// 
			this.directCheckbox.AutoSize = true;
			this.directCheckbox.Location = new System.Drawing.Point(19, 187);
			this.directCheckbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.directCheckbox.Name = "directCheckbox";
			this.directCheckbox.Size = new System.Drawing.Size(171, 24);
			this.directCheckbox.TabIndex = 5;
			this.directCheckbox.Text = "Automatic Upload?";
			// 
			// languageCombo
			// 
			this.languageCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.languageCombo.FormattingEnabled = true;
			this.languageCombo.Items.AddRange(new object[] {
            "English"});
			this.languageCombo.Location = new System.Drawing.Point(132, 132);
			this.languageCombo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.languageCombo.Name = "languageCombo";
			this.languageCombo.Size = new System.Drawing.Size(242, 27);
			this.languageCombo.TabIndex = 4;
			// 
			// languageLabel
			// 
			this.languageLabel.AutoSize = true;
			this.languageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.languageLabel.Location = new System.Drawing.Point(15, 135);
			this.languageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.languageLabel.Name = "languageLabel";
			this.languageLabel.Size = new System.Drawing.Size(85, 20);
			this.languageLabel.TabIndex = 3;
			this.languageLabel.Text = "Language:";
			// 
			// getApiButton
			// 
			this.getApiButton.Location = new System.Drawing.Point(132, 65);
			this.getApiButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.getApiButton.Name = "getApiButton";
			this.getApiButton.Padding = new System.Windows.Forms.Padding(8);
			this.getApiButton.Size = new System.Drawing.Size(242, 35);
			this.getApiButton.TabIndex = 2;
			this.getApiButton.Text = "Get API key";
			this.getApiButton.Click += new System.EventHandler(this.getApiButton_Click);
			// 
			// apiTextbox
			// 
			this.apiTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
			this.apiTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.apiTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.apiTextbox.Location = new System.Drawing.Point(132, 29);
			this.apiTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.apiTextbox.Name = "apiTextbox";
			this.apiTextbox.Size = new System.Drawing.Size(530, 26);
			this.apiTextbox.TabIndex = 1;
			// 
			// apiLabel
			// 
			this.apiLabel.AutoSize = true;
			this.apiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.apiLabel.Location = new System.Drawing.Point(10, 32);
			this.apiLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.apiLabel.Name = "apiLabel";
			this.apiLabel.Size = new System.Drawing.Size(67, 20);
			this.apiLabel.TabIndex = 0;
			this.apiLabel.Text = "API key:";
			// 
			// saveButton
			// 
			this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.saveButton.Location = new System.Drawing.Point(534, 271);
			this.saveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.saveButton.Name = "saveButton";
			this.saveButton.Padding = new System.Windows.Forms.Padding(8);
			this.saveButton.Size = new System.Drawing.Size(155, 35);
			this.saveButton.TabIndex = 2;
			this.saveButton.Text = "Save";
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// resetBtn
			// 
			this.resetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.resetBtn.Location = new System.Drawing.Point(20, 271);
			this.resetBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.resetBtn.Name = "resetBtn";
			this.resetBtn.Padding = new System.Windows.Forms.Padding(8);
			this.resetBtn.Size = new System.Drawing.Size(155, 35);
			this.resetBtn.TabIndex = 3;
			this.resetBtn.Text = "Reset";
			this.resetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
			// 
			// contextChk
			// 
			this.contextChk.Location = new System.Drawing.Point(297, 187);
			this.contextChk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.contextChk.Name = "contextChk";
			this.contextChk.Size = new System.Drawing.Size(344, 24);
			this.contextChk.TabIndex = 6;
			this.contextChk.Text = "Add to Context Menu?";
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(702, 320);
			this.Controls.Add(this.resetBtn);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.generalGroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private DarkUI.Controls.DarkCheckBox directCheckbox;
		private DarkUI.Controls.DarkButton resetBtn;
		private DarkUI.Controls.DarkCheckBox contextChk;
	}
}