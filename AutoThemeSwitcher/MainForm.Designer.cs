
namespace AutoThemeSwitcher
{
	partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lightTime = new System.Windows.Forms.DateTimePicker();
            this.rbLightTime = new System.Windows.Forms.RadioButton();
            this.cbLightSunphase = new System.Windows.Forms.ComboBox();
            this.rbLightSunphase = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.darkTime = new System.Windows.Forms.DateTimePicker();
            this.rbDarkTime = new System.Windows.Forms.RadioButton();
            this.cbDarkSunphase = new System.Windows.Forms.ComboBox();
            this.rbDarkSunphase = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.tbLatitude = new System.Windows.Forms.TextBox();
            this.tbLongitude = new System.Windows.Forms.TextBox();
            this.gbLocation = new System.Windows.Forms.GroupBox();
            this.btnSystemPos = new System.Windows.Forms.Button();
            this.llMaps = new System.Windows.Forms.LinkLabel();
            this.btnPastePosition = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblColorMode = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbLocation.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Switch to light at:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lightTime);
            this.groupBox2.Controls.Add(this.rbLightTime);
            this.groupBox2.Controls.Add(this.cbLightSunphase);
            this.groupBox2.Controls.Add(this.rbLightSunphase);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(14, 389);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(503, 104);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // lightTime
            // 
            this.lightTime.CustomFormat = "";
            this.lightTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.lightTime.Location = new System.Drawing.Point(267, 60);
            this.lightTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lightTime.Name = "lightTime";
            this.lightTime.ShowUpDown = true;
            this.lightTime.Size = new System.Drawing.Size(228, 27);
            this.lightTime.TabIndex = 8;
            // 
            // rbLightTime
            // 
            this.rbLightTime.AutoSize = true;
            this.rbLightTime.Checked = true;
            this.rbLightTime.Location = new System.Drawing.Point(143, 61);
            this.rbLightTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbLightTime.Name = "rbLightTime";
            this.rbLightTime.Size = new System.Drawing.Size(117, 24);
            this.rbLightTime.TabIndex = 7;
            this.rbLightTime.TabStop = true;
            this.rbLightTime.Text = "specific time:";
            this.rbLightTime.UseVisualStyleBackColor = true;
            // 
            // cbLightSunphase
            // 
            this.cbLightSunphase.Enabled = false;
            this.cbLightSunphase.FormattingEnabled = true;
            this.cbLightSunphase.Location = new System.Drawing.Point(269, 21);
            this.cbLightSunphase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbLightSunphase.Name = "cbLightSunphase";
            this.cbLightSunphase.Size = new System.Drawing.Size(227, 28);
            this.cbLightSunphase.TabIndex = 6;
            // 
            // rbLightSunphase
            // 
            this.rbLightSunphase.AutoSize = true;
            this.rbLightSunphase.Location = new System.Drawing.Point(143, 23);
            this.rbLightSunphase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbLightSunphase.Name = "rbLightSunphase";
            this.rbLightSunphase.Size = new System.Drawing.Size(98, 24);
            this.rbLightSunphase.TabIndex = 5;
            this.rbLightSunphase.TabStop = true;
            this.rbLightSunphase.Text = "sun phase:";
            this.rbLightSunphase.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.darkTime);
            this.groupBox3.Controls.Add(this.rbDarkTime);
            this.groupBox3.Controls.Add(this.cbDarkSunphase);
            this.groupBox3.Controls.Add(this.rbDarkSunphase);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(16, 277);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(503, 104);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // darkTime
            // 
            this.darkTime.CustomFormat = "";
            this.darkTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.darkTime.Location = new System.Drawing.Point(266, 60);
            this.darkTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.darkTime.Name = "darkTime";
            this.darkTime.ShowUpDown = true;
            this.darkTime.Size = new System.Drawing.Size(228, 27);
            this.darkTime.TabIndex = 8;
            // 
            // rbDarkTime
            // 
            this.rbDarkTime.AutoSize = true;
            this.rbDarkTime.Checked = true;
            this.rbDarkTime.Location = new System.Drawing.Point(143, 61);
            this.rbDarkTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbDarkTime.Name = "rbDarkTime";
            this.rbDarkTime.Size = new System.Drawing.Size(117, 24);
            this.rbDarkTime.TabIndex = 7;
            this.rbDarkTime.TabStop = true;
            this.rbDarkTime.Text = "specific time:";
            this.rbDarkTime.UseVisualStyleBackColor = true;
            // 
            // cbDarkSunphase
            // 
            this.cbDarkSunphase.Enabled = false;
            this.cbDarkSunphase.FormattingEnabled = true;
            this.cbDarkSunphase.Location = new System.Drawing.Point(267, 21);
            this.cbDarkSunphase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbDarkSunphase.Name = "cbDarkSunphase";
            this.cbDarkSunphase.Size = new System.Drawing.Size(227, 28);
            this.cbDarkSunphase.TabIndex = 6;
            // 
            // rbDarkSunphase
            // 
            this.rbDarkSunphase.AutoSize = true;
            this.rbDarkSunphase.Location = new System.Drawing.Point(143, 21);
            this.rbDarkSunphase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbDarkSunphase.Name = "rbDarkSunphase";
            this.rbDarkSunphase.Size = new System.Drawing.Size(98, 24);
            this.rbDarkSunphase.TabIndex = 5;
            this.rbDarkSunphase.Text = "sun phase:";
            this.rbDarkSunphase.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Switch to dark at:";
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Location = new System.Drawing.Point(7, 51);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(66, 20);
            this.lblLatitude.TabIndex = 8;
            this.lblLatitude.Text = "Latitude:";
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Location = new System.Drawing.Point(7, 99);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(79, 20);
            this.lblLongitude.TabIndex = 9;
            this.lblLongitude.Text = "Longitude:";
            // 
            // tbLatitude
            // 
            this.tbLatitude.Location = new System.Drawing.Point(87, 47);
            this.tbLatitude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbLatitude.Name = "tbLatitude";
            this.tbLatitude.Size = new System.Drawing.Size(179, 27);
            this.tbLatitude.TabIndex = 10;
            // 
            // tbLongitude
            // 
            this.tbLongitude.Location = new System.Drawing.Point(87, 95);
            this.tbLongitude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbLongitude.Name = "tbLongitude";
            this.tbLongitude.Size = new System.Drawing.Size(179, 27);
            this.tbLongitude.TabIndex = 11;
            // 
            // gbLocation
            // 
            this.gbLocation.Controls.Add(this.btnSystemPos);
            this.gbLocation.Controls.Add(this.llMaps);
            this.gbLocation.Controls.Add(this.btnPastePosition);
            this.gbLocation.Controls.Add(this.lblLongitude);
            this.gbLocation.Controls.Add(this.tbLongitude);
            this.gbLocation.Controls.Add(this.lblLatitude);
            this.gbLocation.Controls.Add(this.tbLatitude);
            this.gbLocation.Location = new System.Drawing.Point(15, 52);
            this.gbLocation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbLocation.Name = "gbLocation";
            this.gbLocation.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbLocation.Size = new System.Drawing.Size(503, 199);
            this.gbLocation.TabIndex = 12;
            this.gbLocation.TabStop = false;
            this.gbLocation.Text = "Geo Location";
            // 
            // btnSystemPos
            // 
            this.btnSystemPos.Location = new System.Drawing.Point(7, 151);
            this.btnSystemPos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSystemPos.Name = "btnSystemPos";
            this.btnSystemPos.Size = new System.Drawing.Size(155, 33);
            this.btnSystemPos.TabIndex = 14;
            this.btnSystemPos.Text = "Get system position";
            this.btnSystemPos.UseVisualStyleBackColor = true;
            this.btnSystemPos.Click += new System.EventHandler(this.btnSystemPos_Click);
            // 
            // llMaps
            // 
            this.llMaps.AutoSize = true;
            this.llMaps.Location = new System.Drawing.Point(172, 157);
            this.llMaps.Name = "llMaps";
            this.llMaps.Size = new System.Drawing.Size(98, 20);
            this.llMaps.TabIndex = 13;
            this.llMaps.TabStop = true;
            this.llMaps.Text = "Google Maps";
            this.llMaps.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llMaps_LinkClicked);
            // 
            // btnPastePosition
            // 
            this.btnPastePosition.Location = new System.Drawing.Point(281, 151);
            this.btnPastePosition.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnPastePosition.Name = "btnPastePosition";
            this.btnPastePosition.Size = new System.Drawing.Size(214, 33);
            this.btnPastePosition.TabIndex = 12;
            this.btnPastePosition.Text = "Paste position from clipboard";
            this.btnPastePosition.UseVisualStyleBackColor = true;
            this.btnPastePosition.Click += new System.EventHandler(this.btnPastePosition_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 516);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 29);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblColorMode
            // 
            this.lblColorMode.AutoSize = true;
            this.lblColorMode.Location = new System.Drawing.Point(14, 12);
            this.lblColorMode.Name = "lblColorMode";
            this.lblColorMode.Size = new System.Drawing.Size(420, 20);
            this.lblColorMode.TabIndex = 0;
            this.lblColorMode.Text = "Current color mode is {system} for system and {apps} for apps.";
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Geo location is required for sun phase switching";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 563);
            this.Controls.Add(this.lblColorMode);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbLocation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Auto Theme Switcher";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbLocation.ResumeLayout(false);
            this.gbLocation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DateTimePicker lightTime;
		private System.Windows.Forms.RadioButton rbLightTime;
		private System.Windows.Forms.ComboBox cbLightSunphase;
		private System.Windows.Forms.RadioButton rbLightSunphase;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.DateTimePicker darkTime;
		private System.Windows.Forms.RadioButton rbDarkTime;
		private System.Windows.Forms.ComboBox cbDarkSunphase;
		private System.Windows.Forms.RadioButton rbDarkSunphase;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblLatitude;
		private System.Windows.Forms.Label lblLongitude;
		private System.Windows.Forms.TextBox tbLatitude;
		private System.Windows.Forms.TextBox tbLongitude;
		private System.Windows.Forms.GroupBox gbLocation;
		private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPastePosition;
        private System.Windows.Forms.Label lblColorMode;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSystemPos;
        private System.Windows.Forms.LinkLabel llMaps;
    }
}

