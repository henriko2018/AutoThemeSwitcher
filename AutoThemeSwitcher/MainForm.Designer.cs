
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbCurrentSystem = new System.Windows.Forms.TextBox();
			this.tbCurrentApps = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
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
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tbLatitude = new System.Windows.Forms.TextBox();
			this.tbLongitude = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(190, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Current system color mode:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 69);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(177, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Current apps color mode:";
			// 
			// tbCurrentSystem
			// 
			this.tbCurrentSystem.Location = new System.Drawing.Point(198, 21);
			this.tbCurrentSystem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbCurrentSystem.Name = "tbCurrentSystem";
			this.tbCurrentSystem.ReadOnly = true;
			this.tbCurrentSystem.Size = new System.Drawing.Size(114, 27);
			this.tbCurrentSystem.TabIndex = 1;
			// 
			// tbCurrentApps
			// 
			this.tbCurrentApps.Location = new System.Drawing.Point(198, 65);
			this.tbCurrentApps.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbCurrentApps.Name = "tbCurrentApps";
			this.tbCurrentApps.ReadOnly = true;
			this.tbCurrentApps.Size = new System.Drawing.Size(114, 27);
			this.tbCurrentApps.TabIndex = 3;
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.tbCurrentApps);
			this.groupBox1.Controls.Add(this.tbCurrentSystem);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(15, 16);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox1.Size = new System.Drawing.Size(319, 108);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lightTime);
			this.groupBox2.Controls.Add(this.rbLightTime);
			this.groupBox2.Controls.Add(this.cbLightSunphase);
			this.groupBox2.Controls.Add(this.rbLightSunphase);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Location = new System.Drawing.Point(15, 133);
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
			this.groupBox3.Location = new System.Drawing.Point(15, 245);
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
			this.rbDarkSunphase.Enabled = false;
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
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(354, 41);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(66, 20);
			this.label5.TabIndex = 8;
			this.label5.Text = "Latitude:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(355, 85);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(79, 20);
			this.label6.TabIndex = 9;
			this.label6.Text = "Longitude:";
			// 
			// tbLatitude
			// 
			this.tbLatitude.Location = new System.Drawing.Point(107, 21);
			this.tbLatitude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbLatitude.Name = "tbLatitude";
			this.tbLatitude.ReadOnly = true;
			this.tbLatitude.Size = new System.Drawing.Size(114, 27);
			this.tbLatitude.TabIndex = 10;
			// 
			// tbLongitude
			// 
			this.tbLongitude.Location = new System.Drawing.Point(107, 65);
			this.tbLongitude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbLongitude.Name = "tbLongitude";
			this.tbLongitude.ReadOnly = true;
			this.tbLongitude.Size = new System.Drawing.Size(114, 27);
			this.tbLongitude.TabIndex = 11;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.tbLongitude);
			this.groupBox4.Controls.Add(this.tbLatitude);
			this.groupBox4.Location = new System.Drawing.Point(342, 16);
			this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox4.Size = new System.Drawing.Size(229, 108);
			this.groupBox4.TabIndex = 12;
			this.groupBox4.TabStop = false;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(15, 357);
			this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(86, 31);
			this.btnSave.TabIndex = 13;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 416);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox4);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MainForm";
			this.Text = "Auto Theme Switcher";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbCurrentSystem;
		private System.Windows.Forms.TextBox tbCurrentApps;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
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
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbLatitude;
		private System.Windows.Forms.TextBox tbLongitude;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button btnSave;
	}
}

