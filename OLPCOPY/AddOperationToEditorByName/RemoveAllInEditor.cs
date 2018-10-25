using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecnomatix.Engineering;

namespace OLPCOPY.AddOperationToEditorByName
{
    public class RemoveAllInEditor : TxButtonCommand
    {
        public RemoveAllInEditor()
        {
        }

        public override string Name
        {
            get
            {
                return "_RemoveAllInEditor";
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
                return "BMP.RemoveAllInEditor.bmp";
            }
        }
        public override string LargeBitmap
        {
            get
            {
                return "BMP.RemoveAllInEditor.png";
            }
        }

        public override void Execute(object cmdParams)
        {
            TxApplication.ViewersManager.PathEditorViewer.RemoveAllItems();
        }
    }
}
