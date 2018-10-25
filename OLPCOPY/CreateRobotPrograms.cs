using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecnomatix.Engineering;

namespace OLPCOPY
{
    public class CreateRobotPrograms : TxButtonCommand
    {
        public CreateRobotPrograms()
        {
        }

        public override string Name
        {
            get
            {
                return "_Create Robot Programs";
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
                return "BMP.RobotPrograms.bmp";
            }
        }
        public override string LargeBitmap
        {
            get
            {
                return "BMP.RobotPrograms.png";
            }
        }


        public override void Execute(object cmdParams)
        {
            ////遍历获取所有机器人列表
            //TxObjectList rolist = TxApplication.ActiveDocument.PhysicalRoot.GetAllDescendants(new TxTypeFilter(typeof(TxRobot)));

            //拾取机器人
            TxObjectList rolist = TxApplication.ActiveSelection.GetFilteredItems(new TxTypeFilter(typeof(TxRobot)));

            foreach (TxRobot robot in rolist)
            {
                //创建机器人program
                ITxRoboticProgram RobotProgram = TxApplication.ActiveDocument.RoboticProgramRoot.CreateProgram(new TxRoboticProgramCreationData(robot));
                RobotProgram.Name = robot.Name + "_Program";

                //将机器人program加载到path editor中
                TxApplication.ViewersManager.PathEditorViewer.SetRoboticProgram(RobotProgram);

                //将机器人的所有op添加到robot program中
                //TxObjectList rplist = robot.GetAllDescendants(new TxTypeFilter(typeof(ITxRoboticOperation)));
                TxObjectList rplist = robot.SimulatingOperations;
                foreach (ITxRoboticOperation item in rplist)
                {
                    ITxRoboticProgramElement txRoboticProgramElement = item as ITxRoboticProgramElement;
                    RobotProgram.AddElement(txRoboticProgramElement);
                    if (txRoboticProgramElement.Name.ToUpper()=="MAIN" | txRoboticProgramElement.Name.ToUpper() == "CELL")
                    {
                        RobotProgram.SetElementNumber(txRoboticProgramElement, 125);
                    }
                }

                //将当前robot program设置为default program，即下载当前program到PS robot中
                ITxRobot txRobot = robot as ITxRobot;
                TxRoboticProgram txRoboticProgram = RobotProgram as TxRoboticProgram;

                txRobot.DefaultProgram = txRoboticProgram;





            }
        }
    }
}
