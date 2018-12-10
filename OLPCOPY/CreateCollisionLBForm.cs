using EngineeringInternalExtension;
using EngineeringInternalExtension.CommandParameters;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using System;
//using System;
using System.Collections;
using System.Collections.Generic;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Forms;
using Tecnomatix.Engineering;
using Tecnomatix.Engineering.Plc;
using Tecnomatix.Engineering.Ui;
using MSExcel = Microsoft.Office.Interop.Excel;

namespace MinoApi
{
    public partial class MinoCEEForm : TxForm
    {
        [DllImport("user32.dll")]
        static extern int MessageBoxTimeout(IntPtr hwnd, string txt, string caption,
            int wtype, int wlange, int dwtimeout);
        public MinoCEEForm()
        {
            InitializeComponent();
            //TxApplication.ActiveDocument.SimulationPlayer.SimulationStopped+=new TxSimulationPlayer_SimulationStoppedEventHandler(this.SimulationStopped);

                tb_ZoneReq.Text = "_ZoneReqX_";
                tb_ZoneEnable.Text = "_ZoneAnsX_";
                tb_Zonefree.Text = "_ZoneRelX_";
                tb_ZoneclearSAIC.Text = "_ClearOfZoneX";
                tb_ZoneEnterSAIC.Text = "_ClearToEntrZoneX";


        }

        public TxRobot[] Robots;
        Dictionary<string, ITxPlcModule> ModDictionary;
        Dictionary<string, TxPlcLogicBehavior> LBDictionary;
        Dictionary<string, TxRobot> RobDictionary;

        public void SimulationStopped(object sender, TxSimulationPlayer_SimulationStoppedEventArgs args)
        {
            //List<string> strlist = TxApplication.ActiveDocument.SimulationPlayer.GetErrorsAndTraces();
            //int i = 1;
            //listBox1.ResetText();
            //foreach (string str in strlist)
            //{
            //    listBox1.Items.Add(i+"\t"+str);
            //    i++;
            //}
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1.Rows[e.ColumnIndex].Cells[e.RowIndex+1].Value = dataGridView1.Rows[e.ColumnIndex].Cells[e.RowIndex+1];
            int i = 1;

        }


