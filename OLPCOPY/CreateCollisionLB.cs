using System.Resources;
using System.Windows.Forms;
using Tecnomatix.Engineering;
using System.Collections.Generic;
using System.Linq;

namespace RobotOLPTool
{
    public class CreateCollisionLB : TxButtonCommand
    {
        public CreateCollisionLB()
        {

        }

     
        
        public override string Bitmap
        {
            get
            {
                return "CMDbmp.CreateCollisionLB.bmp";
            }
        }
        
        public override string LargeBitmap
        {
            get
            {
                return "CMDbmp.CreateCollisionLB.bmp";
            }
        }

        public override string Name
        {
            get
            {
                return "_CreateCollisionLB";
            }
        }

        public override string Category
        {
            get
            {
                return "Create Collision LB of Robots";
            }
        }
        public override void Execute(object cmdParams)
        {
            //if (!MinoApi.LicenseCheck.LicenceCheck())// 20180427
            //{
            //    return;
            //}

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
                    rz.rb_saicFanuc.Checked = true;
                }
                else
                {
                    rz.rb_minokuka.Checked = true;
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
            rz.dgv_Robotlist.Columns[0].HeaderCell.Style = dataGridViewCellStyle1;

            //初始化Segment表达式列表
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Menu;
            //DataGridViewComboBoxColumn col = rz.dgv_RobotSegExp.Columns[0] as DataGridViewComboBoxColumn; 
            
            //根据当前项目的机器人列表生成机器人矩阵表
                foreach (TxRobot robot in Roblist)
                {
                rz.Robots[i] = robot;
                DataGridViewTextBoxColumn  dc= new System.Windows.Forms.DataGridViewTextBoxColumn();
                dc.HeaderText = robot.Name;
                dc.Name = "Column" +i+1;
                dc.HeaderCell.Style = dataGridViewCellStyle1;
                dc.DefaultCellStyle = dataGridViewCellStyle1;
                dc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

                rz.dgv_robotzone.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {dc});

                rz.dgv_Robotlist.Rows.Add();
                rz.dgv_Robotlist.Rows[i].Cells[0].Value = robot.Name;
                rz.dgv_robotzone.Rows.Add();
                rz.dgv_robotzone.Rows[i].Cells[i].Style = dataGridViewCellStyle2;

 
                //col.Items.Add(robot.Name);
              
                i = i + 1;
            }

            TxApplication.ActiveUndoManager.EndTransaction();
            rz.Show();
        }

       
    }
}
