using System.Resources;
using System.Windows.Forms;
using Tecnomatix.Engineering;
using System.Collections.Generic;
using System.Linq;

namespace MinoApi
{
    public class MinoCEECmd : TxButtonCommand
    {
        public MinoCEECmd()
        {
        }

        public override string Name
        {
            get
            {
                return GetResourceManager().GetString("CMD_NAME_MinoCEE");

            }
        }

        public override string Category
        {
            get
            {
                return GetResourceManager().GetString("CMD_CATEGORY");
            }
        }

        public override string Description
        {
            get
            {
                return GetResourceManager().GetString("CMD_Description_MinoCEE");
            }
        }
        
        public override string Bitmap
        {
            get
            {
                return "BMP.MinoCEECmd.bmp";
            }
        }
        
        public override string LargeBitmap
        {
            get
            {
                return "BMP.MinoCEECmd.bmp";
            }
        }

        public override void Execute(object cmdParams)
        {
            if (!MinoApi.LicenseCheck.LicenceCheck())// 20180427
            {
                return;
            }

            //get the root of physical//all physical
            TxPhysicalRoot physRoot = TxApplication.ActiveDocument.PhysicalRoot;
            //need filter.robot
            ITxTypeFilter objFilter = new TxTypeFilter(typeof(TxRobot));
            //return all descendants by filter
            TxObjectList objst = physRoot.GetAllDescendants(objFilter);
            //
            TxApplication.ActiveUndoManager.StartTransaction();

            MinoApi.MinoCEEForm rz = new MinoApi.MinoCEEForm();
            //
            rz.Robots = new TxRobot[objst.Count];

            if (objst.Count>0)
            {
                TxRobot tr = objst[0] as TxRobot;
                if (tr.Controller.Name == "Fanuc-Rj")
                {
                    rz.radioButton2.Checked = true;
                }
                else
                {
                    rz.radioButton1.Checked = true;
                }
            }

             List<TxRobot> Roblist = new List<TxRobot>();
                foreach (TxRobot robot in objst)
                {
                    Roblist.Add(robot);
                }
                Roblist = Roblist.OrderBy(s => s.Name).ToList();

            int c = objst.Count,i=0;

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F);
            rz.dataGridView3.Columns[0].HeaderCell.Style = dataGridViewCellStyle1;

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Menu;
            DataGridViewComboBoxColumn col = rz.dataGridView2.Columns[0] as DataGridViewComboBoxColumn;        
                foreach (TxRobot robot in Roblist)
            {
                rz.Robots[i] = robot;
                DataGridViewTextBoxColumn  dc= new System.Windows.Forms.DataGridViewTextBoxColumn();
                dc.HeaderText = robot.Name;
                dc.Name = "Column" +i+1;
                dc.HeaderCell.Style = dataGridViewCellStyle1;
                dc.DefaultCellStyle = dataGridViewCellStyle1;
                dc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

                rz.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            dc});

                rz.dataGridView3.Rows.Add();
                rz.dataGridView3.Rows[i].Cells[0].Value = robot.Name;
                rz.dataGridView1.Rows.Add();
                rz.dataGridView1.Rows[i].Cells[i].Style = dataGridViewCellStyle2;

                DataGridViewTextBoxColumn dc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                dc1.HeaderText = robot.Name;
                dc1.Name = "Column" + i + 1;
                dc1.HeaderCell.Style = dataGridViewCellStyle1;
                dc1.DefaultCellStyle = dataGridViewCellStyle1;
                dc1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
                rz.dataGridView8.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            dc1});
                col.Items.Add(robot.Name);
                i = i + 1;
            }

            TxApplication.ActiveUndoManager.EndTransaction();
            rz.dataGridView8.Rows.Add();
            rz.Show();
        }

        private ResourceManager GetResourceManager()
        {
            return new ResourceManager("MinoApi.StringTable", GetType().Assembly);
        }
    }
}