        /// <summary>
        /// Clear form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)//clear form
        {
            if (tabControl1.SelectedIndex==1)
            {
                for (int i = 0; i < dgv_robotzone.Rows.Count; i++)
                {
                    dgv_Robotlist.Rows[i].Cells[0].Style.BackColor = System.Drawing.SystemColors.Control;
                    for (int j = 0; j < dgv_robotzone.Columns.Count; j++)
                    {
                        dgv_robotzone.Rows[i].Cells[j].Value = "";
                    }
                }
            }

        }
        private TxPlcSignalBase FindSig(TxObjectList RobSigs, string SigKeyname, bool input)
        {
            if (input)
            {   //根据INPUT的BOOL值来确定要返回的是FROMROBOT还是TOROBOT。
                foreach (ITxPlcSignal sig in RobSigs)
                {
                    if (sig.Name.Contains(SigKeyname) && sig is TxPlcFromRobotSignal)
                    {
                        return (TxPlcSignalBase)sig;
                    }
                }
            }
            else
            {
                foreach (ITxPlcSignal sig in RobSigs)
                {
                    if (sig.Name.Contains(SigKeyname) && sig is TxPlcToRobotSignal)
                    {
                        return (TxPlcSignalBase)sig;
                    }
                }
            }
            //=========|=========|=========|=========|=========|=========|=========|===
            
            //=========|=========|=========|=========|=========|=========|=========|===
            string str = "";
            if (RobSigs.Count > 0)
            {
                str = RobSigs[0].Name.Split('_')[0];
            }
            MessageBox.Show(str+" 机器人信号表中没有找到信号-" + str + SigKeyname);
            return null;
        }
        /// <summary>
        /// MINO标准zone module表达式生成
        /// </summary>
        /// <param name="Rob1"></param>
        /// <param name="Rob1Sigs"></param>
        /// <param name="Rob2"></param>
        /// <param name="Rob2Sigs"></param>
        /// <param name="Zone"></param>
        /// <param name="p1"></param>
        private void ZoneModlueM(string Rob1, TxObjectList Rob1Sigs, string Rob2, TxObjectList Rob2Sigs, string[] Zone, ITxPlcModule p1)
        {
            TxPlcExpressionBuilder eb1 = new TxPlcExpressionBuilder();
            try
            {
                foreach (string z in Zone)
                {
                    string str1 = tb_ZoneReq.Text.Replace("Rob", Rob1).Replace("X", z);
                    string str2 = tb_Zonefree.Text.Replace("Rob", Rob2).Replace("X", z);
                    string str3 = tb_ZoneEnable.Text.Replace("Rob", Rob2).Replace("X", z);
                    string str4 = tb_ZoneEnable.Text.Replace("Rob", Rob1).Replace("X", z);

                    eb1.Add(FindSig(Rob1Sigs, str1, true));
                    eb1.Add(TxPlcExpressionOperator.And);
                    eb1.Add(FindSig(Rob2Sigs, str2, true));
                    eb1.Add(TxPlcExpressionOperator.And);
                    eb1.Add(TxPlcExpressionOperator.Not);
                    eb1.Add(FindSig(Rob2Sigs, str3, false));
                    p1.AddEntry(FindSig(Rob1Sigs, str4, false), eb1.Expression);
                }
            }
            catch (System.Exception ex)
            {
            	
            }
          

        }
        /// <summary>
        /// SAIC标准Zone module表达式生成
        /// </summary>
        /// <param name="Rob1"></param>
        /// <param name="Rob1Sigs"></param>
        /// <param name="Rob2"></param>
        /// <param name="Rob2Sigs"></param>
        /// <param name="Zone"></param>
        /// <param name="p1"></param>
        private void ZoneModlueS(string Rob1, TxObjectList Rob1Sigs, string Rob2, TxObjectList Rob2Sigs, string[] Zone, ITxPlcModule p1)
        {
            TxPlcExpressionBuilder eb1 = new TxPlcExpressionBuilder();
            try
            {
                foreach (string z in Zone)
                {
                    string str1 = tb_ZoneclearSAIC.Text.Replace("X", z);
                    string str2 = tb_ZoneEnterSAIC.Text.Replace("X", z);

                    eb1.Add(TxPlcExpressionOperator.Not);
                    eb1.Add(FindSig(Rob1Sigs, str1, true));
                    eb1.Add(TxPlcExpressionOperator.And);
                    eb1.Add(TxPlcExpressionOperator.LeftParenthesis);
                    eb1.Add(TxPlcExpressionOperator.Not);
                    eb1.Add(FindSig(Rob2Sigs, str2, false));
                    eb1.Add(TxPlcExpressionOperator.Or);
                    eb1.Add(FindSig(Rob2Sigs, str1, true));
                    eb1.Add(TxPlcExpressionOperator.RightParenthesis);
                    p1.AddEntry(FindSig(Rob1Sigs, str2, false), eb1.Expression);
                }
            }
            catch (System.Exception ex)
            {
            	
            }
           
        }
        /// <summary>
        /// 创建LB
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public TxPlcLogicBehavior CreatNewLB(string name)
        {
            TxTypeFilter objF1 = new TxTypeFilter(typeof(TxCompoundResource));
            TxObjectList objs = TxApplication.ActiveDocument.PhysicalRoot.GetAllDescendants(objF1);
            TxObjectList objs1 = new TxObjectList();
            bool b = false;
            foreach (TxCompoundResource c in objs)
            {
                if (c.Name=="LB_Main")
                {
                    b = true;
                    objs1.Add(c);
                    TxTypeFilter objF2 = new TxTypeFilter(typeof(TxComponent));
                    foreach(ITxObject obj in c.GetAllDescendants(objF2))
                    {
                        if (obj.Name == "LB_"+name+"_Collision")
                        {
                            obj.Delete();
                        }
                    }
                    break;
                }
            }

            if (!b)
            {
                objs1.Add(TxApplication.ActiveDocument.PhysicalRoot.CreateCompoundResource(new TxCompoundResourceCreationData("LB_Main")));
            }


            TxApplication.ActiveSelection.SetItems(objs1);

            ITxObject m_logicResource;
            TxPlcLogicBehavior txPlcLogicBehavior;
            TxNewPartResourceParametersEx txNewPartResourceParametersEx = new TxNewPartResourceParametersEx();
            txNewPartResourceParametersEx.Type = "PmToolPrototype";
            txNewPartResourceParametersEx.TypeNiceName = "LB_" + name + "_Collision";
            TxApplication.CommandsManager.ExecuteCommand("ComponentOperations.NewResource", txNewPartResourceParametersEx);
            m_logicResource = txNewPartResourceParametersEx.CreatedObject;

            TxComponentEx.ConnectComponentToDatabase(m_logicResource);
            TxLogicResourceEx.ConnectLogicResource(m_logicResource);
            TxPlcLogicBehaviorCreationData creationData2 = new TxPlcLogicBehaviorCreationData();
            TxComponent txComponent = m_logicResource as TxComponent;
            txPlcLogicBehavior = txComponent.CreateLogicBehavior(creationData2);
            TxLinearUnitEnumEx linearUnits = TxLinearUnitEnumEx.Milimeter;
            TxAngularUnitEnumEx angularUnits = TxAngularUnitEnumEx.Radian;
            TxUnitsOptions.TxLinearUnit linearUnit = TxApplication.Options.Units.LinearUnit;
            TxUnitsOptions.TxAngularUnit angularUnit = TxApplication.Options.Units.AngularUnit;
            switch (linearUnit)
            {
                case TxUnitsOptions.TxLinearUnit.Millimeter:
                    linearUnits = TxLinearUnitEnumEx.Milimeter;
                    break;
                case TxUnitsOptions.TxLinearUnit.Centimeter:
                    linearUnits = TxLinearUnitEnumEx.Centimeter;
                    break;
                case TxUnitsOptions.TxLinearUnit.Meter:
                    linearUnits = TxLinearUnitEnumEx.Meter;
                    break;
                case TxUnitsOptions.TxLinearUnit.Inch:
                    linearUnits = TxLinearUnitEnumEx.Inch;
                    break;
                case TxUnitsOptions.TxLinearUnit.Foot:
                    linearUnits = TxLinearUnitEnumEx.Foot;
                    break;
            }
            switch (angularUnit)
            {
                case TxUnitsOptions.TxAngularUnit.Degree:
                    angularUnits = TxAngularUnitEnumEx.Degree;
                    break;
                case TxUnitsOptions.TxAngularUnit.Radian:
                    angularUnits = TxAngularUnitEnumEx.Radian;
                    break;
            }
            TxLogicBehaviorEx.SetLogicBehaviorUnits(txPlcLogicBehavior, linearUnits, angularUnits);
            return txPlcLogicBehavior;

        }

