namespace VARLightControl
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.m_checkBoxSwitchCh3 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_btnWriteCh3 = new System.Windows.Forms.Button();
            this.m_trackBarCh3 = new System.Windows.Forms.TrackBar();
            this.m_btnReadCh3 = new System.Windows.Forms.Button();
            this.m_numericUpDownCh3 = new System.Windows.Forms.NumericUpDown();
            this.m_HoldingTimeCh3 = new System.Windows.Forms.NumericUpDown();
            this.m_comboBoxModeCh3 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.m_checkBoxSwitchCh0 = new System.Windows.Forms.CheckBox();
            this.m_btnWriteCh0 = new System.Windows.Forms.Button();
            this.m_btnReadCh0 = new System.Windows.Forms.Button();
            this.m_HoldingTimeCh0 = new System.Windows.Forms.NumericUpDown();
            this.m_comboBoxModeCh0 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_btnConnect = new System.Windows.Forms.Button();
            this.m_comboBoxPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_trackBarCh3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDownCh3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_HoldingTimeCh3)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_HoldingTimeCh0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, -3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1093, 724);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1085, 695);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Light Control";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.flowLayoutPanel2);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.m_btnWriteCh3);
            this.groupBox4.Controls.Add(this.m_trackBarCh3);
            this.groupBox4.Controls.Add(this.m_btnReadCh3);
            this.groupBox4.Controls.Add(this.m_numericUpDownCh3);
            this.groupBox4.Controls.Add(this.m_HoldingTimeCh3);
            this.groupBox4.Controls.Add(this.m_comboBoxModeCh3);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(7, 524);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1044, 134);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "CH3";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.m_checkBoxSwitchCh3);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(799, 53);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(106, 34);
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // m_checkBoxSwitchCh3
            // 
            this.m_checkBoxSwitchCh3.AutoSize = true;
            this.m_checkBoxSwitchCh3.Location = new System.Drawing.Point(3, 3);
            this.m_checkBoxSwitchCh3.Name = "m_checkBoxSwitchCh3";
            this.m_checkBoxSwitchCh3.Size = new System.Drawing.Size(55, 20);
            this.m_checkBoxSwitchCh3.TabIndex = 0;
            this.m_checkBoxSwitchCh3.Text = "OFF";
            this.m_checkBoxSwitchCh3.UseVisualStyleBackColor = true;
            this.m_checkBoxSwitchCh3.CheckedChanged += new System.EventHandler(this.m_checkBoxSwitchCh3_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mode";
            // 
            // m_btnWriteCh3
            // 
            this.m_btnWriteCh3.Location = new System.Drawing.Point(674, 94);
            this.m_btnWriteCh3.Name = "m_btnWriteCh3";
            this.m_btnWriteCh3.Size = new System.Drawing.Size(86, 30);
            this.m_btnWriteCh3.TabIndex = 6;
            this.m_btnWriteCh3.Text = "Write";
            this.m_btnWriteCh3.UseVisualStyleBackColor = true;
            this.m_btnWriteCh3.Click += new System.EventHandler(this.m_btnWriteCh3_Click);
            // 
            // m_trackBarCh3
            // 
            this.m_trackBarCh3.Location = new System.Drawing.Point(6, 21);
            this.m_trackBarCh3.Maximum = 100;
            this.m_trackBarCh3.Name = "m_trackBarCh3";
            this.m_trackBarCh3.Size = new System.Drawing.Size(652, 56);
            this.m_trackBarCh3.TabIndex = 2;
            this.m_trackBarCh3.ValueChanged += new System.EventHandler(this.m_trackBarCh3_ValueChanged);
            // 
            // m_btnReadCh3
            // 
            this.m_btnReadCh3.Location = new System.Drawing.Point(554, 94);
            this.m_btnReadCh3.Name = "m_btnReadCh3";
            this.m_btnReadCh3.Size = new System.Drawing.Size(86, 30);
            this.m_btnReadCh3.TabIndex = 6;
            this.m_btnReadCh3.Text = "Read";
            this.m_btnReadCh3.UseVisualStyleBackColor = true;
            this.m_btnReadCh3.Click += new System.EventHandler(this.m_btnReadCh3_Click);
            // 
            // m_numericUpDownCh3
            // 
            this.m_numericUpDownCh3.Location = new System.Drawing.Point(674, 21);
            this.m_numericUpDownCh3.Name = "m_numericUpDownCh3";
            this.m_numericUpDownCh3.Size = new System.Drawing.Size(82, 22);
            this.m_numericUpDownCh3.TabIndex = 1;
            // 
            // m_HoldingTimeCh3
            // 
            this.m_HoldingTimeCh3.Location = new System.Drawing.Point(313, 92);
            this.m_HoldingTimeCh3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_HoldingTimeCh3.Name = "m_HoldingTimeCh3";
            this.m_HoldingTimeCh3.Size = new System.Drawing.Size(120, 22);
            this.m_HoldingTimeCh3.TabIndex = 5;
            // 
            // m_comboBoxModeCh3
            // 
            this.m_comboBoxModeCh3.FormattingEnabled = true;
            this.m_comboBoxModeCh3.Items.AddRange(new object[] {
            "Soft Trigger",
            "Hard Switch",
            "Raising Edge"});
            this.m_comboBoxModeCh3.Location = new System.Drawing.Point(54, 91);
            this.m_comboBoxModeCh3.Name = "m_comboBoxModeCh3";
            this.m_comboBoxModeCh3.Size = new System.Drawing.Size(159, 24);
            this.m_comboBoxModeCh3.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(219, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Holding Time";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.trackBar3);
            this.groupBox3.Controls.Add(this.numericUpDown2);
            this.groupBox3.Location = new System.Drawing.Point(7, 381);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1044, 137);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CH2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mode";
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(6, 30);
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(652, 56);
            this.trackBar3.TabIndex = 2;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(674, 30);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(82, 22);
            this.numericUpDown2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Location = new System.Drawing.Point(7, 233);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1040, 131);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CH1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mode";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(6, 21);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(652, 56);
            this.trackBar1.TabIndex = 2;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(674, 21);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(82, 22);
            this.numericUpDown1.TabIndex = 1;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.flowLayoutPanel1);
            this.groupBox.Controls.Add(this.m_btnWriteCh0);
            this.groupBox.Controls.Add(this.m_btnReadCh0);
            this.groupBox.Controls.Add(this.m_HoldingTimeCh0);
            this.groupBox.Controls.Add(this.m_comboBoxModeCh0);
            this.groupBox.Controls.Add(this.label6);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.trackBar4);
            this.groupBox.Controls.Add(this.numericUpDown4);
            this.groupBox.Location = new System.Drawing.Point(4, 78);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(1043, 132);
            this.groupBox.TabIndex = 5;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "CH0";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.m_checkBoxSwitchCh0);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(802, 58);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(106, 34);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // m_checkBoxSwitchCh0
            // 
            this.m_checkBoxSwitchCh0.AutoSize = true;
            this.m_checkBoxSwitchCh0.Location = new System.Drawing.Point(3, 3);
            this.m_checkBoxSwitchCh0.Name = "m_checkBoxSwitchCh0";
            this.m_checkBoxSwitchCh0.Size = new System.Drawing.Size(55, 20);
            this.m_checkBoxSwitchCh0.TabIndex = 0;
            this.m_checkBoxSwitchCh0.Text = "OFF";
            this.m_checkBoxSwitchCh0.UseVisualStyleBackColor = true;
            this.m_checkBoxSwitchCh0.CheckedChanged += new System.EventHandler(this.m_checkBoxSwitchCh0_CheckedChanged);
            // 
            // m_btnWriteCh0
            // 
            this.m_btnWriteCh0.Location = new System.Drawing.Point(677, 91);
            this.m_btnWriteCh0.Name = "m_btnWriteCh0";
            this.m_btnWriteCh0.Size = new System.Drawing.Size(86, 30);
            this.m_btnWriteCh0.TabIndex = 6;
            this.m_btnWriteCh0.Text = "Write";
            this.m_btnWriteCh0.UseVisualStyleBackColor = true;
            this.m_btnWriteCh0.Click += new System.EventHandler(this.m_btnWriteCh0_Click);
            // 
            // m_btnReadCh0
            // 
            this.m_btnReadCh0.Location = new System.Drawing.Point(557, 90);
            this.m_btnReadCh0.Name = "m_btnReadCh0";
            this.m_btnReadCh0.Size = new System.Drawing.Size(86, 30);
            this.m_btnReadCh0.TabIndex = 6;
            this.m_btnReadCh0.Text = "Read";
            this.m_btnReadCh0.UseVisualStyleBackColor = true;
            this.m_btnReadCh0.Click += new System.EventHandler(this.m_btnReadCh0_Click);
            // 
            // m_HoldingTimeCh0
            // 
            this.m_HoldingTimeCh0.Location = new System.Drawing.Point(316, 98);
            this.m_HoldingTimeCh0.Name = "m_HoldingTimeCh0";
            this.m_HoldingTimeCh0.Size = new System.Drawing.Size(120, 22);
            this.m_HoldingTimeCh0.TabIndex = 5;
            this.m_HoldingTimeCh0.ValueChanged += new System.EventHandler(this.m_HoldingTimeCh0_ValueChanged);
            // 
            // m_comboBoxModeCh0
            // 
            this.m_comboBoxModeCh0.FormattingEnabled = true;
            this.m_comboBoxModeCh0.Location = new System.Drawing.Point(57, 95);
            this.m_comboBoxModeCh0.Name = "m_comboBoxModeCh0";
            this.m_comboBoxModeCh0.Size = new System.Drawing.Size(159, 24);
            this.m_comboBoxModeCh0.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(222, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Holding Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mode";
            // 
            // trackBar4
            // 
            this.trackBar4.Location = new System.Drawing.Point(9, 21);
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(652, 56);
            this.trackBar4.TabIndex = 2;
            this.trackBar4.Scroll += new System.EventHandler(this.m_trackBarCh0);
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(677, 21);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(82, 22);
            this.numericUpDown4.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_btnConnect);
            this.groupBox2.Controls.Add(this.m_comboBoxPort);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1041, 66);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "COM";
            // 
            // m_btnConnect
            // 
            this.m_btnConnect.BackColor = System.Drawing.Color.Red;
            this.m_btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_btnConnect.Location = new System.Drawing.Point(658, 15);
            this.m_btnConnect.Name = "m_btnConnect";
            this.m_btnConnect.Size = new System.Drawing.Size(148, 42);
            this.m_btnConnect.TabIndex = 4;
            this.m_btnConnect.Text = "Connect";
            this.m_btnConnect.UseVisualStyleBackColor = false;
            this.m_btnConnect.Click += new System.EventHandler(this.m_btnConnect_Click);
            // 
            // m_comboBoxPort
            // 
            this.m_comboBoxPort.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_comboBoxPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_comboBoxPort.FormattingEnabled = true;
            this.m_comboBoxPort.Location = new System.Drawing.Point(209, 21);
            this.m_comboBoxPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.m_comboBoxPort.Name = "m_comboBoxPort";
            this.m_comboBoxPort.Size = new System.Drawing.Size(185, 28);
            this.m_comboBoxPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Port";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1085, 695);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 722);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_trackBarCh3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDownCh3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_HoldingTimeCh3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_HoldingTimeCh0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TrackBar m_trackBarCh3;
        private System.Windows.Forms.NumericUpDown m_numericUpDownCh3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button m_btnConnect;
        private System.Windows.Forms.ComboBox m_comboBoxPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox m_checkBoxSwitchCh0;
        private System.Windows.Forms.Button m_btnWriteCh0;
        private System.Windows.Forms.Button m_btnReadCh0;
        private System.Windows.Forms.NumericUpDown m_HoldingTimeCh0;
        private System.Windows.Forms.ComboBox m_comboBoxModeCh0;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox m_checkBoxSwitchCh3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button m_btnWriteCh3;
        private System.Windows.Forms.Button m_btnReadCh3;
        private System.Windows.Forms.NumericUpDown m_HoldingTimeCh3;
        private System.Windows.Forms.ComboBox m_comboBoxModeCh3;
        private System.Windows.Forms.Label label7;
    }
}

