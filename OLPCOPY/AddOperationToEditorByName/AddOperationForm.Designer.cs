namespace OLPCOPY.AddOperationToEditorByName
{
    partial class AddOperationForm
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
            this.OPName_lb = new System.Windows.Forms.Label();
            this.opname_tb = new Tecnomatix.Engineering.Ui.TxObjComboBoxCtrl();
            this.AddToEditor_bt = new System.Windows.Forms.Button();
            this.Close_bt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OPName_lb
            // 
            this.OPName_lb.AutoSize = true;
            this.OPName_lb.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OPName_lb.Location = new System.Drawing.Point(12, 24);
            this.OPName_lb.Name = "OPName_lb";
            this.OPName_lb.Size = new System.Drawing.Size(113, 17);
            this.OPName_lb.TabIndex = 0;
            this.OPName_lb.Text = "Operation Name :";
            // 
            // opname_tb
            // 
            this.opname_tb.AutoSize = true;
            this.opname_tb.DropDownHeight = 106;
            this.opname_tb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.opname_tb.ListenToPick = true;
            this.opname_tb.Location = new System.Drawing.Point(132, 24);
            this.opname_tb.Name = "opname_tb";
            this.opname_tb.Object = null;
            this.opname_tb.PickLevel = Tecnomatix.Engineering.Ui.TxPickLevel.Component;
            this.opname_tb.Size = new System.Drawing.Size(126, 23);
            this.opname_tb.TabIndex = 1;
            this.opname_tb.ValidatorType = Tecnomatix.Engineering.Ui.TxValidatorType.Operation;
            this.opname_tb.Picked += new Tecnomatix.Engineering.Ui.TxObjComboBoxCtrl_PickedEventHandler(this.opname_tb_Picked);
            // 
            // AddToEditor_bt
            // 
            this.AddToEditor_bt.Location = new System.Drawing.Point(96, 79);
            this.AddToEditor_bt.Name = "AddToEditor_bt";
            this.AddToEditor_bt.Size = new System.Drawing.Size(75, 23);
            this.AddToEditor_bt.TabIndex = 2;
            this.AddToEditor_bt.Text = "Apply";
            this.AddToEditor_bt.UseVisualStyleBackColor = true;
            this.AddToEditor_bt.Click += new System.EventHandler(this.AddToEditor_bt_Click);
            // 
            // Close_bt
            // 
            this.Close_bt.Location = new System.Drawing.Point(177, 79);
            this.Close_bt.Name = "Close_bt";
            this.Close_bt.Size = new System.Drawing.Size(75, 23);
            this.Close_bt.TabIndex = 3;
            this.Close_bt.Text = "Close";
            this.Close_bt.UseVisualStyleBackColor = true;
            this.Close_bt.Click += new System.EventHandler(this.Close_bt_Click);
            // 
            // AddOperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 113);
            this.Controls.Add(this.Close_bt);
            this.Controls.Add(this.AddToEditor_bt);
            this.Controls.Add(this.opname_tb);
            this.Controls.Add(this.OPName_lb);
            this.Name = "AddOperationForm";
            this.Text = "Add Operation by Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label OPName_lb;
        private Tecnomatix.Engineering.Ui.TxObjComboBoxCtrl opname_tb;
        private System.Windows.Forms.Button AddToEditor_bt;
        private System.Windows.Forms.Button Close_bt;
    }
}