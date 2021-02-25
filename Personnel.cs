using System;
using System.Collections.Generic;
using System.Text;

namespace EX_7A____Military_Unit__Implementing_Inheritance_
{
    public class Personnel
    {
        //Public enum for outside initialization and context.
        public enum PRank { E1, E2, E3, E4, E5, E6, E7, E8, E9, O1, O2, O3, O4, O5, O6, O7, O8, O9 };
        protected string name;
        protected int age;
        protected string title;
        protected char gender;
        protected PRank Rank;

        //Get *field* methods so that the fields above can remain protected when calls are made outside.
        public string GetName() => this.name;
        public static string GetName(Personnel input) => input.name;
        public int GetAge() => this.age;
        public static int GetAge(Personnel input) => input.age;
        public char GetGender() => this.gender;
        public static char GetGender(Personnel input) => input.gender;
        public PRank GetRank() => this.Rank;
        public static PRank GetRank(Personnel input) => input.Rank;

        //Checks the persons rank and applies the correct title.
        public string getTitle()
        {
            switch (this.Rank)
            {
                case PRank.E1: return "Private";
                case PRank.E2: return "PFC";
                case PRank.E3: return "Lance Corporal";
                case PRank.E4: return "Corporal";
                case PRank.E5: return "Sergeant";
                case PRank.E6: return "Staff Sergeant";
                case PRank.E7: return "Gunnery Sergeant";
                case PRank.E8: return "First Sergeant";
                case PRank.E9: return "Sergeant Major";
                default:
                    if (this.gender == 'M')
                    {
                        return "Sir";
                    }
                    if (this.gender == 'F')
                    {
                        return "Ma\'am";
                    }
                    return "Shiny";
            }
        }
        public static string getTitle(Personnel input)
        {
            switch (input.Rank)
            {
                case PRank.E1: return "Private"; 
                case PRank.E2: return "PFC"; 
                case PRank.E3: return "Lance Corporal"; 
                case PRank.E4: return "Corporal"; 
                case PRank.E5: return "Sergeant";
                case PRank.E6: return "Staff Sergeant"; 
                case PRank.E7: return "Gunnery Sergeant"; 
                case PRank.E8: return "First Sergeant"; 
                case PRank.E9: return "Sergeant Major";
                default:
                    if (input.gender == 'M')
                    {
                        return "Sir";
                    }
                    if (input.gender == 'F')
                    {
                        return "Ma\'am";
                    }
                    return "Shiny";
            }
        }
        
        //Constructors
        public Personnel()
        {
            this.name = "Seniram Su";
            this.age = 0;
            this.gender = 'U';
        }
        public Personnel(string inName, int inAge, char inGender)
        {
            this.name = inName;
            this.age = inAge;
            this.gender = inGender;
        }
    }

    public class Enlisted : Personnel
    {
        protected int MOS;
        public int GetMOS(Enlisted input) => input.MOS;

        //Gives appropriate responce based on rank.
        public void reportTo(Personnel input)
        {
            if (this.Rank >= GetRank(input))
            {
                Console.WriteLine($"{this.name}: \"I don't report to you, {input.GetName()}!\"");
            }
            else
            {
                Console.WriteLine($"{this.name}: {this.title} {this.name} reporting for duty, {input.getTitle()}.");
            }
        }

        //Takes a mission, officer, and equipment and performs the action.
        //Calls methods to complete the action, and the officer will reference the mission to advance the mission.
        public void DoOrder(Mission EX, Officer rTar, CommEquipment Terminal)
        {
            Console.Write(this.title + ' ' + this.name + ": ");
            switch (EX.GetMissionStep())
            {
                case 1:
                    Terminal.Setup(); 
                    break;
                case 2: 
                    Terminal.Configure(); 
                    break;
                case 3: 
                    Terminal.Deploy(); 
                    break;
                case 4: 
                    Terminal.Engage(); 
                    break;
                case 5: 
                    Terminal.Maintain(); 
                    break;
                case 6: 
                    Terminal.Disengage(); 
                    break;
                case 7: 
                    Terminal.TearDown(); 
                    break;
                default: 
                    this.reportTo(rTar); 
                    break;
            }
            Console.WriteLine($"{this.title} {this.name}: \"Objective completed, {rTar.getTitle()}.\"");
            rTar.ObjComplete(EX);
        }
        


        public Enlisted() : base()
        {
            this.Rank = PRank.E1;
            this.MOS = 0;
            this.title = this.getTitle();
        }
        public Enlisted(string inName, int inAge, int inMOS, char inGender, PRank inRank) : base( inName,  inAge, inGender)
        {
            this.Rank = inRank;
            this.MOS = 0627;
            this.title = this.getTitle();
        }
    }
    public class Officer : Personnel
    {
        public void GiveOrder(Mission EX)
        {
            Console.WriteLine($"Officer {this.name}: \"Current objective of Mission {EX.GetMissionID()} is to {EX.GetMissionObj()}.\"");
        }
        public void ObjComplete(Mission EX)
        {
            Console.WriteLine($"Officer {this.name}: \"Current objective is complete, {(EX.GetMissionStep() == 7 ? "we're going home." : "moving to next objective.")}\"");
            EX.ObjComplete();
        }
        public Officer() : base()
        {
            this.Rank = PRank.O1;
            this.title = this.getTitle();
        }
        public Officer(string inName, int inAge, char inGender, PRank inRank) : base(inName, inAge, inGender)
        {
            this.Rank = inRank;
            this.title = this.getTitle();
        }
    }
}
