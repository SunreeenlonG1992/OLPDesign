using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tecnomatix.Engineering;
using Tecnomatix.Engineering.Ui;

namespace example
{
    public partial class MypathForm : TxForm
    {
        private bool isEditForm;

        public MypathForm()
        {
            InitializeComponent();
            TxApplication.ActiveSelection.ItemsSet += new TxSelection_ItemsSetEventHandler(this.myItems_set);
            isEditForm = true;
        }

        public void myItems_set(object sender, Tecnomatix.Engineering.TxSelection_ItemsSetEventArgs args)
        {
            try
            {
                if (isEditForm)
                {
                    sourceLocation_tb.Object = args.ObjectList[0];
                    ITxRoboticOperation ro = sourceLocation_tb.Object as ITxRoboticOperation;
                    string[] strs = new string[ro.Commands.Count];
                    int i = 0;
                    foreach (TxRoboticCommand co in ro.Commands)
                    {
                        strs[i] = co.Text;
                        i++;
                    }
                    richTextBox_sourceOLP.Text = string.Join("\n", strs);
                }
                else
                {
                    foreach (ITxObject obj in args.ObjectList)
                    {
                        txObjGridCtrl_targetLocation.AppendObject(obj);
                    }
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 减少Target Object选择的项目数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            while (txObjGridCtrl_targetLocation.Objects.Count > 0)
            {
                txObjGridCtrl_targetLocation.DeleteRow(txObjGridCtrl_targetLocation.Objects.Count - 1);
            }
        }
 
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 拾取源轨迹点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void txObjEditBoxCtrl1_Picked(object sender, Tecnomatix.Engineering.Ui.TxObjEditBoxCtrl_PickedEventArgs args)
        {
            try
            {
                ITxRoboticOperation ro = args.Object as ITxRoboticOperation;
                string[] strs = new string[ro.Commands.Count];
                int i = 0;
                foreach (TxRoboticCommand co in ro.Commands)
                {
                    strs[i] = co.Text;
                    i++;
                }
                richTextBox_sourceOLP.Text = string.Join("\n", strs);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 添加目标operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            foreach (ITxObject obj in TxApplication.ActiveSelection.GetAllItems())
            {
                try
                {
                    if (obj is ITxCompoundOperation)
                    {
                        ITxCompoundOperation cop = obj as ITxCompoundOperation;
                        TxTypeFilter tp = new TxTypeFilter(typeof(ITxRoboticOperation));
                        TxObjectList objlist = cop.GetAllDescendants(tp);
                        foreach (ITxObject obj1 in objlist)
                        {
                            txObjGridCtrl_targetLocation.AppendObject(obj1);
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            txObjGridCtrl_targetLocation.LoseFocus();
        }

        private void txObjEditBoxCtrl1_Enter(object sender, EventArgs e)
        {
            isEditForm = true;
        }

        private void txObjGridCtrl1_Enter(object sender, EventArgs e)
        {
            isEditForm = false;
        }

        private void MypathForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            txObjGridCtrl_targetLocation.LoseFocus();
            TxApplication.ActiveSelection.ItemsSet -= new TxSelection_ItemsSetEventHandler(this.myItems_set);
        }
        /// <summary>
        /// 清空find /replace的文本窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox_replaceOLP.Text = "";
            richTextBox_findOLP.Text = "";
        }


        /// <summary>
        /// 复制源的olp command文本到目标operation 命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void pictureBox_apply_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strs = richTextBox_sourceOLP.Text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (ITxRoboticOperation ro in txObjGridCtrl_targetLocation.Objects)
                {
                    foreach (TxRoboticCommand rc in ro.Commands)
                    {
                        if (rc is TxRoboticCompositeCommand)
                        {
                        }
                        else
                        {
                            rc.Delete();
                        }
                    }

                    for (int i = 0; i < strs.Length; i++)
                    {
                        ro.CreateCommand(new TxRoboticCommandCreationData(strs[i]));
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
        }
        /// <summary>
        /// 执行替换OLP指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Dictionary<ITxOperation, string> operationdic= new Dictionary<ITxOperation, string>();

            try
            {
               
                if (richTextBox_findOLP.Text != "")
                {
                    foreach (ITxRoboticOperation ro in txObjGridCtrl_targetLocation.Objects)
                    {
                       

                        int k = ro.Commands.Count;
                        if (k > 0)
                        {
                            string[] strs = new string[k];
                            int j = 0;
                            foreach (TxRoboticCommand rc in ro.Commands)
                            {
                                string[] strs1 = richTextBox_findOLP.Text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                                string[] strs2 = richTextBox_replaceOLP.Text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                                for (int i = 0; i < strs1.Length; i++)
                                {
                                    if (strs2.Length == 0)
                                    {
                                        rc.Text = rc.Text.Replace(strs1[i], "");
                                    }
                                    else if (strs2.Length == 1)
                                    {
                                        rc.Text = rc.Text.Replace(strs1[i], strs2[0]);
                                    }
                                    else
                                    {
                                        rc.Text = rc.Text.Replace(strs1[i], strs2[i]);
                                    }
                                }
                                j++;
                            }
                        }
                        
                    }
                  
                    foreach (ITxRoboticOperation ro in txObjGridCtrl_targetLocation.Objects)
                    {
                      
                        ITxOperation operation = ro.Collection as ITxOperation;
                        if (!operationdic.ContainsKey(operation))
                        {
                            operationdic.Add(operation, operation.Name);
                        }

                    }
                    foreach (ITxOperation operation in operationdic.Keys)
                    {

                        TxApplication.ViewersManager.PathEditorViewer.RemoveOperation(operation);
                        TxApplication.ViewersManager.PathEditorViewer.AddOperation(operation);

                    }


                }
            }
            catch (System.Exception ex)
            {
            }

        }

        /// <summary>
        /// AddWeldCommand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addweldName_Click(object sender, EventArgs e)
        {
            ITxRoboticLocationOperation ro = sourceLocation_tb.Object as ITxRoboticLocationOperation;
            ITxTypeFilter objFilter = new TxTypeFilter(typeof(ITxRoboticLocationOperation));
            TxObjectList obj = ro.ParentRoboticOperation.GetAllDescendants(objFilter);

            try
            {
                for (int i = 0; i < obj.Count; i++)
                {
                    if (obj[i + 1] is TxWeldLocationOperation)
                    {
                        string str = ";-- " + obj[i + 1].Name + " --";
                        ITxRoboticOperation rop = obj[i] as ITxRoboticOperation;
                        if (rop.Commands.Count == 0)
                        {
                            rop.CreateCommand(new TxRoboticCommandCreationData(str));
                        }
                        else
                        {
                            TxRoboticCommand rc = rop.Commands[rop.Commands.Count - 1] as TxRoboticCommand;
                            if (!rc.Text.Contains("_ps_"))
                            {
                                rop.CreateCommand(new TxRoboticCommandCreationData(str));
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
        }
        /// <summary>
        /// 清空find /replace的文本窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void pictureBox_clearsearch_Click(object sender, EventArgs e)
        {
     
                richTextBox_replaceOLP.Text = "";
                richTextBox_findOLP.Text = "";
           
        }
    }
}