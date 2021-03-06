using System.Resources;
using Tecnomatix.Engineering;

namespace example
{
    /// <summary>
    /// Summary description for MypathCmd.
    /// </summary>
    public class MypathCmd : TxButtonCommand
    {
        public MypathCmd()
        {
        }

        public override string Name
        {
            get
            {
                return GetResourceManager().GetString("CMD_NAME_Mypath");
            }
        }

        public override string Category
        {
            get
            {
                return GetResourceManager().GetString("CMD_CATEGORY");
            }
        }
        
        public override string Bitmap
        {
            get
            {
                return "BMP.OLPCopy.bmp";
            }
        }
        public override string LargeBitmap
        {
            get
            {
                return "BMP.OLPCopy.png";
            }
        }

        public override void Execute(object cmdParams)
        {
            if (!MinoApi.LicenseCheck.LicenceCheck())// 20180427
            {
                return;
            }

            MypathForm f = new MypathForm();
            f.Show();
        }

        private ResourceManager GetResourceManager()
        {
            //return new ResourceManager("example.StringTable", GetType().Assembly);
            return new ResourceManager("MinoApi.StringTable", GetType().Assembly);
        }
    }
}