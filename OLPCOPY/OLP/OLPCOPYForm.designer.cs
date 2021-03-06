﻿namespace example
{
    partial class MypathForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MypathForm));
            this.txObjGridCtrl_targetLocation = new Tecnomatix.Engineering.Ui.TxObjGridCtrl();
            this.sourceLocation_tb = new Tecnomatix.Engineering.Ui.TxObjEditBoxCtrl();
            this.richTextBox_sourceOLP = new System.Windows.Forms.RichTextBox();
            this.button_remove = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.pictureBox_clearsearch = new System.Windows.Forms.PictureBox();
            this.pictureBox_replace = new System.Windows.Forms.PictureBox();
            this.pictureBox_apply = new System.Windows.Forms.PictureBox();
            this.button_addWeldName = new System.Windows.Forms.Button();
            this.richTextBox_replaceOLP = new System.Windows.Forms.RichTextBox();
            this.richTextBox_findOLP = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Add = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_clearsearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_replace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_apply)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txObjGridCtrl_targetLocation
            // 
            this.txObjGridCtrl_targetLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txObjGridCtrl_targetLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txObjGridCtrl_targetLocation.ChangeGeneralSelection = false;
            this.txObjGridCtrl_targetLocation.CurrentRow = -1;
            this.txObjGridCtrl_targetLocation.EnableMultipleSelection = true;
            this.txObjGridCtrl_targetLocation.EnableRecurringObjects = false;
            this.txObjGridCtrl_targetLocation.ListenToPick = false;
            this.txObjGridCtrl_targetLocation.Location = new System.Drawing.Point(9, 40);
            this.txObjGridCtrl_targetLocation.Margin = new System.Windows.Forms.Padding(5);
            this.txObjGridCtrl_targetLocation.Name = "txObjGridCtrl_targetLocation";
            this.txObjGridCtrl_targetLocation.PickLevel = Tecnomatix.Engineering.Ui.TxPickLevel.Component;
            this.txObjGridCtrl_targetLocation.ReadOnly = false;
            this.txObjGridCtrl_targetLocation.Size = new System.Drawing.Size(317, 518);
            this.txObjGridCtrl_targetLocation.TabIndex = 2;
            this.txObjGridCtrl_targetLocation.ValidatorType = Tecnomatix.Engineering.Ui.TxValidatorType.RoboticLocationOperation;
            this.txObjGridCtrl_targetLocation.Enter += new System.EventHandler(this.txObjGridCtrl1_Enter);
            // 
            // sourceLocation_tb
            // 
            this.sourceLocation_tb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceLocation_tb.KeepFaceEmphasizedWhenControlIsNotFocused = true;
            this.sourceLocation_tb.ListenToPick = true;
            this.sourceLocation_tb.Location = new System.Drawing.Point(41, 52);
            this.sourceLocation_tb.Margin = new System.Windows.Forms.Padding(4);
            this.sourceLocation_tb.Name = "sourceLocation_tb";
            this.sourceLocation_tb.Object = null;
            this.sourceLocation_tb.PickAndClear = true;
            this.sourceLocation_tb.PickLevel = Tecnomatix.Engineering.Ui.TxPickLevel.Component;
            this.sourceLocation_tb.PickOnly = true;
            this.sourceLocation_tb.ReadOnly = false;
            this.sourceLocation_tb.Size = new System.Drawing.Size(380, 26);
            this.sourceLocation_tb.TabIndex = 1;
            this.sourceLocation_tb.ValidatorType = Tecnomatix.Engineering.Ui.TxValidatorType.RoboticLocationOperation;
            this.sourceLocation_tb.Picked += new Tecnomatix.Engineering.Ui.TxObjEditBoxCtrl_PickedEventHandler(this.txObjEditBoxCtrl1_Picked);
            this.sourceLocation_tb.Enter += new System.EventHandler(this.txObjEditBoxCtrl1_Enter);
            // 
            // richTextBox_sourceOLP
            // 
            this.richTextBox_sourceOLP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_sourceOLP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox_sourceOLP.Location = new System.Drawing.Point(42, 139);
            this.richTextBox_sourceOLP.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox_sourceOLP.Name = "richTextBox_sourceOLP";
            this.richTextBox_sourceOLP.Size = new System.Drawing.Size(385, 179);
            this.richTextBox_sourceOLP.TabIndex = 3;
            this.richTextBox_sourceOLP.Text = "";
            this.richTextBox_sourceOLP.Enter += new System.EventHandler(this.richTextBox1_Enter);
            // 
            // button_remove
            // 
            this.button_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_remove.Location = new System.Drawing.Point(351, 122);
            this.button_remove.Margin = new System.Windows.Forms.Padding(4);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(34, 20);
            this.button_remove.TabIndex = 4;
            this.button_remove.Text = "-";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(240, 582);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(4);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(86, 23);
            this.button_cancel.TabIndex = 6;
            this.button_cancel.Text = "Close";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox_clearsearch
            // 
            this.pictureBox_clearsearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_clearsearch.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_clearsearch.Image")));
            this.pictureBox_clearsearch.Location = new System.Drawing.Point(318, 565);
            this.pictureBox_clearsearch.Name = "pictureBox_clearsearch";
            this.pictureBox_clearsearch.Size = new System.Drawing.Size(35, 40);
            this.pictureBox_clearsearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_clearsearch.TabIndex = 20;
            this.pictureBox_clearsearch.TabStop = false;
            this.pictureBox_clearsearch.Click += new System.EventHandler(this.pictureBox_clearsearch_Click);
            // 
            // pictureBox_replace
            // 
            this.pictureBox_replace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_replace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_replace.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_replace.Image")));
            this.pictureBox_replace.Location = new System.Drawing.Point(386, 565);
            this.pictureBox_replace.Name = "pictureBox_replace";
            this.pictureBox_replace.Size = new System.Drawing.Size(35, 40);
            this.pictureBox_replace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_replace.TabIndex = 19;
            this.pictureBox_replace.TabStop = false;
            this.pictureBox_replace.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox_apply
            // 
            this.pictureBox_apply.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox_apply.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_apply.BackgroundImage")));
            this.pictureBox_apply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_apply.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_apply.Image")));
            this.pictureBox_apply.Location = new System.Drawing.Point(386, 325);
            this.pictureBox_apply.Name = "pictureBox_apply";
            this.pictureBox_apply.Size = new System.Drawing.Size(35, 40);
            this.pictureBox_apply.TabIndex = 18;
            this.pictureBox_apply.TabStop = false;
            this.pictureBox_apply.Tag = "";
            this.pictureBox_apply.Click += new System.EventHandler(this.pictureBox_apply_Click);
            // 
            // button_addWeldName
            // 
            this.button_addWeldName.Font = new System.Drawing.Font("宋体", 10F);
            this.button_addWeldName.Location = new System.Drawing.Point(318, 82);
            this.button_addWeldName.Margin = new System.Windows.Forms.Padding(4);
            this.button_addWeldName.Name = "button_addWeldName";
            this.button_addWeldName.Size = new System.Drawing.Size(103, 30);
            this.button_addWeldName.TabIndex = 17;
            this.button_addWeldName.Text = "AddWeldName";
            this.button_addWeldName.UseVisualStyleBackColor = true;
            this.button_addWeldName.Click += new System.EventHandler(this.addweldName_Click);
            // 
            // richTextBox_replaceOLP
            // 
            this.richTextBox_replaceOLP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_replaceOLP.Location = new System.Drawing.Point(44, 498);
            this.richTextBox_replaceOLP.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox_replaceOLP.Name = "richTextBox_replaceOLP";
            this.richTextBox_replaceOLP.Size = new System.Drawing.Size(377, 60);
            this.richTextBox_replaceOLP.TabIndex = 15;
            this.richTextBox_replaceOLP.Text = "";
            // 
            // richTextBox_findOLP
            // 
            this.richTextBox_findOLP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_findOLP.Location = new System.Drawing.Point(43, 377);
            this.richTextBox_findOLP.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox_findOLP.Name = "richTextBox_findOLP";
            this.richTextBox_findOLP.Size = new System.Drawing.Size(379, 60);
            this.richTextBox_findOLP.TabIndex = 11;
            this.richTextBox_findOLP.Text = "";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 479);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Replace:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Find:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Source OLP Command :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Target Location :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Source Location :";
            // 
            // button_Add
            // 
            this.button_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Add.Location = new System.Drawing.Point(351, 70);
            this.button_Add.Margin = new System.Windows.Forms.Padding(4);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(34, 20);
            this.button_Add.TabIndex = 7;
            this.button_Add.Text = "+";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox_clearsearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox_replace);
            this.groupBox1.Controls.Add(this.sourceLocation_tb);
            this.groupBox1.Controls.Add(this.pictureBox_apply);
            this.groupBox1.Controls.Add(this.richTextBox_sourceOLP);
            this.groupBox1.Controls.Add(this.button_addWeldName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.richTextBox_replaceOLP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.richTextBox_findOLP);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(1, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 629);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_cancel);
            this.groupBox2.Controls.Add(this.txObjGridCtrl_targetLocation);
            this.groupBox2.Controls.Add(this.button_remove);
            this.groupBox2.Controls.Add(this.button_Add);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(500, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 629);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target";
            // 
            // MypathForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 639);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MypathForm";
            this.Text = "MypathForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MypathForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_clearsearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_replace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_apply)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Tecnomatix.Engineering.Ui.TxObjGridCtrl txObjGridCtrl_targetLocation;
        private Tecnomatix.Engineering.Ui.TxObjEditBoxCtrl sourceLocation_tb;
        private System.Windows.Forms.RichTextBox richTextBox_sourceOLP;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox_findOLP;
        private System.Windows.Forms.RichTextBox richTextBox_replaceOLP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_addWeldName;
        private System.Windows.Forms.PictureBox pictureBox_apply;
        private System.Windows.Forms.PictureBox pictureBox_replace;
        private System.Windows.Forms.PictureBox pictureBox_clearsearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}