        private ITxPlcLogicBehaviorEntry SegEn(TxPlcLogicBehavior LB, TxPlcSignalBase sig1)
        {
            TxPlcLogicBehaviorEntryCreationData en1 = new TxPlcLogicBehaviorEntryCreationData(sig1.Name);
            en1.HardwareType = (TxPlcHardwareType)sig1.DataType;
            ITxPlcLogicBehaviorEntry e1 = LB.CreateEntry(en1);
            if (sig1 != null)
            {
                e1.ConnectSignal(sig1);
            }
            return e1;
        }

        private ITxPlcLogicBehaviorExit SegEx(TxPlcLogicBehavior LB,TxPlcSignalBase sig1, TxPlcExpression expression)
        {
            TxPlcLogicBehaviorExitCreationData ex1 = new TxPlcLogicBehaviorExitCreationData();
            ex1.Name = sig1.Name;
            ex1.Expression = expression;
            ex1.HardwareType = TxPlcHardwareType.Bool;
            ITxPlcLogicBehaviorExit ex = LB.CreateExit(ex1);

            if (sig1 != null && !sig1.IsConnectedToLBExit)
            {
                ex.ConnectSignal(sig1);
            }
            return ex;
        }
        private ITxPlcLogicBehaviorParameter SegPa(TxPlcLogicBehavior LB, string paName, TxPlcExpression expression)
        {
            TxPlcLogicBehaviorInternalExitParameterCreationData exp1 = new TxPlcLogicBehaviorInternalExitParameterCreationData();
            exp1.Name = paName;
            exp1.Expression = expression;
            exp1.HardwareType = TxPlcHardwareType.Bool;
            ITxPlcLogicBehaviorParameter pa = LB.CreateParameter(exp1);
            return pa;
        }

       
        private void ZoneLBM(string Rob1, TxObjectList Rob1Sigs, string Rob2, TxObjectList Rob2Sigs, string[] Zone, TxPlcLogicBehavior LB)
        {
             
            TxPlcExpressionBuilder eb1 = new TxPlcExpressionBuilder();
            try
            {
                foreach (string z in Zone)
                {
                    string str1 = tb_ZoneReq.Text.Replace("Rob", Rob1).Replace("X", z);
                    string str2 = tb_Zonefree.Text.Replace("Rob", Rob2).Replace("X", z);
                    string str3 = tb_ZoneEnable.Text.Replace("Rob", Rob2).Replace("X", z);
                    string str4 = tb_ZoneEnable.Text.Replace("Rob", Rob1).Replace("X", z);


                    ITxPlcLogicBehaviorEntry en1 = SegEn(LB, FindSig(Rob1Sigs, str1, true));
                    ITxPlcLogicBehaviorEntry en2 = SegEn(LB, FindSig(Rob2Sigs, str2, true));
                    ITxPlcLogicBehaviorEntry en3 = SegEn(LB, FindSig(Rob2Sigs, str3, false));

                    eb1.Add(en1);
                    eb1.Add(TxPlcExpressionOperator.And);
                    eb1.Add(en2);
                    eb1.Add(TxPlcExpressionOperator.And);
                    eb1.Add(TxPlcExpressionOperator.Not);
                    eb1.Add(en3);

                    ITxPlcLogicBehaviorExit ex1 = SegEx(LB, FindSig(Rob1Sigs, str4, false),eb1.Expression);
                }
            }
            catch (System.Exception ex)
            {

            }


        }

