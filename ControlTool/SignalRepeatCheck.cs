using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecnomatix.Engineering;

namespace ControlTool
{
    public class SignalRepeatCheck : TxButtonCommand
    {
        public SignalRepeatCheck()
        {
        }

        public override string Name
        {
            get
            {
                return "_SignalRepeatCheck";
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
                return "BMP.SignalRepeatCheck.bmp";
            }
        }
        public override string LargeBitmap
        {
            get
            {
                return "BMP.SignalRepeatCheck.png";
            }
        }
        public override void Execute(object cmdParams)
        {
            TxObjectList objlist = TxApplication.ActiveDocument.PhysicalRoot.GetAllDescendants(new TxTypeFilter(typeof(TxPlcSignalBase)));



        }
    }
}
