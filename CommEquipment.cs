using System;
using System.Collections.Generic;
using System.Text;

namespace EX_7A____Military_Unit__Implementing_Inheritance_
{
    public class CommEquipment
    {
        protected string sysType;
        protected int serialNum;

        public string GetSysType() => this.sysType;
        public int GetSerialNum() => this.serialNum;

        //Making virtual placeholder methods, intended to be overridden.
        public virtual void Setup()
        {
            Console.WriteLine("That terminal does not exist.");
        }
        public virtual void Configure()
        {
            Console.WriteLine("That terminal does not exist.");
        }
        public virtual void Deploy()
        {
            Console.WriteLine("That terminal does not exist.");
        }
        public virtual void Engage()
        {
            Console.WriteLine("That terminal does not exist.");
        }
        public virtual void Maintain()
        {
            Console.WriteLine("That terminal does not exist.");
        }
        public virtual void Disengage()
        {
            Console.WriteLine("That terminal does not exist.");
        }
        public virtual void TearDown()
        {
            Console.WriteLine("That terminal does not exist.");
        }

        public CommEquipment()
        {
            sysType = "Unknown";
            serialNum = 000;
        }
    }
    
    public class VSAT : CommEquipment
    {
        string size;

        //Overriding virtual methods.
        public override void Setup()
        {
            Console.WriteLine($"*Terminal {this.serialNum} stabilizer legs are deployed, area is secure.*");
        }
        public override void Configure()
        {
            Console.WriteLine($"*Terminal {this.serialNum} modems are turned on, and configured.*");
        }
        public override void Deploy()
        {
            Console.WriteLine($"*Terminal {this.serialNum}'s {this.size} dish is raised to the sky.*");
        }
        public override void Engage()
        {
            Console.WriteLine($"*Terminal {this.serialNum} begins transmitting.*");
        }
        public override void Maintain()
        {
            Console.WriteLine($"*Terminal {this.serialNum}'s connection is stable.*");
        }
        public override void Disengage()
        {
            Console.WriteLine($"*Terminal {this.serialNum} turns off transmit.*");
        }
        public override void TearDown()
        {
            Console.WriteLine($"*Terminal {this.serialNum} is stowed, all electronics turned off, and put away.*");
        }
        public VSAT() : base()
        {
            this.sysType = "VSAT";
            this.size = "Unknown";
        }
        public VSAT(int inSerial, string inSize)
        {
            this.sysType = "VSAT";
            this.serialNum = inSerial;
            this.size = inSize;
        }
    }

    public class SmartTerminal : CommEquipment
    {
        bool goodCrypto;

        //Overriding virtual methods.
        public override void Setup()
        {
            Console.WriteLine($"*Terminal {this.serialNum} stabilizer legs are deployed, area is secure.*");
        }
        public override void Configure()
        {
            Console.WriteLine($"*Terminal {this.serialNum} modems are turned on, cyrpto material inserted.*");
        }
        public override void Deploy()
        {
            Console.WriteLine($"*Terminal {this.serialNum}'s crypto is {(this.goodCrypto ? "good" : "bad")}, loading comm plan.*");
        }
        public override void Engage()
        {
            Console.WriteLine($"*Terminal {this.serialNum}'s dish is raised, begins transmitting.*");
        }
        public override void Maintain()
        {
            Console.WriteLine($"*Terminal {this.serialNum}'s connection is stable, terminal is secure.*");
        }
        public override void Disengage()
        {
            Console.WriteLine($"*Terminal {this.serialNum} turns off transmit, stows antenna.*");
        }
        public override void TearDown()
        {
            Console.WriteLine($"*Terminal {this.serialNum}'s cryto removed, and all misc items put away.*");
        }
        public SmartTerminal() : base()
        {
            this.sysType = "Smart Terminal";
            goodCrypto = true;
        }
        public SmartTerminal(int inSerNum) 
        {
            this.sysType = "Smart Terminal";
            this.serialNum = inSerNum;
            this.goodCrypto = true;
        }
    }




}