        private void ZoneLBS(string Rob1, TxObjectList Rob1Sigs, string Rob2, TxObjectList Rob2Sigs, string[] Zone, TxPlcLogicBehavior LB)
        {

            TxPlcExpressionBuilder eb1 = new TxPlcExpressionBuilder();
            try
            {
                foreach (string z in Zone)
                {

                    string str1 = tb_ZoneclearSAIC.Text.Replace("X", z);
                    string str2 = tb_ZoneEnterSAIC.Text.Replace("X", z);

                    ITxPlcLogicBehaviorEntry en1 = SegEn(LB, FindSig(Rob1Sigs, str1, true));
                    ITxPlcLogicBehaviorEntry en2 = SegEn(LB, FindSig(Rob2Sigs, str2, true));
                    ITxPlcLogicBehaviorEntry en3 = SegEn(LB, FindSig(Rob2Sigs, str1, true));
                    //Not Rob1ClearZone AND (NOT Rob2Enterzone or Rob2ClearZone)
                    eb1.Add(TxPlcExpressionOperator.Not);
                    eb1.Add(en1);
                    eb1.Add(TxPlcExpressionOperator.And);
                    eb1.Add(TxPlcExpressionOperator.LeftParenthesis);
                    eb1.Add(TxPlcExpressionOperator.Not);
                    eb1.Add(en2);
                    eb1.Add(TxPlcExpressionOperator.Or);
                    eb1.Add(en3);
                    eb1.Add(TxPlcExpressionOperator.RightParenthesis);

                    ITxPlcLogicBehaviorExit ex1 = SegEx(LB, FindSig(Rob1Sigs, str2, false), eb1.Expression);
                }
            }
            catch (System.Exception ex)
            {

            }


        }
        /// <summary>
        /// 点击生成干涉区LB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            TxApplication.ActiveUndoManager.StartTransaction();
            TxPlcProgram pr = TxApplication.ActiveDocument.PlcProgramRoot.CurrentPlcProgram;
            RobDictionary = new Dictionary<string, TxRobot>();
            ModDictionary = new Dictionary<string, ITxPlcModule>();
            LBDictionary = new Dictionary<string, TxPlcLogicBehavior>();

            foreach (TxRobot r in Robots)
            {
                RobDictionary.Add(r.Name, r);
                //ModDictionary.Add(r.Name, pr.CreateModule(new TxPlcModuleCreationData(r.Name)));
                LBDictionary.Add(r.Name, CreatNewLB(r.Name));
            }


