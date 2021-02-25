using System;

namespace EX_7A____Military_Unit__Implementing_Inheritance_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare Missions
            Mission EX1 = new Mission();
            Mission EX2 = new Mission();
            Mission EX3 = new Mission();

            //Officers and Missions have direct contact, and from the mission step the officer will
            //instruct the enlisted what steps to perform.
            //The Equipment is only usable by Enlisted, as shinies don't know how.

            //Declare Terminals (Equipment)
            VSAT Term1 = new VSAT(1040,"Large");
            VSAT Term2 = new VSAT(0106, "Small");
            SmartTerminal Term3 = new SmartTerminal(4057);

            //Declare indiviuals
            Officer Gurung = new Officer("Gurung",32, 'M', Personnel.PRank.O2);
            Enlisted Deleon = new Enlisted("Deleon", 24, 0627, 'M', Personnel.PRank.E5);
            Enlisted Arvayo = new Enlisted("Arvayo", 21, 0627, 'M', Personnel.PRank.E3);
            Enlisted Hejl = new Enlisted("Hejl", 23, 0627, 'M', Personnel.PRank.E4);

            //Report check, if persons outranks the indivual reporting too theres some flavor dialouge.
            Hejl.reportTo(Gurung);
            Hejl.reportTo(Deleon);
            Hejl.reportTo(Arvayo);
            Deleon.reportTo(Hejl);
            Deleon.reportTo(Gurung);
            Deleon.reportTo(Arvayo);
            Arvayo.reportTo(Gurung);
            Arvayo.reportTo(Hejl);
            Arvayo.reportTo(Deleon);



            //Each mission class has a bool value wether or not its complete or not, 
            //Mission will end execution when it is complete.

            //Mission EX 1
            Console.Write("\n");
            while (EX1.Complete == false)
            {
                Gurung.GiveOrder(EX1);
                Deleon.DoOrder(EX1, Gurung, Term1);
            }
            //Mission EX 2
            Console.Write("\n");
            while (EX2.Complete == false)
            {
                Gurung.GiveOrder(EX2);
                Arvayo.DoOrder(EX2, Gurung, Term2);
            }
            //Mission EX 3
            Console.Write("\n");
            while (EX3.Complete == false)
            {
                Gurung.GiveOrder(EX3);
                Hejl.DoOrder(EX3, Gurung, Term3);
            }
        }
    }
}
