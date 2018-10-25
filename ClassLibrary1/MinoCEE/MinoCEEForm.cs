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
using MSExcel = Microsoft.Office.Interop.Excel;

namespace MinoApi
{
    public partial class MinoCEEForm : Form
    {
        [DllImport("user32.dll")]
        static extern int MessageBoxTimeout(IntPtr hwnd, string txt, string caption,
            int wtype, int wlange, int dwtimeout);
        public MinoCEEForm()
        {
            InitializeComponent();
            //TxApplication.ActiveDocument.SimulationPlayer.SimulationStopped+=new TxSimulationPlayer_SimulationStoppedEventHandler(this.SimulationStopped);
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex  == e.RowIndex )
            {   //行列相等，内容为空－对角线
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            }
            else
            {   //对角线对称的内容相等
                dataGridView1.Rows[e.ColumnIndex ].Cells[e.RowIndex ].Value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if ((dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != "")
                    && (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null))
                {
                    dataGridView3.Rows[e.RowIndex].Cells[0].Style.BackColor = System.Drawing.SystemColors.Highlight;
                    dataGridView3.Rows[e.ColumnIndex].Cells[0].Style.BackColor = System.Drawing.SystemColors.Highlight;
                }
            }

            //if (e.ColumnIndex - 1 == e.RowIndex && e.RowIndex + 1 == e.ColumnIndex)
            //{
            //    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            //}
            //else
            //{
            //    dataGridView1.Rows[e.ColumnIndex - 1].Cells[e.RowIndex + 1].Value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            //    if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != "")
            //    {
            //        dataGridView1.Rows[e.RowIndex].Cells[0].Style.BackColor = System.Drawing.SystemColors.Highlight;
            //        dataGridView1.Rows[e.ColumnIndex - 1].Cells[0].Style.BackColor = System.Drawing.SystemColors.Highlight;
            //    }
            //}
        }

