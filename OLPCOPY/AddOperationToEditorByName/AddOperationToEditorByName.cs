using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecnomatix.Engineering;

namespace OLPCOPY.AddOperationToEditorByName
{
    public class AddOperationToEditorByName : TxButtonCommand
    {
        public AddOperationToEditorByName()
        {
        }

        public override string Name
        {
            get
            {
                return "_AddOperationToEditorByName";
            }
        }

        public override string Category
        {
            get
            {
                return "CMD_CATEGORY";
            }
        }

        public override string Bitmap
        {
            get
            {
                return "BMP.AddOperationToEditorByName.bmp";
            }
        }
        public override string LargeBitmap
        {
            get
            {
                return "BMP.AddOperationToEditorByName.png";
            }
        }

        public override void Execute(object cmdParams)
        {
            AddOperationForm addOperationForm = new AddOperationForm();
            addOperationForm.Show();

        }
    }
}
