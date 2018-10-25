using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecnomatix.Engineering.Ui;
using Tecnomatix.Engineering;

namespace OLPCOPY.AddOperationToEditorByName
{
    public partial class AddOperationForm : TxForm
    {
        public AddOperationForm()
        {
            InitializeComponent();
        }

        private void AddToEditor_bt_Click(object sender, EventArgs e)
        {
            Dictionary<ITxRoboticOperation, string> operationdic = new Dictionary<ITxRoboticOperation, string>();

            //遍历获取所有operation
            TxObjectList oplist = TxApplication.ActiveDocument.OperationRoot.GetAllDescendants(new TxTypeFilter(typeof(ITxRoboticOperation)));

            if (!(opname_tb.Text==""))
            {
                foreach (ITxRoboticOperation op in oplist)
                {

                    //if (op.Name== opname_tb.Text)
                    //{
                    //    TxApplication.ViewersManager.PathEditorViewer.AddOperation(op);
                    //}
                    if (op.Name == opname_tb.Text)
                    {
                        operationdic.Add(op, op.Name);
                     
                    }
                }
                foreach (ITxRoboticOperation item in operationdic.Keys)
                {
                    TxApplication.ViewersManager.PathEditorViewer.AddOperation(item);
                }
            }
            else
            {

                MessageBox.Show("Please define the searching text by picking up operation or entering its name!");
            }

            
            
        }

        private void Close_bt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void opname_tb_Picked(object sender, TxObjComboBoxCtrl_PickedEventArgs args)
        {
            ITxOperation txOperation = args.Obj as ITxOperation;
            opname_tb.AddItem(txOperation.Name, txOperation);
        }
    }
}
