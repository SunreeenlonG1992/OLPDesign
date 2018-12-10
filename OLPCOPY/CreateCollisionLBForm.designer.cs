

namespace MinoApi
{
    partial class MinoCEEForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinoCEEForm));
            this.dgv_robotzone = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_setting = new System.Windows.Forms.TabPage();
            this.rb_minofanuc = new System.Windows.Forms.RadioButton();
            this.rb_saicFanuc = new System.Windows.Forms.RadioButton();
            this.rb_minokuka = new System.Windows.Forms.RadioButton();
            this.gb_saic = new System.Windows.Forms.GroupBox();
            this.tb_ZoneEnterSAIC = new System.Windows.Forms.TextBox();
            this.tb_ZoneclearSAIC = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.gb_mino = new System.Windows.Forms.GroupBox();
            this.tb_Zonefree = new System.Windows.Forms.TextBox();
            this.tb_ZoneEnable = new System.Windows.Forms.TextBox();
            this.tb_ZoneReq = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgv_Robotlist = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_ClearForm = new System.Windows.Forms.Button();
            this.bt_CreatLB = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bt_ExportExcel = new System.Windows.Forms.Button();
            this.bt_ImportExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_robotzone)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage_setting.SuspendLayout();
            this.gb_saic.SuspendLayout();
            this.gb_mino.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Robotlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_robotzone
            // 
            this.dgv_robotzone.AllowUserToAddRows = false;
            this.dgv_robotzone.AllowUserToDeleteRows = false;
            this.dgv_robotzone.AllowUserToResizeRows = false;
            this.dgv_robotzone.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_robotzone.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dgv_robotzone.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_robotzone.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_robotzone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_robotzone.Location = new System.Drawing.Point(0, 0);
            this.dgv_robotzone.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_robotzone.MultiSelect = false;
            this.dgv_robotzone.Name = "dgv_robotzone";
            this.dgv_robotzone.RowHeadersVisible = false;
            this.dgv_robotzone.RowTemplate.Height = 27;
            this.dgv_robotzone.Size = new System.Drawing.Size(896, 622);
            this.dgv_robotzone.TabIndex = 0;
            this.dgv_robotzone.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Robotlist_CellEndEdit);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage_setting);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1080, 659);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage_setting
            // 
            this.tabPage_setting.Controls.Add(this.rb_minofanuc);
            this.tabPage_setting.Controls.Add(this.rb_saicFanuc);
            this.tabPage_setting.Controls.Add(this.rb_minokuka);
            this.tabPage_setting.Controls.Add(this.gb_saic);
            this.tabPage_setting.Controls.Add(this.gb_mino);
            this.tabPage_setting.Location = new System.Drawing.Point(4, 25);
            this.tabPage_setting.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage_setting.Name = "tabPage_setting";
            this.tabPage_setting.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage_setting.Size = new System.Drawing.Size(1072, 630);
            this.tabPage_setting.TabIndex = 0;
            this.tabPage_setting.Text = "Setting";
            this.tabPage_setting.UseVisualStyleBackColor = true;
            // 
            // rb_minofanuc
            // 
            this.rb_minofanuc.AutoSize = true;
            this.rb_minofanuc.Location = new System.Drawing.Point(286, 45);
            this.rb_minofanuc.Name = "rb_minofanuc";
            this.rb_minofanuc.Size = new System.Drawing.Size(105, 19);
            this.rb_minofanuc.TabIndex = 21;
            this.rb_minofanuc.Text = "Mino_Fanuc";
            this.rb_minofanuc.UseVisualStyleBackColor = true;
            this.rb_minofanuc.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // rb_saicFanuc
            // 
            this.rb_saicFanuc.AutoSize = true;
            this.rb_saicFanuc.Location = new System.Drawing.Point(550, 45);
            this.rb_saicFanuc.Name = "rb_saicFanuc";
            this.rb_saicFanuc.Size = new System.Drawing.Size(105, 19);
            this.rb_saicFanuc.TabIndex = 20;
            this.rb_saicFanuc.Text = "SAIC_Fanuc";
            this.rb_saicFanuc.UseVisualStyleBackColor = true;
            this.rb_saicFanuc.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rb_minokuka
            // 
            this.rb_minokuka.AutoSize = true;
            this.rb_minokuka.Checked = true;
            this.rb_minokuka.Location = new System.Drawing.Point(32, 45);
            this.rb_minokuka.Name = "rb_minokuka";
            this.rb_minokuka.Size = new System.Drawing.Size(97, 19);
            this.rb_minokuka.TabIndex = 19;
            this.rb_minokuka.TabStop = true;
            this.rb_minokuka.Text = "Mino_KUKA";
            this.rb_minokuka.UseVisualStyleBackColor = true;
            this.rb_minokuka.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // gb_saic
            // 
            this.gb_saic.Controls.Add(this.tb_ZoneEnterSAIC);
            this.gb_saic.Controls.Add(this.tb_ZoneclearSAIC);
            this.gb_saic.Controls.Add(this.label11);
            this.gb_saic.Controls.Add(this.label12);
            this.gb_saic.Location = new System.Drawing.Point(540, 115);
            this.gb_saic.Name = "gb_saic";
            this.gb_saic.Size = new System.Drawing.Size(468, 337);
            this.gb_saic.TabIndex = 18;
            this.gb_saic.TabStop = false;
            this.gb_saic.Text = "SignalName_SAIC";
            // 
            // tb_ZoneEnterSAIC
            // 
            this.tb_ZoneEnterSAIC.Location = new System.Drawing.Point(239, 78);
            this.tb_ZoneEnterSAIC.Name = "tb_ZoneEnterSAIC";
            this.tb_ZoneEnterSAIC.Size = new System.Drawing.Size(187, 24);
            this.tb_ZoneEnterSAIC.TabIndex = 10;
            this.tb_ZoneEnterSAIC.Text = "_ClearToEntrZoneX";
            // 
            // tb_ZoneclearSAIC
            // 
            this.tb_ZoneclearSAIC.Location = new System.Drawing.Point(239, 36);
            this.tb_ZoneclearSAIC.Name = "tb_ZoneclearSAIC";
            this.tb_ZoneclearSAIC.Size = new System.Drawing.Size(187, 24);
            this.tb_ZoneclearSAIC.TabIndex = 9;
            this.tb_ZoneclearSAIC.Text = "_ClearOfZoneX";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 11F);
            this.label11.Location = new System.Drawing.Point(43, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(181, 15);
            this.label11.TabIndex = 7;
            this.label11.Text = "ClearToEntrZone（Q）: ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 11F);
            this.label12.Location = new System.Drawing.Point(43, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(149, 15);
            this.label12.TabIndex = 6;
            this.label12.Text = "ClearOfZone（I）: ";
            // 
            // gb_mino
            // 
            this.gb_mino.Controls.Add(this.tb_Zonefree);
            this.gb_mino.Controls.Add(this.tb_ZoneEnable);
            this.gb_mino.Controls.Add(this.tb_ZoneReq);
            this.gb_mino.Controls.Add(this.label3);
            this.gb_mino.Controls.Add(this.label2);
            this.gb_mino.Controls.Add(this.label1);
            this.gb_mino.Location = new System.Drawing.Point(23, 115);
            this.gb_mino.Name = "gb_mino";
            this.gb_mino.Size = new System.Drawing.Size(468, 337);
            this.gb_mino.TabIndex = 16;
            this.gb_mino.TabStop = false;
            this.gb_mino.Text = "SignalName_Mino";
            // 
            // tb_Zonefree
            // 
            this.tb_Zonefree.Location = new System.Drawing.Point(239, 125);
            this.tb_Zonefree.Name = "tb_Zonefree";
            this.tb_Zonefree.Size = new System.Drawing.Size(187, 24);
            this.tb_Zonefree.TabIndex = 11;
            this.tb_Zonefree.Text = "_Area X";
            // 
            // tb_ZoneEnable
            // 
            this.tb_ZoneEnable.Location = new System.Drawing.Point(239, 83);
            this.tb_ZoneEnable.Name = "tb_ZoneEnable";
            this.tb_ZoneEnable.Size = new System.Drawing.Size(187, 24);
            this.tb_ZoneEnable.TabIndex = 10;
            this.tb_ZoneEnable.Text = "_Zone X_To_RB";
            // 
            // tb_ZoneReq
            // 
            this.tb_ZoneReq.Location = new System.Drawing.Point(239, 41);
            this.tb_ZoneReq.Name = "tb_ZoneReq";
            this.tb_ZoneReq.Size = new System.Drawing.Size(187, 24);
            this.tb_ZoneReq.TabIndex = 9;
            this.tb_ZoneReq.Text = "_Zone X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(43, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Area Free（I）:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(43, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Zone Enable（Q）: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(43, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Zone Req（I）: ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel6);
            this.tabPage2.Controls.Add(this.splitter1);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1072, 630);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "RobotZone";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgv_robotzone);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(172, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(896, 622);
            this.panel6.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(164, 4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 622);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgv_Robotlist);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(160, 622);
            this.panel4.TabIndex = 3;
            // 
            // dgv_Robotlist
            // 
            this.dgv_Robotlist.AllowUserToAddRows = false;
            this.dgv_Robotlist.AllowUserToDeleteRows = false;
            this.dgv_Robotlist.AllowUserToResizeColumns = false;
            this.dgv_Robotlist.AllowUserToResizeRows = false;
            this.dgv_Robotlist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Robotlist.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dgv_Robotlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Robotlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Robotlist.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_Robotlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Robotlist.Location = new System.Drawing.Point(0, 0);
            this.dgv_Robotlist.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Robotlist.MultiSelect = false;
            this.dgv_Robotlist.Name = "dgv_Robotlist";
            this.dgv_Robotlist.RowHeadersVisible = false;
            this.dgv_Robotlist.RowTemplate.Height = 27;
            this.dgv_Robotlist.ShowEditingIcon = false;
            this.dgv_Robotlist.Size = new System.Drawing.Size(160, 622);
            this.dgv_Robotlist.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 11F);
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn1.HeaderText = "Robot";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // bt_ClearForm
            // 
            this.bt_ClearForm.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bt_ClearForm.Font = new System.Drawing.Font("宋体", 11F);
            this.bt_ClearForm.Location = new System.Drawing.Point(1112, 188);
            this.bt_ClearForm.Margin = new System.Windows.Forms.Padding(4);
            this.bt_ClearForm.Name = "bt_ClearForm";
            this.bt_ClearForm.Size = new System.Drawing.Size(137, 72);
            this.bt_ClearForm.TabIndex = 3;
            this.bt_ClearForm.Text = "Clear Form";
            this.bt_ClearForm.UseVisualStyleBackColor = true;
            this.bt_ClearForm.Click += new System.EventHandler(this.button1_Click);
            // 
            // bt_CreatLB
            // 
            this.bt_CreatLB.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bt_CreatLB.Font = new System.Drawing.Font("宋体", 11F);
            this.bt_CreatLB.Location = new System.Drawing.Point(1112, 301);
            this.bt_CreatLB.Margin = new System.Windows.Forms.Padding(4);
            this.bt_CreatLB.Name = "bt_CreatLB";
            this.bt_CreatLB.Size = new System.Drawing.Size(137, 72);
            this.bt_CreatLB.TabIndex = 4;
            this.bt_CreatLB.Text = "Creat";
            this.bt_CreatLB.UseVisualStyleBackColor = true;
            this.bt_CreatLB.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1112, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(315, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // bt_ExportExcel
            // 
            this.bt_ExportExcel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bt_ExportExcel.Font = new System.Drawing.Font("宋体", 11F);
            this.bt_ExportExcel.Location = new System.Drawing.Point(1290, 301);
            this.bt_ExportExcel.Margin = new System.Windows.Forms.Padding(4);
            this.bt_ExportExcel.Name = "bt_ExportExcel";
            this.bt_ExportExcel.Size = new System.Drawing.Size(137, 72);
            this.bt_ExportExcel.TabIndex = 8;
            this.bt_ExportExcel.Text = "Export";
            this.bt_ExportExcel.UseVisualStyleBackColor = true;
            this.bt_ExportExcel.Click += new System.EventHandler(this.button5_Click);
            // 
            // bt_ImportExcel
            // 
            this.bt_ImportExcel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bt_ImportExcel.Font = new System.Drawing.Font("宋体", 11F);
            this.bt_ImportExcel.Location = new System.Drawing.Point(1290, 188);
            this.bt_ImportExcel.Margin = new System.Windows.Forms.Padding(4);
            this.bt_ImportExcel.Name = "bt_ImportExcel";
            this.bt_ImportExcel.Size = new System.Drawing.Size(137, 72);
            this.bt_ImportExcel.TabIndex = 9;
            this.bt_ImportExcel.Text = "Import";
            this.bt_ImportExcel.UseVisualStyleBackColor = true;
            this.bt_ImportExcel.Click += new System.EventHandler(this.button6_Click);
            // 
            // MinoCEEForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 659);
            this.Controls.Add(this.bt_ImportExcel);
            this.Controls.Add(this.bt_ExportExcel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bt_CreatLB);
            this.Controls.Add(this.bt_ClearForm);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MinoCEEForm";
            this.ShowIcon = false;
            this.Text = "Robot Interference Editor";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_robotzone)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_setting.ResumeLayout(false);
            this.tabPage_setting.PerformLayout();
            this.gb_saic.ResumeLayout(false);
            this.gb_saic.PerformLayout();
            this.gb_mino.ResumeLayout(false);
            this.gb_mino.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Robotlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgv_robotzone;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_setting;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gb_mino;
        private System.Windows.Forms.TextBox tb_Zonefree;
        private System.Windows.Forms.TextBox tb_ZoneEnable;
        private System.Windows.Forms.TextBox tb_ZoneReq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_ClearForm;
        private System.Windows.Forms.Button bt_CreatLB;
        public System.Windows.Forms.RadioButton rb_saicFanuc;
        public System.Windows.Forms.RadioButton rb_minokuka;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.DataGridView dgv_Robotlist;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button bt_ExportExcel;
        private System.Windows.Forms.Button bt_ImportExcel;
        public System.Windows.Forms.RadioButton rb_minofanuc;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox gb_saic;
        private System.Windows.Forms.TextBox tb_ZoneEnterSAIC;
        private System.Windows.Forms.TextBox tb_ZoneclearSAIC;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}