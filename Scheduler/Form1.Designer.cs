namespace Scheduler
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.quantumT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.preB = new System.Windows.Forms.RadioButton();
            this.nonpreB = new System.Windows.Forms.RadioButton();
            this.rrB = new System.Windows.Forms.RadioButton();
            this.priorityB = new System.Windows.Forms.RadioButton();
            this.sjfB = new System.Windows.Forms.RadioButton();
            this.fcfsB = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.addB = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.priorityT = new System.Windows.Forms.TextBox();
            this.burstT = new System.Windows.Forms.TextBox();
            this.arrivalT = new System.Windows.Forms.TextBox();
            this.processT = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.waitingT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startB = new System.Windows.Forms.Button();
            this.restB = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.rrB);
            this.groupBox1.Controls.Add(this.priorityB);
            this.groupBox1.Controls.Add(this.sjfB);
            this.groupBox1.Controls.Add(this.fcfsB);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 163);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scheduling Type";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.quantumT);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(117, 121);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(118, 36);
            this.panel2.TabIndex = 7;
            this.panel2.Visible = false;
            // 
            // quantumT
            // 
            this.quantumT.Location = new System.Drawing.Point(35, 6);
            this.quantumT.Name = "quantumT";
            this.quantumT.Size = new System.Drawing.Size(35, 20);
            this.quantumT.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Q:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.preB);
            this.panel1.Controls.Add(this.nonpreB);
            this.panel1.Location = new System.Drawing.Point(117, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(118, 69);
            this.panel1.TabIndex = 6;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // preB
            // 
            this.preB.AutoSize = true;
            this.preB.Location = new System.Drawing.Point(13, 10);
            this.preB.Name = "preB";
            this.preB.Size = new System.Drawing.Size(79, 17);
            this.preB.TabIndex = 4;
            this.preB.TabStop = true;
            this.preB.Text = "Preemptive";
            this.preB.UseVisualStyleBackColor = true;
            // 
            // nonpreB
            // 
            this.nonpreB.AutoSize = true;
            this.nonpreB.Location = new System.Drawing.Point(13, 46);
            this.nonpreB.Name = "nonpreB";
            this.nonpreB.Size = new System.Drawing.Size(101, 17);
            this.nonpreB.TabIndex = 5;
            this.nonpreB.TabStop = true;
            this.nonpreB.Text = "Non Preemptive";
            this.nonpreB.UseVisualStyleBackColor = true;
            // 
            // rrB
            // 
            this.rrB.AutoSize = true;
            this.rrB.Location = new System.Drawing.Point(6, 128);
            this.rrB.Name = "rrB";
            this.rrB.Size = new System.Drawing.Size(39, 17);
            this.rrB.TabIndex = 3;
            this.rrB.Text = "RR";
            this.rrB.UseVisualStyleBackColor = true;
            this.rrB.CheckedChanged += new System.EventHandler(this.rrB_CheckedChanged);
            // 
            // priorityB
            // 
            this.priorityB.AutoSize = true;
            this.priorityB.Location = new System.Drawing.Point(6, 92);
            this.priorityB.Name = "priorityB";
            this.priorityB.Size = new System.Drawing.Size(59, 17);
            this.priorityB.TabIndex = 2;
            this.priorityB.Text = "Priority";
            this.priorityB.UseVisualStyleBackColor = true;
            this.priorityB.CheckedChanged += new System.EventHandler(this.priorityB_CheckedChanged);
            // 
            // sjfB
            // 
            this.sjfB.AutoSize = true;
            this.sjfB.Location = new System.Drawing.Point(6, 56);
            this.sjfB.Name = "sjfB";
            this.sjfB.Size = new System.Drawing.Size(42, 17);
            this.sjfB.TabIndex = 1;
            this.sjfB.Text = "SJF";
            this.sjfB.UseVisualStyleBackColor = true;
            this.sjfB.CheckedChanged += new System.EventHandler(this.sjfB_CheckedChanged);
            // 
            // fcfsB
            // 
            this.fcfsB.AutoSize = true;
            this.fcfsB.Checked = true;
            this.fcfsB.Location = new System.Drawing.Point(6, 20);
            this.fcfsB.Name = "fcfsB";
            this.fcfsB.Size = new System.Drawing.Size(50, 17);
            this.fcfsB.TabIndex = 0;
            this.fcfsB.TabStop = true;
            this.fcfsB.Text = "FCFS";
            this.fcfsB.UseVisualStyleBackColor = true;
            this.fcfsB.CheckedChanged += new System.EventHandler(this.fcfsB_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.addB);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.priorityT);
            this.groupBox2.Controls.Add(this.burstT);
            this.groupBox2.Controls.Add(this.arrivalT);
            this.groupBox2.Controls.Add(this.processT);
            this.groupBox2.Location = new System.Drawing.Point(345, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 163);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Process";
            // 
            // addB
            // 
            this.addB.Location = new System.Drawing.Point(81, 128);
            this.addB.Name = "addB";
            this.addB.Size = new System.Drawing.Size(100, 23);
            this.addB.TabIndex = 8;
            this.addB.Text = "Add Process";
            this.addB.UseVisualStyleBackColor = true;
            this.addB.Click += new System.EventHandler(this.addB_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Priority";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Burst";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Arrival";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Process";
            // 
            // priorityT
            // 
            this.priorityT.Location = new System.Drawing.Point(81, 99);
            this.priorityT.Name = "priorityT";
            this.priorityT.Size = new System.Drawing.Size(100, 20);
            this.priorityT.TabIndex = 3;
            // 
            // burstT
            // 
            this.burstT.Location = new System.Drawing.Point(81, 73);
            this.burstT.Name = "burstT";
            this.burstT.Size = new System.Drawing.Size(100, 20);
            this.burstT.TabIndex = 2;
            // 
            // arrivalT
            // 
            this.arrivalT.Location = new System.Drawing.Point(81, 47);
            this.arrivalT.Name = "arrivalT";
            this.arrivalT.Size = new System.Drawing.Size(100, 20);
            this.arrivalT.TabIndex = 1;
            // 
            // processT
            // 
            this.processT.Enabled = false;
            this.processT.Location = new System.Drawing.Point(81, 21);
            this.processT.Name = "processT";
            this.processT.Size = new System.Drawing.Size(100, 20);
            this.processT.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chart1);
            this.groupBox3.Location = new System.Drawing.Point(12, 232);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1118, 343);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Results";
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(6, 19);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1106, 318);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // waitingT
            // 
            this.waitingT.Location = new System.Drawing.Point(1019, 199);
            this.waitingT.Name = "waitingT";
            this.waitingT.Size = new System.Drawing.Size(105, 20);
            this.waitingT.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(899, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Average waiting Time:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(681, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 156);
            this.dataGridView1.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Proceses";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Arrival";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Burst";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Priority";
            this.Column4.Name = "Column4";
            // 
            // startB
            // 
            this.startB.Location = new System.Drawing.Point(345, 190);
            this.startB.Name = "startB";
            this.startB.Size = new System.Drawing.Size(134, 36);
            this.startB.TabIndex = 4;
            this.startB.Text = "Start Scheduling";
            this.startB.UseVisualStyleBackColor = true;
            this.startB.Click += new System.EventHandler(this.startB_Click);
            // 
            // restB
            // 
            this.restB.Location = new System.Drawing.Point(499, 190);
            this.restB.Name = "restB";
            this.restB.Size = new System.Drawing.Size(134, 36);
            this.restB.TabIndex = 5;
            this.restB.Text = "Reset";
            this.restB.UseVisualStyleBackColor = true;
            this.restB.Click += new System.EventHandler(this.restB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 587);
            this.Controls.Add(this.waitingT);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.restB);
            this.Controls.Add(this.startB);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox quantumT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton preB;
        private System.Windows.Forms.RadioButton nonpreB;
        private System.Windows.Forms.RadioButton rrB;
        private System.Windows.Forms.RadioButton priorityB;
        private System.Windows.Forms.RadioButton sjfB;
        private System.Windows.Forms.RadioButton fcfsB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button addB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox priorityT;
        private System.Windows.Forms.TextBox burstT;
        private System.Windows.Forms.TextBox arrivalT;
        private System.Windows.Forms.TextBox processT;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button startB;
        private System.Windows.Forms.Button restB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.TextBox waitingT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