            for (int i = 0; i < dgv_Robotlist.Rows.Count; i++)
            {
                if (dgv_Robotlist.Rows[i].Cells[0].Style.BackColor == System.Drawing.SystemColors.Highlight)
                {
                    string rob1name = dgv_Robotlist.Rows[i].Cells[0].Value.ToString();

                    for (int j = 0; j < dgv_robotzone.Columns.Count; j++)
                    {
                        string rob2name = dgv_robotzone.Columns[j].HeaderText;
                        object zone = dgv_robotzone.Rows[i].Cells[j].Value;
                        if (zone != null)
                        {
                            if (zone != "")
                            {
                                if (rb_minokuka.Checked == true || rb_minofanuc.Checked == true)
                                {
                                    //ZoneModlueM(rob1name, RobDictionary[rob1name].Signals, rob2name, RobDictionary[rob2name].Signals, zone.ToString().Split('.'), ModDictionary["Zone"]);

                                    ZoneLBM(rob1name, RobDictionary[rob1name].Signals, rob2name, RobDictionary[rob2name].Signals, zone.ToString().Split('.'), LBDictionary[rob1name]);
                                } 
                                else
                                {
                                    //ZoneModlueS(rob1name, RobDictionary[rob1name].Signals, rob2name, RobDictionary[rob2name].Signals, zone.ToString().Split('.'), ModDictionary["Zone"]);

                                    ZoneLBS(rob1name, RobDictionary[rob1name].Signals, rob2name, RobDictionary[rob2name].Signals, zone.ToString().Split('.'), LBDictionary[rob1name]);
                                }
                               
                            }
                        }
                    }
                }
            }

