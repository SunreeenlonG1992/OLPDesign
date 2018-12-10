using System.Resources;
using Tecnomatix.Engineering;

namespace RobotOLPTool
{
    /// <summary>
    /// Summary description for MypathCmd.
    /// </summary>
    public class OLPCOPY : TxButtonCommand
    {
        public OLPCOPY()
        {
        }

        public override string Name
        {
            get
            {
                return "_OLPCOPY";
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
                return "CMDbmp.OLPCopy.bmp";
            }
        }
        public override string LargeBitmap
        {
            get
            {
                return "CMDbmp.OLPCopy.png";
            }
        }

        public override void Execute(object cmdParams)
        {
            //if (!MinoApi.LicenseCheck.LicenceCheck())// 20180427
            //{
            //    return;
            //}

            example.MypathForm f = new example.MypathForm();
            f.Show();
        }

        
    }
}