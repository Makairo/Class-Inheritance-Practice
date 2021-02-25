using System;
using System.Collections.Generic;
using System.Text;

namespace EX_7A____Military_Unit__Implementing_Inheritance_
{
    public class Mission
    {
        protected static int MissionCounter= 0;
        protected int MissionID;
        protected int MissionStep;
        protected string MissionObj;
        public bool Complete;

        //Returns the appropriate objective for the current state of the mission, each mission has the same objs.
        public string GetObj()
        {
            switch (this.MissionStep)
            {
                case 1: return "Set Up Terminals";
                case 2: return "Configure Terminals";
                case 3: return "Deploy Antenna";
                case 4: return "Engage Transmission";
                case 5: return "Maintain Connection";
                case 6: return "Disengage Transmit";
                case 7: return "Tear Down";
                default:
                    this.Complete = true;
                    return "Complete";
            }
        }
        public int GetMissionID() => this.MissionID;
        public int GetMissionStep() => this.MissionStep;
        public string GetMissionObj() => this.MissionObj;
        public void ObjComplete()
        {
            this.MissionStep += 1;
            this.MissionObj = this.GetObj();
        }

        public Mission()
        {
            this.MissionID = ++MissionCounter + 1000;
            this.MissionStep = 1;
            MissionObj = this.GetObj();
            this.Complete = false;
        }
    }
}