        private void button1_Click(object sender, EventArgs e)//clear form
        {
            if (tabControl1.SelectedIndex==1)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView3.Rows[i].Cells[0].Style.BackColor = System.Drawing.SystemColors.Control;
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = "";
                    }
                }
            }
            else if (tabControl1.SelectedIndex == 2)//C#中可以不是ELSE结束
            {
                for (int i = 0; i < dataGridView8.Rows.Count; i++)
                {
                    dataGridView8.Rows.Clear();
                    dataGridView2.Rows.Clear();
                }
            }
        }


        private TxPlcSignalBase FindSig(TxObjectList RobSigs, string Signame, bool input)
        {
            if (input)//无论INPUT值，无论SIG是FROMROBOT还是TOROBOT，返回都是SIG？？？，那么IF、内嵌IF意义何在
            {   //根据INPUT的BOOL值来确定要返回的是FROMROBOT还是TOROBOT。
                foreach (ITxPlcSignal sig in RobSigs)
                {
                    if (sig.Name.Contains(Signame) && sig is TxPlcFromRobotSignal)
                    {
                        return (TxPlcSignalBase)sig;
                    }
                }
            }
            else
            {
                foreach (ITxPlcSignal sig in RobSigs)
                {
                    if (sig.Name.Contains(Signame) && sig is TxPlcToRobotSignal)
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
            MessageBox.Show(str+" 机器人信号表中没有找到信号-" + str + Signame);
            return null;
        }

        private void ZoneModlueM(string Rob1, TxObjectList Rob1Sigs, string Rob2, TxObjectList Rob2Sigs, string[] Zone, ITxPlcModule p1)
        {
            TxPlcExpressionBuilder eb1 = new TxPlcExpressionBuilder();
            try
            {
                foreach (string z in Zone)
                {
                    string str1 = textBox1.Text.Replace("Rob", Rob1).Replace("X", z);
                    string str2 = textBox3.Text.Replace("Rob", Rob2).Replace("X", z);
                    string str3 = textBox2.Text.Replace("Rob", Rob2).Replace("X", z);
                    string str4 = textBox2.Text.Replace("Rob", Rob1).Replace("X", z);

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
        private void ZoneModlueS(string Rob1, TxObjectList Rob1Sigs, string Rob2, TxObjectList Rob2Sigs, string[] Zone, ITxPlcModule p1)
        {
            TxPlcExpressionBuilder eb1 = new TxPlcExpressionBuilder();
            try
            {
                foreach (string z in Zone)
                {
                    string str1 = textBox12.Text.Replace("X", z);
                    string str2 = textBox11.Text.Replace("X", z);

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

        private void SegModlueM()
        {
            TxPlcExpressionBuilder eb1 = new TxPlcExpressionBuilder();
            try
            {
                for (int i = 0; i < dataGridView8.Rows.Count; i++)//TxPlcExpressionOperator.Add
                {

                    if (dataGridView2.Rows[i].Cells[0].Value != null && dataGridView2.Rows[i].Cells[1].Value != null)
                    {
                        string rob1name = dataGridView2.Rows[i].Cells[0].Value.ToString();
                        string strseg1 = dataGridView2.Rows[i].Cells[1].Value.ToString();
                        string str1 = textBox4.Text;//cont
                        string str2 = textBox5.Text;//seg
                        string str3 = textBox6.Text;//req
                        TxRobot r1 = RobDictionary[rob1name];


                        eb1.Add(FindSig(r1.Signals, str3.Replace("Rob", rob1name), true));
                        eb1.Add(TxPlcExpressionOperator.And);
                        //eb1.Add(TxPlcExpressionOperator.LeftParenthesis);
                        eb1.Add(TxPlcExpressionOperator.LeftParenthesis);

                        int c = 0;
                        if (int.TryParse(strseg1, out c))
                        {
                            TxPlcValue pv = new TxPlcValue();
                            pv.ByteValue = (ushort)c;
                            eb1.Add(TxPlcExpressionOperator.LeftParenthesis);
                            eb1.Add(FindSig(r1.Signals, str2.Replace("Rob", rob1name), true));
                            eb1.Add(TxPlcExpressionOperator.IsEqualTo);
                            eb1.Add(TxPlcSignalDataType.Byte, pv);
                            eb1.Add(TxPlcExpressionOperator.RightParenthesis);
                            eb1.Add(TxPlcExpressionOperator.And);
                        }

                        for (int j = 0; j < dataGridView8.Columns.Count; j++)
                        {
                            string rob2name = dataGridView8.Columns[j].HeaderText;
                            if (dataGridView8.Rows[i].Cells[j].Value != null)
                            {

                                string strseg2 = dataGridView8.Rows[i].Cells[j].Value.ToString();

                                if (j > 0)
                                {
                                    eb1.Add(TxPlcExpressionOperator.And);
                                }
                                eb1.Add(TxPlcExpressionOperator.LeftParenthesis);
                                eb1.Add(FindSig(Robots[j].Signals, str2.Replace("Rob", rob2name), true));
                                eb1.Add(TxPlcExpressionOperator.IsEqualTo);
                                int c1 = 0;
                                if (int.TryParse(strseg2, out c1))
                                {
                                    TxPlcValue pv = new TxPlcValue();
                                    pv.ByteValue = (ushort)c1;
                                    eb1.Add(TxPlcSignalDataType.Byte, pv);
                                    eb1.Add(TxPlcExpressionOperator.RightParenthesis);
                                }
                            }
                        }

                        eb1.Add(TxPlcExpressionOperator.RightParenthesis);

                        if (string.Equals(rob1name, dataGridView2.Rows[i + 1].Cells[0].Value))
                        {
                            eb1.Add(TxPlcExpressionOperator.Or);
                        }
                        else
                        {
                            ModDictionary[rob1name].AddEntry(FindSig(r1.Signals, str1.Replace("Rob", rob1name), false), eb1.Expression);
                            eb1 = new TxPlcExpressionBuilder();
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
            	
            }
        }
        private void SegModlueS()
        {
            TxPlcExpressionBuilder eb1 = new TxPlcExpressionBuilder();
            try
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[0].Value != null && dataGridView2.Rows[i].Cells[1].Value != null)
                    {
                        string rob1name = dataGridView2.Rows[i].Cells[0].Value.ToString();
                        string strseg1 = dataGridView2.Rows[i].Cells[1].Value.ToString();
                        string str1 = textBox9.Text;
                        string str2 = textBox10.Text;
                        string str3 = textBox8.Text;
                        TxRobot r1 = RobDictionary[rob1name];


                        eb1.Add(FindSig(r1.Signals, str3.Replace("Rob", rob1name), true));

                        eb1.Add(TxPlcExpressionOperator.And);
                        //eb1.Add(TxPlcExpressionOperator.LeftParenthesis);
                        eb1.Add(TxPlcExpressionOperator.LeftParenthesis);

                        int c = 0;
                        if (int.TryParse(strseg1, out c))
                        {
                            TxPlcValue pv = new TxPlcValue();
                            pv.ByteValue = (ushort)c;
                            eb1.Add(TxPlcExpressionOperator.LeftParenthesis);
                            eb1.Add(FindSig(r1.Signals, str2.Replace("Rob", rob1name), true));
                            eb1.Add(TxPlcExpressionOperator.IsEqualTo);
                            eb1.Add(TxPlcSignalDataType.Byte, pv);
                            eb1.Add(TxPlcExpressionOperator.RightParenthesis);
                            eb1.Add(TxPlcExpressionOperator.And);
                        }

                        for (int j = 0; j < dataGridView8.Columns.Count; j++)
                        {
                            string rob2name = dataGridView8.Columns[j].HeaderText;
                            if (dataGridView8.Rows[i].Cells[j].Value != null)
                            {
                                if (j > 0)
                                {
                                    eb1.Add(TxPlcExpressionOperator.And);
                                }
                                string strseg2 = dataGridView8.Rows[i].Cells[j].Value.ToString();
                                eb1.Add(TxPlcExpressionOperator.LeftParenthesis);
                                eb1.Add(FindSig(Robots[j].Signals, str2.Replace("Rob", rob2name), true));
                                eb1.Add(TxPlcExpressionOperator.IsEqualTo);
                                int c1 = 0;
                                if (int.TryParse(strseg2, out c1))
                                {
                                    TxPlcValue pv = new TxPlcValue();
                                    pv.ByteValue = (ushort)c1;
                                    eb1.Add(TxPlcSignalDataType.Byte, pv);
                                    eb1.Add(TxPlcExpressionOperator.RightParenthesis);
                                }
                            }
                        }

                        //eb1.Add(TxPlcExpressionOperator.RightParenthesis);
                        eb1.Add(TxPlcExpressionOperator.RightParenthesis);

                        if (string.Equals(rob1name, dataGridView2.Rows[i + 1].Cells[0].Value))
                        {
                            eb1.Add(TxPlcExpressionOperator.Or);
                        }
                        else
                        {
                            ITxPlcSignal sig=FindSig(r1.Signals, str1.Replace("Rob", rob1name), false);
                            ITxPlcModuleEntry pe= ModDictionary[rob1name].AddEntry(sig, eb1.Expression);
                            eb1 = new TxPlcExpressionBuilder();
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
            	
            }
          
        }

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
                        if (obj.Name == "LB_"+name)
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

            TxApplication.ActiveSelection.Clear();
            TxApplication.ActiveSelection.AddItems(objs1);

            ITxObject m_logicResource;
            TxPlcLogicBehavior txPlcLogicBehavior;
            TxNewPartResourceParametersEx txNewPartResourceParametersEx = new TxNewPartResourceParametersEx();
            txNewPartResourceParametersEx.Type = "PmToolPrototype";
            txNewPartResourceParametersEx.TypeNiceName = "LB_" + name;
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

        private void SegLBM()
        {
            string str1 = textBox4.Text;//ok
            string str2 = textBox5.Text;//seg
            string str3 = textBox6.Text;//req

           TxPlcLogicBehavior LB= CreatNewLB("RobSeg");
            Dictionary<string, ITxPlcLogicBehaviorEntry> LBEnDic = new Dictionary<string, ITxPlcLogicBehaviorEntry>();
            Dictionary<string, ITxPlcLogicBehaviorParameter> LBPaDic = new Dictionary<string, ITxPlcLogicBehaviorParameter>();
            Dictionary<string, TxPlcExpressionBuilder> ExbuDic = new Dictionary<string, TxPlcExpressionBuilder>();
            Dictionary<string, TxPlcExpressionBuilder> ExbuDic1 = new Dictionary<string, TxPlcExpressionBuilder>();

            //try
            //{
                for (int i = 0; i < Robots.Length; i++)
                {
                    TxRobot r1 = Robots[i];
                    try
                    {
                        ITxPlcLogicBehaviorEntry en1 = SegEn(LB, FindSig(r1.Signals, str2, true));
                        ITxPlcLogicBehaviorEntry en2 = SegEn(LB, FindSig(r1.Signals, str3, true));
                        LBEnDic.Add(r1.Name + str2, en1);
                        LBEnDic.Add(r1.Name + str3, en2);
                    }
                    catch (System.Exception ex)
                    {
                    	
                    }
                   
                }

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[0].Value != null && dataGridView2.Rows[i].Cells[1].Value != null && dataGridView2.Rows[i].Cells[0].Value != "" && dataGridView2.Rows[i].Cells[1].Value != "")
                    {
                        string rob1name = dataGridView2.Rows[i].Cells[0].Value.ToString();
                        string strseg1 = dataGridView2.Rows[i].Cells[1].Value.ToString();
                        string rob1segok = rob1name + str1;
                        string rob1seg = rob1name + str2;
                        string rob1segreq = rob1name + str3;
                        TxRobot r1 = RobDictionary[rob1name];
                        if (!ExbuDic1.ContainsKey(rob1segok))
                        {
                            ExbuDic1.Add(rob1segok, new TxPlcExpressionBuilder());
                            ExbuDic1[rob1segok].Add(LBEnDic[rob1segreq]);
                            ExbuDic1[rob1segok].Add(TxPlcExpressionOperator.And);
                            ExbuDic1[rob1segok].Add(TxPlcExpressionOperator.LeftParenthesis);
                        }

                        //SegPa(LB,rob1name+"_seg_"+c,);
                        string Parob1seg = "";
                        int c = 0;
                        if (int.TryParse(strseg1, out c))
                        {
                            Parob1seg = rob1name + "_seg_" + strseg1;
                            if (!ExbuDic.ContainsKey(Parob1seg))
                            {
                                ExbuDic.Add(Parob1seg, new TxPlcExpressionBuilder());
                                TxPlcValue pv = new TxPlcValue();
                                pv.ByteValue = (ushort)c;
                                ExbuDic[Parob1seg].Add(TxPlcExpressionOperator.LeftParenthesis);
                                ExbuDic[Parob1seg].Add(LBEnDic[rob1seg]);
                                ExbuDic[Parob1seg].Add(TxPlcExpressionOperator.IsEqualTo);
                                ExbuDic[Parob1seg].Add(TxPlcSignalDataType.Byte, pv);
                                ExbuDic[Parob1seg].Add(TxPlcExpressionOperator.RightParenthesis);
                                ExbuDic[Parob1seg].Add(TxPlcExpressionOperator.And);
                            }
                        }

                        for (int j = 0; j < dataGridView8.Columns.Count; j++)
                        {
                            string rob2name = dataGridView8.Columns[j].HeaderText;
                            string rob2seg = rob2name+str2;

                            if (dataGridView8.Rows[i].Cells[j].Value != null && dataGridView8.Rows[i].Cells[j].Value != "")
                            {
                                if (j > 0)
                                {
                                    ExbuDic[Parob1seg].Add(TxPlcExpressionOperator.And);
                                }
                                string strseg2 = dataGridView8.Rows[i].Cells[j].Value.ToString();

                                ExbuDic[Parob1seg].Add(TxPlcExpressionOperator.LeftParenthesis);
                                ExbuDic[Parob1seg].Add(LBEnDic[rob2seg]);
                                ExbuDic[Parob1seg].Add(TxPlcExpressionOperator.IsEqualTo);
                                int c1 = 0;
                                if (int.TryParse(strseg2, out c1))
                                {
                                    TxPlcValue pv = new TxPlcValue();
                                    pv.ByteValue = (ushort)c1;
                                    ExbuDic[Parob1seg].Add(TxPlcSignalDataType.Byte, pv);
                                    ExbuDic[Parob1seg].Add(TxPlcExpressionOperator.RightParenthesis);
                                }
                            }
                        }

                        LBPaDic.Add(Parob1seg, SegPa(LB, Parob1seg, ExbuDic[Parob1seg].Expression));
                    }
                }

                foreach (KeyValuePair<string, TxPlcExpressionBuilder> k in ExbuDic1)
                {
                    string strkey = k.Key;
                    string[] str = strkey.Split('_');
                    TxRobot r1 = RobDictionary[str[0]];
                    int j = 0;
                    foreach (KeyValuePair<string, ITxPlcLogicBehaviorParameter> k1 in LBPaDic)
                    {
                        if (k1.Key.Contains(str[0]))
                        {
                            if (j > 0 && j < LBPaDic.Count)
                            {
                                k.Value.Add(TxPlcExpressionOperator.Or);
                            }
                            k.Value.Add(k1.Value);
                            j = j + 1;
                        }
                    }

                    k.Value.Add(TxPlcExpressionOperator.RightParenthesis);
                    SegEx(LB, FindSig(r1.Signals, str[1], false), k.Value.Expression);
                }

            //}
            //catch (System.Exception ex)
            //{

            //}

        }
        private void SegLBS()
        {
            string str1 = textBox9.Text;//ok
            string str2 = textBox10.Text;//seg
            string str3 = textBox8.Text;//req

            TxPlcLogicBehavior LB = CreatNewLB("RobSeg");
            Dictionary<string, ITxPlcLogicBehaviorEntry> LBEnDic = new Dictionary<string, ITxPlcLogicBehaviorEntry>();
            Dictionary<string, ITxPlcLogicBehaviorParameter> LBPaDic = new Dictionary<string, ITxPlcLogicBehaviorParameter>();
            Dictionary<string, TxPlcExpressionBuilder> ExbuDic = new Dictionary<string, TxPlcExpressionBuilder>();
            Dictionary<string, TxPlcExpressionBuilder> ExbuDic1 = new Dictionary<string, TxPlcExpressionBuilder>();

            //try
            //{
            for (int i = 0; i < Robots.Length; i++)
            {
                TxRobot r1 = Robots[i];
                ITxPlcLogicBehaviorEntry en1 = SegEn(LB, FindSig(r1.Signals, str2, true));
                ITxPlcLogicBehaviorEntry en2 = SegEn(LB, FindSig(r1.Signals, str3, true));
                LBEnDic.Add(r1.Name + str2, en1);
                LBEnDic.Add(r1.Name + str3, en2);
            }

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Cells[0].Value != null && dataGridView2.Rows[i].Cells[1].Value != null && dataGridView2.Rows[i].Cells[0].Value != "" && dataGridView2.Rows[i].Cells[1].Value != "")
                {
                    string rob1name = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    string strseg1 = dataGridView2.Rows[i].Cells[1].Value.ToString();
                    string rob1segok = rob1name + str1;
                    string rob1seg = rob1name + str2;
                    string rob1segreq = rob1name + str3;
                    TxRobot r1 = RobDictionary[rob1name];
                    if (!ExbuDic1.ContainsKey(rob1segok))
                    {
                        ExbuDic1.Add(rob1segok, new TxPlcExpressionBuilder());
                        ExbuDic1[rob1segok].Add(LBEnDic[rob1segreq]);
                        ExbuDic1[rob1segok].Add(TxPlcExpressionOperator.And);
                        ExbuDic1[rob1segok].Add(TxPlcExpressionOperator.LeftParenthesis);
                    }

                    //SegPa(LB,rob1name+"_seg_"+c,);
                    string Parob1seg = "";
                    int c = 0;
                    if (int.TryParse(strseg1, out c))
                    {
                        Parob1seg = rob1name + "_seg_" + strseg1;
                        if (!ExbuDic.ContainsKey(Parob1seg))
                        {
                            ExbuDic.Add(Parob1seg, new TxPlcExpressionBuilder());
                            TxPlcValue pv = new TxPlcValue();
                            pv.ByteValue = (ushort)c;
                            ExbuDic[Parob1seg].Add(TxPlcExpressionOperator.LeftParenthesis);
                            ExbuDic[Parob1seg].Add(LBEnDic[rob1seg]);
                            ExbuDic[Parob1seg].Add(TxPlcExpressionOperator.IsEqualTo);
                            ExbuDic[Parob1seg].Add(TxPlcSignalDataType.Byte, pv);
                            ExbuDic[Parob1seg].Add(TxPlcExpressionOperator.RightParenthesis);
                            ExbuDic[Parob1seg].Add(TxPlcExpressionOperator.And);
                        }
                    }

                    for (int j = 0; j < dataGridView8.Columns.Count; j++)
                    {
                        string rob2name = dataGridView8.Columns[j].HeaderText;
                        string rob2seg = rob2name + str2;

                        if (dataGridView8.Rows[i].Cells[j].Value != null && dataGridView8.Rows[i].Cells[j].Value != "")
                        {
                            if (j > 0)
                            {
                                ExbuDic[Parob1seg].Add(TxPlcExpressionOperator.And);
                            }
                            string strseg2 = dataGridView8.Rows[i].Cells[j].Value.ToString();

                            ExbuDic[Parob1seg].Add(TxPlcExpressionOperator.LeftParenthesis);
                            ExbuDic[Parob1seg].Add(LBEnDic[rob2seg]);
                            ExbuDic[Parob1seg].Add(TxPlcExpressionOperator.IsEqualTo);
                            int c1 = 0;
                            if (int.TryParse(strseg2, out c1))
                            {
                                TxPlcValue pv = new TxPlcValue();
                                pv.ByteValue = (ushort)c1;
                                ExbuDic[Parob1seg].Add(TxPlcSignalDataType.Byte, pv);
                                ExbuDic[Parob1seg].Add(TxPlcExpressionOperator.RightParenthesis);
                            }
                        }
                    }

                    LBPaDic.Add(Parob1seg, SegPa(LB, Parob1seg, ExbuDic[Parob1seg].Expression));
                }
            }

            foreach (KeyValuePair<string, TxPlcExpressionBuilder> k in ExbuDic1)
            {
                string strkey = k.Key;
                string[] str = strkey.Split('_');
                TxRobot r1 = RobDictionary[str[0]];
                int j = 0;
                foreach (KeyValuePair<string, ITxPlcLogicBehaviorParameter> k1 in LBPaDic)
                {
                    if (k1.Key.Contains(str[0]))
                    {
                        if (j > 0 && j < LBPaDic.Count)
                        {
                            k.Value.Add(TxPlcExpressionOperator.Or);
                        }
                        k.Value.Add(k1.Value);
                        j = j + 1;
                    }
                }

                k.Value.Add(TxPlcExpressionOperator.RightParenthesis);
                SegEx(LB, FindSig(r1.Signals, str[1], false), k.Value.Expression);
            }

            //}
            //catch (System.Exception ex)
            //{

            //}

        }

        private void ZoneLBM(string Rob1, TxObjectList Rob1Sigs, string Rob2, TxObjectList Rob2Sigs, string[] Zone, TxPlcLogicBehavior LB)
        {
             
            TxPlcExpressionBuilder eb1 = new TxPlcExpressionBuilder();
            try
            {
                foreach (string z in Zone)
                {
                    string str1 = textBox1.Text.Replace("Rob", Rob1).Replace("X", z);
                    string str2 = textBox3.Text.Replace("Rob", Rob2).Replace("X", z);
                    string str3 = textBox2.Text.Replace("Rob", Rob2).Replace("X", z);
                    string str4 = textBox2.Text.Replace("Rob", Rob1).Replace("X", z);


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

                    string str1 = textBox12.Text.Replace("X", z);
                    string str2 = textBox11.Text.Replace("X", z);

                    ITxPlcLogicBehaviorEntry en1 = SegEn(LB, FindSig(Rob1Sigs, str1, true));
                    ITxPlcLogicBehaviorEntry en2 = SegEn(LB, FindSig(Rob2Sigs, str2, true));
                    ITxPlcLogicBehaviorEntry en3 = SegEn(LB, FindSig(Rob2Sigs, str1, true));

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

            //foreach (ITxPlcModule mod in pr.PlcModules)
            //{
            //    if (mod.Name=="Zone")
            //    {
            //        mod.Delete();
            //    }
            //}
            //ModDictionary.Add("Zone", pr.CreateModule(new TxPlcModuleCreationData("Zone")));

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                if (dataGridView3.Rows[i].Cells[0].Style.BackColor == System.Drawing.SystemColors.Highlight)
                {
                    string rob1name = dataGridView3.Rows[i].Cells[0].Value.ToString();

                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        string rob2name = dataGridView1.Columns[j].HeaderText;
                        object zone = dataGridView1.Rows[i].Cells[j].Value;
                        if (zone != null)
                        {
                            if (zone != "")
                            {
                                if (radioButton1.Checked == true || radioButton3.Checked == true)
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

            if (radioButton1.Checked == true || radioButton3.Checked == true)
            {
                SegLBM();
            }
            else
            {
                //SegModlueS();
                //SegModlueli();
                SegLBS();
            }
            TxApplication.ActiveUndoManager.EndTransaction();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            this.Dispose(true);
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            foreach (ITxPlcModule mo in TxApplication.ActiveDocument.PlcProgramRoot.CurrentPlcProgram.PlcModules)
            {
                if (mo.Name!="Main")
                {
                mo.Delete();
                }
            }

        }
        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = false;
                radioButton3.Checked = false;
            }

            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            textBox11.ReadOnly = true;
            textBox12.ReadOnly = true;


            textBox1.Text = "_Zone X";
            textBox2.Text = "_Zone X_To_RB";
            textBox3.Text = "_Area X";
            textBox4.Text = "_Seg_cont_$IN[79]";
            textBox5.Text = "_Seg_$GO[2]";
            textBox6.Text = "_Req_Cont";


        }
        private void radioButton3_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButton3.Checked==true)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }

            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            textBox11.ReadOnly = true;
            textBox12.ReadOnly = true;

            textBox1.Text = "_ZoneReqX";
            textBox2.Text = "_ZoneAnsX";
            textBox3.Text = "_ZoneRelX";
            textBox4.Text = "_SegAnw";
            textBox5.Text = "_GO[2]";
            textBox6.Text = "_SegReq";
        }

        private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                radioButton1.Checked = false;
                radioButton3.Checked = false;
            }
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
            textBox10.ReadOnly = false;
            textBox11.ReadOnly = false;
            textBox12.ReadOnly = false;
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            string filename = @"C:\temp\dqq.csv";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv (*.csv)|*.csv";
            ofd.FileName = @"C:\temp\dqq.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                dataGridView8.Rows.Clear();
                dataGridView2.Rows.Clear();
                filename = ofd.FileName;
                System.IO.StreamReader sr = new System.IO.StreamReader(filename);
                string strLine = sr.ReadLine();

                int i = 0, r = 0;
                while (strLine != null)
                {
                    string[] str = strLine.Split(',');
                    //if (str[0]=="setting")
                    //{

                    //}
                    if (str[0] == "collision")
                    {
                        for (int j = 1; j < str.Length - 1; j++)
                        {
                            dataGridView1.Rows[i].Cells[j - 1].Value = str[j];
                            if (str[j] != "")
                            {
                                dataGridView3.Rows[i].Cells[0].Style.BackColor = System.Drawing.SystemColors.Highlight;
                            }
                        }
                        i = i + 1;
                    }
                    else if (str[0] == "segment")
                    {
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[r].Cells[0].Value = str[1];
                        dataGridView2.Rows[r].Cells[1].Value = str[2];
                        for (int j = 3; j < str.Length - 1; j++)
                        {
                            dataGridView8.Rows[r].Cells[j - 3].Value = str[j];
                        }
                        r = r + 1;
                    }
                    strLine = sr.ReadLine();
                }
            }
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            string filename = @"C:\temp\MinoCEEExport_" + DateTime.Now.ToString().Replace(":", "").Replace("/", "").Replace(" ", "") + ".csv";
            System.IO.StreamWriter sw = new System.IO.StreamWriter(filename);
            string str1="";

            sw.WriteLine(TxApplication.ActiveDocument.CurrentStudy.Caption);
            //if (radioButton1.Checked==true)
            //{
            //    sw.WriteLine("setting,radioButton1," + "true");
            //    sw.WriteLine("setting,textBox1," + textBox1.Text);
            //    sw.WriteLine("setting,textBox2," + textBox2.Text);
            //    sw.WriteLine("setting,textBox3," + textBox3.Text);
            //    sw.WriteLine("setting,textBox4," + textBox4.Text);
            //    sw.WriteLine("setting,textBox5," + textBox5.Text);
            //    sw.WriteLine("setting,textBox6," + textBox6.Text);
            //} 
            //else
            //{
            //    sw.WriteLine("setting,radioButton2," + "true");
            //    sw.WriteLine("setting,textBox8," + textBox8.Text);
            //    sw.WriteLine("setting,textBox9," + textBox9.Text);
            //    sw.WriteLine("setting,textBox10," + textBox10.Text);
            //    sw.WriteLine("setting,textBox11," + textBox11.Text);
            //    sw.WriteLine("setting,textBox12," + textBox12.Text);
            //}

            for (int i = 0; i < dataGridView8.RowCount; i++)
            {
                if (dataGridView2.Rows[i].Cells[0].Value != null)
                {
                    str1 = dataGridView2.Rows[i].Cells[0].Value + ",";
                    str1 = str1 + dataGridView2.Rows[i].Cells[1].Value.ToString() + ",";
                    for (int j = 0; j < dataGridView8.ColumnCount; j++)
                    {
                        str1 = str1 + dataGridView8.Rows[i].Cells[j].Value + ",";
                    }
                    sw.WriteLine("segment," + str1);
                }

            }
           
            for (int i = 0; i < dataGridView1.RowCount;i++ )
            {
                str1 = "";
                for (int j=0;j<dataGridView1.ColumnCount;j++)
                {
                    str1 = str1+dataGridView1.Rows[i].Cells[j].Value + ",";
                }
                sw.WriteLine("collision,"+str1);
            }

            sw.Close();
            MessageBoxTimeout(IntPtr.Zero, "数据已导出-"+filename, "导出完成", 64, 0, 2000);
        }

        private void dataGridView4_RowsAdded(object sender, System.Windows.Forms.DataGridViewRowsAddedEventArgs e)
        {
            dataGridView8.Rows.Add();
        }

        private void dataGridView4_RowsRemoved(object sender, System.Windows.Forms.DataGridViewRowsRemovedEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView8.Rows.Count>0)
            {
            dataGridView8.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void dataGridView4_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].Cells[0] != null && dataGridView2.Rows[e.RowIndex].Cells[0].Value != "")
            {
                if (dataGridView2.Rows[e.RowIndex].Cells[1] != null && dataGridView2.Rows[e.RowIndex].Cells[1].Value == "0")
                {
                    dataGridView2.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

     
    }
}