            if (rb_minokuka.Checked == true || rb_minofanuc.Checked == true)
            {
   
            }
            else
            {
    
            }
            TxApplication.ActiveUndoManager.EndTransaction();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            this.Dispose(true);
        }
        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rb_minokuka.Checked == true)
            {
                rb_saicFanuc.Checked = false;
                rb_minofanuc.Checked = false;
            }

            tb_ZoneReq.ReadOnly = false;
            tb_ZoneEnable.ReadOnly = false;
            tb_Zonefree.ReadOnly = false;
            tb_ZoneEnterSAIC.ReadOnly = true;
            tb_ZoneclearSAIC.ReadOnly = true;



        }
        private void radioButton3_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rb_minofanuc.Checked==true)
            {
                rb_minokuka.Checked = false;
                rb_saicFanuc.Checked = false;
            }

            tb_ZoneReq.ReadOnly = false;
            tb_ZoneEnable.ReadOnly = false;
            tb_Zonefree.ReadOnly = false;
            tb_ZoneEnterSAIC.ReadOnly = true;
            tb_ZoneclearSAIC.ReadOnly = true;

        }

        private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rb_saicFanuc.Checked == true)
            {
                rb_minokuka.Checked = false;
                rb_minofanuc.Checked = false;
            }
            tb_ZoneReq.ReadOnly = true;
            tb_ZoneEnable.ReadOnly = true;
            tb_Zonefree.ReadOnly = true;
            tb_ZoneEnterSAIC.ReadOnly = false;
            tb_ZoneclearSAIC.ReadOnly = false;

           
        }
        /// <summary>
        /// 配置文件导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, System.EventArgs e)
        {
            if (Robots.Length == 0)
            {
                MessageBox.Show("There is no Robots,Please load a correct study!", "Error");
                return;
            }
            string filename = @"C:\temp\dqq.csv";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv (*.csv)|*.csv";
            ofd.FileName = @"C:\temp\dqq.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                
                filename = ofd.FileName;
                System.IO.StreamReader sr = new System.IO.StreamReader(filename);
                string strLine = sr.ReadLine();
                List<string> AllRowStrList = new List<string>();

                int i = 0, r = 0;
                while (strLine != null)
                {
                    string[] str = strLine.Split(',');
                    AllRowStrList.Add(strLine);

                    if (str[0].Contains( "collision"))
                    {
                        for (int j = 1; j < dgv_Robotlist.Rows.Count+1; j++)
                        {
                            dgv_robotzone.Rows[i].Cells[j-1].Value = str[j];
                            if (str[j] != "")
                            {
                                dgv_Robotlist.Rows[i].Cells[0].Style.BackColor = System.Drawing.SystemColors.Highlight;
                            }
                        }
                        i = i + 1;
                    }
                    
                    strLine = sr.ReadLine();
                }
                //获取文件抬头处的干涉区信号关键字，规定MINO标准2-4行记录干涉区信号的关键字
                if (rb_minofanuc.Checked|rb_minokuka.Checked)
                {
                    if (AllRowStrList[1] != null)
                    {
                        string[] zonestr = AllRowStrList[1].Split(',');
                        tb_ZoneReq.Text = zonestr[1];

                    }
                    if (AllRowStrList[2] != null)
                    {
                        string[] zonestr = AllRowStrList[2].Split(',');
                        tb_ZoneEnable.Text = zonestr[1];

                    }
                    if (AllRowStrList[3] != null)
                    {
                        string[] zonestr = AllRowStrList[3].Split(',');
                        tb_Zonefree.Text = zonestr[1];

                    }
                }
                else if (rb_saicFanuc.Checked)
                {
                    if (AllRowStrList[1] != null)
                    {
                        string[] zonestr = AllRowStrList[1].Split(',');
                        tb_ZoneclearSAIC.Text  = zonestr[1];

                    }
                    if (AllRowStrList[2] != null)
                    {
                        string[] zonestr = AllRowStrList[2].Split(',');
                        tb_ZoneEnterSAIC.Text  = zonestr[1];

                    }
                }
                


            }
        }
        /// <summary>
        /// 配置文件导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, System.EventArgs e)
        {
            if (Robots.Length==0)
            {
                MessageBox.Show("There is no Robots,Please load a correct study!", "Error");
                return;
            }
            string filename = @"C:\temp\MinoCEEExport_" + DateTime.Now.ToString().Replace(":", "").Replace("/", "").Replace(" ", "") + ".csv";
            System.IO.StreamWriter sw = new System.IO.StreamWriter(filename);
            string str1="";
            string strcol = "";

            sw.WriteLine(TxApplication.ActiveDocument.CurrentStudy.Caption);

            if (rb_minokuka.Checked || rb_minofanuc.Checked)
            {
                str1 = "Zone Req(I): ," + tb_ZoneReq.Text + "\r\n" + "Zone Enable(Q): ," + tb_ZoneEnable.Text + "\r\n"
                    + "Area Free(I): ," + tb_Zonefree.Text + "\r\n"+",";
                foreach (TxRobot  robot in Robots)
                {
                    str1 = str1 + robot.Name + ",";
                }
             
                sw.WriteLine(str1);
            }
            else if (rb_saicFanuc.Checked)
            {
                str1 = "ClearOfZone(I): ," + tb_ZoneclearSAIC.Text + "\r\n" + "ClearToEntrZone(Q): ," + tb_ZoneEnterSAIC.Text + "\r\n" + ",";
                foreach (TxRobot robot in Robots)
                {
                    str1 = str1 + robot.Name + ",";
                }

                sw.WriteLine(str1);
            }


            for (int i = 0; i < dgv_robotzone.RowCount;i++ )
            {
                strcol = "";
                for (int j=0;j<dgv_robotzone.ColumnCount;j++)
                {
                    strcol = strcol + dgv_robotzone.Rows[i].Cells[j].Value + ",";
                }
                sw.WriteLine("collision:"+dgv_Robotlist.Rows[i].Cells[0].Value.ToString()+","+strcol);
            }


            sw.Close();
            MessageBoxTimeout(IntPtr.Zero, "数据已导出-"+filename, "导出完成", 64, 0, 2000);
        }

        private void dataGridView4_RowsAdded(object sender, System.Windows.Forms.DataGridViewRowsAddedEventArgs e)
        {
            //dataGridView8.Rows.Add();
        }

        private void dataGridView4_RowsRemoved(object sender, System.Windows.Forms.DataGridViewRowsRemovedEventArgs e)
        {
            //if (e.RowIndex >= 0 && dataGridView8.Rows.Count>0)
            //{
            //dataGridView8.Rows.RemoveAt(e.RowIndex);
            //}
        }

        private void dataGridView4_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            //if (dgv_RobotSegExp.Rows[e.RowIndex].Cells[0] != null && dgv_RobotSegExp.Rows[e.RowIndex].Cells[0].Value != "")
            //{
            //    if (dgv_RobotSegExp.Rows[e.RowIndex].Cells[1] != null && dgv_RobotSegExp.Rows[e.RowIndex].Cells[1].Value == "0")
            //    {
            //        dgv_RobotSegExp.Rows.RemoveAt(e.RowIndex);
            //    }
            //}
        }

        private void dgv_Robotlist_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == e.RowIndex)
            {   //行列相等，内容为空－对角线
                dgv_robotzone.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            }
            else
            {   //对角线对称的内容相等
                dgv_robotzone.Rows[e.ColumnIndex].Cells[e.RowIndex].Value = dgv_robotzone.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if ((dgv_robotzone.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != "")
                    && (dgv_robotzone.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null))
                {
                    dgv_Robotlist.Rows[e.RowIndex].Cells[0].Style.BackColor = System.Drawing.SystemColors.Highlight;
                    dgv_Robotlist.Rows[e.ColumnIndex].Cells[0].Style.BackColor = System.Drawing.SystemColors.Highlight;
                }
            }
        }
    }
}
