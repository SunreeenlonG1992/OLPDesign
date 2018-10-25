using System;
using System.Windows.Forms;
using Tecnomatix.Engineering;

namespace example
{
    public partial class MypathForm : Form
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
                    txObjEditBoxCtrl1.Object = args.ObjectList[0];
                    ITxRoboticOperation ro = txObjEditBoxCtrl1.Object as ITxRoboticOperation;
                    string[] strs = new string[ro.Commands.Count];
                    int i = 0;
                    foreach (TxRoboticCommand co in ro.Commands)
                    {
                        strs[i] = co.Text;
                        i++;
                    }
                    richTextBox1.Text = string.Join("\n", strs);
                }
                else
                {
                    foreach (ITxObject obj in args.ObjectList)
                    {
                        txObjGridCtrl1.AppendObject(obj);
                    }
                }
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (txObjGridCtrl1.Objects.Count > 0)
            {
                txObjGridCtrl1.DeleteRow(txObjGridCtrl1.Objects.Count - 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strs = richTextBox1.Text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (ITxRoboticOperation ro in txObjGridCtrl1.Objects)
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                richTextBox1.Text = string.Join("\n", strs);
            }
            catch
            {
            }
        }

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
                            txObjGridCtrl1.AppendObject(obj1);
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
            txObjGridCtrl1.LoseFocus();
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
            txObjGridCtrl1.LoseFocus();
            TxApplication.ActiveSelection.ItemsSet -= new TxSelection_ItemsSetEventHandler(this.myItems_set);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = "";
            richTextBox2.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox2.Text != "")
                {
                    foreach (ITxRoboticOperation ro in txObjGridCtrl1.Objects)
                    {
                        int k = ro.Commands.Count;
                        if (k > 0)
                        {
                            string[] strs = new string[k];
                            int j = 0;
                            foreach (TxRoboticCommand rc in ro.Commands)
                            {
                                string[] strs1 = richTextBox2.Text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                                string[] strs2 = richTextBox3.Text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

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
                }
            }
            catch (System.Exception ex)
            {
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ITxRoboticLocationOperation ro = txObjEditBoxCtrl1.Object as ITxRoboticLocationOperation;
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
    }
}