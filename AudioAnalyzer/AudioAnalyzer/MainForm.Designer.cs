namespace AudioAnalyzer
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
            this.components = new System.ComponentModel.Container();
            this.comboBoxDevices = new System.Windows.Forms.ComboBox();
            this.progressBarVol = new System.Windows.Forms.ProgressBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.comboBoxSampleRate = new System.Windows.Forms.ComboBox();
            this.progressBarHigh = new System.Windows.Forms.ProgressBar();
            this.progressBarMid = new System.Windows.Forms.ProgressBar();
            this.progressBarLow = new System.Windows.Forms.ProgressBar();
            this.numericUpDownRefreshRate = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownSensitivity = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSensitivity)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxDevices
            // 
            this.comboBoxDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDevices.FormattingEnabled = true;
            this.comboBoxDevices.Location = new System.Drawing.Point(236, 12);
            this.comboBoxDevices.Name = "comboBoxDevices";
            this.comboBoxDevices.Size = new System.Drawing.Size(293, 21);
            this.comboBoxDevices.TabIndex = 1;
            this.comboBoxDevices.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDevices_SelectedIndexChanged);
            // 
            // progressBarVol
            // 
            this.progressBarVol.Location = new System.Drawing.Point(106, 157);
            this.progressBarVol.Name = "progressBarVol";
            this.progressBarVol.Size = new System.Drawing.Size(135, 21);
            this.progressBarVol.TabIndex = 0;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // comboBoxSampleRate
            // 
            this.comboBoxSampleRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSampleRate.FormattingEnabled = true;
            this.comboBoxSampleRate.Items.AddRange(new object[] {
            "8000",
            "11025",
            "16000",
            "22050",
            "32000",
            "44100",
            "48000"});
            this.comboBoxSampleRate.Location = new System.Drawing.Point(106, 12);
            this.comboBoxSampleRate.Name = "comboBoxSampleRate";
            this.comboBoxSampleRate.Size = new System.Drawing.Size(61, 21);
            this.comboBoxSampleRate.TabIndex = 2;
            this.comboBoxSampleRate.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSampleRate_SelectedIndexChanged);
            // 
            // progressBarHigh
            // 
            this.progressBarHigh.Location = new System.Drawing.Point(106, 68);
            this.progressBarHigh.Name = "progressBarHigh";
            this.progressBarHigh.Size = new System.Drawing.Size(423, 23);
            this.progressBarHigh.TabIndex = 6;
            // 
            // progressBarMid
            // 
            this.progressBarMid.Location = new System.Drawing.Point(106, 97);
            this.progressBarMid.Name = "progressBarMid";
            this.progressBarMid.Size = new System.Drawing.Size(423, 23);
            this.progressBarMid.TabIndex = 7;
            // 
            // progressBarLow
            // 
            this.progressBarLow.Location = new System.Drawing.Point(106, 126);
            this.progressBarLow.Name = "progressBarLow";
            this.progressBarLow.Size = new System.Drawing.Size(423, 23);
            this.progressBarLow.TabIndex = 8;
            // 
            // numericUpDownRefreshRate
            // 
            this.numericUpDownRefreshRate.Location = new System.Drawing.Point(106, 41);
            this.numericUpDownRefreshRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownRefreshRate.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownRefreshRate.Name = "numericUpDownRefreshRate";
            this.numericUpDownRefreshRate.Size = new System.Drawing.Size(61, 20);
            this.numericUpDownRefreshRate.TabIndex = 9;
            this.numericUpDownRefreshRate.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownRefreshRate.ValueChanged += new System.EventHandler(this.NumericUpDownRefreshRate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Refresh rate (ms):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sample rate (Hz):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "High:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Mid:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Low:";
            // 
            // numericUpDownSensitivity
            // 
            this.numericUpDownSensitivity.Location = new System.Drawing.Point(236, 41);
            this.numericUpDownSensitivity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownSensitivity.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownSensitivity.Name = "numericUpDownSensitivity";
            this.numericUpDownSensitivity.Size = new System.Drawing.Size(72, 20);
            this.numericUpDownSensitivity.TabIndex = 16;
            this.numericUpDownSensitivity.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownSensitivity.ValueChanged += new System.EventHandler(this.NumericUpDownSensitivity_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Sensitivity:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(314, 39);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(215, 23);
            this.buttonStart.TabIndex = 18;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(186, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Device:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(75, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Vol:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(247, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Port:";
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(282, 157);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(85, 21);
            this.comboBoxPort.TabIndex = 22;
            this.comboBoxPort.SelectedIndexChanged += new System.EventHandler(this.comboBoxPort_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(373, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Baud rate:";
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBoxBaudRate.Location = new System.Drawing.Point(440, 157);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(89, 21);
            this.comboBoxBaudRate.TabIndex = 24;
            this.comboBoxBaudRate.SelectedIndexChanged += new System.EventHandler(this.comboBoxBaudRate_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 190);
            this.Controls.Add(this.comboBoxBaudRate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBoxPort);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDownSensitivity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownRefreshRate);
            this.Controls.Add(this.progressBarLow);
            this.Controls.Add(this.progressBarMid);
            this.Controls.Add(this.progressBarHigh);
            this.Controls.Add(this.comboBoxSampleRate);
            this.Controls.Add(this.progressBarVol);
            this.Controls.Add(this.comboBoxDevices);
            this.Name = "MainForm";
            this.Text = "AudioAnalyzer";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSensitivity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDevices;
        private System.Windows.Forms.ProgressBar progressBarVol;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ComboBox comboBoxSampleRate;
        private System.Windows.Forms.ProgressBar progressBarHigh;
        private System.Windows.Forms.ProgressBar progressBarMid;
        private System.Windows.Forms.ProgressBar progressBarLow;
        private System.Windows.Forms.NumericUpDown numericUpDownRefreshRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownSensitivity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
    }
}

