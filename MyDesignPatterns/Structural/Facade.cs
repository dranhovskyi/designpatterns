using System;
namespace MyDesignPatterns.Structural
{
    public class Facade
    {
        protected Subsystem1 subsystem1;

        protected Subsystem2 subsystem2;

        public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2)
        {
            this.subsystem1 = subsystem1;
            this.subsystem2 = subsystem2;
        }

        public string Operation()
        {
            string result = "Facade initializes subsystems:\n";
            result += this.subsystem1.operation1();
            result += this.subsystem2.operation1();
            result += "Facade orders subsystems to perform the action:\n";
            result += this.subsystem1.operationN();
            result += this.subsystem2.operationZ();
            return result;
        }
    }

    public class Subsystem1
    {
        public string operation1()
        {
            return "Subsystem1: Ready!\n";
        }

        public string operationN()
        {
            return "Subsystem1: Go!\n";
        }
    }

    public class Subsystem2
    {
        public string operation1()
        {
            return "Subsystem2: Get ready!\n";
        }

        public string operationZ()
        {
            return "Subsystem2: Fire!\n";
        }
    }

    public class FacadeDemo
    {
        public static void Run()
        {
            Subsystem1 subsystem1 = new Subsystem1();
            Subsystem2 subsystem2 = new Subsystem2();
            Facade facade = new Facade(subsystem1, subsystem2);

            Console.Write(facade.Operation());
        }
    }
}
